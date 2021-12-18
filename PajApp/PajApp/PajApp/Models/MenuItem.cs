using System;
using System.Collections.Generic;
using System.Text;

namespace PajApp.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public Type PageType { get; set; }
        public MenuItemType Type { get; set; }

        protected MenuItem()
        {

        }

        public MenuItem(MenuItemType menuType, string title, Type pageType) : this()
        {
            Type = menuType;
            Title = title;
            PageType = pageType;
        }
    }

    public enum MenuItemType
    {
        Home,
        Stats,
        Season,
        EnduPlanner,
        SeasonPlanner,
        EnduLive,
        SetupManager,
        Settings

    }
}
