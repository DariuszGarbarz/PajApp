using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PajApp
{
    public partial class MainPage : MasterDetailPage
    {
        public ObservableCollection<Models.MenuItem> MenuPages { get; set; }
        public MainPage(ObservableCollection<Models.MenuItem> menuPages)
        {
            InitializeComponent();
            MenuPages = menuPages;
            MasterBehavior = MasterBehavior.Split;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(menuPages[0].PageType));
            this.IsPresented = false;
            menuPagesListView.ItemsSource = MenuPages;
            pajacLogo.Source = ImageSource.FromResource("PajApp.Images.pajacerka-1.gif");

        }

        private void MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuItem = e.SelectedItem as Models.MenuItem;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(menuItem.PageType));
            this.IsPresented = false;
        }
    }
}
