using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// It is a model to match json data that comes from GetSeasons api
    /// </summary>
    public class Track
    {
        public string lowername { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int pkgid { get; set; }
        public int priority { get; set; }
        public int raceweek { get; set; }
        public string config { get; set; }
        public int timeOfDay { get; set; }
    }
}
