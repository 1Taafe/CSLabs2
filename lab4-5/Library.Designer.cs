namespace lab2
{
    partial class Library
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgramTitle = new System.Windows.Forms.Label();
            this.FormatPicker = new System.Windows.Forms.ComboBox();
            this.SizeField = new System.Windows.Forms.TextBox();
            this.UDCField = new System.Windows.Forms.TextBox();
            this.PagesField = new System.Windows.Forms.NumericUpDown();
            this.PublisherField = new System.Windows.Forms.TextBox();
            this.YearField = new System.Windows.Forms.NumericUpDown();
            this.UploadTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AuthorField = new System.Windows.Forms.ComboBox();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.UDCLabel = new System.Windows.Forms.Label();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.PagesLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.UploadTimeLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.AddAuthorButton = new System.Windows.Forms.Button();
            this.AddBookButton = new System.Windows.Forms.Button();
            this.SizeFormatField = new System.Windows.Forms.ComboBox();
            this.ProgramLabel2 = new System.Windows.Forms.Label();
            this.TitleField = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
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
            this.ExportButton = new System.Windows.Forms.Button();
            this.LibLabel = new System.Windows.Forms.Label();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CountryField = new System.Windows.Forms.TextBox();
            this.NameField = new System.Windows.Forms.TextBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.CloneButton = new System.Windows.Forms.Button();
            this.BuilderButton = new System.Windows.Forms.Button();
            this.BackwardButton = new System.Windows.Forms.Button();
            this.ForewardButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PagesField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgramTitle
            // 
            this.ProgramTitle.AutoSize = true;
            this.ProgramTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProgramTitle.Location = new System.Drawing.Point(34, 19);
            this.ProgramTitle.Name = "ProgramTitle";
            this.ProgramTitle.Size = new System.Drawing.Size(126, 50);
            this.ProgramTitle.TabIndex = 0;
            this.ProgramTitle.Text = "Книга";
            // 
            // FormatPicker
            // 
            this.FormatPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatPicker.FormattingEnabled = true;
            this.FormatPicker.Items.AddRange(new object[] {
            "pdf",
            "epub"});
            this.FormatPicker.Location = new System.Drawing.Point(34, 170);
            this.FormatPicker.Name = "FormatPicker";
            this.FormatPicker.Size = new System.Drawing.Size(318, 28);
            this.FormatPicker.TabIndex = 1;
            // 
            // SizeField
            // 
            this.SizeField.Location = new System.Drawing.Point(34, 233);
            this.SizeField.Name = "SizeField";
            this.SizeField.Size = new System.Drawing.Size(220, 27);
            this.SizeField.TabIndex = 2;
            // 
            // UDCField
            // 
            this.UDCField.Location = new System.Drawing.Point(34, 296);
            this.UDCField.Name = "UDCField";
            this.UDCField.Size = new System.Drawing.Size(318, 27);
            this.UDCField.TabIndex = 3;
            // 
            // PagesField
            // 
            this.PagesField.Location = new System.Drawing.Point(34, 428);
            this.PagesField.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PagesField.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.PagesField.Name = "PagesField";
            this.PagesField.Size = new System.Drawing.Size(108, 27);
            this.PagesField.TabIndex = 4;
            this.PagesField.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // PublisherField
            // 
            this.PublisherField.Location = new System.Drawing.Point(34, 358);
            this.PublisherField.Name = "PublisherField";
            this.PublisherField.Size = new System.Drawing.Size(318, 27);
            this.PublisherField.TabIndex = 5;
            // 
            // YearField
            // 
            this.YearField.Location = new System.Drawing.Point(179, 428);
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
            this.YearField.TabIndex = 6;
            this.YearField.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            // 
            // UploadTimePicker
            // 
            this.UploadTimePicker.Location = new System.Drawing.Point(34, 496);
            this.UploadTimePicker.Name = "UploadTimePicker";
            this.UploadTimePicker.Size = new System.Drawing.Size(318, 27);
            this.UploadTimePicker.TabIndex = 8;
            // 
            // AuthorField
            // 
            this.AuthorField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthorField.FormattingEnabled = true;
            this.AuthorField.Location = new System.Drawing.Point(34, 844);
            this.AuthorField.Name = "AuthorField";
            this.AuthorField.Size = new System.Drawing.Size(318, 28);
            this.AuthorField.TabIndex = 9;
            this.AuthorField.Visible = false;
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Location = new System.Drawing.Point(34, 147);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(110, 20);
            this.FormatLabel.TabIndex = 10;
            this.FormatLabel.Text = "Формат файла";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(34, 210);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(107, 20);
            this.SizeLabel.TabIndex = 11;
            this.SizeLabel.Text = "Размер файла";
            // 
            // UDCLabel
            // 
            this.UDCLabel.AutoSize = true;
            this.UDCLabel.Location = new System.Drawing.Point(34, 273);
            this.UDCLabel.Name = "UDCLabel";
            this.UDCLabel.Size = new System.Drawing.Size(37, 20);
            this.UDCLabel.TabIndex = 12;
            this.UDCLabel.Text = "УДК";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Location = new System.Drawing.Point(34, 335);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(103, 20);
            this.PublisherLabel.TabIndex = 13;
            this.PublisherLabel.Text = "Издательство";
            // 
            // PagesLabel
            // 
            this.PagesLabel.AutoSize = true;
            this.PagesLabel.Location = new System.Drawing.Point(34, 405);
            this.PagesLabel.Name = "PagesLabel";
            this.PagesLabel.Size = new System.Drawing.Size(119, 20);
            this.PagesLabel.TabIndex = 14;
            this.PagesLabel.Text = "Кол-во страниц";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(179, 405);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(33, 20);
            this.YearLabel.TabIndex = 15;
            this.YearLabel.Text = "Год";
            // 
            // UploadTimeLabel
            // 
            this.UploadTimeLabel.AutoSize = true;
            this.UploadTimeLabel.Location = new System.Drawing.Point(34, 473);
            this.UploadTimeLabel.Name = "UploadTimeLabel";
            this.UploadTimeLabel.Size = new System.Drawing.Size(105, 20);
            this.UploadTimeLabel.TabIndex = 17;
            this.UploadTimeLabel.Text = "Дата загрузки";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(34, 821);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(95, 20);
            this.AuthorLabel.TabIndex = 18;
            this.AuthorLabel.Text = "Автор книги";
            this.AuthorLabel.Visible = false;
            // 
            // AddAuthorButton
            // 
            this.AddAuthorButton.Location = new System.Drawing.Point(219, 811);
            this.AddAuthorButton.Name = "AddAuthorButton";
            this.AddAuthorButton.Size = new System.Drawing.Size(133, 30);
            this.AddAuthorButton.TabIndex = 19;
            this.AddAuthorButton.Text = "Добавить";
            this.AddAuthorButton.UseVisualStyleBackColor = true;
            this.AddAuthorButton.Visible = false;
            // 
            // AddBookButton
            // 
            this.AddBookButton.Location = new System.Drawing.Point(87, 675);
            this.AddBookButton.Name = "AddBookButton";
            this.AddBookButton.Size = new System.Drawing.Size(212, 47);
            this.AddBookButton.TabIndex = 20;
            this.AddBookButton.Text = "Загрузить книгу";
            this.AddBookButton.UseVisualStyleBackColor = true;
            this.AddBookButton.Click += new System.EventHandler(this.AddBookButton_Click);
            // 
            // SizeFormatField
            // 
            this.SizeFormatField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SizeFormatField.FormattingEnabled = true;
            this.SizeFormatField.Items.AddRange(new object[] {
            "MB",
            "KB"});
            this.SizeFormatField.Location = new System.Drawing.Point(260, 233);
            this.SizeFormatField.Name = "SizeFormatField";
            this.SizeFormatField.Size = new System.Drawing.Size(92, 28);
            this.SizeFormatField.TabIndex = 21;
            // 
            // ProgramLabel2
            // 
            this.ProgramLabel2.AutoSize = true;
            this.ProgramLabel2.Location = new System.Drawing.Point(65, 19);
            this.ProgramLabel2.Name = "ProgramLabel2";
            this.ProgramLabel2.Size = new System.Drawing.Size(51, 20);
            this.ProgramLabel2.TabIndex = 22;
            this.ProgramLabel2.Text = "новая";
            // 
            // TitleField
            // 
            this.TitleField.Location = new System.Drawing.Point(34, 107);
            this.TitleField.Name = "TitleField";
            this.TitleField.Size = new System.Drawing.Size(318, 27);
            this.TitleField.TabIndex = 23;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(34, 84);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(121, 20);
            this.TitleLabel.TabIndex = 24;
            this.TitleLabel.Text = "Название книги";
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
            this.BooksTable.Location = new System.Drawing.Point(389, 107);
            this.BooksTable.Name = "BooksTable";
            this.BooksTable.RowHeadersVisible = false;
            this.BooksTable.RowHeadersWidth = 51;
            this.BooksTable.RowTemplate.Height = 29;
            this.BooksTable.Size = new System.Drawing.Size(1250, 654);
            this.BooksTable.TabIndex = 25;
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
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(118, 728);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(157, 29);
            this.ExportButton.TabIndex = 26;
            this.ExportButton.Text = "Извлечь";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // LibLabel
            // 
            this.LibLabel.AutoSize = true;
            this.LibLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LibLabel.Location = new System.Drawing.Point(389, 19);
            this.LibLabel.Name = "LibLabel";
            this.LibLabel.Size = new System.Drawing.Size(260, 54);
            this.LibLabel.TabIndex = 27;
            this.LibLabel.Text = "Список книг";
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Location = new System.Drawing.Point(87, 604);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(58, 20);
            this.CountryLabel.TabIndex = 31;
            this.CountryLabel.Text = "Страна";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(87, 542);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(91, 20);
            this.NameLabel.TabIndex = 30;
            this.NameLabel.Text = "Имя автора";
            // 
            // CountryField
            // 
            this.CountryField.Location = new System.Drawing.Point(87, 627);
            this.CountryField.Name = "CountryField";
            this.CountryField.Size = new System.Drawing.Size(221, 27);
            this.CountryField.TabIndex = 29;
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(87, 565);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(221, 27);
            this.NameField.TabIndex = 28;
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(1500, 50);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(139, 29);
            this.AboutButton.TabIndex = 32;
            this.AboutButton.Text = "О приложении";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // CloneButton
            // 
            this.CloneButton.Location = new System.Drawing.Point(1448, 15);
            this.CloneButton.Name = "CloneButton";
            this.CloneButton.Size = new System.Drawing.Size(191, 29);
            this.CloneButton.TabIndex = 33;
            this.CloneButton.Text = "Клон последней книги";
            this.CloneButton.UseVisualStyleBackColor = true;
            this.CloneButton.Click += new System.EventHandler(this.CloneButton_Click);
            // 
            // BuilderButton
            // 
            this.BuilderButton.Location = new System.Drawing.Point(1223, 24);
            this.BuilderButton.Name = "BuilderButton";
            this.BuilderButton.Size = new System.Drawing.Size(204, 50);
            this.BuilderButton.TabIndex = 34;
            this.BuilderButton.Text = "Набор из двух последних\r\nкниг (Builder)";
            this.BuilderButton.UseVisualStyleBackColor = true;
            this.BuilderButton.Click += new System.EventHandler(this.BuilderButton_Click);
            // 
            // BackwardButton
            // 
            this.BackwardButton.Location = new System.Drawing.Point(389, 75);
            this.BackwardButton.Name = "BackwardButton";
            this.BackwardButton.Size = new System.Drawing.Size(94, 29);
            this.BackwardButton.TabIndex = 35;
            this.BackwardButton.Text = "Назад";
            this.BackwardButton.UseVisualStyleBackColor = true;
            this.BackwardButton.Click += new System.EventHandler(this.BackwardButton_Click);
            // 
            // ForewardButton
            // 
            this.ForewardButton.Location = new System.Drawing.Point(489, 75);
            this.ForewardButton.Name = "ForewardButton";
            this.ForewardButton.Size = new System.Drawing.Size(94, 29);
            this.ForewardButton.TabIndex = 36;
            this.ForewardButton.Text = "Вперед";
            this.ForewardButton.UseVisualStyleBackColor = true;
            this.ForewardButton.Click += new System.EventHandler(this.ForewardButton_Click);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 799);
            this.Controls.Add(this.ForewardButton);
            this.Controls.Add(this.BackwardButton);
            this.Controls.Add(this.BuilderButton);
            this.Controls.Add(this.CloneButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.CountryLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.CountryField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.LibLabel);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.BooksTable);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleField);
            this.Controls.Add(this.ProgramLabel2);
            this.Controls.Add(this.SizeFormatField);
            this.Controls.Add(this.AddBookButton);
            this.Controls.Add(this.AddAuthorButton);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.UploadTimeLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.PagesLabel);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.UDCLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.AuthorField);
            this.Controls.Add(this.UploadTimePicker);
            this.Controls.Add(this.YearField);
            this.Controls.Add(this.PublisherField);
            this.Controls.Add(this.PagesField);
            this.Controls.Add(this.UDCField);
            this.Controls.Add(this.SizeField);
            this.Controls.Add(this.FormatPicker);
            this.Controls.Add(this.ProgramTitle);
            this.Name = "Library";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E Library";
            this.Load += new System.EventHandler(this.Library_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PagesField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ProgramTitle;
        private ComboBox FormatPicker;
        private TextBox SizeField;
        private TextBox UDCField;
        private NumericUpDown PagesField;
        private TextBox PublisherField;
        private NumericUpDown YearField;
        private DateTimePicker UploadTimePicker;
        private ComboBox AuthorField;
        private Label FormatLabel;
        private Label SizeLabel;
        private Label UDCLabel;
        private Label PublisherLabel;
        private Label PagesLabel;
        private Label YearLabel;
        private Label UploadTimeLabel;
        private Label AuthorLabel;
        private Button AddAuthorButton;
        private Button AddBookButton;
        private ComboBox SizeFormatField;
        private Label ProgramLabel2;
        private TextBox TitleField;
        private Label TitleLabel;
        private DataGridView BooksTable;
        private Button ExportButton;
        private Label LibLabel;
        private DataGridViewTextBoxColumn DGTitle;
        private DataGridViewTextBoxColumn DGType;
        private DataGridViewTextBoxColumn DGFileSize;
        private DataGridViewTextBoxColumn DGUDC;
        private DataGridViewTextBoxColumn DGPages;
        private DataGridViewTextBoxColumn DGPublisher;
        private DataGridViewTextBoxColumn DGYear;
        private DataGridViewTextBoxColumn DGUploadTime;
        private DataGridViewTextBoxColumn DGAuthor;
        private Label CountryLabel;
        private Label NameLabel;
        private TextBox CountryField;
        private TextBox NameField;
        private Button AboutButton;
        private Button CloneButton;
        private Button BuilderButton;
        private Button BackwardButton;
        private Button ForewardButton;
    }
}