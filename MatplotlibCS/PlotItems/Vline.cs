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
    public class Vline : PlotItem
    {
        /// <summary>
        /// X coord of a line
        /// </summary>
        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }
    }
}
