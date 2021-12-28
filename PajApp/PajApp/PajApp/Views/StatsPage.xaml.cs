using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PajApp.Services;

namespace PajApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        public StatsPage()
        {
            InitializeComponent();
            DisplayAlert("DATA GATHERING", "You need to be logged in on iRacing Website to gather statistics data.", "OK");
            //WebRequestService web = new WebRequestService("", "");
            //web.Connect();
            //web.GetSeasonData();


        }
    }
}