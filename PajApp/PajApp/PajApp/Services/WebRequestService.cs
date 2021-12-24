using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using PajApp.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace PajApp.Services
{
    public class WebRequestService
    {
        private HttpClient _httpClient;
        private string _userName;
        private string _password;


        public WebRequestService(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }
        
        /// <summary>
        /// Tries to connect to iRacing Website using dictionary as a Payload of POST request to the Login page. Keeps cookies in http client.
        /// </summary>
        /// <returns>Is connection Successful?</returns>
        public bool Connect()
        {
            _httpClient = new HttpClient();

            var dict = new Dictionary<string, string>();
            dict.Add("username", _userName);
            dict.Add("password", _password);
            dict.Add("utcoffset", "-60");
            dict.Add("todaysdate", "");

            var uri = new Uri("https://members.iracing.com/membersite/Login");

            var content = new FormUrlEncodedContent(dict);
            HttpResponseMessage response = _httpClient.PostAsync(uri, content).Result;

            if (response != null && response.Headers != null)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Scraping javascript that contains info about owned content - "var ownedcontentlisting", For now i have no idea how to extract this data through javascript to json.
        /// </summary>
        /// 
        public void GetOwnedContentListing()
        {
            var driverCareerUrl = $"https://members.iracing.com/membersite/member/Tracks.do?forceload=owned";
            HttpResponseMessage body = _httpClient.GetAsync(driverCareerUrl).Result;
            var getBody = body.Content.ReadAsStringAsync().Result;
                     
            var doc = new HtmlDocument();
            doc.LoadHtml(getBody);

            var ownedContentListing = doc.QuerySelector("head > script:nth-child(40)");
    
        }

        /// <summary>
        /// Keepeing api URLs so i would not forget them through digging through iracing network communication
        /// </summary>
       // private static void ApiUrlKeeper()
       // {
            //get season schedule, a lot of info, could be used for seasopn planner
            //string getSeason = "https://members.iracing.com/membersite/member/GetSeasons"
            //gets all races and practices, can use it to pick owned cars and tracks
            //string getSeriesResult = "https://members.iracing.com/memberstats/member/SearchSeriesResults?custid=360858&seasonyear=2022&seasonquarter=1"
            //Get Driver stats by custId friends, gives back json response
            //string getDriverStats = "https://members.iracing.com/memberstats/member/GetDriverStats?search=null&friend=360858&watched=-1&recent=-1&country=null&category=2&classlow=-1&classhigh=-1&iratinglow=-1&iratinghigh=-1&ttratinglow=-1&ttratinghigh=-1&avgstartlow=-1&avgstarthigh=-1&avgfinishlow=-1&avgfinishhigh=-1&avgpointslow=-1&avgpointshigh=-1&avgincidentslow=-1&avgincidentshigh=-1&custid=360858&lowerbound=1&upperbound=25&sort=irating&order=desc&active=1";
       // }

        /// <summary>
        /// Get drivers stats based on custId friends, picks data for DriverModel. Saves all driver in json file
        /// </summary>
        /// <param name="custId">Customer Id for friends list</param>
        /// <returns>List of Drivers</returns>
        public List<DriverModel> GetDriverStats(int custId)
        {
            string getDriverStats = $"https://members.iracing.com/memberstats/member/GetDriverStats?search=null&friend={custId}&watched=-1&recent=-1&country=null&category=2&classlow=-1&classhigh=-1&iratinglow=-1&iratinghigh=-1&ttratinglow=-1&ttratinghigh=-1&avgstartlow=-1&avgstarthigh=-1&avgfinishlow=-1&avgfinishhigh=-1&avgpointslow=-1&avgpointshigh=-1&avgincidentslow=-1&avgincidentshigh=-1&custid={custId}&lowerbound=1&upperbound=25&sort=irating&order=desc&active=1";

            HttpResponseMessage response2 = _httpClient.GetAsync(getDriverStats).Result;
            var getResultsJson = response2.Content.ReadAsStringAsync().Result;

            JObject o = JObject.Parse(getResultsJson);

            var result = new List<DriverModel>();

            try
            {
                var numberOfDrivers = int.Parse(o["d"]["20"].ToString());

                for (int i = 1; i < numberOfDrivers; i++)
                {
                    var driver = new DriverModel();
                    
                    driver.CustId = int.Parse(o["d"]["r"][i]["34"].ToString());
                    driver.DisplayName = o["d"]["r"][i]["32"].ToString();
                    driver.SafetyLetter = char.Parse(o["d"]["r"][i]["39"].ToString());
                    driver.SafetyRating = o["d"]["r"][i]["16"].ToString();
                    driver.IRating = int.Parse(o["d"]["r"][i]["3"].ToString());

                    result.Add(driver);
                }
            }
            catch { }

            try
            {
                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
                var filePath = System.IO.Path.Combine(basePath, "driversSerialized.json");

                string driversSerialized = JsonConvert.SerializeObject(result);
                File.WriteAllText(filePath, driversSerialized);
            }

            catch
            {
                //UnauthorizedAccessException
            }

            return result;
        }

        /// <summary>
        /// Get user data and stores it in json file for later use.
        /// </summary>
        /// <returns>data in DriverModel</returns>
        public MemberModel GetMemberStats()
        {
            string getMemberStats = "https://members.iracing.com/membersite/member/GetMember";

            HttpResponseMessage response = _httpClient.GetAsync(getMemberStats).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

         
            var memberResult = JsonConvert.DeserializeObject<MemberModel>(getResultsJson);

            // Now its time to get owned content data and apply it into memberresult
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
            var filePath = System.IO.Path.Combine(basePath, "memberContentSerialized.json");
            
            string ownedContent = File.ReadAllText(filePath);

            var contentDeserialized = JsonConvert.DeserializeObject<List<OwnedContentListing>>(ownedContent);

            memberResult.OwnedCars = new List<List<int>>();
            memberResult.OwnedTracks = new List<List<int>>();

            try
            {
                var numberOfContent = contentDeserialized.Count;

                for (int i = 0; i < numberOfContent; i++)
                {
                    if (contentDeserialized[i].isrequired == 0 && contentDeserialized[i].contenttype == "c")
                    {
                        memberResult.OwnedCars.Add(contentDeserialized[i].ids);
                    }

                    if (contentDeserialized[i].isrequired == 0 && contentDeserialized[i].contenttype == "t")
                    {
                        memberResult.OwnedTracks.Add(contentDeserialized[i].ids);
                    }
                }
            }
            catch { }

            string memberSerialized = JsonConvert.SerializeObject(memberResult);

            try
            {
                basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
                filePath = System.IO.Path.Combine(basePath, "memberSerialized.json");


                File.WriteAllText(filePath, memberSerialized);
            }

            catch
            {
                //UnauthorizedAccessException
            }




            return memberResult;

        }

    }

}
