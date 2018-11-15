using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        #region Fields

        /// <summary>
        /// Internal X values string representation
        /// </summary>
        private List<object> _x = new List<object>();

        #endregion

        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название линии</param>
        /// 
        public Line2D(string name) : base(name)
        {
            X = new List<object>();
            Y = new List<double>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Line color
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public Color Color { get; set; } = Color.Black;

        /// <summary>
        /// Color of markers edge
        /// </summary>
        [JsonProperty(PropertyName = "markeredgecolor")]
        public Color MarkerEdgeColor { get; set; } = Color.Black;
        
        /// <summary>
        /// Marker's background
        /// </summary>
        [JsonProperty(PropertyName = "markerfacecolor")]
        public Color MarkerFaceColor { get; set; }

        /// <summary>
        /// Color transparency
        /// </summary>
        [JsonProperty(PropertyName = "alpha")]
        public double Alpha { get; set; } = 1;

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
        /// Width of line
        /// </summary>
        [JsonProperty(PropertyName = "lineWidth")]
        public float LineWidth { get; set; } = 1;

        /// <summary>
        /// Width of markers edge
        /// </summary>
        [JsonProperty(PropertyName = "markeredgewidth")]
        public float MarkerEdgeWidth { get; set; } = 1;

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
        public List<object> X
        {
            get
            {
                return _x.ToList();
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    _x.Clear();
                    return;
                }

                var firstItem = value[0];

                if (firstItem is DateTime)
                {
                    _x.Clear();
                    foreach (var item in value)
                        _x.Add(((DateTime) item).ToString("yyyy-MM-ddTHH:mm:ss,ffffff"));
                }
                else if (firstItem is double || firstItem is int || firstItem is long || firstItem is float)
                {
                    _x.Clear();
                    foreach (var item in value)
                        _x.Add(item);
                }
            }
        }

        /// <summary>
        /// Данные для графика, значение
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public List<double> Y { get; set; }

        #endregion
    }
}
