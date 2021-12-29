
namespace GETIID
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.IID_GET_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.iid_textbox = new System.Windows.Forms.TextBox();
            this.REFRESH_BUTTON = new System.Windows.Forms.Button();
            this.UNINSTALL_SELECTED_BUTTON = new System.Windows.Forms.Button();
            this.ACTIVE_SERIALS = new System.Windows.Forms.ListView();
            this.ch_skuid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cid_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ACTIVATE_BUTTON = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ActivationGroup = new System.Windows.Forms.GroupBox();
            this.CID_GET_BUTTON = new System.Windows.Forms.Button();
            this.OFFICE_ACTIVATION_BUTTON = new System.Windows.Forms.Button();
            this.officekey_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OfficeKeysGroup = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.connectonStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ActivationGroup.SuspendLayout();
            this.OfficeKeysGroup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IID_GET_BUTTON
            // 
            this.IID_GET_BUTTON.Location = new System.Drawing.Point(395, 150);
            this.IID_GET_BUTTON.Name = "IID_GET_BUTTON";
            this.IID_GET_BUTTON.Size = new System.Drawing.Size(75, 20);
            this.IID_GET_BUTTON.TabIndex = 0;
            this.IID_GET_BUTTON.Text = "GET IID";
            this.toolTip1.SetToolTip(this.IID_GET_BUTTON, "Get current IID");
            this.IID_GET_BUTTON.UseVisualStyleBackColor = true;
            this.IID_GET_BUTTON.Click += new System.EventHandler(this.IID_GET_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IID";
            // 
            // iid_textbox
            // 
            this.iid_textbox.Location = new System.Drawing.Point(7, 124);
            this.iid_textbox.Name = "iid_textbox";
            this.iid_textbox.Size = new System.Drawing.Size(463, 20);
            this.iid_textbox.TabIndex = 2;
            // 
            // REFRESH_BUTTON
            // 
            this.REFRESH_BUTTON.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.REFRESH_BUTTON.Location = new System.Drawing.Point(3, 259);
            this.REFRESH_BUTTON.Name = "REFRESH_BUTTON";
            this.REFRESH_BUTTON.Size = new System.Drawing.Size(550, 50);
            this.REFRESH_BUTTON.TabIndex = 2;
            this.REFRESH_BUTTON.Text = "Refresh";
            this.toolTip1.SetToolTip(this.REFRESH_BUTTON, "Refresh Office Key List");
            this.REFRESH_BUTTON.UseVisualStyleBackColor = true;
            this.REFRESH_BUTTON.Click += new System.EventHandler(this.REFRESH_BUTTON_Click);
            // 
            // UNINSTALL_SELECTED_BUTTON
            // 
            this.UNINSTALL_SELECTED_BUTTON.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UNINSTALL_SELECTED_BUTTON.Location = new System.Drawing.Point(3, 309);
            this.UNINSTALL_SELECTED_BUTTON.Name = "UNINSTALL_SELECTED_BUTTON";
            this.UNINSTALL_SELECTED_BUTTON.Size = new System.Drawing.Size(550, 55);
            this.UNINSTALL_SELECTED_BUTTON.TabIndex = 1;
            this.UNINSTALL_SELECTED_BUTTON.Text = "Uninstall Selected";
            this.toolTip1.SetToolTip(this.UNINSTALL_SELECTED_BUTTON, "Uninstall Selected Office Key");
            this.UNINSTALL_SELECTED_BUTTON.UseVisualStyleBackColor = true;
            this.UNINSTALL_SELECTED_BUTTON.Click += new System.EventHandler(this.UNINSTALL_SELECTED_BUTTON_Click);
            // 
            // ACTIVE_SERIALS
            // 
            this.ACTIVE_SERIALS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ACTIVE_SERIALS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_skuid,
            this.ch_name,
            this.ch_key,
            this.ch_desc,
            this.ch_status});
            this.ACTIVE_SERIALS.FullRowSelect = true;
            this.ACTIVE_SERIALS.HideSelection = false;
            this.ACTIVE_SERIALS.Location = new System.Drawing.Point(8, 19);
            this.ACTIVE_SERIALS.MultiSelect = false;
            this.ACTIVE_SERIALS.Name = "ACTIVE_SERIALS";
            this.ACTIVE_SERIALS.Size = new System.Drawing.Size(542, 234);
            this.ACTIVE_SERIALS.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ACTIVE_SERIALS, "Select the installation key that you want to uninstall");
            this.ACTIVE_SERIALS.UseCompatibleStateImageBehavior = false;
            this.ACTIVE_SERIALS.View = System.Windows.Forms.View.Details;
            // 
            // ch_skuid
            // 
            this.ch_skuid.Text = "SKU ID";
            // 
            // ch_name
            // 
            this.ch_name.Text = "Product Name";
            this.ch_name.Width = 83;
            // 
            // ch_key
            // 
            this.ch_key.Text = "Last 5 of Key";
            this.ch_key.Width = 86;
            // 
            // ch_desc
            // 
            this.ch_desc.Text = "License Description";
            this.ch_desc.Width = 183;
            // 
            // ch_status
            // 
            this.ch_status.Text = "Status";
            this.ch_status.Width = 90;
            // 
            // cid_textbox
            // 
            this.cid_textbox.Location = new System.Drawing.Point(9, 212);
            this.cid_textbox.Name = "cid_textbox";
            this.cid_textbox.Size = new System.Drawing.Size(461, 20);
            this.cid_textbox.TabIndex = 7;
            this.cid_textbox.TextChanged += new System.EventHandler(this.cid_textbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CID";
            // 
            // ACTIVATE_BUTTON
            // 
            this.ACTIVATE_BUTTON.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ACTIVATE_BUTTON.Enabled = false;
            this.ACTIVATE_BUTTON.Location = new System.Drawing.Point(3, 348);
            this.ACTIVATE_BUTTON.Name = "ACTIVATE_BUTTON";
            this.ACTIVATE_BUTTON.Size = new System.Drawing.Size(470, 53);
            this.ACTIVATE_BUTTON.TabIndex = 9;
            this.ACTIVATE_BUTTON.Text = "Activate";
            this.ACTIVATE_BUTTON.UseVisualStyleBackColor = true;
            this.ACTIVATE_BUTTON.Click += new System.EventHandler(this.ACTIVATE_BUTTON_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1088, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.progressBar,
            this.connectonStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1088, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(42, 17);
            this.status.Text = "Status:";
            // 
            // ActivationGroup
            // 
            this.ActivationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ActivationGroup.Controls.Add(this.CID_GET_BUTTON);
            this.ActivationGroup.Controls.Add(this.OFFICE_ACTIVATION_BUTTON);
            this.ActivationGroup.Controls.Add(this.officekey_textbox);
            this.ActivationGroup.Controls.Add(this.label2);
            this.ActivationGroup.Controls.Add(this.iid_textbox);
            this.ActivationGroup.Controls.Add(this.IID_GET_BUTTON);
            this.ActivationGroup.Controls.Add(this.cid_textbox);
            this.ActivationGroup.Controls.Add(this.ACTIVATE_BUTTON);
            this.ActivationGroup.Controls.Add(this.label1);
            this.ActivationGroup.Controls.Add(this.label3);
            this.ActivationGroup.Location = new System.Drawing.Point(20, 29);
            this.ActivationGroup.Name = "ActivationGroup";
            this.ActivationGroup.Size = new System.Drawing.Size(476, 404);
            this.ActivationGroup.TabIndex = 13;
            this.ActivationGroup.TabStop = false;
            this.ActivationGroup.Text = "Activation";
            // 
            // CID_GET_BUTTON
            // 
            this.CID_GET_BUTTON.Location = new System.Drawing.Point(395, 239);
            this.CID_GET_BUTTON.Name = "CID_GET_BUTTON";
            this.CID_GET_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.CID_GET_BUTTON.TabIndex = 13;
            this.CID_GET_BUTTON.Text = "GET CID";
            this.toolTip1.SetToolTip(this.CID_GET_BUTTON, "Process current IID into a CID for activation");
            this.CID_GET_BUTTON.UseVisualStyleBackColor = true;
            this.CID_GET_BUTTON.Click += new System.EventHandler(this.CID_GET_BUTTON_Click);
            // 
            // OFFICE_ACTIVATION_BUTTON
            // 
            this.OFFICE_ACTIVATION_BUTTON.Location = new System.Drawing.Point(395, 62);
            this.OFFICE_ACTIVATION_BUTTON.Name = "OFFICE_ACTIVATION_BUTTON";
            this.OFFICE_ACTIVATION_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.OFFICE_ACTIVATION_BUTTON.TabIndex = 12;
            this.OFFICE_ACTIVATION_BUTTON.Text = "Activate";
            this.toolTip1.SetToolTip(this.OFFICE_ACTIVATION_BUTTON, "Activate Office 2016 using a Microsoft Office Key");
            this.OFFICE_ACTIVATION_BUTTON.UseVisualStyleBackColor = true;
            this.OFFICE_ACTIVATION_BUTTON.Click += new System.EventHandler(this.OFFICE_ACTIVATION_BUTTON_Click);
            // 
            // officekey_textbox
            // 
            this.officekey_textbox.Location = new System.Drawing.Point(7, 36);
            this.officekey_textbox.Name = "officekey_textbox";
            this.officekey_textbox.Size = new System.Drawing.Size(463, 20);
            this.officekey_textbox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Office Key Override";
            // 
            // OfficeKeysGroup
            // 
            this.OfficeKeysGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OfficeKeysGroup.Controls.Add(this.REFRESH_BUTTON);
            this.OfficeKeysGroup.Controls.Add(this.ACTIVE_SERIALS);
            this.OfficeKeysGroup.Controls.Add(this.UNINSTALL_SELECTED_BUTTON);
            this.OfficeKeysGroup.Location = new System.Drawing.Point(6, 4);
            this.OfficeKeysGroup.Name = "OfficeKeysGroup";
            this.OfficeKeysGroup.Size = new System.Drawing.Size(556, 367);
            this.OfficeKeysGroup.TabIndex = 14;
            this.OfficeKeysGroup.TabStop = false;
            this.OfficeKeysGroup.Text = "Installed Office Keys";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(502, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 403);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OfficeKeysGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Maximum = 70;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // connectonStatus
            // 
            this.connectonStatus.Name = "connectonStatus";
            this.connectonStatus.Size = new System.Drawing.Size(104, 17);
            this.connectonStatus.Text = "Connection Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 463);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ActivationGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IID_GET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ActivationGroup.ResumeLayout(false);
            this.ActivationGroup.PerformLayout();
            this.OfficeKeysGroup.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IID_GET_BUTTON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iid_textbox;
        private System.Windows.Forms.ListView ACTIVE_SERIALS;
        private System.Windows.Forms.Button UNINSTALL_SELECTED_BUTTON;
        private System.Windows.Forms.TextBox cid_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ACTIVATE_BUTTON;
        private System.Windows.Forms.Button REFRESH_BUTTON;
        private System.Windows.Forms.ColumnHeader ch_name;
        private System.Windows.Forms.ColumnHeader ch_key;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.GroupBox ActivationGroup;
        private System.Windows.Forms.TextBox officekey_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox OfficeKeysGroup;
        private System.Windows.Forms.Button OFFICE_ACTIVATION_BUTTON;
        private System.Windows.Forms.Button CID_GET_BUTTON;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader ch_skuid;
        private System.Windows.Forms.ColumnHeader ch_desc;
        private System.Windows.Forms.ColumnHeader ch_status;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel connectonStatus;
    }
}

