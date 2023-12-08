using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace sqliteLoadExpansion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // C:\\Users\\q\\Desktop\\test  this is simple.dll dir
            Environment.SetEnvironmentVariable("PATH", $"{Environment.GetEnvironmentVariable("PATH")};C:\\Users\\q\\Desktop\\test");
            var connection = new SqliteConnection("DataSource=test.sqlite");
            connection.Open();
            #region snippet_LoadExtension
            // Load the SpatiaLite extension
            connection.LoadExtension("simple.dll");

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                select simple_query('pinyin')
            ";
            var version = (string)command.ExecuteScalar();

            Console.WriteLine($"Using SpatiaLite {version}");
            #endregion
        }
    }
}
