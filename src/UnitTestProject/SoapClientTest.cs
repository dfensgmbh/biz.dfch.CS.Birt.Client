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
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class SoapClientTest
    {
        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void Login()
        {
            ActuateAPI.ActuateSoapPortClient ws = new ActuateAPI.ActuateSoapPortClient();

            ActuateAPI.Login login = new ActuateAPI.Login();
            login.User = "Administrator";
            login.Password = "";
            login.UserSetting = true;
            login.UserSettingSpecified = true;

            ws.login(login);
        }
    }
}
