using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace szakdolgozatmvpnullarol.DataAccess
{
    class Connect : IConnect
    {
        public MySqlConnection conn;
        public Connect()
        {
            string connS = "server=localhost; database=td_webshop; uid=administrator_and_employee; password=IHapeTTLqTgNp6Py;";
            conn = new MySqlConnection(connS);
        }
        public bool open()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        public bool close()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}
