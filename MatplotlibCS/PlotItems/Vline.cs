﻿using System;
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
        /// <summary>
        /// X coord of a line
        /// </summary>
        [JsonProperty(PropertyName = "x")]
        public double[] X { get; set; }

        [JsonProperty(PropertyName = "ymin")]
        public double YMin { get; set; }

        [JsonProperty(PropertyName = "ymax")]
        public double YMax { get; set; }

        public Vline(string name, double[] x, double ymin, double ymax) : base(name)
        {
            X = x;
            YMin = ymin;
            YMax = ymax;
        }

        public Vline(string name, double x, double ymin, double ymax) : this(name, new[] { x }, ymin, ymax)
        {
        }
    }
}
