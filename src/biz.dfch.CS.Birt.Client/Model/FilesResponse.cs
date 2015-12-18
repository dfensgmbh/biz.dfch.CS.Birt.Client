using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biz.dfch.CS.Birt.Client.Model
{
    public class FilesResponse
    {
        public File File {get; set;}
        public ACL ACL { get; set; }
        public ArchiveRules ArchiveRules { get; set; }

 //"File": {
 //   "Id": "114000000100",
 //   "Name": "/MyCreatedReportCWI.rptdocument",
 //   "FileType": "RPTDOCUMENT",
 //   "PageCount": "1",
 //   "Size": "426188",
 //   "TimeStamp": "2015-12-17T15:25:19.000Z",
 //   "Version": "1",
 //   "Owner": "Administrator"
 // },
 // "ACL": {},
 // "ArchiveRules": {}

      
    }
}
