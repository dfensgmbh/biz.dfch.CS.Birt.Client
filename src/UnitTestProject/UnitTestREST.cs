using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Birt.Client;
using biz.dfch.CS.Birt.Client.Model;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestREST
    {
        private BirtClient bc = new BirtClient(new Uri(@"http://schefdev:5000/ihub/v1"));

        [TestMethod]
        public void Login()
        {
            bc.Login();
            Assert.IsTrue(bc.IsLoggedIn);
        }

        [TestMethod]
        public void GetReportTemplate()
        {
            if (!bc.IsLoggedIn) bc.Login();
            Assert.IsTrue(bc.IsLoggedIn);
            FilesResponse f = bc.GetReportTemplate("114000000100");
            Assert.IsTrue(f.File.Name == "/MyCreatedReportCWI.rptdocument");
        }

        [TestMethod]
        public void CreateReport()
        {
            if (!bc.IsLoggedIn) bc.Login();
            Assert.IsTrue(bc.IsLoggedIn);

            Hashtable paramValues = new Hashtable();
            paramValues.Add("pProduct", "Product (e.g. 1957 Chevy Pickup CWI)");
            paramValues.Add("saveOutputFile","True");
            paramValues.Add("requestedOutputFile","MyCreatedReportCWI2");
            paramValues.Add("replaceExisting","True");

            string ret = bc.CreateReport("904000000100", paramValues, null, "");
           // Assert.IsTrue(f.File.Name == "/MyCreatedReportCWI.rptdocument");
        }

        [TestMethod]
        public void DownloadReport()
        {
            if (!bc.IsLoggedIn) bc.Login();
            Assert.IsTrue(bc.IsLoggedIn);

            Hashtable paramValues = new Hashtable();
            paramValues.Add("base64Encode", "True");


           
                bc.DownloadReport("200100000100", paramValues, null, "");
            // Assert.IsTrue(f.File.Name == "/MyCreatedReportCWI.rptdocument");
        }

        // files/ID/download


        //[TestMethod]
        //public void GetReportTemplates()
        //{
        //    bc.GetReportTemplates();
        //    Assert.IsTrue(bc.IsLoggedIn);

        //}


    }
}
