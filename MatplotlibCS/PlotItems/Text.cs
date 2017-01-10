using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// Text label on a plot
    /// </summary>
    public class Text : PlotItem
    {
        public Text(string name, string text, double x, double y) : base(name)
        {
            this.X = x;
            this.Y = y;
            this.Value = text;
        }

        [JsonProperty(PropertyName = "text")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }

        [JsonProperty(PropertyName = "fontSize")]
        public double FontSize { get; set; } = 12;

        [JsonProperty(PropertyName = "color")]
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// Color transparency
        /// </summary>
        [JsonProperty(PropertyName = "alpha")]
        public double Alpha { get; set; } = 1;
    }
}
