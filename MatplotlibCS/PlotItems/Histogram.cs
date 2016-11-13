﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    /// <summary></summary>
    public class Histogram : PlotItem
    {
        #region Properties

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

        #endregion

        #region .ctor

        public Histogram(string name) : base(name) { }

        #endregion
    }
}
