using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
    /// b: blue
    /// g: green
    /// r: red
    /// c: cyan
    /// m: magenta
    /// y: yellow
    /// k: black
    /// w: white
    /// </summary>
    public enum Color
    {
        [EnumMember(Value = "k")]
        Black,

        [EnumMember(Value = "r")]
        Red,

        [EnumMember(Value = "b")]
        Blue,

        [EnumMember(Value = "y")]
        Yellow,

        [EnumMember(Value = "c")]
        Cyan,

        [EnumMember(Value = "g")]
        Green,

        [EnumMember(Value = "w")]
        White,

        [EnumMember(Value = "m")]
        Magenta,
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
