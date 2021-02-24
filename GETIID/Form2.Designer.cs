
namespace GETIID
{
    partial class Options_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Driver_Location_Button = new System.Windows.Forms.Button();
            this.Driver_Location_Textbox = new System.Windows.Forms.TextBox();
            this.Browser_Driver_Label = new System.Windows.Forms.Label();
            this.Portable_Mode = new System.Windows.Forms.CheckBox();
            this.Find_Binary_Location_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Binary_Location_Textbox = new System.Windows.Forms.TextBox();
            this.Default_Browser_Driver_Label = new System.Windows.Forms.Label();
            this.Default_Browser_Settings = new System.Windows.Forms.ComboBox();
            this.url_textbox = new System.Windows.Forms.TextBox();
            this.URL_Label = new System.Windows.Forms.Label();
            this.Save_Button = new System.Windows.Forms.Button();
            this.About_Group = new System.Windows.Forms.GroupBox();
            this.github_link = new System.Windows.Forms.LinkLabel();
            this.Author_Label = new System.Windows.Forms.Label();
            this.BrowserBinaryLocation = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Office_License_Location_Label = new System.Windows.Forms.Label();
            this.Office_Licenes_Location_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.About_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Office_Licenes_Location_Button);
            this.groupBox1.Controls.Add(this.Office_License_Location_Label);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.Driver_Location_Button);
            this.groupBox1.Controls.Add(this.Driver_Location_Textbox);
            this.groupBox1.Controls.Add(this.Browser_Driver_Label);
            this.groupBox1.Controls.Add(this.Portable_Mode);
            this.groupBox1.Controls.Add(this.Find_Binary_Location_Button);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Binary_Location_Textbox);
            this.groupBox1.Controls.Add(this.Default_Browser_Driver_Label);
            this.groupBox1.Controls.Add(this.Default_Browser_Settings);
            this.groupBox1.Controls.Add(this.url_textbox);
            this.groupBox1.Controls.Add(this.URL_Label);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // Driver_Location_Button
            // 
            this.Driver_Location_Button.Location = new System.Drawing.Point(256, 174);
            this.Driver_Location_Button.Name = "Driver_Location_Button";
            this.Driver_Location_Button.Size = new System.Drawing.Size(52, 23);
            this.Driver_Location_Button.TabIndex = 10;
            this.Driver_Location_Button.Text = "Find";
            this.Driver_Location_Button.UseVisualStyleBackColor = true;
            this.Driver_Location_Button.Click += new System.EventHandler(this.Driver_Location_Button_Click);
            // 
            // Driver_Location_Textbox
            // 
            this.Driver_Location_Textbox.Location = new System.Drawing.Point(9, 174);
            this.Driver_Location_Textbox.Name = "Driver_Location_Textbox";
            this.Driver_Location_Textbox.Size = new System.Drawing.Size(241, 20);
            this.Driver_Location_Textbox.TabIndex = 9;
            // 
            // Browser_Driver_Label
            // 
            this.Browser_Driver_Label.AutoSize = true;
            this.Browser_Driver_Label.Location = new System.Drawing.Point(6, 153);
            this.Browser_Driver_Label.Name = "Browser_Driver_Label";
            this.Browser_Driver_Label.Size = new System.Drawing.Size(120, 13);
            this.Browser_Driver_Label.TabIndex = 8;
            this.Browser_Driver_Label.Text = "Browser Driver Location";
            // 
            // Portable_Mode
            // 
            this.Portable_Mode.AutoSize = true;
            this.Portable_Mode.Checked = global::GETIID.Properties.Settings.Default.portable_mode;
            this.Portable_Mode.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GETIID.Properties.Settings.Default, "portable_mode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Portable_Mode.Location = new System.Drawing.Point(170, 86);
            this.Portable_Mode.Name = "Portable_Mode";
            this.Portable_Mode.Size = new System.Drawing.Size(95, 17);
            this.Portable_Mode.TabIndex = 7;
            this.Portable_Mode.Text = "Portable Mode";
            this.Portable_Mode.UseVisualStyleBackColor = true;
            // 
            // Find_Binary_Location_Button
            // 
            this.Find_Binary_Location_Button.Location = new System.Drawing.Point(256, 128);
            this.Find_Binary_Location_Button.Name = "Find_Binary_Location_Button";
            this.Find_Binary_Location_Button.Size = new System.Drawing.Size(52, 23);
            this.Find_Binary_Location_Button.TabIndex = 6;
            this.Find_Binary_Location_Button.Text = "Find";
            this.Find_Binary_Location_Button.UseVisualStyleBackColor = true;
            this.Find_Binary_Location_Button.Click += new System.EventHandler(this.Find_Binary_Location_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Browser Binary Location";
            // 
            // Binary_Location_Textbox
            // 
            this.Binary_Location_Textbox.Location = new System.Drawing.Point(9, 130);
            this.Binary_Location_Textbox.Name = "Binary_Location_Textbox";
            this.Binary_Location_Textbox.Size = new System.Drawing.Size(241, 20);
            this.Binary_Location_Textbox.TabIndex = 4;
            // 
            // Default_Browser_Driver_Label
            // 
            this.Default_Browser_Driver_Label.AutoSize = true;
            this.Default_Browser_Driver_Label.Location = new System.Drawing.Point(6, 67);
            this.Default_Browser_Driver_Label.Name = "Default_Browser_Driver_Label";
            this.Default_Browser_Driver_Label.Size = new System.Drawing.Size(106, 13);
            this.Default_Browser_Driver_Label.TabIndex = 3;
            this.Default_Browser_Driver_Label.Text = "Using Browser Driver";
            // 
            // Default_Browser_Settings
            // 
            this.Default_Browser_Settings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Default_Browser_Settings.Items.AddRange(new object[] {
            "chrome",
            "edge",
            "edge_legacy"});
            this.Default_Browser_Settings.Location = new System.Drawing.Point(9, 84);
            this.Default_Browser_Settings.Name = "Default_Browser_Settings";
            this.Default_Browser_Settings.Size = new System.Drawing.Size(121, 21);
            this.Default_Browser_Settings.TabIndex = 2;
            // 
            // url_textbox
            // 
            this.url_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url_textbox.Location = new System.Drawing.Point(9, 41);
            this.url_textbox.Name = "url_textbox";
            this.url_textbox.Size = new System.Drawing.Size(305, 20);
            this.url_textbox.TabIndex = 1;
            // 
            // URL_Label
            // 
            this.URL_Label.AutoSize = true;
            this.URL_Label.Location = new System.Drawing.Point(6, 25);
            this.URL_Label.Name = "URL_Label";
            this.URL_Label.Size = new System.Drawing.Size(89, 13);
            this.URL_Label.TabIndex = 0;
            this.URL_Label.Text = "Self-Service URL";
            // 
            // Save_Button
            // 
            this.Save_Button.AutoSize = true;
            this.Save_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Save_Button.Location = new System.Drawing.Point(3, 96);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(314, 48);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // About_Group
            // 
            this.About_Group.Controls.Add(this.github_link);
            this.About_Group.Controls.Add(this.Author_Label);
            this.About_Group.Controls.Add(this.Save_Button);
            this.About_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.About_Group.Location = new System.Drawing.Point(0, 276);
            this.About_Group.Name = "About_Group";
            this.About_Group.Size = new System.Drawing.Size(320, 147);
            this.About_Group.TabIndex = 2;
            this.About_Group.TabStop = false;
            this.About_Group.Text = "About";
            // 
            // github_link
            // 
            this.github_link.AutoSize = true;
            this.github_link.Location = new System.Drawing.Point(6, 55);
            this.github_link.Name = "github_link";
            this.github_link.Size = new System.Drawing.Size(279, 13);
            this.github_link.TabIndex = 3;
            this.github_link.TabStop = true;
            this.github_link.Text = "Checkout my GitHub, you can find the source code there!";
            this.github_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.github_link_LinkClicked);
            // 
            // Author_Label
            // 
            this.Author_Label.AutoSize = true;
            this.Author_Label.Location = new System.Drawing.Point(6, 30);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(167, 13);
            this.Author_Label.TabIndex = 2;
            this.Author_Label.Text = "Created By: Maciej \"Mac\" Bregisz";
            // 
            // BrowserBinaryLocation
            // 
            this.BrowserBinaryLocation.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 11;
            // 
            // Office_License_Location_Label
            // 
            this.Office_License_Location_Label.AutoSize = true;
            this.Office_License_Location_Label.Location = new System.Drawing.Point(9, 202);
            this.Office_License_Location_Label.Name = "Office_License_Location_Label";
            this.Office_License_Location_Label.Size = new System.Drawing.Size(124, 13);
            this.Office_License_Location_Label.TabIndex = 12;
            this.Office_License_Location_Label.Text = "Office Licenses Location";
            // 
            // Office_Licenes_Location_Button
            // 
            this.Office_Licenes_Location_Button.Location = new System.Drawing.Point(257, 221);
            this.Office_Licenes_Location_Button.Name = "Office_Licenes_Location_Button";
            this.Office_Licenes_Location_Button.Size = new System.Drawing.Size(51, 23);
            this.Office_Licenes_Location_Button.TabIndex = 13;
            this.Office_Licenes_Location_Button.Text = "Find";
            this.Office_Licenes_Location_Button.UseVisualStyleBackColor = true;
            // 
            // Options_Form
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(320, 423);
            this.Controls.Add(this.About_Group);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Options_Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.About_Group.ResumeLayout(false);
            this.About_Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox url_textbox;
        private System.Windows.Forms.Label URL_Label;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.GroupBox About_Group;
        private System.Windows.Forms.Label Author_Label;
        private System.Windows.Forms.LinkLabel github_link;
        private System.Windows.Forms.ComboBox Default_Browser_Settings;
        private System.Windows.Forms.Label Default_Browser_Driver_Label;
        private System.Windows.Forms.Button Find_Binary_Location_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Binary_Location_Textbox;
        private System.Windows.Forms.OpenFileDialog BrowserBinaryLocation;
        private System.Windows.Forms.CheckBox Portable_Mode;
        private System.Windows.Forms.TextBox Driver_Location_Textbox;
        private System.Windows.Forms.Label Browser_Driver_Label;
        private System.Windows.Forms.Button Driver_Location_Button;
        private System.Windows.Forms.Button Office_Licenes_Location_Button;
        private System.Windows.Forms.Label Office_License_Location_Label;
        private System.Windows.Forms.TextBox textBox1;
    }
}