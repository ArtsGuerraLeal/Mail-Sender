using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Mail_Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendEmail();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sendEmail();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = Convert.ToInt32(txtInterval.Text);
            timer1.Start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void sendEmail()
        {
            if (chkRandBody.Checked)
            {
                
                Random rand1 = new Random();
                int i = rand1.Next(0,100000);
                txtBody.Text = i.ToString();
            }

            if (chkRandSub.Checked)
            {
                Random rand2 = new Random();
                int c = rand2.Next(0, 100000);
                txtSubject.Text = c.ToString();
            }


            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                Random rand2 = new Random();
                int c = rand2.Next(0, 100000);

                mail.From = new MailAddress(txtEmail.Text);
                mail.To.Add(txtTo.Text);
                mail.Subject = txtSubject.Text + " " + c;
                mail.Body = txtBody.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(txtEmail.Text, txtPassword.Text);
                SmtpServer.EnableSsl = true;
               
                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }


    
}
