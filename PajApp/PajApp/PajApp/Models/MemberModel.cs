using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// Class made to match API json result from GetMember iRacing website api, it includes License and Helmet models
    /// </summary>
    public class MemberModel
    {
        public int Id { get; set; }
        public List<List<int>> OwnedCars { get; set; }
        public List<List<int>> OwnedTracks { get; set; }


        public string readTC { get; set; }
        public List<License> licenses { get; set; }
        public string readPP { get; set; }
        public bool hasReadPP { get; set; }
        public bool success { get; set; }
        public string displayName { get; set; }
        public Helmet helmet { get; set; }
        public List<object> allowedSeasons { get; set; }
        public int custID { get; set; }
        public bool hasReadTC { get; set; }

    }
}
