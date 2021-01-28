
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
            this.url_textbox = new System.Windows.Forms.TextBox();
            this.URL_Label = new System.Windows.Forms.Label();
            this.Save_Button = new System.Windows.Forms.Button();
            this.About_Group = new System.Windows.Forms.GroupBox();
            this.Author_Label = new System.Windows.Forms.Label();
            this.github_link = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.About_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.url_textbox);
            this.groupBox1.Controls.Add(this.URL_Label);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // url_textbox
            // 
            this.url_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url_textbox.Location = new System.Drawing.Point(6, 41);
            this.url_textbox.Name = "url_textbox";
            this.url_textbox.Size = new System.Drawing.Size(308, 20);
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
            this.Save_Button.Location = new System.Drawing.Point(3, 204);
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
            this.About_Group.Location = new System.Drawing.Point(0, 86);
            this.About_Group.Name = "About_Group";
            this.About_Group.Size = new System.Drawing.Size(320, 255);
            this.About_Group.TabIndex = 2;
            this.About_Group.TabStop = false;
            this.About_Group.Text = "About";
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
            // Options_Form
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(320, 341);
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
    }
}