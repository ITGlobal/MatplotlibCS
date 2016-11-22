using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    public class Hline : Line2D
    {
        /// <summary>
        /// Y coord of a line
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public double[] Y { get; set; }

        [JsonProperty(PropertyName = "xmin")]
        public double XMin { get; set; }

        [JsonProperty(PropertyName = "xmax")]
        public double XMax { get; set; }

        public Hline(string name, double[] y, double xmin, double xmax) : base(name)
        {
            Y = y;
            XMin = xmin;
            XMax = xmax;
            ShowLegend = false;
        }

        public Hline(string name, double y, double xmin, double xmax) : this(name, new[] { y }, xmin, xmax)
        {
            ShowLegend = false;
        }
    }
}
