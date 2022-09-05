
namespace ZooMar
{
    partial class MarketForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.warehouseButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Магазин: ";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 307);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(260, 23);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // warehouseButton
            // 
            this.warehouseButton.Location = new System.Drawing.Point(12, 249);
            this.warehouseButton.Name = "warehouseButton";
            this.warehouseButton.Size = new System.Drawing.Size(260, 23);
            this.warehouseButton.TabIndex = 4;
            this.warehouseButton.Text = "Склад";
            this.warehouseButton.UseVisualStyleBackColor = true;
            this.warehouseButton.Click += new System.EventHandler(this.warehouseButton_Click);
            // 
            // usersButton
            // 
            this.usersButton.Location = new System.Drawing.Point(12, 278);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(260, 23);
            this.usersButton.TabIndex = 4;
            this.usersButton.Text = "Персонал";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Адрес: ";
            // 
            // MarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.usersButton);
            this.Controls.Add(this.warehouseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MarketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Магазин: ";
            this.Shown += new System.EventHandler(this.MarketForm_Shown);
            this.Move += new System.EventHandler(this.MarketForm_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button warehouseButton;
        private System.Windows.Forms.Button usersButton;
        private System.Windows.Forms.Label label2;
    }
}