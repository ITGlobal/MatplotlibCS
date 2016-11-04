using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    public class Hline : PlotItem
    {
        /// <summary>
        /// Y coord of a line
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }
    }
}
