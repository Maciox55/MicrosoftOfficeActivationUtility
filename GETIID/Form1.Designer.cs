﻿
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
            this.IID_GET_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.REFRESH_BUTTON = new System.Windows.Forms.Button();
            this.UNINSTALL_SELECTED_BUTTON = new System.Windows.Forms.Button();
            this.ACTIVE_SERIALS = new System.Windows.Forms.ListView();
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.OPEN_BROWSER = new System.Windows.Forms.Button();
            this.cid_text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ACTIVATE_BUTTON = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status_strip = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IID_GET_BUTTON
            // 
            this.IID_GET_BUTTON.Location = new System.Drawing.Point(421, 61);
            this.IID_GET_BUTTON.Name = "IID_GET_BUTTON";
            this.IID_GET_BUTTON.Size = new System.Drawing.Size(75, 20);
            this.IID_GET_BUTTON.TabIndex = 0;
            this.IID_GET_BUTTON.Text = "GET IID";
            this.IID_GET_BUTTON.UseVisualStyleBackColor = true;
            this.IID_GET_BUTTON.Click += new System.EventHandler(this.IID_GET_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(399, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.REFRESH_BUTTON);
            this.panel1.Controls.Add(this.UNINSTALL_SELECTED_BUTTON);
            this.panel1.Controls.Add(this.ACTIVE_SERIALS);
            this.panel1.Location = new System.Drawing.Point(502, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 313);
            this.panel1.TabIndex = 4;
            // 
            // REFRESH_BUTTON
            // 
            this.REFRESH_BUTTON.Location = new System.Drawing.Point(4, 282);
            this.REFRESH_BUTTON.Name = "REFRESH_BUTTON";
            this.REFRESH_BUTTON.Size = new System.Drawing.Size(67, 23);
            this.REFRESH_BUTTON.TabIndex = 2;
            this.REFRESH_BUTTON.Text = "Refresh";
            this.REFRESH_BUTTON.UseVisualStyleBackColor = true;
            this.REFRESH_BUTTON.Click += new System.EventHandler(this.REFRESH_BUTTON_Click);
            // 
            // UNINSTALL_SELECTED_BUTTON
            // 
            this.UNINSTALL_SELECTED_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UNINSTALL_SELECTED_BUTTON.Location = new System.Drawing.Point(77, 282);
            this.UNINSTALL_SELECTED_BUTTON.Name = "UNINSTALL_SELECTED_BUTTON";
            this.UNINSTALL_SELECTED_BUTTON.Size = new System.Drawing.Size(292, 23);
            this.UNINSTALL_SELECTED_BUTTON.TabIndex = 1;
            this.UNINSTALL_SELECTED_BUTTON.Text = "Uninstall Selected";
            this.UNINSTALL_SELECTED_BUTTON.UseVisualStyleBackColor = true;
            this.UNINSTALL_SELECTED_BUTTON.Click += new System.EventHandler(this.UNINSTALL_SELECTED_BUTTON_Click);
            // 
            // ACTIVE_SERIALS
            // 
            this.ACTIVE_SERIALS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ACTIVE_SERIALS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_name,
            this.ch_key});
            this.ACTIVE_SERIALS.HideSelection = false;
            this.ACTIVE_SERIALS.Location = new System.Drawing.Point(4, 4);
            this.ACTIVE_SERIALS.MultiSelect = false;
            this.ACTIVE_SERIALS.Name = "ACTIVE_SERIALS";
            this.ACTIVE_SERIALS.Size = new System.Drawing.Size(365, 271);
            this.ACTIVE_SERIALS.TabIndex = 0;
            this.ACTIVE_SERIALS.UseCompatibleStateImageBehavior = false;
            this.ACTIVE_SERIALS.View = System.Windows.Forms.View.Details;
            // 
            // ch_name
            // 
            this.ch_name.Text = "Product Name";
            this.ch_name.Width = 83;
            // 
            // ch_key
            // 
            this.ch_key.Text = "Key";
            this.ch_key.Width = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Temporary";
            // 
            // OPEN_BROWSER
            // 
            this.OPEN_BROWSER.Location = new System.Drawing.Point(16, 129);
            this.OPEN_BROWSER.Name = "OPEN_BROWSER";
            this.OPEN_BROWSER.Size = new System.Drawing.Size(75, 23);
            this.OPEN_BROWSER.TabIndex = 6;
            this.OPEN_BROWSER.Text = "GETIID.info";
            this.OPEN_BROWSER.UseVisualStyleBackColor = true;
            this.OPEN_BROWSER.Click += new System.EventHandler(this.OPEN_BROWSER_Click);
            // 
            // cid_text
            // 
            this.cid_text.Location = new System.Drawing.Point(12, 263);
            this.cid_text.Name = "cid_text";
            this.cid_text.Size = new System.Drawing.Size(480, 20);
            this.cid_text.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CID";
            // 
            // ACTIVATE_BUTTON
            // 
            this.ACTIVATE_BUTTON.Location = new System.Drawing.Point(40, 289);
            this.ACTIVATE_BUTTON.Name = "ACTIVATE_BUTTON";
            this.ACTIVATE_BUTTON.Size = new System.Drawing.Size(415, 53);
            this.ACTIVATE_BUTTON.TabIndex = 9;
            this.ACTIVATE_BUTTON.Text = "Activate";
            this.ACTIVATE_BUTTON.UseVisualStyleBackColor = true;
            this.ACTIVATE_BUTTON.Click += new System.EventHandler(this.ACTIVATE_BUTTON_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Office Keys Installed";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_strip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 350);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(887, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status_strip
            // 
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(42, 17);
            this.status_strip.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 372);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ACTIVATE_BUTTON);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cid_text);
            this.Controls.Add(this.OPEN_BROWSER);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IID_GET_BUTTON);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IID_GET";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IID_GET_BUTTON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView ACTIVE_SERIALS;
        private System.Windows.Forms.Button UNINSTALL_SELECTED_BUTTON;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OPEN_BROWSER;
        private System.Windows.Forms.TextBox cid_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ACTIVATE_BUTTON;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button REFRESH_BUTTON;
        private System.Windows.Forms.ColumnHeader ch_name;
        private System.Windows.Forms.ColumnHeader ch_key;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status_strip;
    }
}

