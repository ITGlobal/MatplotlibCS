using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// Class describes a histogram
    /// </summary>
    public class Histogram : PlotItem
    {
        #region Properties
        
        /// <summary>
        /// Data values
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public List<double> Y { get; set; }

        [JsonProperty(PropertyName = "bins")]
        public int Bins { get; set; } = 50;

        [JsonProperty(PropertyName = "normed")]
        public bool Normed { get; set; } = false;

        [JsonProperty(PropertyName = "orientation")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HistogramOrientation Orientation { get; set; } = HistogramOrientation.Vertical;

        [JsonProperty(PropertyName = "color")]
        public Color Color { get; set; } = Color.Blue;

        [JsonProperty(PropertyName = "range")]
        public double[] Range { get; set; }

        [JsonProperty(PropertyName = "cumulative")]
        public bool Cumulative { get; set; }

        [JsonProperty(PropertyName = "histtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Histtype Histtype { get; set; }

        [JsonProperty(PropertyName = "alpha")]
        public double Alpha { get; set; } = 1;

        #endregion

        #region .ctor

        public Histogram(string name) : base(name) { }

        #endregion
    }

    public enum HistogramOrientation
    {
        [EnumMember(Value = "vertical")]
        Vertical,

        [EnumMember(Value = "horizontal")]
        Horizontal
    }

    public enum Histtype
    {
        [EnumMember(Value = "bar")]
        Bar,

        [EnumMember(Value = "barstacked")]
        Barstacked,

        [EnumMember(Value = "step")]
        Step,

        [EnumMember(Value = "stepfilled")]
        Stepfilled
    }
}

/*  
  weights=None
  bottom=None
 histtype='bar'
 align='mid'
 rwidth=None
 log=False 
  label=None
 stacked=False
 hold=None
 data=None
 */
