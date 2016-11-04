from annotations import Text, Annotation
from histogram import Histogram
from line_2d import Line2D


class Subplot:
    def __init__(self, jsonDict):
        self.index = 1
        self.title = ""
        self.xtitle = ""
        self.ytitle = ""

        self.__dict__ = jsonDict

        self.items = []
        if "__items__" in jsonDict:
            for item in jsonDict["__items__"]:
                if item["type"] == "Line2D":
                    self.items.append(Line2D(item))
                elif item["type"] == "Histogram":
                    self.items.append(Histogram(item))
                elif item["type"] == "Text":
                    self.items.append(Text(item))
                elif item["type"] == "Annotation":
                    self.items.append(Annotation(item))

        if "grid" in jsonDict:
            self.grid = Grid(jsonDict["grid"])
        else:
            self.grid = Grid()


class Grid:
    def __init__(self, jsonDict):
        self.which = 'both'
        self.minor_alfa = 0.4
        self.major_alfa = 0.5
        self.on = 'on'
        self.__dict__ = jsonDict