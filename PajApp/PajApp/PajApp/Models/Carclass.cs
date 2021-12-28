using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// It is a model to match json data that comes from GetSeasons api
    /// </summary>
    public class Carclass
    {
        public int relspeed { get; set; }
        public string lowername { get; set; }
        public int custid { get; set; }
        public string name { get; set; }
        public int max_dry_tire_sets { get; set; }
        public List<Carsinclass> carsinclass { get; set; }
        public int id { get; set; }
        public string shortname { get; set; }
    }
}
