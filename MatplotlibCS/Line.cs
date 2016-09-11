using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary>
    /// Описание линии графика
    /// </summary>
    [JsonObject(Title = "line")]
    public class Line
    {
        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название линии</param>
        /// <param name="color">Цвет линии</param>
        public Line(string name, string color)
        {
            Name = name;
            Color = color;
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
        public string Color { get; set; }
        
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
