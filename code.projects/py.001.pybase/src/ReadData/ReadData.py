class ReadData:
    def get_data_int(self, message):
        while True:
            try:
                print(message, end=": ")
                return int(input())
            except ValueError:
                print("Invalid input. Instroduce un número entero.")

    def get_data_float(self, message):
        while True:
            try:
                print(message, end=": ")
                return float(input())
            except ValueError:
                print("Invalid input. Introduce un número decimal.")