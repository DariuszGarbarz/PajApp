using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// Class made to match API json result from GetMember iRacing website api
    /// </summary>
    public class License
    {
        public int licGroup { get; set; }
        public int licLevel { get; set; }
        public string srSub { get; set; }
        public object ttRating { get; set; }
        public int true_iRating { get; set; }
        public int mprNumRaces { get; set; }
        public object iRating { get; set; }
        public int catId { get; set; }
        public string srPrime { get; set; }
        public string licLevelDisplayName { get; set; }
        public int mprNumTTs { get; set; }
        public string licColor { get; set; }
        public int subLevel { get; set; }
        public string licGroupDisplayName { get; set; }
    }
}
