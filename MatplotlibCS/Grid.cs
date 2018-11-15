using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS.PlotItems;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS
{
    /// <summary>
    /// Class describes a grid settings on a plot
    /// </summary>
    public class Grid : IHealthCheck
    {
        #region Fields

        /// <summary>
        /// Internal time ticks string representation
        /// </summary>
        private List<object> _x;

        #endregion

        /// <summary>
        /// Which grids to show on a plot
        /// </summary>
        [JsonProperty(PropertyName = "which")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GridWhich Which { get; set; } = GridWhich.Both;

        [JsonProperty(PropertyName = "x_lim")]
        public double[] XLim { get; set; }

        [JsonProperty(PropertyName = "y_lim")]
        public double[] YLim { get; set; }

        [JsonProperty(PropertyName = "minor_alpha")]
        public double MinorAlpha { get; set; } = 0.3;

        [JsonProperty(PropertyName = "major_alpha")]
        public double MajorAlpha { get; set; } = 0.7;

        [JsonProperty(PropertyName = "on")]
        public string On { get; set; } = "on";

        [JsonProperty(PropertyName = "x_major_ticks")]
        public double[] XMajorTicks { get; set; }

        [JsonProperty(PropertyName = "y_major_ticks")]
        public double[] YMajorTicks { get; set; }

        [JsonProperty(PropertyName = "x_minor_ticks")]
        public double[] XMinorTicks { get; set; }

        [JsonProperty(PropertyName = "y_minor_ticks")]
        public double[] YMinorTicks { get; set; }

        [JsonProperty(PropertyName = "x_time_ticks")]
        public List<object> XTimeTicks
        {
            get
            {
                return _x;
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
                    if(_x == null)
                        _x = new List<object>();

                    _x.Clear();
                    foreach (var item in value)
                        _x.Add(((DateTime)item).ToString("yyyy-MM-ddTHH:mm:ss,ffffff"));
                }
                else 
                    throw new ArgumentException("XTimeTicks must be set with List<DateTime> only");
            }
        }

        [JsonProperty(PropertyName = "time_ticks_format")]
        public TimeTickFormat TimeTickFormat { get; set; } = TimeTickFormat.DateAndTime;

        [JsonProperty(PropertyName = "regular_time_axis")]
        public bool RegularTimeAxis { get; set; } = false;

        [JsonProperty(PropertyName = "x_tick_fontsize")]
        public double XTickFontSize { get; set; }

        [JsonProperty(PropertyName = "x_tick_rotation")]
        public double XTickRotation { get; set; }

        public void HealthCheck()
        {
            //if(XTimeTicks!=null && XTimeTicks.Count>0 && XMajorTicks!=null && XMajorTicks.Length>0 && XMajorTicks.Length!= XTimeTicks.Count)
            //    throw new HealthCheckException("Grid.XTimeTicks and Grid.XMajorTicks must be of the same leangth");
        }
    }

    
}
