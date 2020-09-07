using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szakdolgozatmvpnullarol.DataAccess
{
    public class EmptyUsrnameOrPswd : Exception
    {
        public EmptyUsrnameOrPswd()
        {
        }
        public EmptyUsrnameOrPswd(string message) : base(message)
        {
        }
        public EmptyUsrnameOrPswd(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
