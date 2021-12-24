using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    public class OwnedContentListing
    {
        public List<int> required_pkgs { get; set; }
        public string currentversion { get; set; }
        public string JSVar { get; set; }
        public int isrequired { get; set; }
        public List<int> ids { get; set; }
        public int pkgid { get; set; }
        public bool listSeparately { get; set; }
        public bool preorder { get; set; }
        public string contenttype { get; set; }
    }
}
