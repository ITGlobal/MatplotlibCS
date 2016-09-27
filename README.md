# MatplotlibCS

[![Build status](https://ci.appveyor.com/api/projects/status/82vbbkqmh4xjig6f/branch/master?svg=true)](https://ci.appveyor.com/project/kapitanov/matplotlibcs/branch/master)
[![NuGet](https://img.shields.io/nuget/v/MatplotlibCS.svg?maxAge=2592000)](https://www.nuget.org/packages/MatplotlibCS/)

A tiny library for utilizing Matplotlib Python charting library from C#. The general process is this:

#Basic usage#
1. You create an instance of the class Figure and initialize it's properties with relative data. This instance describes everything you want to see on the figure.
2. You initialize MatplotlibCS class instance. You need to specify a path to python.exe and matplotlib_cs.py in constructor.
3. Call MatplotlibCS instance BuildFigure method to plot the figure.

#Examples#
