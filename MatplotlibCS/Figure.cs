using System.Collections.Generic;
using System.IO;
using MatplotlibCS.PlotItems;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary>
    /// Class desribing a figure to be build
    /// </summary>
    [JsonObject(Title = "figure")]
    public class Figure : IHealthCheck
    {
        #region ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="rows">Number of rows in subplots grid</param>
        /// <param name="columns">Number of columns in subplots grid</param>
        public Figure(int rows = 1, int columns = 1)
        {
            Rows = rows;
            Columns = columns;
            Subplots = new List<Axes>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Number of rows in subplots grid
        /// </summary>
        [JsonProperty(PropertyName = "rows")]
        public int Rows { get; set; } = 1;

        /// <summary>
        /// Number of columns in subplots grid
        /// </summary>
        [JsonProperty(PropertyName = "columns")]
        public int Columns { get; set; } = 1;

        /// <summary>
        /// Figuree subplots
        /// </summary>
        [JsonProperty(PropertyName = "__subplots__")]
        public List<Axes> Subplots { get; set; }

        /// <summary>
        /// Name or full path of the file where to save result
        /// </summary>
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; }

        /// <summary>
        /// If true, matplotlib window won't be shown, only image will be saved to disk
        /// </summary>
        [JsonProperty(PropertyName = "onlySaveImage")]
        public bool OnlySaveImage { get; set; }

        /// <summary>
        /// Dots per inch
        /// </summary>
        [JsonProperty(PropertyName = "dpi")]
        public int DPI { get; set; } = 300;

        /// <summary>
        /// Image width
        /// </summary>
        [JsonProperty(PropertyName = "w")]
        public int Width { get; set; } = 1920;

        /// <summary>
        /// Image height
        /// </summary>
        [JsonProperty(PropertyName = "h")]
        public int Height { get; set; } = 1080;
        
        #endregion

        public void HealthCheck()
        {
            foreach (var subplot in Subplots)
            {
                subplot.HealthCheck();
            }
        }
    }
}
