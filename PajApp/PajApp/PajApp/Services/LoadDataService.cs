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

      
    }
}
