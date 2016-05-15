using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace WindowsFormsApplication3

{


    public partial class Form1 : Form
    {
        SqlConnection c;
       // SqlCommandBuilder scmdb;
        
       // SqlDataAdapter dasub;
        DataSet ds;
        DataSet dssubcat;
        //DataSet ds2 = Database.ds2;
        DataSet dscus;
        DataSet dssell;
        DataSet dsprods;
        


        public Form1()
        {
            
            string winDir = System.Environment.GetEnvironmentVariable("windir");
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDatabaseDataSet.customer' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'storages.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.storages.customer);
            // TODO: This line of code loads data into the 'storages.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.storages.category);
            // TODO: This line of code loads data into the 'myDatabaseDataSet1.category' table. You can move, or remove it, as needed.
            



        }



        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
        }
        

 

        private void button4_Click(object sender, EventArgs e)
        {
          
  

        }


        private void lockform()
        {
            tabControl1.Hide();
            menuStrip1.Hide();

        }
        
        
   

         private void prgress(object sender,   
            ProgressChangedEventArgs e)  
        {  
             //update progress bar  
              

        }
        

        void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult dialog = MessageBox.Show("هل انت متأكد برعبتك بالخروج؟ ", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.Exit();
                    
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("هل انت متأكد برعبتك بالخروج؟ ", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
               
            }
            else if (dialog == DialogResult.No)
            {
                
            }
        }
        Form2 sm;
        private void button5_Click_1(object sender, EventArgs e)
        {


        }

        private void Sm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sm= null;
            tabControl1.Show();
        }

        private void ادارةالمستودعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sm == null)
            {
                sm = new Form2();
                //sm.MdiParent = this;
                sm.FormClosed += Sm_FormClosed;
                sm.Show();
            }
            else
                sm.Activate();

          //  tabControl1.Hide();
        }
        void connection()
        {
            Console.Write("Connecting...");
            c = Database.getConnection();
            toolStripStatusLabel1.Text = "جاهز";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            //if(cnameField.Text == "")
            //{
            //    MessageBox.Show("الرجاء ادخاء اسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //try {
            //    string query = "INSERT INTO [dbo].[customer] (cname, ccontact, caddress, comments) "
            //        + "VALUES('" + cnameField.Text + "', '" + CphoneField.Text + "', '" + cAddressField.Text + "', '" + CdetailsField.Text + "')";
            //    SqlCommand cmd = new SqlCommand(query, c);
            //    SqlDataReader readercus = cmd.ExecuteReader();
            //    MessageBox.Show("Done", "تم اضافة العميل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    readercus.Close();
            //    cnameField.Text = "";
            //    CphoneField.Text = "";
            //    cAddressField.Text = "";
            //    CdetailsField.Text = "";




            //    Database.loadcustomer();
            //    dscus = Database.dscus;
            //    metroGrid2.DataSource = dscus.Tables[0];
            this.customerBindingSource.AddNew();


            //}
            //catch(SqlException ex)
            //{
            //    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pSellerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pAdd_Click(object sender, EventArgs e)
        {
            if(pNameField.Text == "")
            {
                MessageBox.Show("الرجاء ادخاء اسم المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pNameField.Focus();
                return;
            }
            try {
                //NSERT INTO dbo.sproducts (subcatname, seller, catname, quantity, comments, dateofbuy, sprice, hprice, pName) 
                //VALUES('', 'dtgjt', 'hgdjgh', 4654, 'dghn', '2015-12-16 05:25:26.468', 64.0, 546.0, '')




                string query = "INSERT INTO dbo.sproducts (subcatname, seller, catname, quantity, comments, dateofbuy, sprice, hprice, pName)"
        + "VALUES('" + pSubcatList.Text + "', '" + pSellerList.Text + "', '" + pCatlist.Text + "','" + pCoantty.Value + "','" + prDetails.Text + "','" + dateTimePicker1.Value + "','" + sPrice.Value + "',  '" + hPrice.Value+"', '" + pNameField.Text + "')";
                Console.Write(dateTimePicker1.Value);
                SqlCommand cmdp = new SqlCommand(query, c);
                SqlDataReader readerp = cmdp.ExecuteReader();
                readerp.Close();
                MessageBox.Show("تم اضافة المنتج", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void selladd_Click(object sender, EventArgs e)
        {
            if (selname.Text == "")
            {
                MessageBox.Show("الرجاء ادخاء اسم المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "INSERT INTO dbo.sellers (sname, scontact, saddress, comments)  "
                    + "VALUES('" + selname.Text + "', '" + selpho.Text + "', '" + seladdress.Text + "', '" + seldetails.Text + "')";
                SqlCommand cmd = new SqlCommand(query, c);
                SqlDataReader readersel = cmd.ExecuteReader();
                MessageBox.Show("Done", "تم اضافة المورد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                readersel.Close();
                selname.Text = "";
                selpho.Text = "";
                seladdress.Text = "";
                seldetails.Text = "";


                Database.loadsellers();
                dssell = Database.dssell;
                selltable.DataSource = dssell.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ds = Database.ds;
         //   ds2 = Database.ds2;
            dssubcat = Database.dssubcat;



            try
            {



                Database.loadds();
                catlist.DataSource = ds.Tables[0];


                Database.loadsubcat();
                subcatlist.DataSource = dssubcat.Tables[0];

                button2.Enabled = true;
              //  catlist.Columns["catid"].HeaderText = "رقم المستودع";


               

            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pcombolist.Text == "")
            {
                MessageBox.Show("الرجاء اختيار المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pNameField.Focus();
                return;
            }
            try
            {
                int cnt = (int)pNewquant.Value +  int.Parse(pquantty.Text);

                string query = "UPDATE dbo.sproducts SET quantity = '"+ cnt +"' WHERE pName = '"+pcombolist.Text +"'";
                Console.Write(dateTimePicker1.Value);
                SqlCommand cmdp = new SqlCommand(query, c);
                SqlDataReader readerp = cmdp.ExecuteReader();
                readerp.Close();
                MessageBox.Show("تم تعديل الكمية", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Database.loadprods();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pcombolist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fid;
            bool parseOK = Int32.TryParse(pcombolist.SelectedValue.ToString(), out fid);
            pquantty.Text = fid.ToString();
            Console.Write(pcombolist.SelectedValue);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            ds = Database.ds;
            dssubcat = Database.dssubcat;
            dscus = Database.dscus;
            dssell = Database.dssell;
            dsprods = Database.dsprods;



            DataTable dt = new DataTable();
            DataTable subdt = new DataTable();



            try
            {
                int snum = 0;


                //string query = "SELECT * from category";
                //string querysub = "SELECT * from categorysub";
                //SqlCommand cmd = new SqlCommand(query, c);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);

                //da.Fill(dt);

                treeView1.Nodes.Clear();


                //SqlCommand cmdsub = new SqlCommand(querysub, c);
                //SqlDataAdapter dasub = new SqlDataAdapter(cmdsub);
                //dasub.Fill(subdt);

                catlist.DataSource = ds.Tables[0];
                pTable.DataSource = dsprods.Tables[0];
                metroGrid1.DataSource = dsprods.Tables[0];
                metroGrid2.DataSource = dscus.Tables[0];
                subcatlist.DataSource = dssubcat.Tables[0];
                selltable.DataSource = dssell.Tables[0];
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine();

                    treeView1.Nodes.Add(row[1].ToString());
                    foreach (DataRow subrow in dssubcat.Tables[0].Rows)
                    {

                        Console.WriteLine(snum);
                        treeView1.Nodes[snum].Nodes.Add(subrow[1].ToString());




                    }
                    snum++;

                }


                //catlist.Columns["catid"].HeaderText = "الرقم";
               // catlist.Columns["catname"].HeaderText = "اسم المستودع";

                pSubcatList.DataSource = dssubcat.Tables[0];
                pSubcatList.DisplayMember = "scatname";

                pSellerList.DataSource = dssell.Tables[0];
                pSellerList.DisplayMember = "sname";

                pCatlist.DataSource = ds.Tables[0];
                pCatlist.DisplayMember = "catname";

                pcombolist.DataSource = dsprods.Tables[0];
                pcombolist.DisplayMember = "pName";
               pcombolist.ValueMember = "quantity";







            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "تحميل البيانات...";
            Thread t = new Thread(new ThreadStart(connection));
            t.Start();



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Database.loadTables();

            ds = Database.ds;
            dssubcat = Database.dssubcat;
            dscus = Database.dscus;
            dssell = Database.dssell;
            dsprods = Database.dsprods;


            metroGrid2.DataSource = dscus.Tables[0];

            DataTable dt = new DataTable();
            DataTable subdt = new DataTable();



            try
            {
                int snum = 0;


                //string query = "SELECT * from category";
                //string querysub = "SELECT * from categorysub";
                //SqlCommand cmd = new SqlCommand(query, c);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);

                //da.Fill(dt);
                treeView1.Nodes.Clear();


                //SqlCommand cmdsub = new SqlCommand(querysub, c);
                //SqlDataAdapter dasub = new SqlDataAdapter(cmdsub);
                //dasub.Fill(subdt);



                metroGrid2.DataSource = dscus.Tables[0];

                treeView1.Nodes.Add("المخازن");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine();

                    treeView1.Nodes[0].Nodes.Add(row[1].ToString());
                    foreach (DataRow subrow in dssubcat.Tables[0].Rows)
                    {

                        Console.WriteLine(snum);
                        treeView1.Nodes[0].Nodes[snum].Nodes.Add(subrow[1].ToString());




                    }
                    snum++;

                }

                //catlist.Columns["catid"].HeaderText = "الرقم";
               // catlist.Columns["catname"].HeaderText = "اسم المستودع";

            }
            catch (SqlException ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("المخزن");
            treeView1.Nodes[0].Nodes.Add("مستودع 1");
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void حفظالتغييراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Database.connected == true)
                try
                {

                    ds = Database.ds;
                //    ds2 = Database.ds2;
                    dssubcat = Database.dssubcat;
                    dscus = Database.dscus;
                    dssell = Database.dssell;
                    dsprods = Database.dsprods;



                    SqlDataAdapter da = Database.sda;
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "Storage_details");

                    //  SqlDataAdapter da2 = new SqlDataAdapter();
                    //    SqlCommandBuilder cb2 = new SqlCommandBuilder(da);
                    //    da.Update(ds2, "Cat_details");

                    SqlDataAdapter da3 = Database.sda3;
                    SqlCommandBuilder cb3 = new SqlCommandBuilder(da3);
                    da3.Update(dssubcat, "Subcat_details");

                    SqlDataAdapter da4 = Database.sda4;
                    SqlCommandBuilder cb4 = new SqlCommandBuilder(da4);
                    da4.Update(dscus, "Customer_details");

                    SqlDataAdapter da5 = Database.sda5;
                    SqlCommandBuilder cb5 = new SqlCommandBuilder(da5);
                    da5.Update(dssell, "Sellers_details");

                    SqlDataAdapter da6 = Database.sda6;
                    SqlCommandBuilder cb6 = new SqlCommandBuilder(da6);
                    da6.Update(dsprods, "Products_details");

                    



                    MessageBox.Show("تم الحفظ الى قاعدة البيانات", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {

                        MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

                }
        }

        private void catlist_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void catlist_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("؟ تأكيد حذف المستودع؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void subcatlist_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("؟ تأكيد حذف الصنف؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void metroGrid2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("؟ تأكيد حذف العميل؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void selltable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("؟ تأكيد حذف المورد؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void pTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("؟ تأكيد حذف المنتج؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            DataView dv = null;
            if (e.Node.Parent == null)
            {
                Console.Write("Parent: " + e.Node.Text);
                dv = new DataView(dsprods.Tables[0], "catname = '" + e.Node.Text + "' ", "catname", DataViewRowState.CurrentRows);
            }
            else
            {
                Console.Write("Node: " + e.Node.Text + "from Parent: " + e.Node.Parent.Text);
                dv = new DataView(dsprods.Tables[0], "subcatname = '" + e.Node.Text + "' ","subcatname", DataViewRowState.CurrentRows);
               // dv.RowFilter = "subcatname = '"+e.Node.Text+"'  ,catname = '" + e.Node.Parent.Text + "'";
                dv.RowFilter = "(subcatname like '" + e.Node.Text + "*') AND (catname like '" + e.Node.Parent.Text + "')";

            }
           
            
            metroGrid1.DataSource = dv;

            //(metroGrid1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", e.Node.Text);

        }

        private void pTable_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void selname_TextChanged(object sender, EventArgs e)
        {

        }

        private void selname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                selladd.PerformClick();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = e.KeyValue.ToString();
        }

        private void cnameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void cnameField_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cnameField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1.PerformClick();
        }

        private void catnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void myDatabaseDataSet1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.storages);
        }
    }



}
