using Microsoft.VisualStudio.TestTools.UnitTesting;
using szakdolgozatmvpnullarol.DataAccess;
using szakdolgozatmvpnullarol;

namespace UnitTestTDmanage
{
    [TestClass]
    public class login_test
    {
        [TestMethod]
        public void Wrong_Login_Throws_LoginException()
        {
            string username = "someusernamethatssurelydontexist";
            string password = "whatever";
            DBops dbops = new DBops();
            Assert.ThrowsException<szakdolgozatmvpnullarol.Exceptions.LoginException>(() => dbops.logIn(username, password));
        }
    }
}
