# -*- coding: utf-8 -*-
import json
import sys, getopt
import matplotlib.pyplot as plot
import matplotlib.patches as patches
import numpy as np

# Скрипт для построение графиков с помощью matplotlib. Данные для графика
# и параметры отрисовки передаются через json

def main(args):

    if len(args) == 0:
        print("No input json with task description passed")
        input("Press Enter to continue...")
        return

    print(args[0])
    jsonRaw = args[0]
    task = json.loads(jsonRaw)

    fig = plot.figure()
    ax = fig.add_subplot(task["subplotRows"], task["subplotColumns"], 1)

    for sbplt in task["subplots"]:
        for line in sbplt["lines"]:
            plot.plot(line["x"], line["y"])

    plot.show()

    # x = np.arange(80, 121, 1)
    # plot.hlines(0, x.min(), x.max())
    # y = x
    # plot.plot(x, y, 'b', linewidth=5, alpha=0.7)
    # plot.show()


if __name__ == "__main__":
    main(sys.argv[1:])
