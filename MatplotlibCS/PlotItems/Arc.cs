using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// An arc, segment of an ellipse
    /// </summary>
    public class Arc : Line2D
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="x">Center x coord</param>
        /// <param name="y">Center y coord</param>
        /// <param name="width">Width along x axis</param>
        /// <param name="height">Height along y axis</param>
        /// <param name="angle">rotation in degrees (anti-clockwise)</param>
        /// <param name="theta1">starting angle of the arc in degrees</param>
        /// <param name="theta2">ending angle of the arc in degrees</param>
        public Arc(string name, double x, double y, double width, double height, double angle, double theta1, double theta2):base(name)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Angle = angle;
            Theta1 = theta1;
            Theta2 = theta2;
            ShowLegend = false;
        }

        /// <summary>
        /// Center x coord
        /// </summary>
        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }

        /// <summary>
        /// Center y coord
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }

        /// <summary>
        /// Width along x axis
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public double Width { get; set; }

        /// <summary>
        /// Height along y axis
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        /// <summary>
        /// rotation in degrees (anti-clockwise)
        /// </summary>
        [JsonProperty(PropertyName = "angle")]
        public double Angle { get; set; }

        /// <summary>
        /// starting angle of the arc in degrees
        /// </summary>
        [JsonProperty(PropertyName = "theta1")]
        public double Theta1 { get; set; }

        /// <summary>
        /// ending angle of the arc in degrees
        /// </summary>
        [JsonProperty(PropertyName = "theta2")]
        public double Theta2 { get; set; }
    }
}
