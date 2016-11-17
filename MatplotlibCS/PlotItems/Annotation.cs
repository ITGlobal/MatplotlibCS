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
    /// Text with an arrow on a plot
    /// </summary>
    public class Annotation : PlotItem
    {
        public Annotation(string name, string text, double textX, double textY, double arrowX, double arrowY) : base(name)
        {
            this.Text = text;
            TextLeftCornerX = textX;
            TextLeftCornerY = textY;
            ArrowX = arrowX;
            ArrowY = arrowY;
        }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "text_x")]
        public double TextLeftCornerX { get; set; }

        [JsonProperty(PropertyName = "text_y")]
        public double TextLeftCornerY { get; set; }

        [JsonProperty(PropertyName = "arrow_x")]
        public double ArrowX { get; set; }

        [JsonProperty(PropertyName = "arrow_y")]
        public double ArrowY { get; set; }

        [JsonProperty(PropertyName = "fontSize")]
        public double FontSize { get; set; } = 12;

        [JsonProperty(PropertyName = "color")]        
        public Color Color { get; set; } = Color.Black;
    }
}
