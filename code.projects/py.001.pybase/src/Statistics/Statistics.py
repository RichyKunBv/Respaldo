import math

class Statistics:
    def __init__(self):
        self.__items = []
        self.__count = 0

    def add_item(self, param):
        self.__items.append(param)
        self.__count += 1

    def get_average(self):
        if self.__count >= 1:
            return sum(self.__items) / self.__count
        return None

    def get_count(self):
        return self.__count

    def get_variance(self):
        if self.__count >= 2:
            total = sum(self.__items)
            total_sq = sum(item ** 2 for item in self.__items)
            scx = total_sq - (total ** 2) / self.__count
            return scx / (self.__count - 1)
        return None

    def get_deviation(self):
        variance = self.get_variance()
        if variance is not None:
            return math.sqrt(variance)
        return None

    def get_items(self):
        return self.__items

    def clear_list(self):
        self.__items = []
        self.__count = 0
