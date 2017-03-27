using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using P3_Mpp_Lab1.Cntrl;
namespace P3_Mpp_Lab1
{
    class Program
    {
        
        public static SQLiteConnection Get_DB_connection(String bd)
        {
            return new SQLiteConnection(bd);
        }




        [STAThread]

        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            Application.Run(new Form1());



        }
    }
}
