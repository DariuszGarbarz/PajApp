using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PajApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            pajacLogo.Source = ImageSource.FromResource("PajApp.Images.pajacerka-1.gif");
            DisplayAlert("DATA GATHERING", "You need to be logged in on iRacing Website to gather statistics data.", "OK");
        }
    }
}
