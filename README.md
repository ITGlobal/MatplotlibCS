# MatplotlibCS

[![Build status](https://ci.appveyor.com/api/projects/status/9kwdn26qx7oh6mho/branch/master?svg=true)](https://ci.appveyor.com/project/itgloballlc/matplotlibcs/branch/master)
[![NuGet](https://img.shields.io/nuget/v/MatplotlibCS.svg?maxAge=2592000)](https://www.nuget.org/packages/MatplotlibCS/)

A tiny library for utilizing Matplotlib Python charting library from C#. The general process is this:

## How to install
```
PS D:\MatplotlibCS> pip install flask
PS D:\MatplotlibCS> python -mpip install matplotlib
```
```
PM> Install-Package MatplotlibCS
```
## Basic usage

1. You create an instance of the class Figure and initialize it's properties with relative data. This instance describes everything you want to see on the figure.
2. You initialize MatplotlibCS class instance. You need to specify a path to python.exe and matplotlib_cs.py in constructor.
3. Call MatplotlibCS instance BuildFigure method to plot the figure.
4. Run
```
PS D:\MatplotlibCS> dotnet .\Examples\bin\Debug\netcoreapp2.1\Examples.dll python .\MatplotlibCS\Python\matplotlib_cs.py
```
## Examples
![ExampleSin](http://i.imgur.com/SXUEFCT.png)

```csharp
// Init engine with right paths
var matplotlibCs = new MatplotlibCS.MatplotlibCS(pythonExePath, dasPlotPyPath);

var figure = new Figure(1, 1)
{
    FileName = "ExampleSin.png",
    OnlySaveImage = true,
    DPI = 150,
    Subplots =
    {
        new Axes(1, "The X axis", "The Y axis")
        {
            Title = "Sin(x), Sin(2x), VLines, HLines, Annotations",
            Grid = new Grid()
            {
                MinorAlpha = 0.2,
                MajorAlpha = 1.0,
                XMajorTicks = new[] {0.0, 7.6, 0.5},
                YMajorTicks = new[] {-1, 2.5, 0.25},
                XMinorTicks = new[] {0.0, 7.25, 0.25},
                YMinorTicks = new[] {-1, 2.5, 0.125}
            },
            PlotItems =
            {
                new Line2D("Sin")
                {
                    X = X.ToList(),
                    Y = Y1.ToList(),
                    LineStyle = LineStyle.Dashed
                },

                new Line2D("Sin 2x")
                {
                    X = X.ToList(),
                    Y = Y2.ToList(),
                    LineStyle = LineStyle.Solid,
                    LineWidth = 0.5f,
                    Color = Color.Green,
                    Markevery = 5,
                    MarkerSize = 10,
                    Marker = Marker.Circle
                },

                new Text("Text annotation", 4.5, 0.76)
                {
                    FontSize = 17
                },

                new Annotation("Arrow text annotation", 0.5, -0.7, 3, 0)
                {
                    Color = Color.Blue
                },

                new Vline("vert line", 3.0, -1, 1),
                new Hline("hrzt line", new[] {0.1, 0.25, 0.375}, 0, 5) {LineStyle = LineStyle.Dashed, Color = Color.Magenta}
            }
        }

    }
};

var t = matplotlibCs.BuildFigure(figure);
t.Wait();
```