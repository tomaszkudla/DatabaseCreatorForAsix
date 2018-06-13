using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataBaseCreatorForAsix
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// OPCserver instance - configured on the PLC.
        /// </summary>
        OPCserver opcserver;

        /// <summary>
        /// List of all tags.
        /// </summary>
        List<Tag> Tags;

        /// <summary>
        /// If the old tags should be replaced.
        /// </summary>
        public bool Overwrite = false;
        
        public Form1()
        {
            InitializeComponent();
            SetColumnsWidth();
            opcserver = new OPCserver();
            opcserver.NewEvent += UpdateLog; //log subscribes to events from OPCserver class
            rbOverwrite.Checked = false; //adding tags is default option
            rbAdd.Checked = true; 
            ssLabel.Text = "Press \"Get OPC tags\" to start";
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.OPCaddress = tbOPCaddress.Text; //remembering OPC server address as a setting
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbOPCaddress.Text = Properties.Settings.Default.OPCaddress;  //restoring OPC server address
        }


        private async void btGetOPCTags_Click(object sender, EventArgs e)
        {
            ssLabel.Text = "Getting OPC tags...";
            opcserver.ProgressChanged += UpdatePercent; //updating the progress bar
            Tags = await opcserver.OPCReadAsync(tbOPCaddress.Text); //the most important OPCserver method - reading PLC tags
            if (Tags.Count() > 0)
            {
                ssLabel.Text = "Press \"Add tags to database\"";
            }
            else
            {
                ssLabel.Text = "Press \"Get OPC tags\" to start";
            }
        }

        private async void btCreate_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); //looking for existing Asix database - it should be created earlier in Asix 
            saveFileDialog.Filter = "MDB files|*.mdb";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != null)
            {
                ssLabel.Text = "Adding tags to database...";
                DataBase dataBase = new DataBase();
                dataBase.NewEvent += UpdateLog; //log subscribes to events from DataBase class
                dataBase.ProgressChanged += UpdatePercent; //updating the progress bar
                await Task.Run(() => dataBase.Create(saveFileDialog.FileName, Overwrite, Tags)); //most important DataBase method - saving tags to the database

                for (int i = 0; i < lvTags.Items.Count; i++) //marking tags on the list that were added to the database
                {
                    if (Tags[i].IsAdded)
                    {
                        lvTags.Items[i].BackColor = Color.Yellow;
                        lvTags.Items[i].EnsureVisible();
                    }
                }

            }
            ssLabel.Text = "Press \"Get OPC tags\" to get tags again or \"Add tags to database\" to add tags to database again";
        }

        /// <summary>
        /// Updates the progress bar. 
        /// </summary>
        public void UpdatePercent(object o, ProgressChangedArgs progressChangedArgs)
        {
            progressBar.Invoke(new Action(delegate () { progressBar.Value = progressChangedArgs.Percent; }));
            lbProgress.Invoke(new Action(delegate () { lbProgress.Text = progressChangedArgs.Percent.ToString() + "%"; }));
        }

        /// <summary>
        /// Refreshes the log. 
        /// </summary>
        public void UpdateLog(object o, LogEventArgs logEventArgs)
        {
            lvLog.Invoke(new Action(() =>
            {
                ListViewItem item = new ListViewItem(DateTime.Now.ToString());
                item.SubItems.Add(logEventArgs.Info);
                lvLog.Items.Add(item);
                lvLog.Items[lvLog.Items.Count - 1].EnsureVisible();
            }
            ));

        }
        /// <summary>
        /// Adds single tag to the list during operation.
        /// </summary>
        public void AddItemPreview(object o,NewTagAddedArgs newTagAddedArgs)
        {
            AddItem(newTagAddedArgs.tag);
        }

        /// <summary>
        /// Adds single tag to the list with colour marking and scrolling list view.
        /// </summary>
        public void AddItem(Tag tag)
        {
            ListViewItem item = new ListViewItem(tag.Name);
            item.SubItems.Add(tag.Address);
            item.SubItems.Add(tag.ConversionFunction);
            item.SubItems.Add(tag.Unit);
            item.SubItems.Add(tag.Group1);
            item.SubItems.Add(tag.Group2);
            item.SubItems.Add(tag.Group3);
            item.SubItems.Add(tag.Group4);
            if (tag.IsAdded) item.BackColor = Color.Yellow;
            lvTags.Items.Add(item);
            lvTags.Items[lvTags.Items.Count - 1].EnsureVisible();
        }

        private void cbPreview_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPreview.Checked)
            {
                if (opcserver != null && opcserver.Tags != null) //refreshing the tag list
                {
                    lvTags.Items.Clear();
                    foreach (Tag tag in opcserver.Tags)
                    {
                        AddItem(tag);
                    }
                }
                opcserver.NewTagAdded += AddItemPreview;
            }
            else
            {
                opcserver.NewTagAdded -= AddItemPreview;
            }
               
                
        }

        private void rbOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            Overwrite = rbOverwrite.Checked;
            rbAdd.Checked=!rbOverwrite.Checked;
        }

        private void rbAdd_CheckedChanged(object sender, EventArgs e)
        {
            Overwrite = !rbAdd.Checked;
            rbOverwrite.Checked = !rbAdd.Checked;
        }

        private void lvTags_Resize(object sender, EventArgs e)
        {
            SetColumnsWidth();
        }

        /// <summary>
        /// Sets proper columns width in tag list and log (runs on startup or resizing form).
        /// </summary>
        private void SetColumnsWidth()
        {
            lvTags.Columns[0].Width = lvTags.Width * 18 / 100;
            lvTags.Columns[1].Width = lvTags.Width * 30  / 100;
            lvTags.Columns[2].Width = lvTags.Width * 10  / 100;
            lvTags.Columns[3].Width = lvTags.Width * 8  / 100;
            lvTags.Columns[4].Width = lvTags.Width * 8  / 100;
            lvTags.Columns[5].Width = lvTags.Width * 8  / 100;
            lvTags.Columns[6].Width = lvTags.Width * 8  / 100;
            lvTags.Columns[7].Width = lvTags.Width * 8  / 100;

            lvLog.Columns[0].Width = lvLog.Width * 12/100;
            lvLog.Columns[1].Width = lvLog.Width * 85/100;
        }
    }
}
