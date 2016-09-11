using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OptionsWorkshop.Math.Helpers.Matplotlib.Protocol
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
        /// <param name="subplotsRows">Количество строк с графиками</param>
        /// <param name="subplotsColumns">Количество колонок с графиками</param>
        /// <param name="title">Заголовок окна</param>
        public Figure(int subplotsRows = 1, int subplotsColumns = 1, string title = "")
        {
            SubplotsRows = subplotsRows;
            SubplotsColumns = subplotsColumns;
            Title = title;
            Subplots = new List<Axes>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Количество строк, на которое разбивается окно
        /// </summary>
        [JsonProperty(PropertyName = "subplotRows")]
        public int SubplotsRows { get; set; }

        /// <summary>
        /// Количество колонок, на которое разбивается окно
        /// </summary>
        [JsonProperty(PropertyName = "subplotColumns")]
        public int SubplotsColumns { get; set; }

        /// <summary>
        /// Заголовок графика
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Отдельные плоты (чарты) в пределах окна
        /// </summary>
        [JsonProperty(PropertyName = "subplots")]
        public List<Axes> Subplots { get; set; }

        #endregion
    }
}
