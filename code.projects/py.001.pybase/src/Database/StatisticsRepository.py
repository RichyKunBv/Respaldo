from src.Database.DBConnection import DBConnection
from src.Export.ExcelExporter import ExcelExporter

try:
    from mysql.connector import Error
except ImportError:
    Error = Exception

class StatisticsRepository:
    def __init__(self):
        self.__db = DBConnection()
        self.table_name = "tablarandom"

    def save_value(self, value, session_id=None, description=None):
        self.__db.ensure_table(self.table_name)
        conn = self.__db.connect()
        if conn:
            try:
                cursor = conn.cursor()
                query = (
                    f"INSERT INTO {self.table_name} "
                    "(value, session_id, description) VALUES (%s, %s, %s)"
                )
                cursor.execute(query, (value, session_id, description))
                conn.commit()
                cursor.close()
            except Error as e:
                print(f"No se pudo guardar en la BD: {e}")
            finally:
                self.__db.close()

    def delete_all_values(self):
        """Elimina todos los registros de tablarandom en la base de datos"""
        self.__db.ensure_table(self.table_name)
        conn = self.__db.connect()
        if conn:
            try:
                cursor = conn.cursor()
                query = f"TRUNCATE TABLE {self.table_name}"
                cursor.execute(query)
                conn.commit()
                cursor.close()
                print("Base de datos limpiada con éxito.")
            except Error as e:
                print(f"Error al borrar en la BD: {e}")
            finally:
                self.__db.close()

    def get_all_values(self):
        self.__db.ensure_table(self.table_name)
        conn = self.__db.connect()
        if conn:
            try:
                cursor = conn.cursor()
                query = (
                    f"SELECT id, value, session_id, description, created_at "
                    f"FROM {self.table_name} ORDER BY id"
                )
                cursor.execute(query)
                rows = cursor.fetchall()
                cursor.close()
                return rows
            except Error as e:
                print(f"Error al leer valores de la BD: {e}")
                return []
            finally:
                self.__db.close()
        return []
    
    def export_to_excel(self, filename=None):
        """
        Exporta todos los valores de la base de datos a un archivo Excel
        
        Args:
            filename: Nombre del archivo (opcional)
        
        Returns:
            str: Ruta del archivo generado
        """
        rows = self.get_all_values()
        if not rows:
            print("No hay datos para exportar.")
            return None
        
        exporter = ExcelExporter()
        return exporter.export_values_to_excel(rows, filename)
    
    def export_statistics_summary_to_excel(self, stats_data, filename=None):
        """
        Exporta un resumen estadístico a un archivo Excel
        
        Args:
            stats_data: Diccionario con las estadísticas (average, variance, deviation, count)
            filename: Nombre del archivo (opcional)
        
        Returns:
            str: Ruta del archivo generado
        """
        exporter = ExcelExporter()
        return exporter.export_statistics_summary(stats_data, filename)
    
    def export_combined_report(self, stats_data, filename=None):
        """
        Exporta un reporte combinado con datos y estadísticas
        
        Args:
            stats_data: Diccionario con las estadísticas
            filename: Nombre del archivo (opcional)
        
        Returns:
            str: Ruta del archivo generado
        """
        rows = self.get_all_values()
        if not rows:
            print("No hay datos para exportar.")
            return None
        
        exporter = ExcelExporter()
        return exporter.export_combined_report(rows, stats_data, filename)
