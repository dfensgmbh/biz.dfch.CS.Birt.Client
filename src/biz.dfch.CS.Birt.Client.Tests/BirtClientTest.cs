/**
 * Copyright 2015 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Birt.Client;
using biz.dfch.CS.Birt.Client.Model;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class BirtClientTest
    {
        private BirtClient birtClient = new BirtClient(new Uri(@"http://schefdev:5000/ihub/v1"));

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void Login()
        {
            birtClient.Login();
            Assert.IsTrue(birtClient.IsLoggedIn);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetReportTemplate()
        {
            if (!birtClient.IsLoggedIn) birtClient.Login();
            Assert.IsTrue(birtClient.IsLoggedIn);
            FilesResponse f = birtClient.GetReportTemplate("114000000100");
            Assert.IsTrue(f.File.Name == "/MyCreatedReportCWI.rptdocument");
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void CreateReport()
        {
            if (!birtClient.IsLoggedIn) birtClient.Login();
            Assert.IsTrue(birtClient.IsLoggedIn);

            Hashtable paramValues = new Hashtable();
            paramValues.Add("pProduct", "Product (e.g. 1957 Chevy Pickup CWI)");
            paramValues.Add("saveOutputFile","True");
            paramValues.Add("requestedOutputFile","MyCreatedReportCWI2");
            paramValues.Add("replaceExisting","True");

            string ret = birtClient.CreateReport("904000000100", paramValues, null, "");
           // Assert.IsTrue(f.File.Name == "/MyCreatedReportCWI.rptdocument");
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void DownloadReport()
        {
            if (!birtClient.IsLoggedIn) birtClient.Login();
            Assert.IsTrue(birtClient.IsLoggedIn);

            Hashtable paramValues = new Hashtable();
            paramValues.Add("base64Encode", "True");


           
            birtClient.DownloadReport("200100000100", paramValues, null, "");
            // Assert.IsTrue(f.File.Name == "/MyCreatedReportCWI.rptdocument");
        }

        [TestMethod]
        public void GetParametersFromReportReturnsParameters()
        {
            Assert.AreEqual("parameters...", birtClient.GetParametersFromReport());
        }

        // files/ID/download


        //[TestMethod]
        //public void GetReportTemplates()
        //{
        //    birtClient.GetReportTemplates();
        //    Assert.IsTrue(birtClient.IsLoggedIn);

        //}
    }
}
