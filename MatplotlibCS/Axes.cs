using System;
using System.Collections.Generic;
using System.Linq;
using MatplotlibCS.PlotItems;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary></summary>
    [JsonObject(Title = "axes")]
    public class Axes : IHealthCheck
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
            Grid = new Grid();
            PlotItems = new List<PlotItem>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Заголовок осей
        /// </summary>
        [JsonProperty(PropertyName = "title", DefaultValueHandling = DefaultValueHandling.Include)]
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
        /// Plot grid settings
        /// </summary>
        [JsonProperty(PropertyName = "grid")]
        public Grid Grid { get; set; }

        [JsonProperty(PropertyName = "show_legend")]
        public bool ShowLegend { get; set; } = true;

        [JsonProperty(PropertyName = "legend_location")]
        public LegendLocation LegendLocation { get; set; } = LegendLocation.Best;

        [JsonProperty(PropertyName = "frameon")]
        public bool LegendBorder { get; set; } = true;

        /// <summary>
        /// Lines and other plot items. Never add items to this list directly, only set the list itself. For adding/removing
        /// items use AddItem/RemoveItem methods
        /// </summary>
        [JsonProperty(PropertyName = "__items__")]
        public List<PlotItem> PlotItems { get; set; }
        
        #endregion

        #region Indexers

        /// <summary>
        /// Returnts first plot item by its name
        /// </summary>
        /// <param name="name">Name of an item</param>
        /// <returns></returns>
        public PlotItem this[string name]
        {
            get { return PlotItems.FirstOrDefault(_ => _.Name == name); }
        }

        #endregion

        public void HealthCheck()
        {
            Grid.HealthCheck();

            foreach (var plotItem in PlotItems)
            {
                plotItem.HealthCheck();
            }
        }
    }

    /// <summary>
    /// Defines where a legend will be located on a chart
    /// </summary>
    public enum LegendLocation
    {
        Best,
        UpperRight,
        UpperLeft,
        LowerLeft,
        LowerRight,
        Right,
        CenterLeft,
        CenterRight,
        LowerCenter,
        UpperCenter,
        Center
    }
}

