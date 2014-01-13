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
    public partial class PromptBox : Form
    {
        object caller; 

        public PromptBox()
        {
            InitializeComponent();
            caller = null; 
        }

        public PromptBox(string prompt, object caller)
        {
            InitializeComponent();
            lblPrompt.Text = prompt;
            this.caller = caller;
        }

        public PromptBox(string prompt, object caller, Point popupLocation)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = popupLocation;
            lblPrompt.Text = prompt;
            this.caller = caller; 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (caller is TextBox)
            {
                TextBox txt = (TextBox)caller;
                txt.Text = txtValue.Text;
            }
            if (caller is TreeView)
            {
                if (txtValue.Text != "")
                {
                    TreeView tv = (TreeView)caller;
                    if (tv.SelectedNode != null)
                    {
                        TreeNode newNode = tv.SelectedNode.Nodes.Add(txtValue.Text);
                        newNode.Tag = "Category";
                        tv.SelectedNode.Expand();
                        tv.SelectedNode = newNode;
                    }
                    else
                    {
                        TreeNode newNode = tv.Nodes.Add(txtValue.Text);
                        newNode.Tag = "Category";
                        tv.SelectedNode = newNode;
                    }
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
