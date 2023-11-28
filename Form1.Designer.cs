namespace Exam_ADOdotNet
{
    partial class Form1
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
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            подключитьсяКБДToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            создатьТаблицыToolStripMenuItem = new ToolStripMenuItem();
            dGVShow = new DataGridView();
            cB_Authors = new ComboBox();
            cB_Genres = new ComboBox();
            cB_Books = new ComboBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGVShow).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, создатьToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { подключитьсяКБДToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // подключитьсяКБДToolStripMenuItem
            // 
            подключитьсяКБДToolStripMenuItem.Name = "подключитьсяКБДToolStripMenuItem";
            подключитьсяКБДToolStripMenuItem.Size = new Size(183, 22);
            подключитьсяКБДToolStripMenuItem.Text = "Подключиться к БД";
            подключитьсяКБДToolStripMenuItem.Click += подключитьсяКБДToolStripMenuItem_Click;
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьТаблицыToolStripMenuItem });
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(62, 20);
            создатьToolStripMenuItem.Text = "Создать";
            // 
            // создатьТаблицыToolStripMenuItem
            // 
            создатьТаблицыToolStripMenuItem.Name = "создатьТаблицыToolStripMenuItem";
            создатьТаблицыToolStripMenuItem.Size = new Size(168, 22);
            создатьТаблицыToolStripMenuItem.Text = "Создать таблицы";
            создатьТаблицыToolStripMenuItem.Click += создатьТаблицыToolStripMenuItem_Click;
            // 
            // dGVShow
            // 
            dGVShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVShow.Location = new Point(12, 204);
            dGVShow.Name = "dGVShow";
            dGVShow.RowTemplate.Height = 25;
            dGVShow.Size = new Size(776, 215);
            dGVShow.TabIndex = 1;
            // 
            // cB_Authors
            // 
            cB_Authors.FormattingEnabled = true;
            cB_Authors.Location = new Point(24, 35);
            cB_Authors.Name = "cB_Authors";
            cB_Authors.Size = new Size(121, 23);
            cB_Authors.TabIndex = 2;
            cB_Authors.Text = "Выбери автора";
            cB_Authors.SelectedValueChanged += cB_Authors_SelectedValueChanged;
            // 
            // cB_Genres
            // 
            cB_Genres.FormattingEnabled = true;
            cB_Genres.Location = new Point(176, 35);
            cB_Genres.Name = "cB_Genres";
            cB_Genres.Size = new Size(121, 23);
            cB_Genres.TabIndex = 2;
            cB_Genres.Text = "Выбери жанр";
            cB_Genres.SelectedValueChanged += cB_Genres_SelectedValueChanged;
            // 
            // cB_Books
            // 
            cB_Books.FormattingEnabled = true;
            cB_Books.Location = new Point(322, 35);
            cB_Books.Name = "cB_Books";
            cB_Books.Size = new Size(121, 23);
            cB_Books.TabIndex = 2;
            cB_Books.Text = "Выбери книгу";
            cB_Books.SelectedValueChanged += cB_Books_SelectedValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cB_Books);
            Controls.Add(cB_Genres);
            Controls.Add(cB_Authors);
            Controls.Add(dGVShow);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGVShow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem подключитьсяКБДToolStripMenuItem;
        private DataGridView dGVShow;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem создатьТаблицыToolStripMenuItem;
        private ComboBox cB_Authors;
        private ComboBox cB_Genres;
        private ComboBox cB_Books;
    }
}