using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// 2D point on a chart
    /// </summary>
    [JsonObject(Title = "point")]
    public class Point2D : Line2D
    {
        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название линии</param>
        /// 
        public Point2D(string name, double x, double y) : base(name)
        {
            X = new List<double> {x};
            Y = new List<double> {y};
        }

        #endregion

        #region Properties

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
