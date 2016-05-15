using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Database
    {
        public static Boolean connected = false;
        public static DataSet ds;
      //  public static DataSet ds2;
        public static DataSet dssubcat;
        public static DataSet dscus;
        public static DataSet dssell;
        public static DataSet dsprods;
        public static SqlDataAdapter sda;
        //public static SqlDataAdapter sda2;
        public static SqlDataAdapter sda3;
        public static SqlDataAdapter sda4;
        public static SqlDataAdapter sda5;
        public static SqlDataAdapter sda6;

        static SqlConnection c = null;
        public static SqlConnection getConnection()
            
        {
            try
            {
                Console.Write("Connecting...");
                if (connected == false)
                {
                    // c = new SqlConnection("Server=tcp:sabtidb.database.windows.net,1433;Database=SabtiDB;User ID=HDestroyer@sabtidb;Password=Hasan1234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDatabase.mdf;Integrated Security=True");
                    
                    c.Open();
                    Console.Write("Loading tables");
                    loadTables();
                    Console.Write("Done!");
                }
                connected = true;

                return c;
            }catch(SqlException ex)
            {
                
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return getConnection();
            }

         }
        public static void loadTables() {

            loadds();
          //  loadds2();
            loadsubcat();
            loadcustomer();
            loadsellers();
            loadprods();

        }


        public static void loadds()
        {
            ds = new DataSet();
            string query = "SELECT * FROM category";
            SqlCommand cmdc = new SqlCommand(query, c);
            sda = new SqlDataAdapter(cmdc);
            sda.Fill(ds, "Storage_details");
        }
        //public static void loadds2()
        //{
        //     ds2= new DataSet();
        //    string querysub = "SELECT * from subcategory";
        //    SqlCommand cmdsub = new SqlCommand(querysub, c);
        //    sda2 = new SqlDataAdapter(cmdsub);
        //    sda2.Fill(ds2, "Cat_details");
        //}
        public static void loadsubcat()
        {
            dssubcat = new DataSet();
            string querysub = "SELECT * from categorysub";
            SqlCommand cmdsub = new SqlCommand(querysub, c);
            sda3 = new SqlDataAdapter(cmdsub);
            sda3.Fill(dssubcat, "Subcat_details");
        }
        public static void loadcustomer()
        {
            dscus = new DataSet();
            string querysub = "SELECT * from customer";
            SqlCommand cmdsub = new SqlCommand(querysub, c);
            sda4 = new SqlDataAdapter(cmdsub);
            sda4.Fill(dscus, "Customer_details");
        }
        public static void loadsellers()
        {
            dssell = new DataSet();
            string querysub = "SELECT * from sellers";
            SqlCommand cmdsub = new SqlCommand(querysub, c);
            sda5 = new SqlDataAdapter(cmdsub);
            sda5.Fill(dssell, "Sellers_details");
        }
        public static void loadprods()
        {
            dsprods = new DataSet();
            string querysub = "SELECT * from sproducts";
            SqlCommand cmdsub = new SqlCommand(querysub, c);
            sda6 = new SqlDataAdapter(cmdsub);
            sda6.Fill(dsprods, "Products_details");
        }



    }        
}



