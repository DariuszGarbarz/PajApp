using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    public class DriverModel
    {
        public int Id { get; set; }
        public int CustId { get; set; }
        public string DisplayName { get; set; }
        public char SafetyLetter { get; set; }
        public string SafetyRating { get; set; }
        public int IRating { get; set; }

    }
}
