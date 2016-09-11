using System.Collections.Generic;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary>
    /// Описание окна с графиками
    /// </summary>
    [JsonObject(Title = "figure")]
    public class Figure
    {
        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rows">Количество строк с графиками</param>
        /// <param name="columns">Количество колонок с графиками</param>
        public Figure(int rows = 1, int columns = 1)
        {
            Rows = rows;
            Columns = columns;
            Subplots = new List<Axes>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Количество строк, на которое разбивается окно
        /// </summary>
        [JsonProperty(PropertyName = "rows")]
        public int Rows { get; set; } = 1;

        /// <summary>
        /// Количество колонок, на которое разбивается окно
        /// </summary>
        [JsonProperty(PropertyName = "columns")]
        public int Columns { get; set; } = 1;
        
        /// <summary>
        /// Отдельные плоты (чарты) в пределах окна
        /// </summary>
        [JsonProperty(PropertyName = "subplots")]
        public List<Axes> Subplots { get; set; }

        /// <summary>
        /// Имя файла, в который нужно сохранить графики
        /// </summary>
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; }

        #endregion
    }
}
