using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS.PlotItems;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS
{
    /// <summary>
    /// Class describes a grid settings on a plot
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Which grids to show on a plot
        /// </summary>
        [JsonProperty(PropertyName = "which")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GridWhich Which { get; set; } = GridWhich.Both;

        [JsonProperty(PropertyName = "x_lim")]
        public double[] XLim { get; set; }

        [JsonProperty(PropertyName = "y_lim")]
        public double[] YLim { get; set; }

        [JsonProperty(PropertyName = "minor_alpha")]
        public double MinorAlpha { get; set; } = 0.3;

        [JsonProperty(PropertyName = "major_alpha")]
        public double MajorAlpha { get; set; } = 0.7;

        [JsonProperty(PropertyName = "on")]
        public string On { get; set; } = "on";

        [JsonProperty(PropertyName = "x_major_ticks")]
        public double[] XMajorTicks { get; set; }

        [JsonProperty(PropertyName = "y_major_ticks")]
        public double[] YMajorTicks { get; set; }

        [JsonProperty(PropertyName = "x_minor_ticks")]
        public double[] XMinorTicks { get; set; }

        [JsonProperty(PropertyName = "y_minor_ticks")]
        public double[] YMinorTicks { get; set; }
    }

    
}
