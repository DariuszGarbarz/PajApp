using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// It is a model to match json data that comes from GetSeasons api
    /// </summary>
    public class HeatSesInfo
    {
        public int consol_first_mins { get; set; }
        public int main_mins { get; set; }
        public int qual_mins { get; set; }
        public int consol_num_to_invert { get; set; }
        public int consol_first_laps { get; set; }
        public int max_entrants { get; set; }
        public int consol_num_to_consol { get; set; }
        public int qual_style { get; set; }
        public int qual_num_to_main { get; set; }
        public int heat_num_to_main { get; set; }
        public int heat_mins { get; set; }
        public int main_num_to_invert { get; set; }
        public int consol_num_to_main { get; set; }
        public int heat_laps { get; set; }
        public int heat_max_field { get; set; }
        public int qual_laps { get; set; }
        public int main_laps { get; set; }
        public int main_max_field { get; set; }
        public int heat_num_to_invert { get; set; }
        public int consol_first_max_field { get; set; }
    }
}
