namespace ZooMar
{
    partial class ManagerForm
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
            if (_pref.Visible == false)
                _pref.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.marketButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Менеджер: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Магазин: ";
            // 
            // marketButton
            // 
            this.marketButton.Location = new System.Drawing.Point(12, 193);
            this.marketButton.Name = "marketButton";
            this.marketButton.Size = new System.Drawing.Size(260, 23);
            this.marketButton.TabIndex = 2;
            this.marketButton.Text = "Магазин";
            this.marketButton.UseVisualStyleBackColor = true;
            this.marketButton.Click += new System.EventHandler(this.marketButton_Click);
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(12, 222);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(260, 23);
            this.profileButton.TabIndex = 3;
            this.profileButton.Text = "Профиль";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 251);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(260, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.marketButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "[Имя пользователя]";
            this.Shown += new System.EventHandler(this.ManagerForm_Shown);
            this.Move += new System.EventHandler(this.ManagerForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button marketButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button exitButton;
    }
}