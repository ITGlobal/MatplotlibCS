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
            X = new List<object> {x};
            Y = new List<double> {y};
            MarkerSize = 5;
            Marker=Marker.Circle;
            LineStyle=LineStyle.Solid;
            LineWidth = 1;
        }

        #endregion
    }
}
