namespace lab2
{
    partial class AuthorForm
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
            this.NameField = new System.Windows.Forms.TextBox();
            this.CountryField = new System.Windows.Forms.TextBox();
            this.IDField = new System.Windows.Forms.TextBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.AddAuthorButton = new System.Windows.Forms.Button();
            this.AuthorLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(33, 120);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(221, 27);
            this.NameField.TabIndex = 0;
            // 
            // CountryField
            // 
            this.CountryField.Location = new System.Drawing.Point(33, 182);
            this.CountryField.Name = "CountryField";
            this.CountryField.Size = new System.Drawing.Size(221, 27);
            this.CountryField.TabIndex = 1;
            // 
            // IDField
            // 
            this.IDField.Location = new System.Drawing.Point(33, 246);
            this.IDField.Name = "IDField";
            this.IDField.Size = new System.Drawing.Size(221, 27);
            this.IDField.TabIndex = 2;
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuthorLabel.Location = new System.Drawing.Point(33, 28);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(140, 54);
            this.AuthorLabel.TabIndex = 3;
            this.AuthorLabel.Text = "Автор";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(33, 97);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(91, 20);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Имя автора";
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Location = new System.Drawing.Point(33, 159);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(58, 20);
            this.CountryLabel.TabIndex = 5;
            this.CountryLabel.Text = "Страна";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(33, 223);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(24, 20);
            this.IDLabel.TabIndex = 6;
            this.IDLabel.Text = "ID";
            // 
            // AddAuthorButton
            // 
            this.AddAuthorButton.Location = new System.Drawing.Point(54, 302);
            this.AddAuthorButton.Name = "AddAuthorButton";
            this.AddAuthorButton.Size = new System.Drawing.Size(177, 41);
            this.AddAuthorButton.TabIndex = 7;
            this.AddAuthorButton.Text = "Добавить";
            this.AddAuthorButton.UseVisualStyleBackColor = true;
            this.AddAuthorButton.Click += new System.EventHandler(this.AddAuthorButton_Click);
            // 
            // AuthorLabel2
            // 
            this.AuthorLabel2.AutoSize = true;
            this.AuthorLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AuthorLabel2.Location = new System.Drawing.Point(63, 28);
            this.AuthorLabel2.Name = "AuthorLabel2";
            this.AuthorLabel2.Size = new System.Drawing.Size(61, 23);
            this.AuthorLabel2.TabIndex = 8;
            this.AuthorLabel2.Text = "новый";
            // 
            // AuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 414);
            this.Controls.Add(this.AuthorLabel2);
            this.Controls.Add(this.AddAuthorButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.CountryLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.IDField);
            this.Controls.Add(this.CountryField);
            this.Controls.Add(this.NameField);
            this.Name = "AuthorForm";
            this.Text = "Author";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthorForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NameField;
        private TextBox CountryField;
        private TextBox IDField;
        private Label AuthorLabel;
        private Label NameLabel;
        private Label CountryLabel;
        private Label IDLabel;
        private Button AddAuthorButton;
        private Label AuthorLabel2;
    }
}