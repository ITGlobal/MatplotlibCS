# -*- coding: utf-8 -*-
import json
import sys, getopt
import matplotlib.pyplot as plot
import matplotlib.patches as patches
import numpy as np
from matplotlib import rc
from flask import Flask, url_for, request, json, Response, abort, jsonify
from task import Task
import datetime
import matplotlib.dates as mdates
from helpers import if_string_convert_to_datetime
import matplotlib.ticker as ticker

# Script builds a matplotlib figure based on information, passed to it through json file.
# Path to the JSON must be passed in first command line argument.

# a trick to enable text labels in cyrillic
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
        for item in subplot.items:
            if item.is_visible == True:
                item.plot(axes)
        if subplot.show_legend:
            plot.legend(loc=subplot.legend_location, frameon=subplot.frameon)

        set_grid(fig, axes, subplot.grid)

    plot.tight_layout()

    save_figure_to_file(task)

    if not task["onlySaveImage"]:
        plot.show()

    plot.close("all")
    return '', 200

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
        plot.savefig(task["filename"], dpi=task["dpi"])

def set_grid(fig, axes, grid):
    """
    Setup axes grid
    :param axes:
    :return:
    """
    axes.grid(which=grid.which)
    axes.grid(which='minor', alpha=grid.minor_alpha)
    axes.grid(which='major', alpha=grid.major_alpha)
    axes.grid(grid.on)

    if grid.x_lim is not None:
        axes.set_xlim(grid.x_lim[0], grid.x_lim[1])

    if grid.y_lim is not None:
        axes.set_ylim(grid.y_lim[0], grid.y_lim[1])

    # if time ticks defined
    if grid.x_time_ticks is not None and len(grid.x_time_ticks) > 0:
        timeTicks = []
        for stringTick in grid.x_time_ticks:
            timeTick = if_string_convert_to_datetime(stringTick)
            timeTicks.append(timeTick)

        # distance between nodes will be equal
        if grid.regular_time_axis:
            n = len(grid.x_time_ticks)

            def format_date(x, pos=None):
                thisind = np.clip(int(x + 0.5), 0, n - 1)
                return timeTicks[thisind].strftime(grid.time_ticks_format['value'])

            axes.xaxis.set_major_formatter(ticker.FuncFormatter(format_date))

        # else distance between time nodes will be as is
        else:
            formatter = mdates.DateFormatter(grid.time_ticks_format['value'])
            axes.xaxis.set_major_formatter(formatter)
            axes.set_xticks(timeTicks)

    # if no time ticks defined
    elif grid.x_major_ticks is not None:
        axes.set_xticks(build_ticks_list(grid.x_major_ticks))
        if grid.x_minor_ticks is not None:
            axes.set_xticks(build_ticks_list(grid.x_minor_ticks), minor=True)

    if grid.y_major_ticks is not None:
        axes.set_yticks(build_ticks_list(grid.y_major_ticks))

    if grid.y_minor_ticks is not None:
        axes.set_yticks(build_ticks_list(grid.y_minor_ticks), minor=True)

    # set font and rotation
    labels = axes.get_xticklabels()

    if grid.x_tick_fontsize is not None and grid.x_tick_fontsize!=0:
        plot.setp(labels, fontsize=grid.x_tick_fontsize)

    if grid.x_tick_rotation is not None and grid.x_tick_rotation!=0:
        plot.setp(labels, rotation=grid.x_tick_rotation)


def build_ticks_list(lims):
    '''
    First two values in lims are the minimum and the maximum values, while third value is a step.
    Values starting from 4 are additional values which will be added to the grid
    :param lims:
    :return:
    '''
    ticks = np.arange(lims[0], lims[1] + lims[2], lims[2])
    if len(lims) > 3:
        for i in range(3, len(lims)):
            ticks = np.append(ticks, [lims[i]])
    return ticks

def set_titles(task):
    """
    Setup subplot X and Y axis titles

    :param task:
    :return:
    """
    plot.title(u"{0}".format(task.title))
    plot.xlabel(task.xtitle)
    plot.ylabel(task.ytitle)

# entry point
if __name__ == "__main__":
    main(sys.argv[1:])
