
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.url_textbox = new System.Windows.Forms.TextBox();
            this.URL_Label = new System.Windows.Forms.Label();
            this.Save_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.url_textbox);
            this.groupBox1.Controls.Add(this.URL_Label);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 137);
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
            this.url_textbox.Size = new System.Drawing.Size(262, 20);
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
            this.Save_Button.Location = new System.Drawing.Point(12, 276);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(275, 34);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Options_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 322);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.groupBox1);
            this.Name = "Options_Form";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox url_textbox;
        private System.Windows.Forms.Label URL_Label;
        private System.Windows.Forms.Button Save_Button;
    }
}