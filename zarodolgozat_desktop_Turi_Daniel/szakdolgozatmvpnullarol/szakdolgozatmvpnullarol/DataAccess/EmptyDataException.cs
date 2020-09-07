using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szakdolgozatmvpnullarol.DataAccess
{
    class EmptyDataException : Exception
    {
        public EmptyDataException()
        {
        }
        public EmptyDataException(string message) : base(message)
        {
        }
        public EmptyDataException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
