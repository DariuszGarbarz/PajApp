using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    public class EnduranceModel
    {
        public int Id { get; set; }
        public string TrackName { get; set; }
        public int TrackId { get; set; }
        public DateTime Distance { get; set; }
        public char Safety { get; set; }
        public string CarName { get; set; }
        public int CarId { get; set; }
        public double AvgFuelConsumption { get; set; }
        public List<DriverModel> DriversList { get; set; }
        
        public DateTime PitLaneTime { get; set; }
        public DateTime PitFuelTime { get; set; }
        public DateTime PitTyresTime { get; set; }
        public DateTime AvgLapTime { get; set; }
        public DateTime DriverSwap { get; set; }
        public int FuelAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime OffSet { get; set; }
        

    }
}
