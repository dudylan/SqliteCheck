using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SqlCipherLoadEx
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
            Environment.SetEnvironmentVariable("PATH", $"{Environment.GetEnvironmentVariable("PATH")};C:\\Users\\q\\Desktop\\test");

            var key = "aaa";
            var options = new SQLiteConnectionString("xuanyou.db", true, key: key);
            var _db = new SQLiteConnection(options);
            _db.EnableLoadExtension(true);
            var extensionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "simple.dll");
            _db.ExecuteScalar<int>($"SELECT load_extension('{extensionPath}');");
            var value = _db.ExecuteScalar<string>("select simple_query('pinyin')");
            Console.WriteLine($"Using SpatiaLite {value}");
        }
    }
}
