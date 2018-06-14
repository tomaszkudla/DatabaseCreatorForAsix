namespace DataBaseCreatorForAsix
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvTags = new System.Windows.Forms.ListView();
            this.TagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConversionFunction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Unit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Group1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Group2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Group3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Group4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.ssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbOPCaddress = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.btGetOPCTags = new System.Windows.Forms.Button();
            this.cbPreview = new System.Windows.Forms.CheckBox();
            this.rbOverwrite = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.lbOPCDescr = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.lvLog = new System.Windows.Forms.ListView();
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ssStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvTags
            // 
            this.lvTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TagName,
            this.Address,
            this.ConversionFunction,
            this.Unit,
            this.Group1,
            this.Group2,
            this.Group3,
            this.Group4});
            this.lvTags.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvTags.FullRowSelect = true;
            this.lvTags.GridLines = true;
            this.lvTags.Location = new System.Drawing.Point(12, 62);
            this.lvTags.Name = "lvTags";
            this.lvTags.Size = new System.Drawing.Size(1085, 317);
            this.lvTags.TabIndex = 0;
            this.lvTags.Tag = "";
            this.lvTags.UseCompatibleStateImageBehavior = false;
            this.lvTags.View = System.Windows.Forms.View.Details;
            this.lvTags.Resize += new System.EventHandler(this.lvTags_Resize);
            // 
            // TagName
            // 
            this.TagName.Text = "Name";
            this.TagName.Width = 161;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            this.Address.Width = 271;
            // 
            // ConversionFunction
            // 
            this.ConversionFunction.DisplayIndex = 3;
            this.ConversionFunction.Text = "ConversionFunction";
            this.ConversionFunction.Width = 145;
            // 
            // Unit
            // 
            this.Unit.DisplayIndex = 2;
            this.Unit.Text = "Unit";
            this.Unit.Width = 158;
            // 
            // Group1
            // 
            this.Group1.Text = "Group1";
            // 
            // Group2
            // 
            this.Group2.Text = "Group2";
            // 
            // Group3
            // 
            this.Group3.Text = "Group3";
            // 
            // Group4
            // 
            this.Group4.Text = "Group4";
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssLabel});
            this.ssStatus.Location = new System.Drawing.Point(0, 573);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1109, 22);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "Press \"Create\" to start";
            // 
            // ssLabel
            // 
            this.ssLabel.Name = "ssLabel";
            this.ssLabel.Size = new System.Drawing.Size(157, 17);
            this.ssLabel.Text = "Press \"Get OPC tags\" to start";
            // 
            // tbOPCaddress
            // 
            this.tbOPCaddress.Location = new System.Drawing.Point(356, 25);
            this.tbOPCaddress.Name = "tbOPCaddress";
            this.tbOPCaddress.Size = new System.Drawing.Size(213, 20);
            this.tbOPCaddress.TabIndex = 2;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(108, 12);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(106, 44);
            this.btCreate.TabIndex = 3;
            this.btCreate.Text = "Add tags to database";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btGetOPCTags
            // 
            this.btGetOPCTags.Location = new System.Drawing.Point(12, 12);
            this.btGetOPCTags.Name = "btGetOPCTags";
            this.btGetOPCTags.Size = new System.Drawing.Size(90, 44);
            this.btGetOPCTags.TabIndex = 5;
            this.btGetOPCTags.Text = "Get OPC tags";
            this.btGetOPCTags.UseVisualStyleBackColor = true;
            this.btGetOPCTags.Click += new System.EventHandler(this.btGetOPCTags_Click);
            // 
            // cbPreview
            // 
            this.cbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPreview.AutoSize = true;
            this.cbPreview.Location = new System.Drawing.Point(12, 385);
            this.cbPreview.Name = "cbPreview";
            this.cbPreview.Size = new System.Drawing.Size(97, 17);
            this.cbPreview.TabIndex = 6;
            this.cbPreview.Text = "Preview tag list";
            this.cbPreview.UseVisualStyleBackColor = true;
            this.cbPreview.CheckedChanged += new System.EventHandler(this.cbPreview_CheckedChanged);
            // 
            // rbOverwrite
            // 
            this.rbOverwrite.AutoSize = true;
            this.rbOverwrite.Location = new System.Drawing.Point(594, 35);
            this.rbOverwrite.Name = "rbOverwrite";
            this.rbOverwrite.Size = new System.Drawing.Size(117, 17);
            this.rbOverwrite.TabIndex = 7;
            this.rbOverwrite.TabStop = true;
            this.rbOverwrite.Text = "Overwrite database";
            this.rbOverwrite.UseVisualStyleBackColor = true;
            this.rbOverwrite.CheckedChanged += new System.EventHandler(this.rbOverwrite_CheckedChanged);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Location = new System.Drawing.Point(594, 12);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(90, 17);
            this.rbAdd.TabIndex = 8;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Add new tags";
            this.rbAdd.UseVisualStyleBackColor = true;
            this.rbAdd.CheckedChanged += new System.EventHandler(this.rbAdd_CheckedChanged);
            // 
            // lbOPCDescr
            // 
            this.lbOPCDescr.AutoSize = true;
            this.lbOPCDescr.Location = new System.Drawing.Point(231, 28);
            this.lbOPCDescr.Name = "lbOPCDescr";
            this.lbOPCDescr.Size = new System.Drawing.Size(119, 13);
            this.lbOPCDescr.TabIndex = 9;
            this.lbOPCDescr.Text = "OPC UA server address";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(734, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(257, 26);
            this.progressBar.TabIndex = 10;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(997, 25);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(21, 13);
            this.lbProgress.TabIndex = 11;
            this.lbProgress.Text = "0%";
            // 
            // lvLog
            // 
            this.lvLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTime,
            this.chEvent});
            this.lvLog.FullRowSelect = true;
            this.lvLog.GridLines = true;
            this.lvLog.Location = new System.Drawing.Point(12, 408);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(1085, 151);
            this.lvLog.TabIndex = 12;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 122;
            // 
            // chEvent
            // 
            this.chEvent.Text = "Event";
            this.chEvent.Width = 468;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 595);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbOPCDescr);
            this.Controls.Add(this.rbAdd);
            this.Controls.Add(this.rbOverwrite);
            this.Controls.Add(this.cbPreview);
            this.Controls.Add(this.btGetOPCTags);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.tbOPCaddress);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.lvTags);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1125, 634);
            this.Name = "Form1";
            this.Text = "Database Creator For Asix";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvTags;
        private System.Windows.Forms.ColumnHeader TagName;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel ssLabel;
        private System.Windows.Forms.TextBox tbOPCaddress;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btGetOPCTags;
        private System.Windows.Forms.ColumnHeader Unit;
        private System.Windows.Forms.CheckBox cbPreview;
        private System.Windows.Forms.ColumnHeader ConversionFunction;
        private System.Windows.Forms.ColumnHeader Group1;
        private System.Windows.Forms.ColumnHeader Group2;
        private System.Windows.Forms.ColumnHeader Group3;
        private System.Windows.Forms.ColumnHeader Group4;
        private System.Windows.Forms.RadioButton rbOverwrite;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.Label lbOPCDescr;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chEvent;
    }
}

