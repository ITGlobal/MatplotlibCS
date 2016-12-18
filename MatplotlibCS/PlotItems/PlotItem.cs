using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// Базовый класс для элементов, которые отрисовываются на графике
    /// </summary>
    public abstract class PlotItem : IHealthCheck
    {
        #region Properties

        /// <summary>
        /// Name of the type of the plot item (line, histogram, text etc
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type => GetType().Name;

        /// <summary>
        /// Unique (within axes) name of a plot item
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Optional fields which can be used to filter plot items. For example, one can precreate all plot items and then save several images with 
        /// different visible items, be setting IsVisible property
        /// </summary>
        public string Tags { get; set; } = "";

        /// <summary>
        /// If false, item will not be drawn
        /// </summary>
        [JsonProperty(PropertyName = "is_visible")]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Whether to show this item in legend
        /// </summary>
        [JsonProperty(PropertyName = "show_legend")]
        public bool ShowLegend { get; set; } = true;

        #endregion

        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="name">Unique name of a plot item</param>
        protected PlotItem(string name)
        {
            Name = name;
        }

        #endregion

        public virtual void HealthCheck()
        {
        }
    }
}
