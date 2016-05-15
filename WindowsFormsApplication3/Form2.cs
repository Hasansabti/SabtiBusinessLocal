using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        SqlConnection c = Database.getConnection();
        SqlCommandBuilder scmdb;
        SqlCommandBuilder scmdbsub;
        SqlDataAdapter da;
        
        DataTable dt = new DataTable();
        DataTable subdt = new DataTable();

        DataSet ds;
        DataSet ds2;
        DataSet dssubcat;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            ds = Database.ds;
            ds2 = Database.dssubcat;
            dssubcat = Database.dssubcat;
            


            try
            {
               


                Database.loadds();
                metroGrid1.DataSource = ds.Tables[0];


                // Database.loadds2();
                Database.loadsubcat();
                metroGrid2.DataSource = dssubcat.Tables[0];

                button2.Enabled = true;
                metroGrid1.Columns["catid"].HeaderText = "رقم المستودع";
                

                metroGrid1.Columns["catname"].HeaderText = "اسم المستودع";

            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Database.connected == true)
            try {
                da = Database.sda;
                scmdb = new SqlCommandBuilder(da);
                da.Update(ds, "Storage_details");
               SqlDataAdapter dasub = Database.sda;
                scmdbsub = new SqlCommandBuilder(dasub);
                dasub.Update(ds2, "Cat_details");
                MessageBox.Show("تم الحفظ الى قاعدة البيانات", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(SqlException ex)
            {
                if (ex.Message.Contains("NULL"))
                {
                    MessageBox.Show("لا يمكن ترك رقم المستودع فارغا في قائمة الأصناف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            toolStripStatusLabel1.Text = "تحميل..";
            Thread.Sleep(100);

            int t = 10;
            backgroundWorker1.ReportProgress(t);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            ds = Database.ds;
       //     ds2 = Database.ds2;


            try
            {


                metroGrid1.DataSource = ds.Tables[0];



                metroGrid2.DataSource = ds2.Tables[0];

                button2.Enabled = true;
                metroGrid1.Columns["catid"].HeaderText = "رقم المستودع";
                metroGrid2.Columns["catid"].HeaderText = "رقم المستودع";
                metroGrid2.Columns["scatid"].HeaderText = "رقم الصنف";
                metroGrid2.Columns["scatname"].HeaderText = "اسم الصنف";

                metroGrid1.Columns["catname"].HeaderText = "اسم المستودع";

            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }



        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "جاهز.";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
