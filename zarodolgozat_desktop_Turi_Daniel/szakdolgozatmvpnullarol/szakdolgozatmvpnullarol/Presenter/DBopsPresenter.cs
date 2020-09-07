using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szakdolgozatmvpnullarol.Model;
using szakdolgozatmvpnullarol.View;
using szakdolgozatmvpnullarol.DataAccess;
using System.Windows.Forms;

namespace szakdolgozatmvpnullarol.Presenter
{
    class DBopsPresenter
    {
        IContainerForm cf;
        DBops dbops = new DBops();
        public DBopsPresenter(IContainerForm cf)
        {
            this.cf = cf;
        }

        //Bejelentkezés
        public void logIn(string usrName, string pswd)
        {
            usrName = cf.textBoxUsrNameText;
            pswd = cf.textBoxPswdText;
            dbops.logIn(usrName, pswd);
        }
        //Admin bejelentkezés
        public void adminLogIn(string usrName, string pswd)
        {
            usrName = cf.textBoxUsrNameText;
            pswd = cf.textBoxPswdText;
            dbops.adminLogIn(usrName, pswd);
        }
        //Új dolgozó hozzáadása
        public void insertNewEmp()
        {
            User u = new User(cf.textBoxAddUsrNameText, cf.textBoxAddPswdText);
            dbops.insertNewEmp(u.getusrName, u.getPswd);
            //uRepo.insertIntoList(u);
        }
        //Új admin hozzáadása
        public void insertNewAdmin()
        {
            User u = new User(cf.textBoxAddUsrNameText, cf.textBoxAddPswdText);
            dbops.insertNewAdmin(u.getusrName, u.getPswd);
            //uRepo.insertIntoList(u);
        }
        //Új termék hozzáadása
        public void insertNewProd()
        {
            if (String.IsNullOrWhiteSpace(cf.newProdMakeText) || String.IsNullOrWhiteSpace(cf.newProdTypeText) || String.IsNullOrWhiteSpace(cf.newProdDetailsText) || 
                String.IsNullOrWhiteSpace(cf.newProdPriceText) || String.IsNullOrWhiteSpace(cf.newProdCatText) || String.IsNullOrWhiteSpace(cf.newProdQuanityText) || 
                String.IsNullOrWhiteSpace(cf.newProdColorText))
            {
                throw new EmptyDataException("Tölste ki az összes mezőt!");
            }
            else
            {
                Product p = new Product(cf.newProdMakeText, cf.newProdTypeText, cf.newProdPicSourceText, double.Parse(cf.newProdPriceText), cf.leftHCheck, cf.newProdCatText, cf.newProdDetailsText, int.Parse(cf.newProdQuanityText), cf.newProdColorText);
                dbops.insertNewProd(p.getMake, p.getType, p.getPic, p.getDetails, p.getPrice, p.getLH, p.getCat, p.getQuanity, p.getColor);
            }
            //pRepo.insertIntoList(p);
        }
        public void fillComboBoxCat(ComboBox cb) //Comboboxcategory feltöltése
        {
            cb = cf.newProdComboBox;
            dbops.fillComboBoxCat(cb);
        }
        //Új hír hozzáadása
        public void insertNewNews()
        {
            News n = new News(cf.titleText, cf.textText, cf.newNewsPicSourceText);
            dbops.insertNewNews(n.getTitle, n.getText, n.getPic);
            //nRepo.insertIntoList(n);
        }
        //Rendelések
        public void fillOrders(DataGridView dataGridViewName, string filterName, DateTimePicker filterDate, int offset, int limit) //Rendelések feltöltése
        {
            dataGridViewName = cf.ordersDataGridView;
            filterName = cf.name;
            filterDate = cf.ordersDate;
            dbops.fillOrders(dataGridViewName, filterName, filterDate, offset, limit);
        }
        public int countOrdRows(string filterName, DateTimePicker filterDate)
        {
            return dbops.countOrdRows(filterName, filterDate);
        }
        //Termékek módosítása
        public void fillModProds(DataGridView dataGridViewName, string filterMake, string filterCat, DateTimePicker filterDate, int offset, int limit) //Datagrid feltöltése
        {
            dataGridViewName = cf.modProdsDataGridView; filterMake = cf.modProdMakeText; filterCat = cf.modProdCatText; filterDate = cf.modProdDate;
            dbops.fillModProds(dataGridViewName, filterMake, filterCat, filterDate, offset, limit);
        }
        public int countProdRows(string make, string cat, DateTimePicker date)
        {
            return dbops.countProdRows(make, cat, date);
        }
        public void updateProds(DataGridView dataGridViewName) //Frissítés
        {
            dataGridViewName = cf.modProdsDataGridView;
            dbops.updateProds(dataGridViewName);
        }
        public void fillComboBoxProdModCat(ComboBox cb) //Combobox feltöltése
        {
            cb = cf.modProdComboBox;
            dbops.fillComboBoxProdModCat(cb);
        }
    }
}
