using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szakdolgozatmvpnullarol.Exceptions;
using szakdolgozatmvpnullarol.Model;

namespace szakdolgozatmvpnullarol.DataAccess
{
    public class DBops : IDBops
    {
        Connect c = new Connect();
        MySqlCommand cmd;
        MySqlDataAdapter msda;
        private string query;

        //Dolgozói bejelentkezés
        public void logIn(string usrName, string pswd)
        {
            string hashedPswd;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pswd));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hashedPswd = builder.ToString();
            }
            query = "SELECT * FROM employees WHERE username = @usrname AND password = @pswd;";
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@usrname", usrName);
            cmd.Parameters.AddWithValue("@pswd", hashedPswd);
            c.open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

            }
            else
            {
                c.close();
                throw new LoginException("A felhasználónév vagy jelszó nem megfelelő!");
            }
            reader.Close();
            c.close();
        }

        //Admin bejelentkezés
        public void adminLogIn(string usrName, string pswd)
        {
            string hashedPswd;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pswd));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hashedPswd = builder.ToString();
            }
            query = "SELECT * FROM admins WHERE username = @usrname AND password = @pswd;";
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@usrname", usrName);
            cmd.Parameters.AddWithValue("@pswd", hashedPswd);
            c.open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
            }
            else
            {
                c.close();
                throw new LoginException("A felhasználónév vagy jelszó nem megfelelő!");
            }
            reader.Close();
            c.close();
        }

        //Új dolgozó beszúrása
        public void insertNewEmp(string usrName, string pswd)
        {
            if (String.IsNullOrWhiteSpace(usrName) || String.IsNullOrWhiteSpace(pswd))
            {
                throw new EmptyUsrnameOrPswd("A felhasználónév vagy jelszó mező nem lehet üres!");
            }
            //Hash
            string hashedPswd;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pswd));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hashedPswd = builder.ToString();
            }
            //Insert
            query = "INSERT INTO employees (username, password) VALUES (@usrname, @pswd);";
            c.open();
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@usrname", usrName);
            cmd.Parameters.AddWithValue("@pswd", hashedPswd);
            cmd.ExecuteNonQuery();
            c.close();

        }

        //Új admin beszúrása
        public void insertNewAdmin(string usrName, string pswd)
        {
            if (String.IsNullOrWhiteSpace(usrName) || String.IsNullOrWhiteSpace(pswd))
            {
                throw new EmptyUsrnameOrPswd("A felhasználónév vagy jelszó mező nem lehet üres!");
            }
            //Hash
            string hashedPswd;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pswd));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hashedPswd = builder.ToString();
            }
            //Insert
            query = "INSERT INTO admins (username, password) VALUES (@usrname, @pswd);";
            c.open();
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@usrname", usrName);
            cmd.Parameters.AddWithValue("@pswd", hashedPswd);
            cmd.ExecuteNonQuery();
            c.close();
        }

        //Új termék beszúrása
        public void insertNewProd(string make, string type, string pic, string details, double price, bool lefthanded, string category, int quantity, string color)
        {
            query = "INSERT INTO products (make, type, color, category, price, details, image, lefthanded, quantity) VALUES (@make, @type, @color, @category, @price, @details, @image, @lefthanded, @quantity);";
            c.open();
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@make", make);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@image", pic);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@lefthanded", lefthanded);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.ExecuteNonQuery();
            c.close();
        }
        public void fillComboBoxCat(ComboBox cb) //új termék beillesztésénél combobox feltöltése
        {
            query = "SELECT category_name FROM categories;";
            msda = new MySqlDataAdapter(query, c.conn);
            DataTable dt = new DataTable();
            msda.Fill(dt);
            cb.DisplayMember = "category_name";
            cb.ValueMember = "category_name";
            cb.DataSource = dt;
        }

        //Új hír beszúrása
        public void insertNewNews(string title, string text, string pic)
        {
            if (String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(text))
            {
                throw new EmptyDataException("A feltöltéshez minden adatot adjon meg!");
            }
            query = "INSERT INTO news (title, text, image) VALUES (@title, @text, @pic);";
            c.open();
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@text", text);
            cmd.Parameters.AddWithValue("@pic", pic);
            cmd.ExecuteNonQuery();
            c.close();
        }

        //Rendelések datagridview betöltése
        public void fillOrders(DataGridView dataGridViewName, string filterName, DateTimePicker filterDate, int offset, int limit)
        {
            query = "SELECT o.id, u.full_name, o.details, o.address, o.order_date " +
                "FROM orders AS o, users AS u " +
                "WHERE u.id=o.user_id ";
            if (String.IsNullOrWhiteSpace(filterName) && filterDate.Checked == false) //ha nincs szűrés beállítva
            {

            }
            else if ((!String.IsNullOrWhiteSpace(filterName)) && filterDate.Checked == false) //ha csak névre akarunk szűrni
            {
                query += "AND u.full_name=@name ";
            }
            else if (String.IsNullOrWhiteSpace(filterName) && filterDate.Checked) //ha csak dátumra
            {
                query += "AND o.order_date=@date ";
            }
            else //ha mindkettőre
            {
                query += "AND u.full_name=@name AND o.order_date=@date ";
            }
            query += "LIMIT @offset,@limit;";
            msda = new MySqlDataAdapter(query, c.conn);
            msda.SelectCommand.Parameters.AddWithValue("@name", filterName);
            msda.SelectCommand.Parameters.AddWithValue("@date", filterDate.Value.Date);
            msda.SelectCommand.Parameters.AddWithValue("@limit", limit);
            msda.SelectCommand.Parameters.AddWithValue("@offset", offset);
            DataSet ds = new DataSet();
            msda.Fill(ds);
            dataGridViewName.DataSource = ds.Tables[0];
        }
        public int countOrdRows(string filterName, DateTimePicker filterDate)
        {
            int rows = 0;
            query = "SELECT COUNT(*) FROM orders;";
            if (String.IsNullOrWhiteSpace(filterName) && filterDate.Checked == false) //ha nincs szűrés beállítva
            {
                query = "SELECT COUNT(*) FROM orders;";
            }
            else if ((!String.IsNullOrWhiteSpace(filterName)) && filterDate.Checked == false) //ha csak névre akarunk szűrni
            {
                query = "SELECT COUNT(*) FROM orders AS o, users AS u WHERE o.user_id=u.id AND u.full_name=@name;";
            }
            else if (String.IsNullOrWhiteSpace(filterName) && filterDate.Checked) //ha csak dátumra
            {
                query = "SELECT COUNT(*) FROM orders AS o WHERE o.order_date=@date;";
            }
            else //ha mindkettőre
            {
                query = "SELECT COUNT(*) FROM orders AS o, users AS u WHERE o.user_id=u.id AND u.full_name=@name AND o.user_id=u.id AND u.full_name=@name AND o.order_date=@date;";
            }
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@name", filterName);
            cmd.Parameters.AddWithValue("@date", filterDate.Value.Date);
            c.open();
            var read = cmd.ExecuteReader();
            while (read.Read())
            {
                rows = int.Parse(read.GetString(0));
            }
            read.Close();
            c.close();
            return rows;
        }

        //Termék módosítás datagridview feltöltése
        public void fillModProds(DataGridView dataGridViewName, string filterMake, string filterCat, DateTimePicker filterDate, int offset, int limit)
        {
            query = "SELECT * FROM products ";
            if (String.IsNullOrWhiteSpace(filterMake) && filterCat == "Összes" && filterDate.Checked == false) //ha nincs szűrés beállítva
            {

            }
            else if ((!String.IsNullOrWhiteSpace(filterMake)) && filterCat == "Összes" && filterDate.Checked == false) //ha csak márkára akarunk szűrni
            {
                query += "WHERE make=@make ";
            }
            else if (String.IsNullOrWhiteSpace(filterMake) && ((!String.IsNullOrWhiteSpace(filterCat)) && filterCat != "Összes") && filterDate.Checked == false) //ha csak kategóriára
            {
                query += "WHERE category=@category ";
            }
            else if (String.IsNullOrWhiteSpace(filterMake) && filterCat == "Összes" && filterDate.Checked) //ha csak dátumra
            {
                query += "WHERE upload_date=@date ";
            }
            else if ((!String.IsNullOrWhiteSpace(filterMake)) && ((!String.IsNullOrWhiteSpace(filterCat)) && filterCat != "Összes") && filterDate.Checked == false) //ha csak márkára és kategóriára
            {
                query += "WHERE make=@make AND category=@category ";
            }
            else if ((!String.IsNullOrWhiteSpace(filterMake)) && filterCat == "Összes" && filterDate.Checked) //ha csak márkára és dátumra
            {
                query += "WHERE make=@make AND upload_date=@date ";
            }
            else if (String.IsNullOrWhiteSpace(filterMake) && ((!String.IsNullOrWhiteSpace(filterCat)) && filterCat != "Összes") && filterDate.Checked) //ha csak kategóriára és dátumra
            {
                query += "WHERE category=@category AND upload_date=@date ";
            }
            else //ha mindháromra
            {
                query += "WHERE category=@category AND upload_date=@date AND make=@make ";
            }
            query += "LIMIT @offset,@limit;";
            msda = new MySqlDataAdapter(query, c.conn);
            msda.SelectCommand.Parameters.AddWithValue("@make", filterMake);
            msda.SelectCommand.Parameters.AddWithValue("@category", filterCat);
            msda.SelectCommand.Parameters.AddWithValue("@date", filterDate.Value.Date);
            msda.SelectCommand.Parameters.AddWithValue("@limit", limit);
            msda.SelectCommand.Parameters.AddWithValue("@offset", offset);
            DataSet ds = new DataSet();
            msda.Fill(ds);
            dataGridViewName.DataSource = ds.Tables[0];
        }
        public int countProdRows(string filterMake, string filterCat, DateTimePicker filterDate)
        {
            int rows = 0;
            query = "SELECT COUNT(*) FROM products;";
            if (String.IsNullOrWhiteSpace(filterMake) && filterCat == "Összes" && filterDate.Checked == false) //ha nincs szűrés beállítva
            {

            }
            else if ((!String.IsNullOrWhiteSpace(filterMake)) && filterCat == "Összes" && filterDate.Checked == false) //ha csak márkára akarunk szűrni
            {
                query = "SELECT COUNT(*) FROM products WHERE make=@make;";
            }
            else if (String.IsNullOrWhiteSpace(filterMake) && ((!String.IsNullOrWhiteSpace(filterCat)) && filterCat != "Összes") && filterDate.Checked == false) //ha csak kategóriára
            {
                query = "SELECT COUNT(*) FROM products WHERE category=@category;";
            }
            else if (String.IsNullOrWhiteSpace(filterMake) && filterCat == "Összes" && filterDate.Checked) //ha csak dátumra
            {
                query = "SELECT COUNT(*) FROM products WHERE upload_date=@date;";
            }
            else if ((!String.IsNullOrWhiteSpace(filterMake)) && ((!String.IsNullOrWhiteSpace(filterCat)) && filterCat != "Összes") && filterDate.Checked == false) //ha csak márkára és kategóriára
            {
                query = "SELECT COUNT(*) FROM products WHERE make=@make AND category=@category;";
            }
            else if ((!String.IsNullOrWhiteSpace(filterMake)) && filterCat == "Összes" && filterDate.Checked) //ha csak márkára és dátumra
            {
                query = "SELECT COUNT(*) FROM products WHERE make=@make AND upload_date=@date;";
            }
            else if (String.IsNullOrWhiteSpace(filterMake) && ((!String.IsNullOrWhiteSpace(filterCat)) && filterCat != "Összes") && filterDate.Checked) //ha csak kategóriára és dátumra
            {
                query = "SELECT COUNT(*) FROM products WHERE category=@category AND upload_date=@date;";
            }
            else //ha mindháromra
            {
                query = "SELECT COUNT(*) FROM products WHERE category=@category AND upload_date=@date AND make=@make;";
            }
            cmd = new MySqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@make", filterMake);
            cmd.Parameters.AddWithValue("@category", filterCat);
            cmd.Parameters.AddWithValue("@date", filterDate.Value.Date);
            c.open();
            var read = cmd.ExecuteReader();
            while (read.Read())
            {
                rows = int.Parse(read.GetString(0));
            }
            read.Close();
            c.close();
            return rows;
        }
        public void updateProds(DataGridView dataGridViewName) //termékek frissítése
        {
            DataTable changes = ((DataTable)dataGridViewName.DataSource).GetChanges();
            if (changes != null)
            {
                MySqlCommandBuilder mscb = new MySqlCommandBuilder(msda);
                msda.UpdateCommand = mscb.GetUpdateCommand();
                msda.Update(changes);
                ((DataTable)dataGridViewName.DataSource).AcceptChanges();
            }
        }
        public void fillComboBoxProdModCat(ComboBox cb) //módosítás szűrésnél combobox feltöltése
        {
            query = "SELECT category_name FROM categories;";
            msda = new MySqlDataAdapter(query, c.conn);
            DataTable dt = new DataTable();
            msda.Fill(dt);
            dt.Rows.Add("Összes");
            cb.DisplayMember = "category_name";
            cb.ValueMember = "category_name";
            cb.DataSource = dt;
            cb.SelectedValue = "Összes";
        }
    }
}
