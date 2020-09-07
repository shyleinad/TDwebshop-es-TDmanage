using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szakdolgozatmvpnullarol.View
{
    interface IContainerForm
    {
        ErrorProvider errorProvider { get; }
        
        //Bejelentkezés:
        string textBoxUsrNameText { get; set; } //bejelentkezés usrname
        string textBoxPswdText { get; set; } //bejelentkezés jelszó

        //Dolgozó/admin hozzáadás:
        string textBoxAddUsrNameText { get; set; } //dolgozó/admin hozzáadás usrname
        string textBoxAddPswdText { get; set; } //dolgozó/admin hozzáadás jelszó

        //Új termék:
        string newProdMakeText { get; set; } //új termék márka
        string newProdTypeText { get; set; } //új termék tipus
        string newProdPicSourceText { get; set; } //új termék kép forrás
        string newProdPriceText { get; set; } //új termék ár
        bool leftHCheck { get; set; } //új termék balkezes-e
        string newProdCatText { get; set; } //új termék kategória
        string newProdDetailsText { get; set; } //új termék leírás
        string newProdQuanityText { get; set; } //új termék darab
        string newProdColorText { get; set; } //új termék szín
        ComboBox newProdComboBox { get; } //új termék combo box

        //Termék módosítás:
        string modProdMakeText { get; set; } //termék módosítás márka 
        string modProdDateValue { get; set; } //termék módosítás dátum
        DateTimePicker modProdDate { get; } //termék módosítás datetimepicker
        string modProdCatText { get; } //termékmódosítás kategória
        ComboBox modProdComboBox { get; } //termékmódosítás kategória combobox
        DataGridView modProdsDataGridView { get; } //termékmódosítás daragridview
        string textBoxCurrPageText { get; set; } //aktuális oldal
        string textBoxTotalPageText { get; set; } //összes oldal

        //Új hír: 
        string titleText { get; set; } //új hír cím
        string newNewsPicSourceText { get; set; } //új hír kép forrás
        string textText { get; set; } //új hír szöveg

        //Rendelések:
        string name { get; set; } //rendelések név
        string ordersDateTimeValue { get; set; } //rendelések dátum
        DateTimePicker ordersDate { get; } //rendelések datetimepicker
        DataGridView ordersDataGridView { get; } //rendelések datagriwdview
        string textBoxCurrPageOrdersText { get; set; }
        string textBoxTotalPageOrdersText { get; set; }
    }
}
