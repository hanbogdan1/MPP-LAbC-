using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P3_Mpp_Lab1.Cntrl;
using P3_Mpp_Lab1.Domain;

namespace P3_Mpp_Lab1
{
    public partial class Form1 : Form
    {
        Controller contrl;
        public Form1()
        {
            contrl = new Controller();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
           {
                Admin x = new Admin();
                x.Username = textBoxUsername.Text;
                x.Parola = textBoxPassword.Text;

                textBoxPassword.Clear();
                textBoxUsername.Clear();

                if (contrl.verify_login(x))
                {
                    Form newform = new Admin_window();
                    newform.FormClosed += new FormClosedEventHandler(newform_formclosed);
                    this.Hide();
                    newform.Show();
                }
                else
                    MessageBox.Show("Login invalid !");
           }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void newform_formclosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin_window newform = new Admin_window();
            newform.FormClosed += new FormClosedEventHandler(newform_formclosed);
            this.Hide();
            newform.Show();
        }
    }
}
