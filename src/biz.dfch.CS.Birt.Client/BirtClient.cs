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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using biz.dfch.CS.Activiti.Client;
using System.Collections;
using biz.dfch.CS.Birt.Client.Model;
using Newtonsoft.Json;

namespace biz.dfch.CS.Birt.Client
{
    public class BirtClient
    {
        // API: See document mail... and http://localhost:5000/ihub/v1/ihubrestdocs/#!/visuals/getReportParameters

        #region Private variables

        private string authId = "";
        RestClient rc = null;

        #endregion

        #region "Constructors"

        public BirtClient(Uri uri)
        {
            rc = new RestClient(uri);
        }

        #endregion

        #region public Methods

        public void Login()
        {
            string username = "administrator";
            string pw = "";
            Contract.Requires(rc != null);
            Contract.Requires(!string.IsNullOrEmpty(this.authId));

            Hashtable parameters = new Hashtable();
            parameters.Add("username", username);
            if (!string.IsNullOrEmpty(pw)) parameters.Add("password", pw);
            var response = rc.Invoke("POST", "login", parameters, null, "");
            Auth result = JsonConvert.DeserializeObject<Auth>(response);
            this.authId = result.AuthId;
        }

        #endregion

        #region Public Methods


        public List<string> GetReportTemplates()
        {
            Contract.Assume(!string.IsNullOrEmpty(authId));
            List<string> templates = new List<string>();

            return templates;
        }

        public FilesResponse GetReportTemplate(string fileId)
        {
            Contract.Requires(rc != null);
            Contract.Requires(!string.IsNullOrEmpty(this.authId));

            Hashtable headers = new Hashtable();
            headers.Add("authId", this.authId);

            var response = rc.Invoke("GET", "files/" + fileId, null, headers, "");
            FilesResponse result = JsonConvert.DeserializeObject<FilesResponse>(response);
            return result;
        }

        public void UploadReportTemplate(string fileNameRptDesign, string folder)
        {

        }

        public void DownloadReportTemplate(string fileName)
        {

        }

        public string GetParametersFromReport()
        {
            return "parameters...";
        }

        public string CreateReport(string reportTemplateId, List<string> parameters, object data, string output)
        {
            string documentId = "";
            return documentId;
        }


        public string CreateReport(string visualId, Hashtable paramValues, object data, string output)
        {
            Contract.Requires(rc != null);
            Contract.Requires(!string.IsNullOrEmpty(this.authId));

            Hashtable headers = new Hashtable();
            headers.Add("authId", this.authId);


            var response = rc.Invoke("GET", "visuals/" + visualId + "/execute", null, headers, "");
            VisualsResponse result = JsonConvert.DeserializeObject<VisualsResponse>(response);
            return "";
        }

       async public void DownloadReport(string fileId, Hashtable paramValues, object data, string output)
        {
            Contract.Requires(rc != null);
            Contract.Requires(!string.IsNullOrEmpty(this.authId));

            Hashtable headers = new Hashtable();
            headers.Add("authId", this.authId);
            headers.Add("Accept-Encoding", "gzip, deflate");
       
            var response = rc.Invoke("GET", "files/" + fileId + "/download", paramValues, headers, "");
            VisualsResponse result = JsonConvert.DeserializeObject<VisualsResponse>(response);
        }
        #endregion

       #region Properties

       public bool IsLoggedIn
        {
            get
            {
                return !string.IsNullOrEmpty(this.authId);
            }
        }

       #endregion
    }


    //Parameter eines reports holen:	http://schefdev:5000/ihub/v1/visuals/904000000100/parameters?authId=ZAfL0Wcw7UE3%2BS2rUMx5j%2FryRVuS2uWI1o5w4abWk3En76upKbQPM5IkDtDe7%2FGOrN9Tjx1TYA5%2FpNI6XjhNjzHU1F%2FVtcUAvUCfqbtHkzskbYfFy8mMa50ZGkWWeJ5xGarbxCfqc6L5ZKte8WIlv9jfK8WRodspfOXduzQVnMPysfJLhsR3KqT%2FpyM4QW%2BiTHzBghWGJzOvKCoek66V0MwGpgNDnPae0ugTNmHx094NIcTIRCFrskKzlAZgq38jVuAXNn41NpX8pEmcCWst%2BEaLWZw5DPOOKivbln8EB3NLxecwGv%2B9MTa2MUBsFwfuBRWmDFhgBJGdvPFusAF1ioPKEKeaXQP5RO1ScSNRGLNftnOf%2FrorTvoxu6DH7mGv
    //        {
    //  "ParameterList": {
    //    "ParameterDefinition": [
    //      {
    //        "Name": "pProduct",
    //        "Position": 0,
    //        "DataType": "String",
    //        "DefaultValue": {},
    //        "IsRequired": true,
    //        "IsPassword": false,
    //        "IsHidden": false,
    //        "DisplayName": "Product (e.g. 1957 Chevy Pickup)",
    //        "IsAdHoc": false,
    //        "ControlType": "AutoSuggest",
    //        "DataSourceType": "ABInfoObject",
    //        "CascadingParentName": {},
    //        "HelpText": "Product examples are: 1903 Ford Model A, 1957 Chevy Pickup, 1968 Ford Mustang",
    //        "IsViewParameter": false,
    //        "IsDynamicSelectionList": true,
    //        "AutoSuggestThreshold": 2,
    //        "DefaultValueIsNull": true
    //      }
    //    ]
    //  }
    //}





    // Report erstellen:
    //        POST http://schefdev:5000/ihub/v1/visuals/904000000100/execute HTTP/1.1
    //Accept: application/json
    //Content-Type: application/x-www-form-urlencoded
    //Referer: http://localhost:5000/ihub/v1/ihubrestdocs/
    //Accept-Language: de-CH
    //Origin: http://localhost:5000
    //Accept-Encoding: gzip, deflate
    //User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko
    //Host: schefdev:5000
    //Content-Length: 579
    //DNT: 1
    //Connection: Keep-Alive
    //Pragma: no-cache

    //authId=ZAfL0Wcw7UE3%2BS2rUMx5j%2FryRVuS2uWI1o5w4abWk3En76upKbQPM5IkDtDe7%2FGOrN9Tjx1TYA5%2FpNI6XjhNjzHU1F%2FVtcUAvUCfqbtHkzskbYfFy8mMa50ZGkWWeJ5xGarbxCfqc6L5ZKte8WIlv9jfK8WRodspfOXduzQVnMPysfJLhsR3KqT%2FpyM4QW%2BiTHzBghWGJzOvKCoek66V0MwGpgNDnPae0ugTNmHx094NIcTIRCFrskKzlAZgq38jVuAXNn41NpX8pEmcCWst%2BEaLWZw5DPOOKivbln8EB3NLxecwGv%2B9MTa2MUBsFwfuBRWmDFhgBJGdvPFusAF1ioPKEKeaXQP5RO1ScSNRGLNftnOf%2FrorTvoxu6DH7mGv&paramValues=%7B%20%22ParameterValue%22%20%3A%20%5B%7B%22Name%22%20%3A%20%22pProduct%22%2C%20%22Value%22%20%3A%20%22Product%20(e.g.%201957%20Chevy%20Pickup)%22%7D%5D%7D

}
