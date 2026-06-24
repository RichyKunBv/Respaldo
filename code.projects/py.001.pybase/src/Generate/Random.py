import math
import os
import sys
import time
import uuid

if __name__ == "__main__":
    sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..')))

from src.Database.StatisticsRepository import StatisticsRepository

class RandomGenerator:
    def __init__(self):
        self.session_id = str(uuid.uuid4())
        self.description = (
            f"Fórmula: (sin(n*123456.789)*1e6 % 900000) + 100000 | Enteros 6 dígitos | sesión: {self.session_id}"
        )
        self.__repo = StatisticsRepository()
        self.mode = 1  # 0: valores enteros, 1: valores decimales

    @staticmethod
    def get_value(n, mode):
        raw = (int(abs(math.sin(n * 123456.789)) * 1e6) % 900000) + 100000

        if mode == 1:
            split = (n % 5) + 1
            divisor = 10 ** (6 - split)
            return raw / divisor

        return raw
    
    def set_mode(self, mode):
        if mode not in (0, 1):
            raise ValueError("Modo inválido: use 0 para enteros o 1 para decimales")
        self.mode = mode

    def generate_values(self, total=10000, save_to_db=False, mode=None):
        if mode is None:
            mode = self.mode

        values = []
        for n in range(1, total + 1):      
            value = self.get_value(n, mode=mode)
            values.append(value)
            if save_to_db:
                self.__repo.save_value(value, self.session_id, self.description)
        return values

    def generate_and_save(self, total=10000):
        print("Generando valores aleatorios y guardando en la base de datos...")
        start_ms = int(time.time() * 1000)
        values = self.generate_values(total=total, save_to_db=True)
        end_ms = int(time.time() * 1000)
        elapsed = end_ms - start_ms
        print(f"Se generaron {len(values)} valores en {elapsed} ms.")
        print(f"Inicio: {start_ms} ms | Fin: {end_ms} ms")
        return values