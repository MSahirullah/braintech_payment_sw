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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "" && password == "")
            {
                MessageBox.Show("Login Success!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainMenu main = new MainMenu();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username Or Password is Incorrect. Please Input Correct Username And Password.", "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

    }
}
