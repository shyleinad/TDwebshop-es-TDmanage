using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szakdolgozatmvpnullarol.Model;
using szakdolgozatmvpnullarol.View;
using szakdolgozatmvpnullarol.DataAccess;

namespace szakdolgozatmvpnullarol.Presenter
{
    class ConnectPresenter
    {
        Connect c = new Connect();
        IContainerForm cf;

        public ConnectPresenter(IContainerForm cf)
        {
            this.cf = cf;
        }

        public void open()
        {
            c.open();
        }
        public void close()
        {
            c.close();
        }
    }
}
