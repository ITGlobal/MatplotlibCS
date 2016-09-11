using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OptionsWorkshop.Math.Helpers.Matplotlib.Protocol
{
    [JsonObject(Title = "axes")]
    public class Axes
    {
        #region .ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="xtitle">Заголовок оси x</param>
        /// <param name="ytitle">Заголовок оси y</param>
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
