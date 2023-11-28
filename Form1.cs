using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Exam_ADOdotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SQLiteConnection conn;

        private DataTable dtBooks_authors;
        private DataTable dtBooks_genres;
        private DataTable dtBooks;

        private SQLiteDataAdapter adBooks_authors;
        private SQLiteDataAdapter adBooks_genres;
        private SQLiteDataAdapter adBooks;





        private void подключитьсяКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename; //"BookShop.db"
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                conn = new SQLiteConnection("DataSource=" + filename);
                conn.Open(); // создаст файл 
                string sqltext = "select name from sqlite_master where type='table';";

                using (SQLiteCommand cmd = new SQLiteCommand(sqltext, conn))
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    создатьТаблицыToolStripMenuItem.Enabled = !reader.HasRows; // отключаем кнопку создания таблиц
                    if (reader.HasRows)
                    {
                        cB_AuthorsFillAuthors();
                        cB_GenresFillGenres();
                        cB_BooksFillBooks();

                    }
                    reader.Close();
                    conn.Close();
                }
            }
            else
            {
                //указать что будет если база не откроится база данных
            }
        }

        private void создатьТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqltext =
                "create table Authors(id INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR(20));" +
                "create table Buyers(id INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR(20));" +
                "create table Publishers(id INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR(20));" +
                "create table Genres(id INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR(20));" +
                "create table Books(id INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR(100), id_genre INTEGER REFERENCES Genres(id), id_author INTEGER REFERENCES Authors(id), number_of_pages INTEGER, publication_year INTEGER, volume_of_volumes VARCHAR(6));" +
                "create table Stock(id INTEGER PRIMARY KEY AUTOINCREMENT, id_book INTEGER REFERENCES Books(id), id_publisher INTEGER REFERENCES Publishers(id), amount INTEGER, cost_price REAL, price REAL, [date] TEXT);" +
                "create table Reserve(id INTEGER PRIMARY KEY AUTOINCREMENT, id_stock INTEGER REFERENCES Stock(id), id_buyer INTEGER REFERENCES Buyers(id), amount INTEGER, [date] TEXT);" +
                "create table Write_off(id INTEGER PRIMARY KEY AUTOINCREMENT, id_stock INTEGER REFERENCES Stock(id), amount INTEGER, [date] TEXT);" +
                "create table Sales_promotions(id INTEGER PRIMARY KEY AUTOINCREMENT, id_book INTEGER REFERENCES Books(id), discount INTEGER, [date] TEXT);" +
                "create table Sales(id INTEGER PRIMARY KEY AUTOINCREMENT, id_stock INTEGER REFERENCES Stock(id), amount INTEGER, [date] TEXT, id_sales_promotions INTEGER REFERENCES Sales_promotions(id));";


            using (SQLiteCommand cmd = new SQLiteCommand(sqltext, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            создатьТаблицыToolStripMenuItem.Enabled = false; // отключаем кнопку создания таблиц
        }
        private void cB_AuthorsFillAuthors()
        {
            string sqltext = "SELECT * FROM Authors;";
            SQLiteCommand cmd = new SQLiteCommand(sqltext, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cB_Authors.Items.Add(dr["name"].ToString());
            }
        }
        private void cB_Authors_SelectedValueChanged(object sender, EventArgs e)
        {
            string sqltext = "SELECT Books.name as 'Книги автора' FROM Books JOIN Authors ON Books.id_author = Authors.id";
            sqltext = sqltext + " WHERE Authors.name='" + cB_Authors.Text + "'";
            adBooks_authors = new SQLiteDataAdapter(sqltext, conn);

            SQLiteCommandBuilder cb_Books_authors = new SQLiteCommandBuilder(adBooks_authors);
            dtBooks_authors = new DataTable();
            adBooks_authors.Fill(dtBooks_authors);
            dGVShow.DataSource = dtBooks_authors;
        }
        private void cB_GenresFillGenres()
        {
            string sqltext = "SELECT * FROM Genres;";
            SQLiteCommand cmd = new SQLiteCommand(sqltext, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cB_Genres.Items.Add(dr["name"].ToString());
            }
        }
        private void cB_Genres_SelectedValueChanged(object sender, EventArgs e)
        {
            string sqltext = "SELECT Books.name as 'Книги жанра' FROM Books JOIN Genres ON Books.id_genre = Genres.id";
            sqltext = sqltext + " WHERE Genres.name='" + cB_Genres.Text + "'";
            adBooks_genres = new SQLiteDataAdapter(sqltext, conn);

            SQLiteCommandBuilder cb_Books_genres = new SQLiteCommandBuilder(adBooks_genres);
            dtBooks_genres = new DataTable();
            adBooks_genres.Fill(dtBooks_genres);
            dGVShow.DataSource = dtBooks_genres;
        }
        private void cB_BooksFillBooks()
        {
            string sqltext = "SELECT * FROM Books;";
            SQLiteCommand cmd = new SQLiteCommand(sqltext, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cB_Books.Items.Add(dr["name"].ToString());
            }
        }

        private void cB_Books_SelectedValueChanged(object sender, EventArgs e)
        {
            string sqltext = "SELECT Books.name as 'Книга',  Genres.name as 'Жанр', Authors.name as 'Автор'," +
                "Books.number_of_pages as 'Количество страниц', " +
                "Books.publication_year as 'Год издания'," +
                "Books.volume_of_volumes as 'Том'," +
                "Publishers.name as 'Издатель'," +
                "Stock.price as 'Цена', " +
                "Stock.amount as 'Количество' " +
                "FROM Books JOIN Genres ON Books.id_genre = Genres.id " +
                "JOIN Authors ON Books.id_author=Authors.id " +
                "JOIN Stock ON Stock.id_book=Books.id " +
                "JOIN Publishers ON Publishers.id=Stock.id_publisher";
            sqltext = sqltext + " WHERE Books.name='" + cB_Books.Text + "'";
            adBooks = new SQLiteDataAdapter(sqltext, conn);

            SQLiteCommandBuilder cb_Books_genres = new SQLiteCommandBuilder(adBooks);
            dtBooks = new DataTable();
            adBooks.Fill(dtBooks);
            dGVShow.DataSource = dtBooks;
        }
    }
}

