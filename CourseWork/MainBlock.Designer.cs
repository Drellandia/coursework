namespace CourseWork
{
    partial class MainBlock
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
            this.bookEnterBtn = new System.Windows.Forms.Button();
            this.extraditionEnterBtn = new System.Windows.Forms.Button();
            this.customerEnterBtn = new System.Windows.Forms.Button();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.customerReturningBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookEnterBtn
            // 
            this.bookEnterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookEnterBtn.Location = new System.Drawing.Point(333, 30);
            this.bookEnterBtn.Name = "bookEnterBtn";
            this.bookEnterBtn.Size = new System.Drawing.Size(150, 65);
            this.bookEnterBtn.TabIndex = 0;
            this.bookEnterBtn.Text = "Book";
            this.bookEnterBtn.UseVisualStyleBackColor = true;
            this.bookEnterBtn.Click += new System.EventHandler(this.bookEnterBtn_Click);
            // 
            // extraditionEnterBtn
            // 
            this.extraditionEnterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.extraditionEnterBtn.Location = new System.Drawing.Point(333, 114);
            this.extraditionEnterBtn.Name = "extraditionEnterBtn";
            this.extraditionEnterBtn.Size = new System.Drawing.Size(150, 65);
            this.extraditionEnterBtn.TabIndex = 1;
            this.extraditionEnterBtn.Text = "Extradition";
            this.extraditionEnterBtn.UseVisualStyleBackColor = true;
            this.extraditionEnterBtn.Click += new System.EventHandler(this.extraditionEnterBtn_Click);
            // 
            // customerEnterBtn
            // 
            this.customerEnterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerEnterBtn.Location = new System.Drawing.Point(333, 201);
            this.customerEnterBtn.Name = "customerEnterBtn";
            this.customerEnterBtn.Size = new System.Drawing.Size(150, 67);
            this.customerEnterBtn.TabIndex = 2;
            this.customerEnterBtn.Text = "Customer";
            this.customerEnterBtn.UseVisualStyleBackColor = true;
            this.customerEnterBtn.Click += new System.EventHandler(this.customerEnterBtn_Click);
            // 
            // logOutBtn
            // 
            this.logOutBtn.Location = new System.Drawing.Point(718, 408);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(70, 30);
            this.logOutBtn.TabIndex = 3;
            this.logOutBtn.Text = "Log out";
            this.logOutBtn.UseVisualStyleBackColor = true;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(12, 408);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(70, 30);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // customerReturningBtn
            // 
            this.customerReturningBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerReturningBtn.Location = new System.Drawing.Point(333, 284);
            this.customerReturningBtn.Name = "customerReturningBtn";
            this.customerReturningBtn.Size = new System.Drawing.Size(150, 72);
            this.customerReturningBtn.TabIndex = 5;
            this.customerReturningBtn.Text = "Customer return";
            this.customerReturningBtn.UseVisualStyleBackColor = true;
            this.customerReturningBtn.Click += new System.EventHandler(this.customerReturningBtn_Click);
            // 
            // MainBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customerReturningBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.logOutBtn);
            this.Controls.Add(this.customerEnterBtn);
            this.Controls.Add(this.extraditionEnterBtn);
            this.Controls.Add(this.bookEnterBtn);
            this.Name = "MainBlock";
            this.Text = "MainBlock";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bookEnterBtn;
        private System.Windows.Forms.Button extraditionEnterBtn;
        private System.Windows.Forms.Button customerEnterBtn;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button customerReturningBtn;
    }
}