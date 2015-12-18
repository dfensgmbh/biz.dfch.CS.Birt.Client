using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biz.dfch.CS.Birt.Client.Model
{
    public class File
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public long PageCount { get; set; }
        public long Size { get; set; }
        public DateTime TimeStamp { get; set; }
        public long Version { get; set; }
        public string Owner { get; set; }
    }
}
