using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    [JsonObject(Title = "axes")]
    public class Axes
    {
        #region .ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xtitle">Title for the X axis</param>
        /// <param name="ytitle">Title for the Y axis</param>
        public Axes(string xtitle = "", string ytitle = "")
        {
            this.XTitle = xtitle;
            this.YTitle = ytitle;
            Lines = new List<Line>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Подпись к оси X
        /// </summary>
        [JsonProperty(PropertyName = "xtitle")]
        public string XTitle { get; set; }

        /// <summary>
        /// Подпись к оси Y
        /// </summary>
        [JsonProperty(PropertyName = "ytitle")]
        public string YTitle { get; set; }

        /// <summary>
        /// Линии
        /// </summary>
        [JsonProperty(PropertyName = "lines")]
        public List<Line> Lines { get; set; }

        #endregion
    }
}
