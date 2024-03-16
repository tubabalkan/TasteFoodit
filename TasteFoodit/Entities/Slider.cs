using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteFoodit.Entities
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string SliderName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}