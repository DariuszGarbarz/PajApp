using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace PajApp.Services
{
    class WebRequestService
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
        /// Should scrap driver career from CareerStats page but for now i dont know how to load dynamic js website by httpclient. Propably i should use Selenium instead.
        /// </summary>
        /// <param name="custId"> Customer Id</param>
        public void GetDriverCareerScraper(int custId)
        {
            var driverCareerUrl = $"https://members.iracing.com/membersite/member/CareerStats.do?custid={custId}";
            HttpResponseMessage body = _httpClient.GetAsync(driverCareerUrl).Result;
            var getBody = body.Content.ReadAsStringAsync().Result;
                     
            var doc = new HtmlDocument();
            doc.LoadHtml(getBody);

            var safetyRating = doc.QuerySelector("body > table > tr:nth-child(8) > td:nth-child(2) > div > table > tr:nth-child(2) > td > div > div:nth-child(20) > div:nth-child(2) > div > div > div:nth-child(4) > div:nth-child(1)");
            //document.querySelector("body > table > tbody > tr:nth-child(8) > td:nth-child(2) > div > table > tbody > tr:nth-child(2) > td > div > div:nth-child(20) > div:nth-child(2) > div > div > div:nth-child(4) > div:nth-child(1)")
        }

    }

}
