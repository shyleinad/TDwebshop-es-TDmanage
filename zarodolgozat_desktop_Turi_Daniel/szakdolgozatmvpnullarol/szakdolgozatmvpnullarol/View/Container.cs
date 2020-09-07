using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szakdolgozatmvpnullarol.DataAccess;
using szakdolgozatmvpnullarol.Exceptions;
using szakdolgozatmvpnullarol.Model;
using szakdolgozatmvpnullarol.Presenter;

namespace szakdolgozatmvpnullarol.View
{
    public partial class Container : Form, IContainerForm
    {
        //TODO: file dialog kezelése (valahova??)
        //TODO: sikertelen belépés után nem lehet belépni (connection already open)
        ConnectPresenter cp;
        DBopsPresenter dbopsP;
        OpenFileDialog openFD;
        int offset = 0;
        int limit = 25;
        int currPage;
        int totalPages;
        int rows;

        //Interface implementálás:
        public ErrorProvider errorProvider { get { return errorProvider1; } }
        public string textBoxUsrNameText { get { return textBoxUID.Text; } set { textBoxUID.Text = value; } }
        public string textBoxPswdText { get { return textBoxPSWD.Text; } set { textBoxPSWD.Text = value; } }
        public string textBoxAddUsrNameText { get { return textBoxUsrUsrName.Text; } set { textBoxUsrUsrName.Text = value; } }
        public string textBoxAddPswdText { get { return textBoxUsrPswd.Text; } set { textBoxUsrPswd.Text = value; } }
        public string newProdMakeText { get { return textBoxMake.Text; } set { textBoxMake.Text = value; } }
        public string newProdTypeText { get { return textBoxType.Text; } set { textBoxType.Text = value; } }
        public string newProdPicSourceText { get { return textBoxPicSource.Text; } set { textBoxPicSource.Text = value; } }
        public string newProdPriceText { get { return textBoxPrice.Text; } set { textBoxPrice.Text = value; } }
        public bool leftHCheck { get { return checkBoxLeftH.Checked; } set { checkBoxLeftH.Checked = value; } }
        public string newProdCatText { get { return comboBoxCat.Text; } set { comboBoxCat.Text = value; } }
        public string newProdDetailsText { get { return textBoxDetails.Text; } set { textBoxDetails.Text = value; } }
        public string newProdQuanityText { get { return textBoxQuanity.Text; } set { textBoxQuanity.Text = value; } }
        public string newProdColorText { get { return textBoxColor.Text; } set { textBoxColor.Text = value; } }
        public ComboBox newProdComboBox { get { return comboBoxCat; } }
        public string modProdMakeText { get { return textBoxModProdMake.Text; } set { textBoxModProdMake.Text = value; } }
        public string modProdDateValue { get { return dateTimePicker2.Text; } set { dateTimePicker2.Text = value; } }
        public DateTimePicker modProdDate { get { return dateTimePicker2; } }
        public string modProdCatText { get { return comboBoxModProdsCat.Text; } set { comboBoxModProdsCat.Text = value; } }
        public ComboBox modProdComboBox { get { return comboBoxModProdsCat; } }
        public string textBoxCurrPageText { get { return textBoxCurrPageProd.Text; } set { textBoxCurrPageProd.Text = value; } }
        public string textBoxTotalPageText { get { return textBoxTotalPageProd.Text; } set { textBoxTotalPageProd.Text = value; } }

        public DataGridView modProdsDataGridView { get { return dataGridViewModProds; } }

        public string titleText { get { return textBoxNewsTitle.Text; } set { textBoxNewsTitle.Text = value; } }
        public string newNewsPicSourceText { get { return textBoxNewsPic.Text; } set { textBoxNewsPic.Text = value; } }
        public string textText { get { return textBoxNewsText.Text; } set { textBoxNewsText.Text = value; } }
        public string name { get { return textBoxName.Text; } set { textBoxName.Text = value; } }
        public string ordersDateTimeValue { get { return dateTimePicker1.Text; } set { dateTimePicker1.Text = value; } }
        public DateTimePicker ordersDate { get { return dateTimePicker1; } }
        public DataGridView ordersDataGridView { get { return dataGridViewOrders; } }

