namespace lab2
{
    partial class SearchForm
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
            this.BooksTable = new System.Windows.Forms.DataGridView();
            this.DGTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGUDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGUploadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearLabel = new System.Windows.Forms.Label();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.YearField = new System.Windows.Forms.NumericUpDown();
            this.PublisherField = new System.Windows.Forms.TextBox();
            this.ProgramLabel2 = new System.Windows.Forms.Label();
            this.ProgramTitle = new System.Windows.Forms.Label();
            this.PublisherCheckBox = new System.Windows.Forms.CheckBox();
            this.YearCheckBox = new System.Windows.Forms.CheckBox();
            this.RegCheckBox = new System.Windows.Forms.CheckBox();
            this.RegField = new System.Windows.Forms.TextBox();
            this.RegLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BooksTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearField)).BeginInit();
            this.SuspendLayout();
            // 
            // BooksTable
            // 
            this.BooksTable.AllowUserToAddRows = false;
            this.BooksTable.AllowUserToResizeColumns = false;
            this.BooksTable.AllowUserToResizeRows = false;
            this.BooksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BooksTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGTitle,
            this.DGType,
            this.DGFileSize,
            this.DGUDC,
            this.DGPages,
            this.DGPublisher,
            this.DGYear,
            this.DGUploadTime,
            this.DGAuthor});
            this.BooksTable.Location = new System.Drawing.Point(12, 12);
            this.BooksTable.Name = "BooksTable";
            this.BooksTable.RowHeadersVisible = false;
            this.BooksTable.RowHeadersWidth = 51;
            this.BooksTable.RowTemplate.Height = 29;
            this.BooksTable.Size = new System.Drawing.Size(1248, 705);
            this.BooksTable.TabIndex = 26;
            // 
            // DGTitle
            // 
            this.DGTitle.HeaderText = "Название";
            this.DGTitle.MinimumWidth = 6;
            this.DGTitle.Name = "DGTitle";
            this.DGTitle.ReadOnly = true;
            this.DGTitle.Width = 200;
            // 
            // DGType
            // 
            this.DGType.HeaderText = "Формат";
            this.DGType.MinimumWidth = 6;
            this.DGType.Name = "DGType";
            this.DGType.ReadOnly = true;
            this.DGType.Width = 75;
            // 
            // DGFileSize
            // 
            this.DGFileSize.HeaderText = "Размер файла";
            this.DGFileSize.MinimumWidth = 6;
            this.DGFileSize.Name = "DGFileSize";
            this.DGFileSize.ReadOnly = true;
            this.DGFileSize.Width = 75;
            // 
            // DGUDC
            // 
            this.DGUDC.HeaderText = "УДК";
            this.DGUDC.MinimumWidth = 6;
            this.DGUDC.Name = "DGUDC";
            this.DGUDC.ReadOnly = true;
            this.DGUDC.Width = 150;
            // 
            // DGPages
            // 
            this.DGPages.HeaderText = "Кол-во страниц";
            this.DGPages.MinimumWidth = 6;
            this.DGPages.Name = "DGPages";
            this.DGPages.ReadOnly = true;
            this.DGPages.Width = 75;
            // 
            // DGPublisher
            // 
            this.DGPublisher.HeaderText = "Издатель";
            this.DGPublisher.MinimumWidth = 6;
            this.DGPublisher.Name = "DGPublisher";
            this.DGPublisher.ReadOnly = true;
            this.DGPublisher.Width = 150;
            // 
            // DGYear
            // 
            this.DGYear.HeaderText = "Год";
            this.DGYear.MinimumWidth = 6;
            this.DGYear.Name = "DGYear";
            this.DGYear.ReadOnly = true;
            this.DGYear.Width = 75;
            // 
            // DGUploadTime
            // 
            this.DGUploadTime.HeaderText = "Время загрузки";
            this.DGUploadTime.MinimumWidth = 6;
            this.DGUploadTime.Name = "DGUploadTime";
            this.DGUploadTime.ReadOnly = true;
            this.DGUploadTime.Width = 175;
            // 
            // DGAuthor
            // 
            this.DGAuthor.HeaderText = "Автор";
            this.DGAuthor.MinimumWidth = 6;
            this.DGAuthor.Name = "DGAuthor";
            this.DGAuthor.ReadOnly = true;
            this.DGAuthor.Width = 250;
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(1305, 360);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(33, 20);
            this.YearLabel.TabIndex = 32;
            this.YearLabel.Text = "Год";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Location = new System.Drawing.Point(1305, 298);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(103, 20);
            this.PublisherLabel.TabIndex = 30;
            this.PublisherLabel.Text = "Издательство";
            // 
            // YearField
            // 
            this.YearField.Enabled = false;
            this.YearField.Location = new System.Drawing.Point(1305, 383);
            this.YearField.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.YearField.Minimum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.YearField.Name = "YearField";
            this.YearField.Size = new System.Drawing.Size(108, 27);
            this.YearField.TabIndex = 29;
            this.YearField.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.YearField.ValueChanged += new System.EventHandler(this.YearField_ValueChanged);
            // 
            // PublisherField
            // 
            this.PublisherField.Location = new System.Drawing.Point(1305, 321);
            this.PublisherField.Name = "PublisherField";
            this.PublisherField.Size = new System.Drawing.Size(318, 27);
            this.PublisherField.TabIndex = 28;
            this.PublisherField.TextChanged += new System.EventHandler(this.PublisherField_TextChanged);
            // 
            // ProgramLabel2
            // 
            this.ProgramLabel2.AutoSize = true;
            this.ProgramLabel2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProgramLabel2.Location = new System.Drawing.Point(1417, 52);
            this.ProgramLabel2.Name = "ProgramLabel2";
            this.ProgramLabel2.Size = new System.Drawing.Size(90, 38);
            this.ProgramLabel2.TabIndex = 34;
            this.ProgramLabel2.Text = "книги";
            // 
            // ProgramTitle
            // 
            this.ProgramTitle.AutoSize = true;
            this.ProgramTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProgramTitle.Location = new System.Drawing.Point(1305, 61);
            this.ProgramTitle.Name = "ProgramTitle";
            this.ProgramTitle.Size = new System.Drawing.Size(219, 81);
            this.ProgramTitle.TabIndex = 33;
            this.ProgramTitle.Text = "Поиск";
            // 
            // PublisherCheckBox
            // 
            this.PublisherCheckBox.AutoSize = true;
            this.PublisherCheckBox.Checked = true;
            this.PublisherCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PublisherCheckBox.Location = new System.Drawing.Point(1305, 170);
            this.PublisherCheckBox.Name = "PublisherCheckBox";
            this.PublisherCheckBox.Size = new System.Drawing.Size(143, 24);
            this.PublisherCheckBox.TabIndex = 35;
            this.PublisherCheckBox.Text = "по издательству";
            this.PublisherCheckBox.UseVisualStyleBackColor = true;
            this.PublisherCheckBox.Click += new System.EventHandler(this.PublisherCheckBox_Click);
            // 
            // YearCheckBox
            // 
            this.YearCheckBox.AutoSize = true;
            this.YearCheckBox.Location = new System.Drawing.Point(1305, 200);
            this.YearCheckBox.Name = "YearCheckBox";
            this.YearCheckBox.Size = new System.Drawing.Size(145, 24);
            this.YearCheckBox.TabIndex = 37;
            this.YearCheckBox.Text = "по году издания";
            this.YearCheckBox.UseVisualStyleBackColor = true;
            this.YearCheckBox.Click += new System.EventHandler(this.YearCheckBox_Click);
            // 
            // RegCheckBox
            // 
            this.RegCheckBox.AutoSize = true;
            this.RegCheckBox.Location = new System.Drawing.Point(1305, 230);
            this.RegCheckBox.Name = "RegCheckBox";
            this.RegCheckBox.Size = new System.Drawing.Size(294, 44);
            this.RegCheckBox.TabIndex = 38;
            this.RegCheckBox.Text = "по диапазону страниц\r\n(с помощью регулярных выражений)";
            this.RegCheckBox.UseVisualStyleBackColor = true;
            this.RegCheckBox.Click += new System.EventHandler(this.RegCheckBox_Click);
            // 
            // RegField
            // 
            this.RegField.Enabled = false;
            this.RegField.Location = new System.Drawing.Point(1449, 382);
            this.RegField.Name = "RegField";
            this.RegField.Size = new System.Drawing.Size(174, 27);
            this.RegField.TabIndex = 39;
            this.RegField.TextChanged += new System.EventHandler(this.RegField_TextChanged);
            // 
            // RegLabel
            // 
            this.RegLabel.AutoSize = true;
            this.RegLabel.Location = new System.Drawing.Point(1449, 359);
            this.RegLabel.Name = "RegLabel";
            this.RegLabel.Size = new System.Drawing.Size(139, 20);
            this.RegLabel.TabIndex = 40;
            this.RegLabel.Text = "Диапазон страниц";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1662, 729);
            this.Controls.Add(this.RegLabel);
            this.Controls.Add(this.RegField);
            this.Controls.Add(this.RegCheckBox);
            this.Controls.Add(this.YearCheckBox);
            this.Controls.Add(this.PublisherCheckBox);
            this.Controls.Add(this.ProgramLabel2);
            this.Controls.Add(this.ProgramTitle);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.YearField);
            this.Controls.Add(this.PublisherField);
            this.Controls.Add(this.BooksTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BooksTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView BooksTable;
        private DataGridViewTextBoxColumn DGTitle;
        private DataGridViewTextBoxColumn DGType;
        private DataGridViewTextBoxColumn DGFileSize;
        private DataGridViewTextBoxColumn DGUDC;
        private DataGridViewTextBoxColumn DGPages;
        private DataGridViewTextBoxColumn DGPublisher;
        private DataGridViewTextBoxColumn DGYear;
        private DataGridViewTextBoxColumn DGUploadTime;
        private DataGridViewTextBoxColumn DGAuthor;
        private Label YearLabel;
        private Label PublisherLabel;
        private NumericUpDown YearField;
        private TextBox PublisherField;
        private Label ProgramLabel2;
        private Label ProgramTitle;
        private CheckBox PublisherCheckBox;
        private CheckBox YearCheckBox;
        private CheckBox RegCheckBox;
        private TextBox RegField;
        private Label RegLabel;
    }
}