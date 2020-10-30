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
    public partial class newlecturer : Form
    {
        public newlecturer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\bt\BTproject\BTproject\BT.mdf;Integrated Security=True;User Instance=True");


        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                string name = textBox1.Text;
                string subject = textBox2.Text;
                string id = textBox3.Text;

                if (name == "" || subject == "" || id == "")
                {
                    MessageBox.Show("Please Complete the Details Correctly.", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = "insert into Lecturer(ID, Name, Subject) values('"+id+"','" + name + "','" + subject + "')";
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Saved Successfully!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                    nxtd();


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error While Saving!. Please Check You Entered Details.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                textBox1.Focus();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }

        private void newlecturer_Load(object sender, EventArgs e)
        {
            nxtd();
        }

        private void nxtd() 
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select count(ID) AS 'len' from Lecturer";
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox3.Text = dr["len"].ToString();
                }
            }
            int myInt = int.Parse(textBox3.Text);
            myInt = myInt + 1;
            textBox3.Text = Convert.ToString(myInt);
            con.Close();
        }
    }
}
