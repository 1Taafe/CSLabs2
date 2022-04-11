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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.UndoButton = new System.Windows.Forms.ToolStripButton();
            this.RedoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchFormButton = new System.Windows.Forms.ToolStripButton();
            this.SortTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.SortByName = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByTime = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutTool = new System.Windows.Forms.ToolStripButton();
            this.HideToolsButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BooksInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BooksLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastActionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastActionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PagesField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksTable)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramTitle
            // 
            this.ProgramTitle.AutoSize = true;
            this.ProgramTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProgramTitle.Location = new System.Drawing.Point(29, 36);
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
            "djvu",
            "txt",
            "doc",
            "epub",
            "fb2"});
            this.FormatPicker.Location = new System.Drawing.Point(29, 187);
            this.FormatPicker.Name = "FormatPicker";
            this.FormatPicker.Size = new System.Drawing.Size(318, 28);
            this.FormatPicker.TabIndex = 1;
            // 
            // SizeField
            // 
            this.SizeField.Location = new System.Drawing.Point(29, 250);
            this.SizeField.Name = "SizeField";
            this.SizeField.Size = new System.Drawing.Size(220, 27);
            this.SizeField.TabIndex = 2;
            this.SizeField.TextChanged += new System.EventHandler(this.SizeField_TextChanged);
            // 
            // UDCField
            // 
            this.UDCField.Location = new System.Drawing.Point(29, 313);
            this.UDCField.Name = "UDCField";
            this.UDCField.Size = new System.Drawing.Size(318, 27);
            this.UDCField.TabIndex = 3;
            this.UDCField.TextChanged += new System.EventHandler(this.UDCField_TextChanged);
            // 
            // PagesField
            // 
            this.PagesField.Location = new System.Drawing.Point(29, 445);
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
            this.PublisherField.Location = new System.Drawing.Point(29, 375);
            this.PublisherField.Name = "PublisherField";
            this.PublisherField.Size = new System.Drawing.Size(318, 27);
            this.PublisherField.TabIndex = 5;
            this.PublisherField.TextChanged += new System.EventHandler(this.PublisherField_TextChanged);
            // 
            // YearField
            // 
            this.YearField.Location = new System.Drawing.Point(174, 445);
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
            this.UploadTimePicker.Location = new System.Drawing.Point(29, 520);
            this.UploadTimePicker.Name = "UploadTimePicker";
            this.UploadTimePicker.Size = new System.Drawing.Size(318, 27);
            this.UploadTimePicker.TabIndex = 8;
            // 
            // AuthorField
            // 
            this.AuthorField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthorField.FormattingEnabled = true;
            this.AuthorField.Location = new System.Drawing.Point(29, 603);
            this.AuthorField.Name = "AuthorField";
            this.AuthorField.Size = new System.Drawing.Size(318, 28);
            this.AuthorField.TabIndex = 9;
            this.AuthorField.Click += new System.EventHandler(this.AuthorField_Click);
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Location = new System.Drawing.Point(29, 164);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(110, 20);
            this.FormatLabel.TabIndex = 10;
            this.FormatLabel.Text = "Формат файла";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(29, 227);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(107, 20);
            this.SizeLabel.TabIndex = 11;
            this.SizeLabel.Text = "Размер файла";
            // 
            // UDCLabel
            // 
            this.UDCLabel.AutoSize = true;
            this.UDCLabel.Location = new System.Drawing.Point(29, 290);
            this.UDCLabel.Name = "UDCLabel";
            this.UDCLabel.Size = new System.Drawing.Size(37, 20);
            this.UDCLabel.TabIndex = 12;
            this.UDCLabel.Text = "УДК";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Location = new System.Drawing.Point(29, 352);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(103, 20);
            this.PublisherLabel.TabIndex = 13;
            this.PublisherLabel.Text = "Издательство";
            // 
            // PagesLabel
            // 
            this.PagesLabel.AutoSize = true;
            this.PagesLabel.Location = new System.Drawing.Point(29, 422);
            this.PagesLabel.Name = "PagesLabel";
            this.PagesLabel.Size = new System.Drawing.Size(119, 20);
            this.PagesLabel.TabIndex = 14;
            this.PagesLabel.Text = "Кол-во страниц";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(174, 422);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(33, 20);
            this.YearLabel.TabIndex = 15;
            this.YearLabel.Text = "Год";
            // 
            // UploadTimeLabel
            // 
            this.UploadTimeLabel.AutoSize = true;
            this.UploadTimeLabel.Location = new System.Drawing.Point(29, 497);
            this.UploadTimeLabel.Name = "UploadTimeLabel";
            this.UploadTimeLabel.Size = new System.Drawing.Size(105, 20);
            this.UploadTimeLabel.TabIndex = 17;
            this.UploadTimeLabel.Text = "Дата загрузки";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(29, 580);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(95, 20);
            this.AuthorLabel.TabIndex = 18;
            this.AuthorLabel.Text = "Автор книги";
            // 
            // AddAuthorButton
            // 
            this.AddAuthorButton.Location = new System.Drawing.Point(214, 570);
            this.AddAuthorButton.Name = "AddAuthorButton";
            this.AddAuthorButton.Size = new System.Drawing.Size(133, 30);
            this.AddAuthorButton.TabIndex = 19;
            this.AddAuthorButton.Text = "Добавить";
            this.AddAuthorButton.UseVisualStyleBackColor = true;
            this.AddAuthorButton.Click += new System.EventHandler(this.AddAuthorButton_Click);
            // 
            // AddBookButton
            // 
            this.AddBookButton.Location = new System.Drawing.Point(82, 651);
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
            this.SizeFormatField.Location = new System.Drawing.Point(255, 250);
            this.SizeFormatField.Name = "SizeFormatField";
            this.SizeFormatField.Size = new System.Drawing.Size(92, 28);
            this.SizeFormatField.TabIndex = 21;
            // 
            // ProgramLabel2
            // 
            this.ProgramLabel2.AutoSize = true;
            this.ProgramLabel2.Location = new System.Drawing.Point(60, 36);
            this.ProgramLabel2.Name = "ProgramLabel2";
            this.ProgramLabel2.Size = new System.Drawing.Size(51, 20);
            this.ProgramLabel2.TabIndex = 22;
            this.ProgramLabel2.Text = "новая";
            // 
            // TitleField
            // 
            this.TitleField.Location = new System.Drawing.Point(29, 124);
            this.TitleField.Name = "TitleField";
            this.TitleField.Size = new System.Drawing.Size(318, 27);
            this.TitleField.TabIndex = 23;
            this.TitleField.TextChanged += new System.EventHandler(this.TitleField_TextChanged);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(29, 101);
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
            this.BooksTable.Location = new System.Drawing.Point(384, 124);
            this.BooksTable.Name = "BooksTable";
            this.BooksTable.RowHeadersVisible = false;
            this.BooksTable.RowHeadersWidth = 51;
            this.BooksTable.RowTemplate.Height = 29;
            this.BooksTable.Size = new System.Drawing.Size(1248, 735);
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
            this.ExportButton.Location = new System.Drawing.Point(113, 704);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(157, 29);
            this.ExportButton.TabIndex = 26;
            this.ExportButton.Text = "Извлечь из XML";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // LibLabel
            // 
            this.LibLabel.AutoSize = true;
            this.LibLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LibLabel.Location = new System.Drawing.Point(384, 36);
            this.LibLabel.Name = "LibLabel";
            this.LibLabel.Size = new System.Drawing.Size(260, 54);
            this.LibLabel.TabIndex = 27;
            this.LibLabel.Text = "Список книг";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoButton,
            this.RedoButton,
            this.toolStripSeparator1,
            this.SearchFormButton,
            this.SortTool,
            this.ClearButton,
            this.DeleteButton,
            this.toolStripSeparator2,
            this.AboutTool});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1644, 27);
            this.toolStrip.TabIndex = 28;
            this.toolStrip.Text = "LibraryTools";
            // 
            // UndoButton
            // 
            this.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoButton.Image = global::lab2.Properties.Resources.undoicon;
            this.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(29, 24);
            this.UndoButton.Text = "Назад";
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoButton.Image = global::lab2.Properties.Resources.redoicon;
            this.RedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(29, 24);
            this.RedoButton.Text = "Вперед";
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // SearchFormButton
            // 
            this.SearchFormButton.Image = global::lab2.Properties.Resources.searchicon;
            this.SearchFormButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchFormButton.Name = "SearchFormButton";
            this.SearchFormButton.Size = new System.Drawing.Size(76, 24);
            this.SearchFormButton.Text = "Поиск";
            this.SearchFormButton.Click += new System.EventHandler(this.SearchFormButton_Click);
            // 
            // SortTool
            // 
            this.SortTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortByName,
            this.SortByTime});
            this.SortTool.Image = global::lab2.Properties.Resources.sorticon;
            this.SortTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortTool.Name = "SortTool";
            this.SortTool.Size = new System.Drawing.Size(126, 24);
            this.SortTool.Text = "Сортировка";
            // 
            // SortByName
            // 
            this.SortByName.Name = "SortByName";
            this.SortByName.Size = new System.Drawing.Size(327, 26);
            this.SortByName.Text = "Сортировка по названию";
            this.SortByName.Click += new System.EventHandler(this.SortByName_Click);
            // 
            // SortByTime
            // 
            this.SortByTime.Name = "SortByTime";
            this.SortByTime.Size = new System.Drawing.Size(327, 26);
            this.SortByTime.Text = "Сортировка по времени загрузки";
            this.SortByTime.Click += new System.EventHandler(this.SortByTime_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Image = global::lab2.Properties.Resources.clearicon;
            this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(97, 24);
            this.ClearButton.Text = "Очистить";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = global::lab2.Properties.Resources.deleteicon;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(89, 24);
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // AboutTool
            // 
            this.AboutTool.Image = global::lab2.Properties.Resources.about;
            this.AboutTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutTool.Name = "AboutTool";
            this.AboutTool.Size = new System.Drawing.Size(132, 24);
            this.AboutTool.Text = " О программе";
            this.AboutTool.Click += new System.EventHandler(this.AboutTool_Click);
            // 
            // HideToolsButton
            // 
            this.HideToolsButton.Location = new System.Drawing.Point(1477, 12);
            this.HideToolsButton.Name = "HideToolsButton";
            this.HideToolsButton.Size = new System.Drawing.Size(155, 29);
            this.HideToolsButton.TabIndex = 29;
            this.HideToolsButton.Text = "Скрыть панель";
            this.HideToolsButton.UseVisualStyleBackColor = true;
            this.HideToolsButton.Click += new System.EventHandler(this.HideToolsButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLabel,
            this.DateLabel,
            this.TimeLabel,
            this.BooksInfoLabel,
            this.BooksLabel,
            this.LastActionInfo,
            this.LastActionLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 877);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1644, 30);
            this.statusStrip.TabIndex = 30;
            this.statusStrip.Text = "statusStrip1";
            // 
            // InfoLabel
            // 
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(26, 24);
            this.InfoLabel.Text = "d1";
            // 
            // DateLabel
            // 
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(26, 24);
            this.DateLabel.Text = "d2";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(26, 24);
            this.TimeLabel.Text = "d3";
            // 
            // BooksInfoLabel
            // 
            this.BooksInfoLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.BooksInfoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.BooksInfoLabel.Name = "BooksInfoLabel";
            this.BooksInfoLabel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BooksInfoLabel.Size = new System.Drawing.Size(110, 24);
            this.BooksInfoLabel.Text = "Всего книг:";
            // 
            // BooksLabel
            // 
            this.BooksLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.BooksLabel.Name = "BooksLabel";
            this.BooksLabel.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.BooksLabel.Size = new System.Drawing.Size(37, 24);
            this.BooksLabel.Text = "0";
            // 
            // LastActionInfo
            // 
            this.LastActionInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LastActionInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.LastActionInfo.Name = "LastActionInfo";
            this.LastActionInfo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.LastActionInfo.Size = new System.Drawing.Size(179, 24);
            this.LastActionInfo.Text = "Последнее действие:";
            // 
            // LastActionLabel
            // 
            this.LastActionLabel.Name = "LastActionLabel";
            this.LastActionLabel.Size = new System.Drawing.Size(32, 24);
            this.LastActionLabel.Text = "нет";
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 907);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.HideToolsButton);
            this.Controls.Add(this.toolStrip);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Library";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E Library";
            this.Load += new System.EventHandler(this.Library_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PagesField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BooksTable)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private ToolStrip toolStrip;
        private ToolStripButton SearchFormButton;
        private ToolStripDropDownButton SortTool;
        private ToolStripMenuItem SortByName;
        private ToolStripMenuItem SortByTime;
        private ToolStripButton AboutTool;
        private ToolStripButton ClearButton;
        private ToolStripButton DeleteButton;
        private ToolStripButton UndoButton;
        private ToolStripButton RedoButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private Button HideToolsButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel InfoLabel;
        private ToolStripStatusLabel DateLabel;
        private ToolStripStatusLabel TimeLabel;
        private ToolStripStatusLabel BooksInfoLabel;
        private ToolStripStatusLabel BooksLabel;
        private ToolStripStatusLabel LastActionInfo;
        private ToolStripStatusLabel LastActionLabel;
    }
}