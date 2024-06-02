using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyProject.Models
{
    public class CityView
    {
        public List<City>? Cities { get; set; }
        public List<City>? Names { get; set; }
        public string? NameCity { get; set; }
        public string? SearchString { get; set; }
    }
}
