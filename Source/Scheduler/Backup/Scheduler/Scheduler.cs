using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Data.Common;
using System.Xml;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;

namespace Scheduler
{
    public partial class Scheduler : Form
    {
        private static String dateFormatString = "yyyy-MM-dd HH:mm:ss";

        #region Data members

        //eventsList is the DataSet that the primary DataGridView binds to
        DataSet eventsList;
        //repeatEvents is a schema-exact temporary storage to hold events to repeat
        DataSet repeatEvents;
        //sourceSelection is used to persist the selected range of days during "Copy Events" operations
        SelectionRange sourceSelection;
        //repeatDestination is used to persist the select range of days during "Repeat" operations
        SelectionRange repeatDestination;

        #endregion

        #region Constructor and init methods

        public Scheduler()
        {
            InitializeComponent();
            SetupEventsDataSet();
        }

        // Define the structure of the eventsList DataSet. Make a duplicate schema for repeatEvents
        private void SetupEventsDataSet()
        {
            eventsList = new DataSet("EventsList");
            eventsList.Tables.Add("ScheduledEvent");
            eventsList.Tables["ScheduledEvent"].Columns.Add("StartPlay");
            eventsList.Tables["ScheduledEvent"].Columns.Add("AudioFile");
            eventsList.Tables["ScheduledEvent"].Columns.Add("AudioFileFullPath");
            eventsList.Tables["ScheduledEvent"].Columns.Add("PlayDuration");
            eventsList.Tables["ScheduledEvent"].Columns.Add("StartRecord");
            eventsList.Tables["ScheduledEvent"].Columns.Add("RecordDuration");
            eventsList.Tables["ScheduledEvent"].Columns.Add("GUID");
            dgvScheduledEvents.DataSource = eventsList.Tables["ScheduledEvent"];

            repeatEvents = eventsList.Copy();
        }

        #endregion

        #region Data utilities

        // Description: Recursively traverse the TreeView and make sure the audio file specified in a TreeNode's tag exists
        // If the file does not exist, mark the TreeNode red
        private void validateAudioFilesInTree(TreeNodeCollection treeNodes)
        {
            for (int i = 0; i < treeNodes.Count; i++)
            {
                TreeNode treeNode = treeNodes[i];
                String filepath = treeNode.Tag.ToString();
                if (filepath != "Category")
                {
                    if (File.Exists(filepath))
                    {
                        treeNode.ForeColor = Color.Black;
                    }
                    else
                    {
                        treeNode.ForeColor = Color.Red;
                        treeNode.EnsureVisible();
                    }
                }
                if (treeNode.Nodes.Count > 0)
                {
                    validateAudioFilesInTree(treeNode.Nodes);
                }
            }
        }

        // Loop through the rows of events in the GridView and verify that the audio file exists
        private void validateAudioFilesInGridView()
        {
            foreach (DataRow dataRow in eventsList.Tables["ScheduledEvent"].Rows)
            {
                String filepath = dataRow.Field<String>("AudioFileFullPath");
                if (!String.IsNullOrEmpty(filepath))
                {
                    if (File.Exists(filepath))
                    {
                        dataRow.ClearErrors();
                    }
                    else
                    {
                        dataRow.SetColumnError("AudioFile", "File not found");
                    }
                }
            }
        }

        // Wrapper to call validateAudioFilesInGridView() and validateAudioFilesInTree(TreeNodeCollection)
        private void validateAudioFiles()
        {
            validateAudioFilesInTree(tvAvailableAudioFiles.Nodes);
            validateAudioFilesInGridView();
        }