        public string textBoxCurrPageOrdersText { get { return textBoxCurrPageOrd.Text; } set { textBoxCurrPageOrd.Text = value; } }
        public string textBoxTotalPageOrdersText { get { return textBoxTotalPageOrd.Text; } set { textBoxTotalPageOrd.Text = value; } }



        //Függvények panelek eltüntetésére:
        private void clearPanels() //Összes panel eltüntetése
        {
            panelLogIn.Visible = false;
            panelMain.Visible = false;
            panelModProds.Visible = false;
            panelNewNews.Visible = false;
            panelNewProd.Visible = false;
            panelOrders.Visible = false;
            panelAdmin.Visible = false;
        }
        private void clearPanelsExcMain() //Összes panel eltüntetése, kivéve panelMain
        {
            panelLogIn.Visible = false;
            panelModProds.Visible = false;
            panelNewNews.Visible = false;
            panelNewProd.Visible = false;
            panelOrders.Visible = false;
        }


        
        //Form példányosítás:
        public Container()
        {
            InitializeComponent();
        }
        //Form betöltődés:
        private void Container_Load(object sender, EventArgs e)
        {
            dbopsP = new DBopsPresenter(this);
            cp = new ConnectPresenter(this);
            cp.open();
            clearPanels();
            panelLogIn.Visible = true;
            panelLogIn.BringToFront();
            errorProvider.Clear();
        }
        //Dolgozói bejelentkezés:
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                dbopsP.logIn(textBoxUsrNameText, textBoxPswdText);
                clearPanels();
                panelMain.Visible = true;
                panelMain.BringToFront();
            }
            catch (InvalidOperationException ioe)
            {
                errorProvider.SetError(buttonLogIn, ioe.Message);
            }
            catch (LoginException le)
            {
                errorProvider.SetError(buttonLogIn, le.Message);
            }
        }

        //Kijelentkezés:
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            cp = new ConnectPresenter(this);
            clearPanels();
            panelLogIn.Visible = true;
            panelLogIn.BringToFront();
            textBoxPswdText = null;
            textBoxUsrNameText = null;
            cp.close();
        }

        //Új termék feltöltés:
        private void linkLabelNewProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            clearPanelsExcMain();
            dbopsP.fillComboBoxCat(newProdComboBox);
            panelNewProd.Visible = true;
            panelNewProd.BringToFront();
        }
        private void comboBoxCat_SelectedIndexChanged(object sender, EventArgs e) //Ha a kategória választás változott
        {
            if ((string)comboBoxCat.Text == "Elektromos gitár" || (string)comboBoxCat.Text == "Jazz gitár" || (string)comboBoxCat.Text == "6+ húros gitár" ||
                (string)comboBoxCat.Text == "Basszusgitár" || (string)comboBoxCat.Text == "Akusztikus-basszus gitár" || (string)comboBoxCat.Text == "4+ húros basszusgitár" ||
                (string)comboBoxCat.Text == "Akusztikus gitár" || (string)comboBoxCat.Text == "Klasszikus gitár" || (string)comboBoxCat.Text == "Elektro-akusztikus gitár" ||
                (string)comboBoxCat.Text == "Elektro-klasszikus gitár") //Ha a kiválasztott kategória gitár, akkor a balkezes checkboxot mutatja
            {
                checkBoxLeftH.Visible = true;
            }
            else //Ha a kiválasztott kategória nem gitár, akkor a balkezes checkboxot el kell tüntetni
            {
                checkBoxLeftH.Visible = false; checkBoxLeftH.Checked = false;
            }
        }
        private void button1_Click(object sender, EventArgs e) //Kép kiválasztás
        {
            openFD = new OpenFileDialog();
            openFD.CheckFileExists = true;
            openFD.CheckPathExists = true;
            openFD.ShowDialog();
            textBoxPicSource.Text = openFD.SafeFileName;
        }
        private void buttonUpload_Click(object sender, EventArgs e) //Termék feltöltése
        {
            errorProvider.Clear();
            try
            {
                System.IO.File.Copy(openFD.FileName, "C:\\xampp\\htdocs\\TDwebshop\\pics\\products\\" + openFD.SafeFileName, false);
                dbopsP.insertNewProd();
                newProdMakeText = null; newProdTypeText = null; newProdPicSourceText = null; newProdDetailsText = null; newProdColorText = null; leftHCheck = false; ;
                newProdCatText = null; newProdQuanityText = null; newProdColorText = null; newProdPriceText = null;
            }
            catch (EmptyDataException ede)
            {
                errorProvider.SetError(buttonUpload, ede.Message);
            }
            catch (FormatException)
            {
                errorProvider.SetError(buttonUpload, "Az ár vagy a darabszám formátuma nem megfelelő! Biztos, hogy számot adott meg?");
            }
            catch (NullReferenceException)
            {
                errorProvider.SetError(textBoxPicSource, "A termék feltöltéséhez válasszon ki egy képet!");
            }
            catch (IOException)
            {
                errorProvider.SetError(textBoxPicSource, "A megadott kép már létezik!");
            }
            catch (ArgumentException)
            {
                errorProvider.SetError(buttonUpload, "A termék feltöltéséhez válasszon ki egy képet!");
            }
        }

        //Rendelések:
        private void linkLabelOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearPanelsExcMain();
            panelOrders.Visible = true;
            panelOrders.BringToFront();
            name = null;
            ordersDate.Checked = false;
            rows = dbopsP.countOrdRows(name, ordersDate);
            totalPages = (int)Math.Ceiling((double)rows / (double)limit);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            currPage = 1;
            offset = 0;
            dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
            textBoxCurrPageOrdersText = Convert.ToString(currPage); textBoxTotalPageOrdersText = Convert.ToString(totalPages);
        }
        private void buttonFilter_Click(object sender, EventArgs e) //Szűrésre kattintás
        {
            rows = dbopsP.countOrdRows(name, ordersDate);
            totalPages = (int)Math.Ceiling((double)rows / (double)limit);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            currPage = 1;
            offset = 0;
            dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
        }
        private void buttonDelFilters_Click(object sender, EventArgs e) //Szűrések törlése
        {
            name = null;
            ordersDate.Checked = false;
            rows = dbopsP.countOrdRows(name, ordersDate);
            totalPages = (int)Math.Ceiling((double)rows / (double)limit);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            currPage = 1;
            offset = 0;
            dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
        }
        private void buttonFirstOrd_Click(object sender, EventArgs e) //lapozás
        {
            currPage = 1;
            offset = 0;
            dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
            textBoxCurrPageOrdersText = Convert.ToString(currPage); textBoxTotalPageOrdersText = Convert.ToString(totalPages);
        }
        private void buttonPrevOrd_Click(object sender, EventArgs e)
        {
            if (currPage > 1)
            {
                currPage -= 1;
                offset -= limit;
                dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
            }
            textBoxCurrPageOrdersText = Convert.ToString(currPage); textBoxTotalPageOrdersText = Convert.ToString(totalPages);
        }
        private void buttonNextOrd_Click(object sender, EventArgs e)
        {
            if (currPage < totalPages)
            {
                currPage += 1;
                offset += limit;
                dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
            }
            textBoxCurrPageOrdersText = Convert.ToString(currPage); textBoxTotalPageOrdersText = Convert.ToString(totalPages);
        }
        private void buttonLastOrd_Click(object sender, EventArgs e)
        {
            currPage = totalPages;
            offset = (totalPages - 1) * limit;
            dbopsP.fillOrders(ordersDataGridView, name, ordersDate, offset, limit);
            textBoxCurrPageOrdersText = Convert.ToString(currPage); textBoxTotalPageOrdersText = Convert.ToString(totalPages);
        }

        //Új hír:
        private void linkLabelNewNews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            clearPanelsExcMain();
            panelNewNews.Visible = true;
            panelNewNews.BringToFront();
        }
        private void buttonNewsPic_Click(object sender, EventArgs e) //Kép kiválasztása
        {
            openFD = new OpenFileDialog();
            openFD.CheckFileExists = true;
            openFD.CheckPathExists = true;
            openFD.ShowDialog();
            newNewsPicSourceText = openFD.SafeFileName;
        }
        private void buttonUplNews_Click(object sender, EventArgs e) //Hír feltöltése
        {
            errorProvider.Clear();
            try
            {
                System.IO.File.Copy(openFD.FileName, "C:\\xampp\\htdocs\\TDwebshop\\pics\\news\\" + openFD.SafeFileName);
                dbopsP.insertNewNews();
                titleText = null; textText = null; newNewsPicSourceText = null;
            }
            catch (NullReferenceException)
            {
                errorProvider.SetError(textBoxNewsPic, "A hír feltöltéséhez válasszon ki egy képet!");
            }
            catch (EmptyDataException ede)
            {
                errorProvider.SetError(textBoxNewsPic, ede.Message);
            }
        }

        //Termékek módosítása:
        private void linkLabelModProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearPanelsExcMain();
            panelModProds.Visible = true;
            panelModProds.BringToFront();
            modProdMakeText = null;
            dbopsP.fillComboBoxProdModCat(modProdComboBox);
            modProdCatText = "Összes";
            modProdDate.Checked = false;
            rows = dbopsP.countProdRows(modProdMakeText, modProdCatText, modProdDate);
            totalPages = (int)Math.Ceiling((double)rows / (double)limit);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            currPage = 1;
            offset = 0;
            dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }
        private void buttonModProdFilter_Click(object sender, EventArgs e) //Szűrés
        {
            rows = dbopsP.countProdRows(modProdMakeText, modProdCatText, modProdDate);
            totalPages = (int)Math.Ceiling((double)rows / (double)limit);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            currPage = 1;
            offset = 0;
            var datumChecked = modProdDate.Checked;
            dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }
        private void buttonFilDelProds_Click(object sender, EventArgs e) //Szűrések törlése
        {
            modProdMakeText = null;
            modProdCatText = "Összes";
            modProdDate.Checked = false;
            rows = dbopsP.countProdRows(modProdMakeText, modProdCatText, modProdDate);
            totalPages = (int)Math.Ceiling((double)rows / (double)limit);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            currPage = 1;
            offset = 0;
            dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }
        private void dataGridViewModProds_RowValidated(object sender, DataGridViewCellEventArgs e) //Termék módosítás
        {
            dbopsP.updateProds(modProdsDataGridView);
        }
        private void buttonFirst_Click(object sender, EventArgs e) //Lapozás a termékek között
        {
            currPage = 1;
            offset = 0;
            dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (currPage > 1)
            {
                currPage -= 1;
                offset -= limit;
                dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            }
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currPage < totalPages)
            {
                currPage += 1;
                offset += limit;
                dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            }
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }
        private void buttonLast_Click(object sender, EventArgs e)
        {
            currPage = totalPages;
            offset = (totalPages - 1) * limit;
            dbopsP.fillModProds(modProdsDataGridView, modProdMakeText, modProdCatText, modProdDate, offset, limit);
            textBoxCurrPageText = Convert.ToString(currPage); textBoxTotalPageText = Convert.ToString(totalPages);
        }

        //Adminisztrátori bejelentkezés:
        private void buttonAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dbopsP.adminLogIn(textBoxUsrNameText, textBoxPswdText);
                clearPanels();
                panelAdmin.Visible = true;
                panelAdmin.BringToFront();
            }
            catch (InvalidOperationException ioe)
            {
                errorProvider.SetError(buttonAdminLogin, ioe.Message);
            }
            catch (LoginException le)
            {
                errorProvider.SetError(buttonAdminLogin, le.Message);
            }
        }
        //Dolgozó hozzáadása
        private void buttonAddEmp_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                dbopsP.insertNewEmp();
                textBoxAddUsrNameText = null; textBoxAddPswdText = null;
            }
            catch (EmptyUsrnameOrPswd euop)
            {
                errorProvider.SetError(buttonAddEmp, euop.Message);
            }
        }
        //Admin hozzáadása
        private void buttonAddAdm_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                dbopsP.insertNewAdmin();
                textBoxAddUsrNameText = null; textBoxAddPswdText = null;
            }
            catch (EmptyUsrnameOrPswd euop)
            {
                errorProvider.SetError(buttonAddAdm, euop.Message);
            }
        }
        //Adminisztrátori módból kijelentkezésS
        private void buttonAdmLogout_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            clearPanels();
            panelLogIn.Visible = true;
            textBoxPSWD.Text = null;
            textBoxUID.Text = null;
            cp.close();
        }
    }
}
