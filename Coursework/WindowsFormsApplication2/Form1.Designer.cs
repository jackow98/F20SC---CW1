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
            this.HTTPStreamLabel = new System.Windows.Forms.Label();
            this.HTTPStreamContent = new System.Windows.Forms.Label();
            this.URLContent = new System.Windows.Forms.TextBox();
            this.URLLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RequestButton
            // 
            this.RequestButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RequestButton.Location = new System.Drawing.Point(78, 201);
            this.RequestButton.Name = "RequestButton";
            this.RequestButton.Size = new System.Drawing.Size(181, 82);
            this.RequestButton.TabIndex = 0;
            this.RequestButton.Text = "Make HTTP Request";
            this.RequestButton.UseVisualStyleBackColor = true;
            this.RequestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // HTTPResponseStatus
            // 
            this.HTTPResponseStatus.AutoSize = true;
            this.HTTPResponseStatus.Location = new System.Drawing.Point(182, 89);
            this.HTTPResponseStatus.Name = "HTTPResponseStatus";
            this.HTTPResponseStatus.Size = new System.Drawing.Size(16, 13);
            this.HTTPResponseStatus.TabIndex = 1;
            this.HTTPResponseStatus.Text = "...";
            // 
            // HTTPResponseLabel
            // 
            this.HTTPResponseLabel.AutoSize = true;
            this.HTTPResponseLabel.Location = new System.Drawing.Point(75, 89);
            this.HTTPResponseLabel.Name = "HTTPResponseLabel";
            this.HTTPResponseLabel.Size = new System.Drawing.Size(87, 13);
            this.HTTPResponseLabel.TabIndex = 2;
            this.HTTPResponseLabel.Text = "HTTP Response";
            this.HTTPResponseLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // HTTPStreamLabel
            // 
            this.HTTPStreamLabel.AutoSize = true;
            this.HTTPStreamLabel.Location = new System.Drawing.Point(78, 131);
            this.HTTPStreamLabel.Name = "HTTPStreamLabel";
            this.HTTPStreamLabel.Size = new System.Drawing.Size(40, 13);
            this.HTTPStreamLabel.TabIndex = 3;
            this.HTTPStreamLabel.Text = "Stream";
            // 
            // HTTPStreamContent
            // 
            this.HTTPStreamContent.AutoSize = true;
            this.HTTPStreamContent.Location = new System.Drawing.Point(182, 131);
            this.HTTPStreamContent.Name = "HTTPStreamContent";
            this.HTTPStreamContent.Size = new System.Drawing.Size(16, 13);
            this.HTTPStreamContent.TabIndex = 4;
            this.HTTPStreamContent.Text = "...";
            this.HTTPStreamContent.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // URLContent
            // 
            this.URLContent.Location = new System.Drawing.Point(137, 49);
            this.URLContent.Name = "URLContent";
            this.URLContent.Size = new System.Drawing.Size(122, 20);
            this.URLContent.TabIndex = 5;
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.Location = new System.Drawing.Point(78, 55);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(29, 13);
            this.URLLabel.TabIndex = 6;
            this.URLLabel.Text = "URL";
            this.URLLabel.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 340);
            this.Controls.Add(this.URLLabel);
            this.Controls.Add(this.URLContent);
            this.Controls.Add(this.HTTPStreamContent);
            this.Controls.Add(this.HTTPStreamLabel);
            this.Controls.Add(this.HTTPResponseLabel);
            this.Controls.Add(this.HTTPResponseStatus);
            this.Controls.Add(this.RequestButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RequestButton;
        private System.Windows.Forms.Label HTTPResponseStatus;
        private System.Windows.Forms.Label HTTPResponseLabel;
        private System.Windows.Forms.Label HTTPStreamLabel;
        private System.Windows.Forms.Label HTTPStreamContent;
        private System.Windows.Forms.TextBox URLContent;
        private System.Windows.Forms.Label URLLabel;
    }
}

