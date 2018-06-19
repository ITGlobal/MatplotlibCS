import matplotlib.pyplot as plot
import matplotlib.patches as patches

from line_2d import Line2D


class Arc(Line2D):
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict
        self.check_if_x_is_time()

    def plot(self, axes):
        label = self.name if self.show_legend else ""
        a = patches.Arc((self.x, self.y),
                        self.width,
                        self.height,
                        angle=self.angle,
                        theta1=self.theta1,
                        theta2=self.theta2,
                        color=self.color["value"],
                        linewidth=self.lineWidth,
                        alpha=self.alpha,
                        label=label)
        axes.add_patch(a)
