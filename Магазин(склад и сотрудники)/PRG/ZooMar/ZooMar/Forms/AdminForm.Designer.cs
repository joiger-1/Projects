namespace ZooMar
{
    partial class AdminForm
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
            this.marketListButton = new System.Windows.Forms.Button();
            this.usersListButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Администратор: ";
            // 
            // marketListButton
            // 
            this.marketListButton.Location = new System.Drawing.Point(12, 194);
            this.marketListButton.Name = "marketListButton";
            this.marketListButton.Size = new System.Drawing.Size(260, 23);
            this.marketListButton.TabIndex = 1;
            this.marketListButton.Text = "Список магазинов";
            this.marketListButton.UseVisualStyleBackColor = true;
            this.marketListButton.Click += new System.EventHandler(this.marketListButton_Click);
            // 
            // usersListButton
            // 
            this.usersListButton.Location = new System.Drawing.Point(12, 224);
            this.usersListButton.Name = "usersListButton";
            this.usersListButton.Size = new System.Drawing.Size(260, 23);
            this.usersListButton.TabIndex = 2;
            this.usersListButton.Text = "Список сотрудников";
            this.usersListButton.UseVisualStyleBackColor = true;
            this.usersListButton.Click += new System.EventHandler(this.usersListButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 254);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(260, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.usersListButton);
            this.Controls.Add(this.marketListButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "[Имя пользователя]";
            this.Shown += new System.EventHandler(this.AdminForm_Shown);
            this.Move += new System.EventHandler(this.AdminForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button marketListButton;
        private System.Windows.Forms.Button usersListButton;
        private System.Windows.Forms.Button ExitButton;
    }
}