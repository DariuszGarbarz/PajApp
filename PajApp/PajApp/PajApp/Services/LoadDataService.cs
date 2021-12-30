using Newtonsoft.Json;
using PajApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PajApp.Services
{
    public static class LoadDataService
    {

        /// <summary>
        /// Loads all saved drivers from json file
        /// </summary>
        /// <returns>list of drivermodels with all drivers downloaded from donor friendlist</returns>
        public static List<DriverModel> LoadDrivers()
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
            var filePath = System.IO.Path.Combine(basePath, "driversSerialized.json");

            string drivers = File.ReadAllText(filePath);
            List<DriverModel> driversDeserialized = JsonConvert.DeserializeObject<List<DriverModel>>(drivers);

            return driversDeserialized;
        }

        /// <summary>
        /// Loads all data of the current user of the app together with all content owned
        /// </summary>
        /// <returns>Member model</returns>
        public static MemberModel LoadMember()
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
            var filePath = System.IO.Path.Combine(basePath, "memberSerialized.json");

            string member = File.ReadAllText(filePath);
            MemberModel memberDeserialized = JsonConvert.DeserializeObject<MemberModel>(member);

            return memberDeserialized;
        }

        /// <summary>
        /// Loads all of Season Data with weeks, tracks and cars ect.
        /// </summary>
        /// <returns>List of Season Series</returns>
        public static List<SeasonModel> LoadSeason()
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
            var filePath = System.IO.Path.Combine(basePath, "seasonDataSerialized.json");

            string season = File.ReadAllText(filePath);
            List<SeasonModel> seasonDeserialized = JsonConvert.DeserializeObject<List<SeasonModel>>(season);

            return seasonDeserialized;
        }

    }
}
