from src.Statistics.Statistics import Statistics
from src.ReadData.ReadData import ReadData
from src.Database.StatisticsRepository import StatisticsRepository
from src.Generate.Random import RandomGenerator

class MenuOptions:
    def __init__(self):
        self.__stat = Statistics()
        self.__data = ReadData()
        self.__repo = StatisticsRepository()
        self.__generator = RandomGenerator()

    def __show_menu_text(self):
        print("\n--- MENÚ DE OPCIONES ---")
        print("1. - Add values")
        print("2. - Average")
        print("3. - Variance")
        print("4. - Standard Deviation")
        print("5. - List values")
        print("6. - Clear list")
        print("7. - Random generator submenu")
        print("8. - Export to Excel")
        print("9. - Exit")

    def add_values(self):
        while True:
            val = self.__data.get_data_float("Value")
            self.__stat.add_item(val)
            self.__repo.save_value(val)
            option = self.__data.get_data_int("Add another value? (1/0)")
            if option == 0:
                break

    def generate_random_values(self):
        total = self.__data.get_data_int("Cantidad de valores a generar")
        if total <= 0:
            print("Introduce un número mayor que 0.")
            return

        save_db = self.__data.get_data_int("Guardar en base de datos? (1 = sí, 0 = no)")
        values = self.__generator.generate_values(total=total, save_to_db=(save_db == 1))
        for value in values:
            self.__stat.add_item(value)

        print(f"Se generaron {len(values)} valores.")
        if save_db == 1:
            print("Los valores se guardaron en la base de datos.")

    def show_values(self):
        items = self.__stat.get_items()
        if not items:
            print("No hay valores en memoria.")
        else:
            print("Values:", items)

    def show_all_generated_values(self):
        rows = self.__repo.get_all_values()
        if not rows:
            print("No se encontraron valores generados en la base de datos.")
        else:
            print("\n--- VALORES GENERADOS EN BASE DE DATOS ---")
            for row in rows:
                row_id, value, session_id, description, created_at = row
                print(
                    f"{row_id}: value={value} | session_id={session_id or '-'} "
                    f"| created_at={created_at} | description={description or '-'}"
                )
        input("\nPresiona Enter para regresar al submenú...")

    def list_cleared(self):
        self.__stat.clear_list()
        print("Memoria RAM limpiada.")
        self.__repo.delete_all_values()

    def random_generator_menu(self):
        while True:
            print("\n--- SUBMENÚ GENERADOR RANDOM ---")
            print("1. - Generate random values and save to database")
            print("2. - Show all generated values")
            print("3. - Return to main menu")

            option = self.__data.get_data_int("Option")
            match option:
                case 1:
                    self.generate_random_values()
                case 2:
                    self.show_all_generated_values()
                case 3:
                    break
                case _:
                    print("Opción inválida. Intenta de nuevo.")
    
    def export_menu(self):
        """Muestra el menú de exportación a Excel"""
        while True:
            print("\n--- MENÚ DE EXPORTACIÓN ---")
            print("1. - Export all database values to Excel")
            print("2. - Export statistics summary to Excel")
            print("3. - Export combined report (values + statistics)")
            print("4. - Return to main menu")
            
            option = self.__data.get_data_int("Option")
            match option:
                case 1:
                    self.export_values()
                case 2:
                    self.export_statistics()
                case 3:
                    self.export_combined()
                case 4:
                    break
                case _:
                    print("Opción inválida. Intenta de nuevo.")
    
    def export_values(self):
        """Exporta tself.export_menu()
                case 9:
                    odos los valores de la base de datos a Excel"""
        filepath = self.__repo.export_to_excel()
        if filepath:
            input("\nPresiona Enter para continuar...")
    
    def export_statistics(self):
        """Exporta un resumen de estadísticas a Excel"""
        average = self.__stat.get_average()
        variance = self.__stat.get_variance()
        deviation = self.__stat.get_deviation()
        
        # Contar valores en la base de datos
        all_values = self.__repo.get_all_values()
        db_count = len(all_values) if all_values else 0
        
        stats_data = {
            'Promedio': average if average is not None else 'N/A',
            'Varianza': variance if variance is not None else 'N/A',
            'Desviación Estándar': deviation if deviation is not None else 'N/A',
            'Total de Valores en BD': db_count
        }
        
        filepath = self.__repo.export_statistics_summary_to_excel(stats_data)
        if filepath:
            input("\nPresiona Enter para continuar...")
    
    def export_combined(self):
        """Exporta un reporte combinado con datos y estadísticas"""
        average = self.__stat.get_average()
        variance = self.__stat.get_variance()
        deviation = self.__stat.get_deviation()
        
        all_values = self.__repo.get_all_values()
        db_count = len(all_values) if all_values else 0
        
        stats_data = {
            'Promedio': average if average is not None else 'N/A',
            'Varianza': variance if variance is not None else 'N/A',
            'Desviación Estándar': deviation if deviation is not None else 'N/A',
            'Total de Valores': db_count
        }
        
        filepath = self.__repo.export_combined_report(stats_data)
        if filepath:
            input("\nPresiona Enter para continuar...")

    def run(self):
        while True:
            self.__show_menu_text()
            option = self.__data.get_data_int("Option")
            match option:
                case 1:
                    self.add_values()
                case 2:
                    average = self.__stat.get_average()
                    print("Average:", average if average is not None else "No hay datos suficientes")
                case 3:
                    variance = self.__stat.get_variance()
                    print("Variance:", variance if variance is not None else "No hay datos suficientes")
                case 4:
                    deviation = self.__stat.get_deviation()
                    print("Deviation:", deviation if deviation is not None else "No hay datos suficientes")
                case 5:
                    self.show_values()
                case 6:
                    self.list_cleared()
                case 7:
                    self.random_generator_menu()
                case 8:
                    self.export_menu()
                case 9:
                    print("Saliendo del programa...")
                    break
                case _:
                    print("Opción inválida. Intenta de nuevo.")