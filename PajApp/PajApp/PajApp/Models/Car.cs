using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// It is a model to match json data that comes from GetSeasons api
    /// </summary>
    public class Car
    {
        public string lowername { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int pkgid { get; set; }
        public int sku { get; set; }
    }
}
