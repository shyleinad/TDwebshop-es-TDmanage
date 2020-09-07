using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using szakdolgozatmvpnullarol;
using szakdolgozatmvpnullarol.DataAccess;

namespace UnitTestTDmanage
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Wrong_Login()
        {
            string username = "ausernamethatssurelydontexest";
            string password = "whatever";
            DBops dbops = new DBops();
            Assert.ThrowsException<szakdolgozatmvpnullarol.Exceptions.LoginException>(() => dbops.logIn(username, password));
        }

        [TestMethod]
        public void Right_Login()
        {
            string username = "dolgozo";
            string password = "dolgozo";
            DBops dbops = new DBops();
            dbops.logIn(username, password);
        }
    }
}
