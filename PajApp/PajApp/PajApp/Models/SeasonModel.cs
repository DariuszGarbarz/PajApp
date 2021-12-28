using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    /// <summary>
    /// It is a model to match json data that comes from GetSeasons api
    /// </summary>
    public class SeasonModel
    {
        public string minsr { get; set; }
        public bool driverChanges { get; set; }
        public int year { get; set; }
        public CarNumberMap carNumberMap { get; set; }
        public int licgroupid { get; set; }
        public string seriesname { get; set; }
        public string whatshotimg { get; set; }
        public List<object> allowedMembers { get; set; }
        public int currentTrack { get; set; }
        public bool active { get; set; }
        public bool show_ss_standings { get; set; }
        public int driverChangeRule { get; set; }
        public int seriesid { get; set; }
        public List<Carclass> carclasses { get; set; }
        public bool isOfficial { get; set; }
        public List<Car> cars { get; set; }
        public bool restrictedByMember { get; set; }
        public bool isFixedSetup { get; set; }
        public int seasonid { get; set; }
        public string lowerseasonshortname { get; set; }
        public string rookieseason { get; set; }
        public int serieslicgroupid { get; set; }
        public int reg_open_len_mins { get; set; }
        public string prefimg { get; set; }
        public bool isRegionCompetition { get; set; }
        public bool isClubAllowed { get; set; }
        public int minlicenselevel { get; set; }
        public bool licenseEligible { get; set; }
        public int catid { get; set; }
        public string lowerseriesshortname { get; set; }
        public string seriesshortname { get; set; }
        public bool ignoreLicenseForPractice { get; set; }
        public object end { get; set; }
        public int cautionTypeRoad { get; set; }
        public string seasonshortname { get; set; }
        public int maxlicenselevel { get; set; }
        public object start { get; set; }
        public bool restrictedToCar { get; set; }
        public bool islite { get; set; }
        public int cautionTypeOval { get; set; }
        public List<Track> tracks { get; set; }
        public bool multiclass { get; set; }
        public int maxTeamDrivers { get; set; }
        public bool isWorldCup { get; set; }
        public bool restrictviewing { get; set; }
        public bool complete { get; set; }
        public int category { get; set; }
        public int raceweek { get; set; }
        public int quarter { get; set; }
        public int minTeamDrivers { get; set; }
        public HeatSesInfo heat_ses_info { get; set; }
    }

    public class CarNumberMap
    {
        public CarNumberMap carNumberMap { get; set; }
    }
}
