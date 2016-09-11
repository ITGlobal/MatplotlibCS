using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    public class Histogram : PlotItem
    {

        /// <summary>
        /// Данные для графика, аргумент
        /// </summary>
        [JsonProperty(PropertyName = "x")]
        public List<double> X { get; set; }

        /// <summary>
        /// Данные для графика, значение
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public List<double> Y { get; set; }
    }
}
