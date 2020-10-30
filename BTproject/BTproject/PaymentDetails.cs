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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=H:\bt\BTproject\BTproject\BT.mdf;Integrated Security=True;User Instance=True");


        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = new MainMenu();
            mainmenu.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "--";
            grade.Text = "";
            cardamount.Text = "";
            fee.Text = "";
            lecpay.Text = "";
            lecname.Text = "";
            ifppay.Text = "";
            totpay.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //calculation
            double tot_pay;
            double ins_pay;
            int fees = int.Parse(fee.Text);
            int cardam = int.Parse(cardamount.Text);
            int prec = 0;
            string pr = ipf.Text;

            if (pr =="25%")
            {
                prec = 25;
            }
            else if (pr == "20")
            {
                prec = 20;
            }
            else if (pr == "0%")
            {
                prec = 0;
            }

            tot_pay = (fees * cardam);
            ins_pay = ((tot_pay * prec)/100);

            double lec_pay = tot_pay - ins_pay;

            lecpay.Text = Convert.ToString(lec_pay);
            ifppay.Text = Convert.ToString(ins_pay);
            totpay.Text = Convert.ToString(tot_pay);


            //id
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "select count(PaymentNo) AS 'lenth' from Payment";
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    label30.Text = dr["lenth"].ToString();
                }
            }

            int myInt = int.Parse(label30.Text);
            myInt = myInt + 1;
            string idno = Convert.ToString(myInt);
            con.Close();


            //geting subject
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;
            cmd5.CommandText = "select Subject AS 'len' from Lecturer";
            con.Open();
            SqlDataReader dr2 = cmd5.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    label11.Text = dr2["len"].ToString();
                }
            }

            con.Close();

            //geting TEACHER NAME
            string lname = comboBox2.Text;
            lecname.Text = lname;


            //save_in_table
            try
            {
                string name = comboBox2.Text;
                string date = dates.Text;
                string grd = grade.Text;
                string mdm = comboBox1.Text;
                string feees = fee.Text;
                string cardamnt = cardamount.Text;
                string ifpap = ipf.Text;
                string lecp_ay = lecpay.Text;
                string ins_paay = ifppay.Text;
                string tot_fee = totpay.Text;


                if (name == "" || date == "" || grd == "" || mdm == "" || feees == "" || cardamnt == "" || ifpap == "")
                {
                    MessageBox.Show("Please Complete the Details Correctly.", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    comboBox2.Focus();
                }
                else
                {

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandText = "insert into Payment(PaymentNo,LecturerName,Date,Subject,Grade,Medium,Fee,CardAmount,IFP,LecturerFee,InstituteFee,TotalFee) values('" + idno + "','" + name + "','" + date + "','" + label11.Text + "','" + grd + "','" + feees + "', '"+ mdm +"','" + cardamnt + "','" + ifpap + "','" + lecp_ay + "','" + ins_paay + "','" + tot_fee + "')";
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    comboBox2.Focus();

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Error While Saving!. Please Check You Entered Details.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                comboBox2.Focus();

            }

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
            
            comboBox2.DataSource = listName1;
            con.Close();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            cmbdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }


    }
}
