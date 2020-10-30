using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTproject
{
    public partial class PaymentDeails : Form
    {
        public PaymentDeails()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\bt\BTproject\BTproject\BT.mdf;Integrated Security=True;User Instance=True");


        private void alldata(string a)
        {
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            con.Open();

            cmd3.CommandText = a;
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Lecturer");
            con.Close();
            dataGridView1.DataSource = ds.Tables["Lecturer"].DefaultView;

        }
        private void PaymentDeails_Load(object sender, EventArgs e)
        {
            alldata("select * from Lecturer");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide(); 
        }

        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "delete from Lecturer";
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfull!","DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            alldata("select * from Lecturer");


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
            this.Hide();
        }
    }
}
