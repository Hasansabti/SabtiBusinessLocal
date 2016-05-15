using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Loginform : Form
    {

        int i = 0;


        int sel1 = 1;
        int sel2 = 4;
       // int sel3 = 9;
      //  int sel4 = 6;
        public Loginform()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            passlogin.PasswordChar = '*';
            chart1.Controls.Add(pictureBox1);
            pictureBox1.BackColor = Color.Transparent;
            chart1.Series["مبيعات الشهر"].Points.Add(0);


            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync(sel1);

            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerSupportsCancellation = true;


        }


        int co = 0;
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            for (; co < i; co++)
            {
                if (!backgroundWorker1.IsBusy)
                    if (co == 0)
                        backgroundWorker1.RunWorkerAsync(sel2);
                    //else if (co == 1)
                    //    backgroundWorker1.RunWorkerAsync(sel3);
                    //else if (co == 2)
                    //    backgroundWorker1.RunWorkerAsync(sel4);
                    //else if (co == 3)
                    //    backgroundWorker1.RunWorkerAsync(2);
                    //else if (co == 4)
                    //    backgroundWorker1.RunWorkerAsync(5);
                    //else if (co == 5)
                    //    backgroundWorker1.RunWorkerAsync(2);
                    //else if (co == 6)
                    //    backgroundWorker1.RunWorkerAsync(7);
                    //else if (co == 7)
                    //    backgroundWorker1.RunWorkerAsync(10);
            }


        }

        public static string passwordEncrypt(string inText, string key)
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }

        public static string passwordDecrypt(string cryptTxt, string key)
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

                StreamReader reader = new StreamReader("userinfo\\" + namelogin.Text.ToUpper() + ".data");
                string EncryptionKey = "SabtiSecured";

                String pass = passwordDecrypt(reader.ReadLine(), EncryptionKey);


                if (passlogin.Text.Equals(pass))
                {
                    successlogin();
                }
                else
                    Console.Write(passwordDecrypt(reader.ReadLine(), "SabtiSecured"));
                Console.Write(namelogin.Text);

                Console.Write( reader.ReadLine());


            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("FileNotFound"))
                {
                    Console.Write("user not found");
                    MessageBox.Show("لم يتم العثور على اسم المستخدم");
                }
                else
                    MessageBox.Show(ex.Message);
                Console.Write(namelogin.Text);
                Console.Write(ex);
            }
        }

        private void successlogin()
        {
            Form main = new Form1();
            main.Show();
            backgroundWorker1.CancelAsync();
            this.Hide();
            

            Loginscreen.Hide();
        }
        double y = 1;


        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("userinfo\\" + namereg.Text.ToUpper() + ".data"))
            {
                MessageBox.Show("هذا الاسم مسجل بالفعل");
                return;
            }

            StreamWriter writer = new StreamWriter("userinfo\\" + namereg.Text.ToUpper() + ".data", true);
            string EncryptionKey = "SabtiSecured";
            string eStr = passwordEncrypt(passreg.Text, EncryptionKey);
            writer.WriteLine(eStr);
            MessageBox.Show("تم التسجيل!");
            writer.Close();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

            i++;

            for (y = 0; y <= (int)e.Argument;)
            {
                if (this.backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                backgroundWorker1.ReportProgress((int)y, y);
                Thread.Sleep(50);

            }
           
        }


        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (i < chart1.Series["مبيعات الشهر"].Points.Count())
                {
                    chart1.Series["مبيعات الشهر"].Points.ElementAt(i).SetValueY(y);


                    chart1.Refresh();
                    y = y + 0.1;
                }
                else
                {
                    chart1.Series["مبيعات الشهر"].Points.Add(0);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }



            Console.Write(e.ProgressPercentage);
        }
    }
}
