using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public class Planet
    {
        public Planet()
        {

        }
        public string id { get; set; }
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public IList<string> films { get; set; }
        public IList<string> residents { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
