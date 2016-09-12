# -*- coding: utf-8 -*-
import json
import sys, getopt
import matplotlib.pyplot as plot
import matplotlib.patches as patches
import numpy as np
from matplotlib import rc

# Script builds a matplotlib figure based on information, passed to it through json file.
# Path to the JSON must be passed in first command line argument.

# a trick to enable text labels in cyrillic
rc('font', **{'sans-serif': 'Arial','family': 'sans-serif'})


def main(args):

    if len(args) == 0:
        print("No input path to json passed")
        input("Press Enter to continue...")
        return

    print(args[0])

    f = open(args[0], 'r')
    json_raw = f.read()
    task = json.loads(json_raw)

    fig = plot.figure()

    # precreate, make basic settings and save subplots
    subplots = {}
    subplot_index = 1
    for i in range(0, task["rows"]):
        for j in range(0, task["columns"]):
            axes = fig.add_subplot(task["rows"], task["columns"], subplot_index)
            subplots[subplot_index] = axes
            set_grid(axes)
            subplot_index += 1

    # draw items on each subplot
    for axes in task["subplots"]:
        for item in axes["items"]:
            axes = subplots[axes["index"]]
            plot.sca(axes)
            set_titles(task, axes)

            if item["type"] == "Line2D":
                plot_line2d(item)
            elif item["type"] == "Histogram":
                plot_histogram(item)

    plot.tight_layout()
    plot.show()

    save_figure_to_file(task)


def save_figure_to_file(task):
    """
    Saves figure content to the file if it's path is provided

    :type task: dict
    :param task: Deserialized json with task description

    :return:
    """
    if "filename" in task and task["filename"] is not None:
        plot.savefig(task["filename"], dpi=300)


def plot_line2d(line):
    """
    Plots simple 2D line
    :param line: Line description dict
    :return:
    """
    c = 'r' if "color" not in line else line["color"]
    m = '' if "marker" not in line else line["marker"]
    lw = 1 if "lineWidth" not in line else line["lineWidth"]
    ms = 1 if "markerSize" not in line else line["markerSize"]
    ls = '-' if "lineStyle" not in line else line["lineStyle"]
    plot.plot(line["x"], line["y"], color=c, marker=m, lw=lw, ms=ms, ls=ls)
    plot.hold(True)


def plot_histogram(hist):
    """
    Plots simple 2D histogram
    :param hist:
    :return:
    """
    plot.hist(hist["y"], 50)
    plot.hold(True)


def set_grid(axes):
    """
    Setup axes grid
    :param axes:
    :return:
    """
    axes.grid(which='both')
    axes.grid(which='minor', alpha=0.2)
    axes.grid(which='major', alpha=0.5)
    axes.grid('on')


def set_titles(axes):
    """
    Setup subplot X and Y axis titles

    :param axes:
    :return:
    """
    plot.title(u"{0}".format(axes["title"]))
    plot.ylabel(axes["xtitle"])
    plot.xlabel(axes["ytitle"])

# entry point
if __name__ == "__main__":
    main(sys.argv[1:])
