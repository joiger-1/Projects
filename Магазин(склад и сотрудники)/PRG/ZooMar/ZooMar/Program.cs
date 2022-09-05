using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooMar
{
    static class Program
    {
        static public Point FormLocation = new Point(100, 100);
        static public string conStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{Directory.GetCurrentDirectory()}\\DataBase.mdf\";Integrated Security=True;Connect Timeout=30";
        public static void My_Execute_Non_Query(string CommandText)
        {
            SqlConnection cn;
            SqlCommand cmd;
            cn = new SqlConnection(conStr);
            cn.Open();
            cmd = cn.CreateCommand(); 
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery(); 
            cn.Close();
        }

        static public void FormMove(object sender, EventArgs e)
        {
            FormLocation = (sender as Form).Location;
        }
        static public void FormShown(object sender, EventArgs e)
        {
            (sender as Form).Location = FormLocation;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
