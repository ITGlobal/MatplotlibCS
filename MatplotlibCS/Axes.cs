using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary></summary>
    [JsonObject(Title = "axes")]
    public class Axes
    {
        #region .ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="index"></param>
        /// <param name="xtitle">Заголовок оси x</param>
        /// <param name="ytitle">Заголовок оси y</param>
        public Axes(int index = 1, string xtitle = "", string ytitle = "")
        {
            this.Index = index;
            this.XTitle = xtitle;
            this.YTitle = ytitle;
            PlotItems = new List<PlotItem>();
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
        /// Lines and other plot items
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<PlotItem> PlotItems { get; set; }

        #endregion
    }
}
