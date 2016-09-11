using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
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
            Lines = new List<PlotItem>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Заголовок осей
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

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
        /// Индекс subplot-а на figure
        /// </summary>
        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; } = 1;

        /// <summary>
        /// Линии
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<PlotItem> Lines { get; set; }

        #endregion
    }
}
