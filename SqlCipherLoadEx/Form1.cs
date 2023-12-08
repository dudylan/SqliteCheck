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
            //Log.Error("我的数据库地址" + Path.Combine(Global.CoreDir, DBName));
            var options = new SQLiteConnectionString("xuanyou.db", true, key: key);

            SQLiteConnection _db = new SQLiteConnection(options);
            _db.EnableLoadExtension(true);
            int rc = raw.sqlite3_db_config(_db.Handle, raw.SQLITE_DBCONFIG_ENABLE_LOAD_EXTENSION, 1, out _);
            int i = raw.sqlite3_load_extension(_db.Handle, utf8z.FromString("simple.dll"),utf8z.FromString(null), out var errmsg);
            string version = _db.ExecuteScalar<string>("select simple_query('pinyin')");

            Console.WriteLine($"Using SpatiaLite {version}");
        }
    }
}
