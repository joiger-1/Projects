namespace ZooMar
{
    partial class SellerForm
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
            this.warehouseButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // warehouseButton
            // 
            this.warehouseButton.Location = new System.Drawing.Point(12, 249);
            this.warehouseButton.Name = "warehouseButton";
            this.warehouseButton.Size = new System.Drawing.Size(260, 23);
            this.warehouseButton.TabIndex = 0;
            this.warehouseButton.Text = "Склад";
            this.warehouseButton.UseVisualStyleBackColor = true;
            this.warehouseButton.Click += new System.EventHandler(this.warehouseButton_Click);
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(12, 278);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(260, 23);
            this.profileButton.TabIndex = 2;
            this.profileButton.Text = "Профиль";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 307);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(260, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Продавец: ";
            // 
            // SellerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.warehouseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SellerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "[Имя пользователя]";
            this.Shown += new System.EventHandler(this.SellerForm_Shown);
            this.Move += new System.EventHandler(this.SellerForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button warehouseButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
    }
}