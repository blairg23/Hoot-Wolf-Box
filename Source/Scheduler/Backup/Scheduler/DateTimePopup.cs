using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class DateTimePopup : Form
    {
        object caller; 
        object callerArgs; 

        public DateTimePopup()
        {
            InitializeComponent();
            caller = null; 
        }

        public DateTimePopup(object caller, object callerArgs)
        {
            InitializeComponent();
            this.caller = caller;
            this.callerArgs = callerArgs;
            GetValueFromCaller();
        }

        private void GetValueFromCaller()
        {
            if (caller is DataGridView)
            {
                DataGridView dgv = (DataGridView)caller;
                DataGridViewCellEventArgs dgvCell = (DataGridViewCellEventArgs)callerArgs;
                dtpUpdateDateTime.Text = dgv.Rows[dgvCell.RowIndex].Cells[dgvCell.ColumnIndex].Value.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (caller is DataGridView)
            {
                DataGridView dgv = (DataGridView)caller;
                DataGridViewCellEventArgs dgvCell = (DataGridViewCellEventArgs)callerArgs;
                dgv.Rows[dgvCell.RowIndex].Cells[dgvCell.ColumnIndex].Value = dtpUpdateDateTime.Text;
                dgv.EndEdit();
            }
            this.Close();
        }
    }
}
