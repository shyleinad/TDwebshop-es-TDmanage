using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szakdolgozatmvpnullarol.DataAccess
{
    interface IDBops
    {
        void logIn(string usrName, string pswd);
        void adminLogIn(string usrName, string pswd);
        void insertNewEmp(string usrName, string pswd);
        void insertNewAdmin(string usrName, string pswd);
        void insertNewProd(string make, string type, string pic, string details, double price, bool lefthanded, string category, int quanity, string color);
        void insertNewNews(string title, string text, string pic);
        void fillOrders(DataGridView dataGridViewName, string filterName, DateTimePicker filterDate, int offset, int limit);
        void fillModProds(DataGridView dataGridViewName, string filterMake, string filterCat, DateTimePicker filterDate, int offset, int limit);
        void updateProds(DataGridView dataGridViewName);
        void fillComboBoxProdModCat(ComboBox cb);
        void fillComboBoxCat(ComboBox cb);
    }
}
