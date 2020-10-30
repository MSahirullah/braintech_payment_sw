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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\bt\BTproject\BTproject\BT.mdf;Integrated Security=True;User Instance=True");


        private void button2_Click(object sender, EventArgs e)
        {
            PaymentDeails pay = new PaymentDeails();
            pay.Show();
            this.Hide();
        }

        private void cmbdata()
        {

            //1
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select Name from Lecturer", con);
            SqlDataReader drs1 = cmd1.ExecuteReader();
            IList<string> listName1 = new List<string>();
            listName1.Add("--");
            while (drs1.Read())
            {
                listName1.Add(drs1[0].ToString());

            }
            listName1 = listName1.Distinct().ToList();
            comboBox1.DataSource = listName1;
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "delete from Lecturer where Name='" + comboBox1.Text+ "'";
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Text = "--";
            }
            catch (Exception)
            {
                MessageBox.Show("Delete Unsuccessful!", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            cmbdata();
        }
    }
}
