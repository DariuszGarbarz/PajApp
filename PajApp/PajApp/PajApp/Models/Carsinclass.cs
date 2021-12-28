using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// It is a model to match json data that comes from GetSeasons api
    /// </summary>
    public class Carsinclass
    {
        public string name { get; set; }
        public int id { get; set; }
    }
}
