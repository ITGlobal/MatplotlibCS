# -*- coding: utf-8 -*-
import json
import sys, getopt
import matplotlib.pyplot as plot
import matplotlib.patches as patches
import numpy as np
from matplotlib import rc
from flask import Flask, url_for, request, json, Response, abort, jsonify
# Script builds a matplotlib figure based on information, passed to it through json file.
# Path to the JSON must be passed in first command line argument.

# a trick to enable text labels in cyrillic
from task import Task

rc('font', **{'sans-serif': 'Arial','family': 'sans-serif'})

app = Flask(__name__)


def main(args):
    host = "127.0.0.1"
    app.run(host=host, port=57123)

@app.route('/', methods=['POST', 'GET'])
def api_check_alive():
    return '', 200

@app.route('/plot', methods=['POST', 'GET'])
def api_plot():
    json_raw = request.json
    task = json.loads(json_raw)
    t = Task(task)

    fig = plot.figure(figsize=[t.w/(1.0*t.dpi), t.h/(1.0*t.dpi)])

    # precreate, make basic settings and save subplots
    subplots = {}
    subplot_index = 1
    for i in range(0, t.rows):
        for j in range(0, t.columns):
            axes = fig.add_subplot(t.rows, t.columns, subplot_index)
            subplots[subplot_index] = axes
            # set_grid(axes)
            subplot_index += 1

    # draw items on each subplot
    for subplot in t.subplots:
        axes = subplots[subplot.index]
        plot.sca(axes)
        set_titles(subplot)
        set_grid(axes, subplot.grid)
        for item in subplot.items:
            if item.is_visible == True:
                item.plot(axes)

    plot.tight_layout()

    save_figure_to_file(task)

    if not task["onlySaveImage"]:
        plot.show()

    # plot.show()

@app.route('/kill', methods=['POST', 'GET'])
def api_kill():
    raise RuntimeError('Stop web service')

def save_figure_to_file(task):
    """
    Saves figure content to the file if it's path is provided

    :type task: dict
    :param task: Deserialized json with task description

    :return:
    """
    if "filename" in task and task["filename"] is not None:
        print ("Saving figure to file {0}".format(task["filename"]))
        plot.savefig(task["filename"], dpi=300)

def set_grid(axes, grid):
    """
    Setup axes grid
    :param axes:
    :return:
    """
    axes.grid(which=grid.which)
    axes.grid(which='minor', alpha=grid.minor_alpha)
    axes.grid(which='major', alpha=grid.major_alpha)
    axes.grid(grid.on)

    # def ticks(self, xmajor, ymajor, xminor=None, yminor=None):
    if grid.x_major_ticks is not None:
        major_ticks = np.arange(grid.x_major_ticks[0], grid.x_major_ticks[1]+grid.x_major_ticks[2], grid.x_major_ticks[2])
        axes.set_xticks(major_ticks)
        axes.set_xlim(major_ticks.min(), major_ticks.max())

    if grid.x_minor_ticks is not None:
        minor_ticks = np.arange(grid.x_minor_ticks[0], grid.x_minor_ticks[1]+grid.x_minor_ticks[2], grid.x_minor_ticks[2])
        axes.axes.set_xticks(minor_ticks, minor=True)

    if grid.y_major_ticks is not None:
        major_ticks = np.arange(grid.y_major_ticks[0], grid.y_major_ticks[1]+grid.y_major_ticks[2], grid.y_major_ticks[2])
        axes.set_yticks(major_ticks)
        axes.set_ylim(major_ticks.min(), major_ticks.max())

    if grid.y_minor_ticks is not None:
        minor_ticks = np.arange(grid.y_minor_ticks[0], grid.y_minor_ticks[1]+grid.y_minor_ticks[2], grid.y_minor_ticks[2])
        axes.set_yticks(minor_ticks, minor=True)


def set_titles(task):
    """
    Setup subplot X and Y axis titles

    :param task:
    :return:
    """
    plot.title(u"{0}".format(task.title))
    plot.ylabel(task.xtitle)
    plot.xlabel(task.ytitle)

# entry point
if __name__ == "__main__":
    main(sys.argv[1:])
