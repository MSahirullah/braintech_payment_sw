using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTproject
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment paymentd = new Payment();
            paymentd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymentDeails payment = new PaymentDeails();
            payment.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newlecturer nl = new newlecturer();
            nl.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lecturerdetails ld = new lecturerdetails();
            ld.Show();
            this.Hide();
        }
    }
}
