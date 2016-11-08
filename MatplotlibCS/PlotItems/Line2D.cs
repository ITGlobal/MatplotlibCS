using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// Описание линии графика
    /// </summary>
    [JsonObject(Title = "line")]
    public class Line2D : PlotItem
    {
        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название линии</param>
        /// 
        public Line2D(string name)
        {
            Name = name;
            X = new List<double>();
            Y = new List<double>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Название линии
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Line color
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// Маркер точки
        /// </summary>
        [JsonProperty(PropertyName = "marker")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Marker Marker { get; set; } = Marker.None;

        /// <summary>
        /// Размер маркера
        /// </summary>
        [JsonProperty(PropertyName = "markerSize")]
        public float MarkerSize { get; set; } = 1;

        /// <summary>
        /// Толщина линии
        /// </summary>
        [JsonProperty(PropertyName = "lineWidth")]
        public float LineWidth { get; set; } = 1;
        
        /// <summary>
        /// Маркер точки
        /// </summary>
        [JsonProperty(PropertyName = "lineStyle")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LineStyle LineStyle { get; set; } = LineStyle.Solid;

        /// <summary>
        /// e.g., if Markevery=5, every 5-th marker will be plotted.
        /// </summary>
        [JsonProperty(PropertyName = "markevery")]
        public int Markevery { get; set; } = 1;

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
    }
}
