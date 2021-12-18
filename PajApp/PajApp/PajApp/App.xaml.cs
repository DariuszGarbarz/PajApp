using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PajApp
{
    public partial class App : Application
    {
        public ObservableCollection<Models.MenuItem> MenuPages = new ObservableCollection<Models.MenuItem>();
            
        public App()
        {
            InitializeComponent();
            SetMenuItem();

            MainPage = new MainPage(MenuPages);
            var masterPage = MainPage as MainPage;
            masterPage.Detail = new NavigationPage((Page)Activator.CreateInstance(MenuPages[0].PageType));

        }

        private void SetMenuItem()
        {
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Home, "Home", typeof(Views.HomePage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Stats, "Season Statistics", typeof(Views.StatsPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Season, "My Season", typeof(Views.SeasonPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.EnduPlanner, "Endurance Planner", typeof(Views.EnduPlannerPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.SeasonPlanner, "Season Planner", typeof(Views.SeasonPlannerPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.EnduLive, "Endurance Live", typeof(Views.EnduLivePage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.SetupManager, "Setup Manager", typeof(Views.SetupManagerPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Settings, "Settings", typeof(Views.SettingPage)));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
