using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// Class made to match API json result from GetMember iRacing website api
    /// </summary>
    public class Helmet
    {
        public string c3 { get; set; }
        public int ll { get; set; }
        public int hp { get; set; }
        public int ht { get; set; }
        public string c1 { get; set; }
        public int ft { get; set; }
        public string c2 { get; set; }
    }
}
