import matplotlib.pyplot as plot


class Line2D:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

    def plot(self, axes):
        line = self.__dict__
        # c = 'r' if "color" not in line else line["color"]
        # m = '' if "marker" not in line else line["marker"]
        # lw = 1 if "lineWidth" not in line else line["lineWidth"]
        # ms = 1 if "markerSize" not in line else line["markerSize"]
        # ls = '-' if "lineStyle" not in line else line["lineStyle"]
        # markevery = 1 if "markevery" not in line else line["markevery"]
        plot.plot(line["x"],
                  line["y"],
                  color=self.color["value"],
                  marker=self.marker,
                  lw=self.lineWidth,
                  ms=self.markerSize,
                  ls=self.lineStyle,
                  markevery=self.markevery)
        plot.hold(True)