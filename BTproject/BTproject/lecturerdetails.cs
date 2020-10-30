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
    public partial class lecturerdetails : Form
    {
        public lecturerdetails()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\bt\BTproject\BTproject\BT.mdf;Integrated Security=True;User Instance=True");

        private void button1_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void cmbdata()
        {

            //1
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select DISTINCT LecturerName from Payment", con);
            SqlDataReader drs1 = cmd1.ExecuteReader();
            IList<string> listName1 = new List<string>();
            listName1.Add("--");
            while (drs1.Read())
            {
                listName1.Add(drs1[0].ToString());

            }
            listName1 = listName1.Distinct().ToList();
            cmblec.DataSource = listName1;
            con.Close();


            //2
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select DISTINCT Date from Payment", con);
            SqlDataReader drs2 = cmd2.ExecuteReader();
            IList<string> listName2 = new List<string>();
            listName2.Add("--");
            while (drs2.Read())
            {
                listName2.Add(drs2[0].ToString());

            }
            listName2 = listName2.Distinct().ToList();
            cmbdate.DataSource = listName2;
            con.Close();
        }

        private void filter()
        {
            string lecname = cmblec.Text;
            string date = cmbdate.Text;

            if (date == "--" && lecname != "--")
            {
                alldata("select * from Payment where LecturerName='" + lecname + "'");
            }
            else if (date != "--" && lecname == "--")
            {
                alldata("select * from Payment where Date='" + date + "'");
            }
            else if (date == "--" && lecname == "--")
            {
                alldata("select * from Payment");
            }
            else if (date != "--" && lecname != "--")
            {
                alldata("select * from Payement where LecturerName='"+lecname+"' and Date='"+date+"'");

            }

        }

        private void alldata(string a)
        {
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            con.Open();

            cmd3.CommandText = a;
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Payment");
            con.Close();
            dataGridView1.DataSource = ds.Tables["Payment"].DefaultView;

            //totlecturer
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["LecturerFee"].Value);
            }
            totlec.Text = sum.ToString();


            //institutefee
            int sum2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum2 += Convert.ToInt32(dataGridView1.Rows[i].Cells["InstituteFee"].Value);
            }
            totins.Text = sum2.ToString();

            //totinstitute
            int sum3 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum3 += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalFee"].Value);
            }
            tottot.Text = sum3.ToString();
        }

        private void lecturerdetails_Load(object sender, EventArgs e)
        {
            alldata("select * from Payment");
            cmbdata();
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
            cmd1.CommandText = "delete from Payment";
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfull!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            alldata("select * from Payment");
        }




    }
}
