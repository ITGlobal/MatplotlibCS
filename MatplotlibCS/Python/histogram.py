import matplotlib.pyplot as plot


class Histogram:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

    def plot(self):
        plot.hist(self.y, 50)
        plot.hold(True)