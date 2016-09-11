using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
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
        /// <param name="color">Цвет линии</param>
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
        /// Название цвета
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; } = "b";

        /// <summary>
        /// Маркер точки
        /// [ '+' | ',' | '.' | '1' | '2' | '3' | '4' ]
        /// </summary>
        [JsonProperty(PropertyName = "marker")]
        public string Marker { get; set; } = "";

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
        /// [ '-' | '--' | '-.' | ':' | 'steps' | ...]
        /// </summary>
        [JsonProperty(PropertyName = "lineStyle")]
        public string LineStyle { get; set; } = "-";
        
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
