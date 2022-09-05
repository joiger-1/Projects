namespace ZooMar
{
    partial class MarketListForm
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
            this.marketGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.editProductButton = new System.Windows.Forms.Button();
            this.openMarketButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.marketGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // marketGridView
            // 
            this.marketGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marketGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.marketGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.marketGridView.Location = new System.Drawing.Point(12, 12);
            this.marketGridView.MultiSelect = false;
            this.marketGridView.Name = "marketGridView";
            this.marketGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.marketGridView.Size = new System.Drawing.Size(401, 275);
            this.marketGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Адрес";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(401, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Назад";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(12, 328);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(401, 23);
            this.addProductButton.TabIndex = 0;
            this.addProductButton.Text = "Добавить";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.Location = new System.Drawing.Point(12, 386);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(401, 23);
            this.deleteProductButton.TabIndex = 2;
            this.deleteProductButton.Text = "Удалить";
            this.deleteProductButton.UseVisualStyleBackColor = true;
            this.deleteProductButton.Click += new System.EventHandler(this.deleteProductButton_Click);
            // 
            // editProductButton
            // 
            this.editProductButton.Location = new System.Drawing.Point(12, 357);
            this.editProductButton.Name = "editProductButton";
            this.editProductButton.Size = new System.Drawing.Size(401, 23);
            this.editProductButton.TabIndex = 1;
            this.editProductButton.Text = "Изменить";
            this.editProductButton.UseVisualStyleBackColor = true;
            this.editProductButton.Click += new System.EventHandler(this.editProductButton_Click);
            // 
            // openMarketButton
            // 
            this.openMarketButton.Location = new System.Drawing.Point(12, 299);
            this.openMarketButton.Name = "openMarketButton";
            this.openMarketButton.Size = new System.Drawing.Size(401, 23);
            this.openMarketButton.TabIndex = 0;
            this.openMarketButton.Text = "Открыть";
            this.openMarketButton.UseVisualStyleBackColor = true;
            this.openMarketButton.Click += new System.EventHandler(this.openMarketButton_Click);
            // 
            // MarketListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.editProductButton);
            this.Controls.Add(this.deleteProductButton);
            this.Controls.Add(this.openMarketButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.marketGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MarketListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Список магазинов";
            this.Load += new System.EventHandler(this.MarketListForm_Load);
            this.Shown += new System.EventHandler(this.MarketListForm_Shown);
            this.Move += new System.EventHandler(this.MarketListForm_Move);
            ((System.ComponentModel.ISupportInitialize)(this.marketGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView marketGridView;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Button editProductButton;
        private System.Windows.Forms.Button openMarketButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}