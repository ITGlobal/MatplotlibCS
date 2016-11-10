import matplotlib.pyplot as plot

from line_2d import Line2D
from subplot import Subplot


class Task:
    def __init__(self, jsonDict):
        # set default values for most important properties
        self.dpi = 300
        self.w = 1920
        self.h = 1080
        self.rows = 1
        self.columns = 1

        # initialize object from json, received from c# process
        self.__dict__ = jsonDict

        self.subplots = []
        if "__subplots__" in jsonDict:
            for subplotJson in jsonDict["__subplots__"]:
                self.subplots.append(Subplot(subplotJson))
