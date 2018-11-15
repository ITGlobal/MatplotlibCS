using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatplotlibCS.PlotItems
{
    /// <summary>
    /// [ '-' | '--' | '-.' | ':' | 'steps' | ...]
    /// </summary>
    public enum LineStyle
    {
        [EnumMember(Value = "-")]
        Solid,

        [EnumMember(Value = "--")]
        Dashed,

        [EnumMember(Value = "steps")]
        Steps,

        [EnumMember(Value = ":")]
        Dotted,

        [EnumMember(Value = "-.")]
        DashDotted
    }

    /// <summary>
    /// Marker type
    /// </summary>
    public enum Marker
    {
        [EnumMember(Value = "")]
        None,

        [EnumMember(Value = ".")]
        Point,

        [EnumMember(Value = ",")]
        Pixel,

        [EnumMember(Value = "o")]
        Circle,

        [EnumMember(Value = "v")]
        TriangleDown,

        [EnumMember(Value = "^")]
        TriangleUp,
        
        [EnumMember(Value = "<")]
        TriangleLeft,

        [EnumMember(Value = ">")]
        TriangleRight,

        [EnumMember(Value = "1")]
        TriDown,

        [EnumMember(Value = "2")]
        TriUp,

        [EnumMember(Value = "3")]
        TriLeft,

        [EnumMember(Value = "4")]
        TriRight,

        [EnumMember(Value = "8")]
        Octagon,

        [EnumMember(Value = "s")]
        Square,

        [EnumMember(Value = "p")]
        Pentagon,

        [EnumMember(Value = "*")]
        Star,

        [EnumMember(Value = "h")]
        Hexagon1,

        [EnumMember(Value = "+")]
        Plus,

        [EnumMember(Value = "x")]
        X,

        [EnumMember(Value = "D")]
        Diamond,

        [EnumMember(Value = "|")]
        Vline,

        [EnumMember(Value = "_")]
        Hline,

        [EnumMember(Value = "TICKLEFT")]
        Tickleft,

        [EnumMember(Value = "TICKRIGHT")]
        Tickright,

        [EnumMember(Value = "TICKUP")]
        Tickup,

        [EnumMember(Value = "TICKDOWN")]
        Tickdown,

        [EnumMember(Value = "CARETLEFT")]
        Caretleft,

        [EnumMember(Value = "CARETRIGHT")]
        Caretright,

        [EnumMember(Value = "CARETUP")]
        Caretup,

        [EnumMember(Value = "CARETDOWN")]
        Caretdown
    }
    
    /// <summary>
    /// Colors
    /// </summary>
    public class Color
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; private set; }

        public Color(string hexColor)
        {
            Value = hexColor;
        }

        public static implicit operator Color(string hexColor)
        {
            return new Color(hexColor);
        }

        public static Color Blue = new Color("b");

        public static Color Black = new Color("k");

        public static Color Red = new Color("r");

        public static Color Yellow = new Color("y");

        public static Color Cyan = new Color("c");

        public static Color Green = new Color("g");

        public static Color White = new Color("w");

        public static Color Magenta = new Color("m");

        public static Color None = new Color("None");
    }

    public class TimeTickFormat
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; private set; }

        public TimeTickFormat(string formatString)
        {
            Value = formatString;
        }

        public static implicit operator TimeTickFormat(string formatString)
        {
            return new TimeTickFormat(formatString);
        }

        public static TimeTickFormat HHMMSS = new TimeTickFormat("%H:%M:%S");

        public static TimeTickFormat HHMM = new TimeTickFormat("%H:%M");

        public static TimeTickFormat DateOnly = new TimeTickFormat("%Y-%m-%d");

        public static TimeTickFormat DateAndTime = new TimeTickFormat("%Y-%m-%d %H:%M:%S");

    }

    /// <summary>
    /// Which grid lines to show
    /// </summary>
    public enum GridWhich
    {
        /// <summary>
        /// Show both grids
        /// </summary>
        [EnumMember(Value = "both")]
        Both,

        /// <summary>
        /// Show only minor grid
        /// </summary>
        [EnumMember(Value = "minor")]
        Minor,

        /// <summary>
        /// Show only major grid
        /// </summary>
        [EnumMember(Value = "major")]
        Major
    }
}
