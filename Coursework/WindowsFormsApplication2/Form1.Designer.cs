namespace Coursewok
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
            this.RequestButton = new System.Windows.Forms.Button();
            this.HTTPResponseStatus = new System.Windows.Forms.Label();
            this.HTTPResponseLabel = new System.Windows.Forms.Label();
            this.URLContent = new System.Windows.Forms.TextBox();
            this.HTTPStreamLabel = new System.Windows.Forms.Label();
            this.HTTPStreamContent = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RequestButton
            // 
            this.RequestButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RequestButton.Location = new System.Drawing.Point(196, 575);
            this.RequestButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RequestButton.Name = "RequestButton";
            this.RequestButton.Size = new System.Drawing.Size(390, 126);
            this.RequestButton.TabIndex = 0;
            this.RequestButton.Text = "Make HTTP Request";
            this.RequestButton.UseVisualStyleBackColor = true;
            this.RequestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // HTTPResponseStatus
            // 
            this.HTTPResponseStatus.AutoSize = true;
            this.HTTPResponseStatus.Location = new System.Drawing.Point(243, 138);
            this.HTTPResponseStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.HTTPResponseStatus.Name = "HTTPResponseStatus";
            this.HTTPResponseStatus.Size = new System.Drawing.Size(18, 20);
            this.HTTPResponseStatus.TabIndex = 1;
            this.HTTPResponseStatus.Text = "...";
            // 
            // HTTPResponseLabel
            // 
            this.HTTPResponseLabel.AutoSize = true;
            this.HTTPResponseLabel.Location = new System.Drawing.Point(101, 138);
            this.HTTPResponseLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.HTTPResponseLabel.Name = "HTTPResponseLabel";
            this.HTTPResponseLabel.Size = new System.Drawing.Size(111, 20);
            this.HTTPResponseLabel.TabIndex = 2;
            this.HTTPResponseLabel.Text = "HTTP Response";
            // 
            // URLContent
            // 
            this.URLContent.Location = new System.Drawing.Point(171, 49);
            this.URLContent.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.URLContent.Name = "URLContent";
            this.URLContent.Size = new System.Drawing.Size(415, 27);
            this.URLContent.TabIndex = 5;
            this.URLContent.Text = "Enter URL";
            // 
            // HTTPStreamLabel
            // 
            this.HTTPStreamLabel.AutoSize = true;
            this.HTTPStreamLabel.Location = new System.Drawing.Point(101, 254);
            this.HTTPStreamLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.HTTPStreamLabel.Name = "HTTPStreamLabel";
            this.HTTPStreamLabel.Size = new System.Drawing.Size(56, 20);
            this.HTTPStreamLabel.TabIndex = 3;
            this.HTTPStreamLabel.Text = "Stream";
            // 
            // HTTPStreamContent
            // 
            this.HTTPStreamContent.Location = new System.Drawing.Point(101, 279);
            this.HTTPStreamContent.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.HTTPStreamContent.Name = "HTTPStreamContent";
            this.HTTPStreamContent.Size = new System.Drawing.Size(571, 270);
            this.HTTPStreamContent.TabIndex = 6;
            this.HTTPStreamContent.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 61);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 715);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HTTPStreamContent);
            this.Controls.Add(this.URLContent);
            this.Controls.Add(this.HTTPStreamLabel);
            this.Controls.Add(this.HTTPResponseLabel);
            this.Controls.Add(this.HTTPResponseStatus);
            this.Controls.Add(this.RequestButton);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button RequestButton;
        private System.Windows.Forms.Label HTTPResponseStatus;
        private System.Windows.Forms.Label HTTPResponseLabel;
        private System.Windows.Forms.TextBox URLContent;
        private System.Windows.Forms.Label HTTPStreamLabel;
        private System.Windows.Forms.RichTextBox HTTPStreamContent;
        private System.Windows.Forms.Button button1;
    }
}

