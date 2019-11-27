using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public enum MenuItemType
    {
        People,
        Planets,
        Species
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