        // Description: Finds the list of files, opens them and compresses them into a single output file
        // Reports progress to a ProgressBar
        public void compressFiles(string[] filenames, string outputFileName, int compressionLevel, ProgressBar progress)
        {
            File.Delete(outputFileName);
            FileStream fsOut = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            using (ZipOutputStream s = new ZipOutputStream(fsOut))
            {
                s.SetLevel(compressionLevel); // 0-9, 9 being the highest compression
                s.UseZip64 = UseZip64.Dynamic; // Enable dynamic Zip64 support. Create a Zip32 archive for files < 4gb
                byte[] buffer = new byte[4096];
                progress.Maximum = filenames.Length;
                progress.Step = 1;
                foreach (String file in filenames)
                {
                    if (file != "" && File.Exists(file))
                    {
                        progress.PerformStep();
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;

                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            buffer = new byte[fs.Length];
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            }
                            while (sourceBytes > 0);
                        }
                    }
                }
                s.Finish();
                s.Close();
            }
            fsOut.Close();
        }

        #endregion

        #region Overlapping events

        // Determine if the specified time spans overlap.
        private bool dateTimeOverlaps(DateTime srcStart, DateTime srcEnd, DateTime cmpStart, DateTime cmpEnd)
        {
            if (srcStart != new DateTime() && srcEnd != new DateTime() && cmpStart != new DateTime() && cmpEnd != new DateTime())
            {
                return (
                  (cmpStart >= srcStart && cmpStart < srcEnd) ||
                  (cmpEnd <= srcEnd && cmpEnd > srcStart) ||
                  (cmpStart <= srcStart && cmpEnd >= srcEnd)
                 );
            }
            else
            {
                return false;
            }

        }

        // Determines if two data rows overlap and returns the overlapping row if so 
        private DataRow eventOverlaps(DataRow row1, DataRow row2)
        {
            /* get the start play and start record DateTimes from both rows */
            DateTime startPlayRow1 = new DateTime();
            DateTime startPlayRow2 = new DateTime();
            DateTime startRecordRow1 = new DateTime();
            DateTime startRecordRow2 = new DateTime();
            DateTime.TryParse(row1.Field<String>("StartPlay"), out startPlayRow1);
            DateTime.TryParse(row2.Field<String>("StartPlay"), out startPlayRow2);
            DateTime.TryParse(row1.Field<String>("StartRecord"), out startRecordRow1);
            DateTime.TryParse(row2.Field<String>("StartRecord"), out startRecordRow2);

            /* get the play and record durations to pad */
            int playDurationRow1 = 0;
            int playDurationRow2 = 0;
            Int32.TryParse(row1.Field<String>("PlayDuration"), out playDurationRow1);
            Int32.TryParse(row2.Field<String>("PlayDuration"), out playDurationRow2);

            int recordDurationRow1 = 0;
            int recordDurationRow2 = 0;
            Int32.TryParse(row1.Field<String>("RecordDuration"), out recordDurationRow1);
            Int32.TryParse(row2.Field<String>("RecordDuration"), out recordDurationRow2);

            /* determine if play or record overlaps */
            bool playOverlaps = false;
            bool recordOverlaps = false;
            bool playOverlapsRecord = false;
            bool recordOverlapsPlay = false;
            bool overlapsItself = false;

            if (row1 != row2)
            {
                playOverlapsRecord = dateTimeOverlaps(startPlayRow1, startPlayRow1.AddSeconds(playDurationRow1), startRecordRow2, startRecordRow2.AddSeconds(recordDurationRow2));
                recordOverlapsPlay = dateTimeOverlaps(startRecordRow1, startRecordRow1.AddSeconds(recordDurationRow1), startPlayRow2, startPlayRow2.AddSeconds(playDurationRow2));
                playOverlaps = dateTimeOverlaps(startPlayRow1, startPlayRow1.AddSeconds(playDurationRow1), startPlayRow2, startPlayRow2.AddSeconds(playDurationRow2));
                recordOverlaps = dateTimeOverlaps(startRecordRow1, startRecordRow1.AddSeconds(recordDurationRow1), startRecordRow2, startRecordRow2.AddSeconds(recordDurationRow2));
            }
            else
            {
                overlapsItself = dateTimeOverlaps(startPlayRow1, startPlayRow1.AddSeconds(playDurationRow1), startRecordRow1, startRecordRow2.AddSeconds(recordDurationRow2));
            }

            if (playOverlaps || recordOverlaps || playOverlapsRecord || recordOverlapsPlay || overlapsItself) { return row2; }
            else { return null; }
        }

        // Compare this new event with every other event to see if they overlap
        private DataRow findAnOverlappingEvent(DataRow newRow)
        {
            foreach (DataRow rowToCompare in eventsList.Tables["ScheduledEvent"].Rows)
            {
                // if our new row overlaps another row, return that row
                if (eventOverlaps(newRow, rowToCompare) != null)
                {
                    return rowToCompare;
                }
            }
            // There may not be any rows in eventsList, so check to see if this row overlaps itself
            if (eventOverlaps(newRow, newRow) != null)
            {
                return newRow;
            }
            // No overlap was detected. Return null
            else
                return null;
        }

        #endregion

        #region Form calls

        // Pops the DateTimePopup Form in the location 
        // where the user clicked and passes in the value of the 
        // existing Date/Time from the cell clicked by the user
        private void popupCalendar(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            using (DateTimePopup dtp = new DateTimePopup(dgv, e))
            {
                dtp.StartPosition = FormStartPosition.Manual;
                Point datePopupLocation = Scheduler.MousePosition;
                datePopupLocation.X -= 10;
                datePopupLocation.Y -= 10;
                dtp.Location = datePopupLocation;
                dtp.ShowDialog();
            }
        }
        #endregion

        #region Display selected events

        // Loop through all rows in the events list and set Visible = true
        private void displayAllEvents()
        {
            foreach (DataGridViewRow dgvr in dgvScheduledEvents.Rows)
            {
                dgvr.Visible = true;
            }
        }

        // Loop through all rows in the events list and set Visible = false if they do not 
        // have a date/time that occurs within the specified SelectionRange
        private void displaySelectedDateRangeEventsOnly(SelectionRange range)
        {
            // If the selection range spans no time, say 01/01/2010 00:00:00 - 01/01/2010 00:00:00, add a day to it
            // and make it span 01/01/2010 00:00:00 - 01/01/2010 23:59:59
            if (range.Start == range.End)
            {
                range.End = range.End.AddDays(1);
            }

            //Suspend databinding on dgvScheduledEvents so we can hide rows that may be in various edit states.
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvScheduledEvents.DataSource];
            cm.SuspendBinding();

            foreach (DataGridViewRow dgvr in dgvScheduledEvents.Rows)
            {
                if (eventOccursOnRange(dgvr, range))
                {
                    dgvr.Visible = true;
                }
                else
                {
                    dgvr.Visible = false;
                }
            }
            cm.ResumeBinding();
        }

        #endregion

        #region Event repeats

        // Determines if the DataRow contains a StartPlay or StartRecord value that lands 
        // within the specified SelectionRange
        private bool eventOccursOnRange(DataGridViewRow dataRow, SelectionRange range)
        {
            DateTime playTime;
            DateTime recordTime;
            DateTime.TryParse(dataRow.Cells["StartPlay"].Value.ToString(), out playTime);
            DateTime.TryParse(dataRow.Cells["StartRecord"].Value.ToString(), out recordTime);

            return (playTime >= range.Start && playTime <= range.End ||
                     recordTime >= range.Start && recordTime <= range.End);
        }

        // Calculates the number of days needed to move a DataRow to the desired destination DateTime
        private int calculateOffset(DataRow dataRow, DateTime dstDate)
        {
            int offsetDays = 0;

            //Convert each field string to a DateTime. 
            DateTime srcPlayDate;
            DateTime srcRecordDate;
            DateTime.TryParse(dataRow.Field<String>("StartPlay"), out srcPlayDate);
            DateTime.TryParse(dataRow.Field<String>("StartRecord"), out srcRecordDate);

            if (isPlayEvent(dataRow) && isRecordEvent(dataRow))
            {
                //If play occurs before record, we want to move based on play date
                if (srcPlayDate <= srcRecordDate)
                {
                    //calculate the number of days to get the play date from src to dst
                    offsetDays = (dstDate - srcPlayDate).Days + 1;
                }
                //record occurs before play
                else
                {
                    //calculate the number of days to get the record date from src to dst
                    offsetDays = (dstDate - srcRecordDate).Days + 1;
                }
            }
            else if (isPlayEvent(dataRow))
            {
                offsetDays = (dstDate - srcPlayDate).Days + 1;
            }
            else if (isRecordEvent(dataRow))
            {
                offsetDays = (dstDate - srcRecordDate).Days + 1;
            }
            //Since the number of days range from 01/01/01 00:00:00 -  01/02/01 00:00:00, the 
            //TimeSpan represents one too few days. Add a day to span 01/01/01 00:00:00 - 01/02/01 23:59:00

            if (offsetDays <= 0)
            {
                //if the TimeSpan represented a negative span, we have counted one too many days, 
                //considering the same logic as above. 
                offsetDays--;
            }
            return offsetDays;
        }


        // Repeats all play values for an event. If the event is not a play event, 
        // returns an array of empty strings for each value
        private string[] repeatPlayEventValues(DataRow dataRow, int offsetDays)
        {
            if (isPlayEvent(dataRow))
            {
                DateTime srcPlayDate;
                DateTime dstPlayDate;
                DateTime.TryParse(dataRow.Field<String>("StartPlay"), out srcPlayDate);

                dstPlayDate = srcPlayDate.AddDays(offsetDays);
                String dstPlayDateString = String.Format("{0:" + dateFormatString + "}", dstPlayDate);
                string[] rowValues = { dstPlayDateString, 
                                       dataRow.Field<String>("AudioFile"),
                                       dataRow.Field<String>("AudioFileFullPath"),
                                       dataRow.Field<String>("PlayDuration"),
                                     };
                return rowValues;
            }
            else
                return new String[] { "", "", "", "" };

        }

        // Repeats all record values for an event. If the event is not a record event, 
        // returns an array of empty strings for each value.
        private string[] repeatRecordEventValues(DataRow dataRow, int offsetDays)
        {
            if (isRecordEvent(dataRow))
            {
                DateTime srcRecordDate;
                DateTime dstRecordDate;
                DateTime.TryParse(dataRow.Field<String>("StartRecord"), out srcRecordDate);

                dstRecordDate = srcRecordDate.AddDays(offsetDays);
                String dstRecordDateString = String.Format("{0:" + dateFormatString + "}", dstRecordDate);
                string[] rowValues = { dstRecordDateString, dataRow.Field<String>("RecordDuration") };
                return rowValues;
            }
            else
                return new String[] { "", "" };
        }

        // repeatSingleDaysEvents(DateTime, DateTime)
        // --------------------------
        // Description: Copies all events from one day to another. If an event
        // contains both a play and a record date time, the destination of the entire event
        // will be relative to the play time. If an event is only a play xor record, 
        // use that field's date time as a source and put the event in the destination
        // --------------------------
        // Calls to: 
        // Called by: Scheduler
        // -------------------------- 
        private bool repeatSingleDaysEvents(DateTime srcDate, DateTime dstDate)
        {
            //Clear the "clipboard" list of events in DataSet repeatEvents
            repeatEvents.Clear();
            //Fill the "clipboard" with a single day's events
            repeatEvents = duplicateSingleDaysEvents(srcDate, repeatEvents);

            Boolean overlapsOccurred = false;

            //For each event found for the day
            foreach (DataRow dataRow in repeatEvents.Tables["ScheduledEvent"].Rows)
            {
                //Convert each field string to a DateTime. 
                DateTime srcPlayDate;
                DateTime srcRecordDate;
                DateTime.TryParse(dataRow.Field<String>("StartPlay"), out srcPlayDate);
                DateTime.TryParse(dataRow.Field<String>("StartRecord"), out srcRecordDate);

                int offsetDays = calculateOffset(dataRow, dstDate);
                string[] newPlayValues = repeatPlayEventValues(dataRow, offsetDays);
                string[] newRecordValues = repeatRecordEventValues(dataRow, offsetDays);
                string[] newEventValues = { newPlayValues[0], newPlayValues[1], newPlayValues[2], newPlayValues[3],
                                              newRecordValues[0], newRecordValues[1], Guid.NewGuid().ToString() };

                DataRow newRow = eventsList.Tables["ScheduledEvent"].NewRow();
                newRow.ItemArray = newEventValues;
                //Search for any overlapping event. If an overlap occurs, don't add the row. 
                if (findAnOverlappingEvent(newRow) == null)
                {
                    //add the row to the evenstList
                    eventsList.Tables["ScheduledEvent"].Rows.Add(newRow);
                }
                else
                {
                    overlapsOccurred = true;
                }
            }

            if (overlapsOccurred)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //returns a data set of all events that occur on a day
        private DataSet duplicateSingleDaysEvents(DateTime day, DataSet dataSetToFill)
        {
            foreach (DataRow dataRow in eventsList.Tables["ScheduledEvent"].Rows)
            {
                string[] newRow = {   dataRow.Field<String>("StartPlay"), 
                               dataRow.Field<String>("AudioFile"),
                               dataRow.Field<String>("AudioFileFullPath"),
                               dataRow.Field<String>("PlayDuration"),
                               dataRow.Field<String>("StartRecord"),
                               dataRow.Field<String>("RecordDuration"),
                               Guid.NewGuid().ToString() };

                DateTime eventStartPlay = DateTime.Now;
                DateTime.TryParse(dataRow.Field<String>("StartPlay"), out eventStartPlay);

                DateTime eventStartRecord = DateTime.Now;
                DateTime.TryParse(dataRow.Field<String>("StartRecord"), out eventStartRecord);

                //If the event's start play or start record time is within the selected date range
                if ((eventStartPlay >= day && eventStartPlay < day.AddDays(1) ||
                    (eventStartRecord >= day && eventStartRecord < day.AddDays(1))))
                {
                    //Add the event to the repeatEvents DataSet
                    dataSetToFill.Tables["ScheduledEvent"].Rows.Add(newRow);
                }
            }
            return dataSetToFill;
        }

        #endregion

        #region Other


        private bool isRecordEvent(DataRow dataRow)
        {
            if (!String.IsNullOrEmpty(dataRow.Field<String>("StartRecord")))
                return true;
            else
                return false;
        }

        private bool isPlayEvent(DataRow dataRow)
        {
            if (!String.IsNullOrEmpty(dataRow.Field<String>("StartPlay")))
                return true;
            else
                return false;
        }

        #endregion

        #region Event handlers

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutHoot aboutBox = new AboutHoot())
            {
                aboutBox.ShowDialog();
            }
        }

        private void chkBoxRecordEnabled_CheckedChanged(object sender, EventArgs e)
        {
            lblCreateEventRecordDuration.Enabled = chkBoxRecordEnabled.Checked;
            dtpCreateEventStartRecord.Enabled = chkBoxRecordEnabled.Checked;
            txtCreateEventRecordDuration.Enabled = chkBoxRecordEnabled.Checked;

        }

        private void chkBoxPlayEnabled_CheckedChanged(object sender, EventArgs e)
        {
            lblCreateEventPlayDuration.Enabled = chkBoxPlayEnabled.Checked;
            dtpCreateEventStartPlay.Enabled = chkBoxPlayEnabled.Checked;
            txtCreateEventPlayDuration.Enabled = chkBoxPlayEnabled.Checked;
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            if (chkBoxPlayEnabled.Checked || chkBoxRecordEnabled.Checked)
            {
                DataRow newRow = eventsList.Tables["ScheduledEvent"].NewRow();
                //if both play and record are enabled
                string[] rowData = new string[newRow.Table.Columns.Count];
                if (chkBoxPlayEnabled.Checked)
                {
                    if (tvAvailableAudioFiles.SelectedNode != null)
                    {
                        if (tvAvailableAudioFiles.SelectedNode.Tag.ToString() != "Category")
                        {
                            newRow.SetField<String>("StartPlay", dtpCreateEventStartPlay.Text);
                            newRow.SetField<String>("AudioFile", tvAvailableAudioFiles.SelectedNode.Text);
                            newRow.SetField<String>("AudioFileFullPath", tvAvailableAudioFiles.SelectedNode.Tag.ToString());
                            if (String.IsNullOrEmpty(txtCreateEventPlayDuration.Text))
                            {
                                //Determine audio file length here instead
                                newRow.SetField<String>("PlayDuration", txtCreateEventPlayDuration.Text);
                            }
                            else
                            {
                                newRow.SetField<String>("PlayDuration", txtCreateEventPlayDuration.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR: You selected a category instead of audio file.\n Please select an audio file first.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: You must select an audio file to create a Play event");
                        return;
                    }
                }
                if (chkBoxRecordEnabled.Checked)
                {
                    if (txtCreateEventRecordDuration.Text == "")
                    {
                        MessageBox.Show("You must provide a record duration in order to create a record event");
                        return;
                    }
                    newRow.SetField<String>("StartRecord", dtpCreateEventStartRecord.Text);
                    newRow.SetField<String>("RecordDuration", txtCreateEventRecordDuration.Text);
                }
                newRow.SetField<String>("GUID", Guid.NewGuid().ToString());
                DataRow overlappingRow = findAnOverlappingEvent(newRow);
                if (overlappingRow == null)
                {
                    eventsList.Tables["ScheduledEvent"].Rows.Add(newRow);
                }
                else if (overlappingRow == newRow)
                {
                    MessageBox.Show("This event overlaps itself and cannot be created");
                }
                else
                {
                    MessageBox.Show("The event overlaps event " + eventsList.Tables["ScheduledEvent"].Rows.IndexOf(overlappingRow) + " and cannot be created\n");
                }
            }
            else
            {
                MessageBox.Show("You must select play and/or record to create an event.");
            }
        }

        private void btnAddAudioFile_Click(object sender, EventArgs e)
        {
            if (tvAvailableAudioFiles.SelectedNode != null)
            {
                if (tvAvailableAudioFiles.SelectedNode.Tag.ToString() != "Category")
                {
                    tvAvailableAudioFiles.SelectedNode = tvAvailableAudioFiles.SelectedNode.Parent;
                }
                ofdAddAudioFile.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must create and select a category to add audio files.");
            }
        }

        // duplicateAudioFile(String)
        // --------------------------
        // Description: Searches the audio files tree for any matching audio file name. Return true if duplicate
        // --------------------------
        // Calls to: duplicateTreeString(TreeNodeCollection, String, ref bool)
        // Called by: Scheduler
        // -------------------------- 
        private bool duplicateAudioFile(String newFile)
        {
            bool duplicateFound = false;
            duplicateTreeString(tvAvailableAudioFiles.Nodes, newFile, ref duplicateFound);
            return duplicateFound;
        }

        // duplicateTreeString(TreeNodeCollection, String, ref bool)
        // --------------------------
        // Description: Recursively searches the TreeNodeCollection searching for a node equal to String. 
        // If found, sets the referenced boolean to true passed as an arg. 
        // --------------------------
        // Calls to: Self
        // Called by: Scheduler
        // -------------------------- 
        private void duplicateTreeString(TreeNodeCollection treeNodes, String value, ref bool duplicateFound)
        {
            for (int i = 0; i < treeNodes.Count; i++)
            {
                if (duplicateFound)
                    break;
                TreeNode treeNode = treeNodes[i];
                String filepath = treeNode.Tag.ToString();
                if (filepath != "Category")
                {
                    if (treeNode.Text == value)
                    {
                        duplicateFound = true;
                    }
                }
                if (treeNode.Nodes.Count > 0 && !duplicateFound)
                {
                    duplicateTreeString(treeNode.Nodes, value, ref duplicateFound);
                }
            }
        }

        private void ofdAddAudioFile_FileOk(object sender, CancelEventArgs e)
        {
            if (tvAvailableAudioFiles.SelectedNode != null)
            {
                for (int i = 0; i < ofdAddAudioFile.FileNames.Length; i++)
                {
                    String filename = ofdAddAudioFile.SafeFileNames[i];
                    String fullpath = ofdAddAudioFile.FileNames[i];
                    if (!duplicateAudioFile(filename))
                    {
                        TreeNode newNode = tvAvailableAudioFiles.SelectedNode.Nodes.Add(filename);
                        newNode.Tag = fullpath;
                    }
                    else
                    {
                        MessageBox.Show("This file '" + filename + "' has the same name as a file already loaded. Please rename the file before adding it.");
                    }
                }
                tvAvailableAudioFiles.SelectedNode.Expand();
            }
            else
            {
                for (int i = 0; i < ofdAddAudioFile.FileNames.Length; i++)
                {
                    TreeNode newNode = tvAvailableAudioFiles.Nodes.Add(ofdAddAudioFile.SafeFileNames[i]);
                    newNode.Tag = ofdAddAudioFile.FileNames[i];
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            TreeNode node = tvAvailableAudioFiles.SelectedNode;
            if (node != null)
            {
                if (System.IO.File.Exists(node.Tag.ToString()))
                {
                    tvAvailableAudioFiles.SelectedNode = node.Parent;
                }
            }
            Point popupLocation = new Point(MousePosition.X, MousePosition.Y - 50);

            if (tvAvailableAudioFiles.SelectedNode != null)
            {
                using (PromptBox pb = new PromptBox("Please enter new " + tvAvailableAudioFiles.SelectedNode.Text + " sub category name.", tvAvailableAudioFiles, popupLocation))
                {
                    pb.ShowDialog();
                }
            }
            else
            {
                using (PromptBox pb = new PromptBox("Please enter category name.", tvAvailableAudioFiles, popupLocation))
                {
                    pb.ShowDialog();
                }
            }
        }

        private void tvAvailableAudioFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvAvailableAudioFiles.SelectedNode != null)
            {
                if (System.IO.File.Exists(tvAvailableAudioFiles.SelectedNode.Tag.ToString()))
                {
                    wmpPlayer.URL = tvAvailableAudioFiles.SelectedNode.Tag.ToString();
                    wmpPlayer.Ctlcontrols.play();
                }
                else if (tvAvailableAudioFiles.SelectedNode.Tag.ToString() != "Category")
                {
                    MessageBox.Show("The audio file cannot be found to play. It was moved, renamed, or deleted.");
                    validateAudioFiles();
                }
            }
        }

        private void tvAvailableAudioFiles_MouseClick(object sender, MouseEventArgs e)
        {
            tvAvailableAudioFiles.SelectedNode = null;
            tvAvailableAudioFiles.Update();
        }

        private void dgvScheduledEvents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    //If the user double clicked on the Start Play column
                    if (e.RowIndex > -1)
                    {
                        popupCalendar(dgvScheduledEvents, e);
                    }
                    break;
                case 1:
                    //If the user double clicked on the Audio file column
                    if (tvAvailableAudioFiles.SelectedNode != null)
                    {
                        if (tvAvailableAudioFiles.SelectedNode.Tag.ToString() != "Category")
                        {
                            eventsList.Tables["ScheduledEvent"].Rows[e.RowIndex].SetField<String>("AudioFile", tvAvailableAudioFiles.SelectedNode.Text);
                            eventsList.Tables["ScheduledEvent"].Rows[e.RowIndex].SetField<String>("AudioFileFullPath", tvAvailableAudioFiles.SelectedNode.Tag.ToString());
                            if (File.Exists(eventsList.Tables["ScheduledEvent"].Rows[e.RowIndex].Field<String>("AudioFileFullPath")))
                                eventsList.Tables["ScheduledEvent"].Rows[e.RowIndex].SetColumnError("AudioFile", "");
                            else
                                eventsList.Tables["ScheduledEvent"].Rows[e.RowIndex].SetColumnError("AudioFile", "File not found");
                        }
                    }
                    break;
                case 4:
                    //If the user double clicked on the Start Record column
                    if (e.RowIndex > -1)
                    {
                        popupCalendar(dgvScheduledEvents, e);
                    }
                    break;
            }
        }

        private void btnDeleteAudioFile_Click(object sender, EventArgs e)
        {
            if (tvAvailableAudioFiles.SelectedNode != null)
            {
                tvAvailableAudioFiles.SelectedNode.Remove();
            }
        }

        private void sendScheduleToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            validateAudioFiles();
            foreach (DataRow dataRow in eventsList.Tables["ScheduledEvent"].Rows)
            {
                if (dataRow.HasErrors)
                {
                    if (MessageBox.Show("One or more play events had missing audio files.\nContinue?", "Missing audio files", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        break;
                    else
                        return;
                }
            }

            ArrayList schedulePackage = new ArrayList();
            try
            {
                File.Move("schedule.xml", "schedule.xml.bk");
            }
            catch (System.IO.IOException) { }
            eventsList.WriteXml("schedule.xml");
            schedulePackage.Add("schedule.xml");

            using (WritingScheduleProgressDialog progressDialog = new WritingScheduleProgressDialog())
            {
                ProgressBar progressBar = (ProgressBar)progressDialog.Controls.Find("progressBar1", false)[0];
                progressDialog.StartPosition = FormStartPosition.Manual;
                progressDialog.Location = MousePosition;
                progressDialog.Show();
                foreach (DataRow eventsRow in eventsList.Tables["ScheduledEvent"].Rows)
                {
                    if (!schedulePackage.Contains(eventsRow.Field<String>("AudioFileFullPath")))
                    {
                        schedulePackage.Add(eventsRow.Field<String>("AudioFileFullPath"));
                    }
                }

                string[] filenames = schedulePackage.ToArray(typeof(String)) as String[];
                string usersDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (File.Exists(usersDesktop + "\\schedule.zip"))
                {
                    if (MessageBox.Show("A schedule.zip already exists in " + usersDesktop + ". Do you want to overwrite it?", "Overwrite existing schedule?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                compressFiles(filenames, usersDesktop + "\\schedule.zip", 0, progressBar);
                File.Delete("schedule.xml");
                try
                {
                    File.Move("schedule.xml.bk", "schedule.xml");
                }
                catch (System.IO.IOException) { }
                progressDialog.Close();
            }
        }

        private void openMyScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvAvailableAudioFiles.Nodes.Clear();
            eventsList.Clear();
            string personalSchedulerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\";
            try
            {
                eventsList.ReadXml(personalSchedulerDirectory + "schedule.xml");
                TreeViewSerializer.DeserializeTreeView(tvAvailableAudioFiles, personalSchedulerDirectory + "audiofiles.dat");
            }
            catch (System.IO.DirectoryNotFoundException directoryNotFoundException)
            {
                Directory.CreateDirectory(personalSchedulerDirectory);
                MessageBox.Show("No personal schedule found to open.");
            }
            catch (System.IO.FileNotFoundException fileNotFoundException)
            {
                MessageBox.Show("No personal schedule found to open.");
            }
            validateAudioFiles();
        }

        private void openSharedScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvAvailableAudioFiles.Nodes.Clear();
            eventsList.Clear();
            string sharedSchedulerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Scheduler\\";
            try
            {
                eventsList.ReadXml(sharedSchedulerDirectory + "schedule.xml");
                TreeViewSerializer.DeserializeTreeView(tvAvailableAudioFiles, sharedSchedulerDirectory + "audiofiles.dat");
            }
            catch (System.IO.DirectoryNotFoundException directoryNotFoundException)
            {
                Directory.CreateDirectory(sharedSchedulerDirectory);
                MessageBox.Show("No shared schedule found to open.");
            }
            catch (System.IO.FileNotFoundException fileNotFoundException)
            {
                MessageBox.Show("No shared schedule found to open.");
            }
            validateAudioFiles();
        }

        private void saveMyScheduleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            validateAudioFiles();
            string sharedSchedulerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\";
            try
            {
                eventsList.WriteXml(sharedSchedulerDirectory + "schedule.xml");
                TreeViewSerializer.SerializeTreeView(tvAvailableAudioFiles, sharedSchedulerDirectory + "audiofiles.dat");
            }
            catch (Exception exception)
            {
            }
        }

        private void saveSharedScheduleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            validateAudioFiles();
            string sharedSchedulerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Scheduler\\";
            try
            {
                eventsList.WriteXml(sharedSchedulerDirectory + "schedule.xml");
                TreeViewSerializer.SerializeTreeView(tvAvailableAudioFiles, sharedSchedulerDirectory + "audiofiles.dat");
            }
            catch (System.IO.DirectoryNotFoundException directoryNotFoundException)
            {
                Directory.CreateDirectory(sharedSchedulerDirectory);
                eventsList.WriteXml(sharedSchedulerDirectory + "schedule.xml");
                TreeViewSerializer.SerializeTreeView(tvAvailableAudioFiles, sharedSchedulerDirectory + "audiofiles.dat");
            }
        }

        private void mntCalendarDateBrowser_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (radBtnViewSelectedDateOnly.Checked)
            {
                SelectionRange dateRange = mntCalendarDateBrowser.SelectionRange;
                dateRange.End = dateRange.End.AddDays(1);
                displaySelectedDateRangeEventsOnly(dateRange);
            }
        }

        private void radBtnViewSelectedDateOnly_CheckedChanged(object sender, EventArgs e)
        {
            displaySelectedDateRangeEventsOnly(mntCalendarDateBrowser.SelectionRange);
        }

        private void radBtnViewAllEvents_CheckedChanged(object sender, EventArgs e)
        {
            displayAllEvents();
        }

        private void txtCreateEventPlayDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) ^ Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCreateEventRecordDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) ^ Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvScheduledEvents_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) ^ Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvScheduledEvents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = (int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex);
            int rowIndex = (int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.RowIndex);
            if (columnIndex == 3 && !String.IsNullOrEmpty(dgvScheduledEvents.Rows[rowIndex].Cells["StartPlay"].Value.ToString()))
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxNumeric_KeyPress);
            }
            else if (columnIndex == 5 && !String.IsNullOrEmpty(dgvScheduledEvents.Rows[rowIndex].Cells["StartRecord"].Value.ToString()))
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxNumeric_KeyPress);
            }
            else
            {
                e.Control.Hide();
            }
        }

        // Called to handle keypress events when a user edits the DataGridView
        // Handles validation of keypresses, and only allows numbers and Ctrl events (ctrl-c, ctrl-v)
        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) ^ Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCopyEvents_Click(object sender, EventArgs e)
        {
            sourceSelection = mntCalendarDateBrowser.SelectionRange;
        }

        private void btnRepeatEvents_Click(object sender, EventArgs e)
        {
            if (sourceSelection != null)
            {
                repeatDestination = mntCalendarDateBrowser.SelectionRange;
                int daysCopied = (sourceSelection.End - sourceSelection.Start).Days;
                int daysToRepeat = (mntCalendarDateBrowser.SelectionEnd - mntCalendarDateBrowser.SelectionStart).Days;
                ArrayList overlappingDays = new ArrayList();

                if (daysCopied != daysToRepeat)
                {
                    MessageBox.Show("You selected " + (daysCopied + 1) + " days to copy, but only " + (daysToRepeat + 1) +
                                    " to repeat. Be sure to select the same number of days to copy/repeat.");
                    return;
                }
                DateTime dstDay = repeatDestination.Start;
                for (DateTime srcDay = sourceSelection.Start; srcDay <= sourceSelection.End; srcDay = srcDay.AddDays(1))
                {
                    if (repeatSingleDaysEvents(srcDay, dstDay))
                    {
                        overlappingDays.Add(dstDay);
                    }
                    dstDay = dstDay.AddDays(1);
                }
                mntCalendarDateBrowser.SelectionRange = repeatDestination;
                if (overlappingDays.Count > 0)
                {
                    String overlappingDaysAsString = "\n\n";
                    foreach (DateTime overlappingDay in overlappingDays)
                    {
                        overlappingDaysAsString += overlappingDay.Month + "/" + overlappingDay.Day + "\t";
                    }
                    MessageBox.Show("Overlapping events were found on the following days:" + overlappingDaysAsString + "\n\nThese events were not repeated.");
                }
            }
            else
            {
                MessageBox.Show("You must select a range of events and copy them first.");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdSaveScheduleAs.ShowDialog();
        }

        private void sfdSaveScheduleAs_FileOk(object sender, CancelEventArgs e)
        {
            validateAudioFiles();
            eventsList.WriteXml(sfdSaveScheduleAs.FileName);
            TreeViewSerializer.SerializeTreeView(tvAvailableAudioFiles, sfdSaveScheduleAs.FileName + "_audiofiles.dat");
        }

        private void savedScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdOpenSavedSchedule.ShowDialog();
        }

        private void ofdOpenSavedSchedule_FileOk(object sender, CancelEventArgs e)
        {
            tvAvailableAudioFiles.Nodes.Clear();
            eventsList.Clear();
            try
            {
                eventsList.ReadXml(ofdOpenSavedSchedule.FileName);
                TreeViewSerializer.DeserializeTreeView(tvAvailableAudioFiles, ofdOpenSavedSchedule.FileName + "_audiofiles.dat");
            }
            catch (FileNotFoundException fnfException)
            {
                MessageBox.Show(fnfException.Message);
            }
            validateAudioFiles();
        }

        private void dgvScheduledEvents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //this method overrides the DataGridView's RowPostPaint event 
            //in order to automatically draw numbers on the row header cells

            //store a string representation of the row number in 'strRowNumber'
            string strRowNumber = (e.RowIndex).ToString();

            Brush b = SystemBrushes.ControlText;
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dgvScheduledEvents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (eventsList != null)
            {
                dgvScheduledEvents.EndEdit();
                DataRow overlappingEvent = findAnOverlappingEvent(eventsList.Tables["ScheduledEvent"].Rows[e.RowIndex]);
                if (overlappingEvent != null)
                {
                    MessageBox.Show("This change would overlap event " +
                                    eventsList.Tables["ScheduledEvent"].Rows.IndexOf(overlappingEvent) +
                                    "\n No change has been made");
                    dgvScheduledEvents.CancelEdit();
                }
            }
        }
        #endregion
    }
}
