using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szakdolgozatmvpnullarol.Model
{
    class User
    {
        private string usrName; private string pswd;
        public string getusrName { get { return usrName; } } public string getPswd { get { return usrName; } }

        public User(string usrName, string pswd)
        {
            this.usrName = usrName; this.pswd = pswd;
        }
    }
}
