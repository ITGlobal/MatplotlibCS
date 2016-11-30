using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// Vertical line
    /// </summary>
    public class Vline : Line2D
    {
        [JsonProperty(PropertyName = "ymin")]
        public double YMin { get; set; }

        [JsonProperty(PropertyName = "ymax")]
        public double YMax { get; set; }

        public Vline(string name, object[] x, double ymin, double ymax) : base(name)
        {
            X = x.ToList();
            YMin = ymin;
            YMax = ymax;
            ShowLegend = false;
        }
    }
}
