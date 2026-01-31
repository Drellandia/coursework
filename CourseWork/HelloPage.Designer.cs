namespace CourseWork
{
    partial class HelloPage
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
            this.helloPageLabel = new System.Windows.Forms.Label();
            this.helloPageRegisterBtn = new System.Windows.Forms.Button();
            this.helloPageLogInBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // helloPageLabel
            // 
            this.helloPageLabel.AutoSize = true;
            this.helloPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helloPageLabel.Location = new System.Drawing.Point(119, 62);
            this.helloPageLabel.Name = "helloPageLabel";
            this.helloPageLabel.Size = new System.Drawing.Size(567, 46);
            this.helloPageLabel.TabIndex = 0;
            this.helloPageLabel.Text = "I am glad to see you dear user!";
            this.helloPageLabel.Click += new System.EventHandler(this.helloPageLabel_Click);
            // 
            // helloPageRegisterBtn
            // 
            this.helloPageRegisterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helloPageRegisterBtn.Location = new System.Drawing.Point(188, 131);
            this.helloPageRegisterBtn.Name = "helloPageRegisterBtn";
            this.helloPageRegisterBtn.Size = new System.Drawing.Size(435, 120);
            this.helloPageRegisterBtn.TabIndex = 1;
            this.helloPageRegisterBtn.Text = "Register";
            this.helloPageRegisterBtn.UseVisualStyleBackColor = true;
            this.helloPageRegisterBtn.Click += new System.EventHandler(this.helloPageRegisterBtn_Click);
            // 
            // helloPageLogInBtn
            // 
            this.helloPageLogInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helloPageLogInBtn.Location = new System.Drawing.Point(188, 257);
            this.helloPageLogInBtn.Name = "helloPageLogInBtn";
            this.helloPageLogInBtn.Size = new System.Drawing.Size(435, 120);
            this.helloPageLogInBtn.TabIndex = 2;
            this.helloPageLogInBtn.Text = "Log In";
            this.helloPageLogInBtn.UseVisualStyleBackColor = true;
            this.helloPageLogInBtn.Click += new System.EventHandler(this.helloPageLogInBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(361, 408);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(95, 30);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // HelloPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.helloPageLogInBtn);
            this.Controls.Add(this.helloPageRegisterBtn);
            this.Controls.Add(this.helloPageLabel);
            this.Name = "HelloPage";
            this.Text = "HelloPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloPageLabel;
        private System.Windows.Forms.Button helloPageRegisterBtn;
        private System.Windows.Forms.Button helloPageLogInBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}