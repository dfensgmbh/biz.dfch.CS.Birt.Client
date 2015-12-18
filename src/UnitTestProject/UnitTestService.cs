using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Birt.Client;
using biz.dfch.CS.Birt.Client.Model;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestService
    {

        [TestMethod]
        public void Login()
        {
            ActuateAPI.ActuateSoapPortClient ws = new ActuateAPI.ActuateSoapPortClient();

            try
            {
                ActuateAPI.Login login = new ActuateAPI.Login();
                login.User = "Administrator";
                login.Password = "";
                login.UserSetting = true;
                login.UserSettingSpecified = true;

                ws.login(login);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}
