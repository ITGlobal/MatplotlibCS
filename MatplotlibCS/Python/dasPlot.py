# -*- coding: utf-8 -*-
import json
import sys, getopt
import matplotlib.pyplot as plot
import matplotlib.patches as patches
import numpy as np
from matplotlib import rc

# Скрипт для построение графиков с помощью matplotlib. Данные для графика
# и параметры отрисовки передаются через json

def main(args):

    if len(args) == 0:
        print("No input json with task description passed")
        input("Press Enter to continue...")
        return

    print(args[0])

    # какой-то трюк, чтобы можно было делать подписи кириллицей
    rc('font', **{'sans-serif': 'Arial',
                  'family': 'sans-serif'})

    f = open(args[0], 'r')
    jsonRaw = f.read()
    task = json.loads(jsonRaw)

    fig = plot.figure()
	
	subplots = {}
	subplotIndex = 1
    for i in range(0, task["rows"]):
        for j in range(0, task["columns"]):
            axes = fig.add_subplot(task["rows"], task["columns"], subplotIndex)
            subplots[subplotIndex] = axes
            setGrid(axes)
            subplotIndex += 1

    for sbplt in task["subplots"]:
        for item in sbplt["items"]:
            axes = subplots[sbplt["index"]]
            plot.sca(axes)
            setTitles(task, sbplt)

            if item["type"] == "Line2D":
                plotLine2D(item)
            elif item["type"] == "Histogram":
                plotHistogram(item)

    plot.tight_layout()
    plot.show()

    if "filename" in task and task["filename"] is not None:
        plot.savefig(task["filename"], dpi=300)

# Отрисовка 2D линии
def plotLine2D(line):
    c = 'r' if "color" not in line else line["color"]
    m = '' if "marker" not in line else line["marker"]
    lw = 1 if "lineWidth" not in line else line["lineWidth"]
    ms = 1 if "markerSize" not in line else line["markerSize"]
    ls = '-' if "lineStyle" not in line else line["lineStyle"]
    plot.plot(line["x"], line["y"], color=c, marker=m, lw=lw, ms=ms, ls=ls)
    plot.hold(True)

# Отрисовка гистограммы
def plotHistogram(line):
    plot.hist(line["y"],50)
    plot.hold(True)

# Настройка сетки
def setGrid(axes):
    axes.grid(which='both')
    axes.grid(which='minor', alpha=0.2)
    axes.grid(which='major', alpha=0.5)
    axes.grid('on')

# Настройка подписей к осям и графику
def setTitles(task, axes):
    plot.title(u"{0}".format(axes["title"]))
    plot.ylabel(axes["xtitle"])
    plot.xlabel(axes["ytitle"])


if __name__ == "__main__":
    main(sys.argv[1:])
