import matplotlib.pyplot as plot
from datetime import datetime
from helpers import if_string_convert_to_datetime


class Text:
    def __init__(self, jsonDict):
        self.fontSize = 12
        self.color = 'k'
        self.alpha = 1
        self.__dict__ = jsonDict
        self.x = if_string_convert_to_datetime(self.x)

    def plot(self, axes):
        plot.text(self.x,
                  self.y,
                  self.text,
                  size=self.fontSize,
                  alpha=self.alpha,
                  color=self.color["value"])


class Annotation:
    def __init__(self, jsonDict):
        self.fontSize = 12
        self.color = 'k'
        self.alpha = 1
        self.__dict__ = jsonDict
        self.x = if_string_convert_to_datetime(self.arrow_x)
        self.x = if_string_convert_to_datetime(self.text_x)

    def plot(self, axes):
        plot.annotate(self.text,
                      xy=(self.arrow_x, self.arrow_y),
                      xycoords='data',
                      xytext=(self.text_x, self.text_y),
                      textcoords='data',
                      color=self.color["value"],
                      size=self.fontSize,
                      alpha=self.alpha,
                      arrowprops=dict(
                          linewidth=self.lineWidth,
                          color=self.color["value"],
                          alpha=self.alpha,
                          arrowstyle=self.arrow_style,
                          connectionstyle='arc3,rad=0',
                      )
                      )
