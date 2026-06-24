from src.Database.DBConfig import DBConfig

try:
    import mysql.connector
    from mysql.connector import Error
except ImportError:
    mysql = None
    Error = Exception

class DBConnection:
    def __init__(self):
        self.__config = DBConfig()
        self.connection = None
        self.__warning_shown = False

    def connect(self):
        if mysql is None:
            if not self.__warning_shown:
                print("Atención: mysql.connector no está instalado. Las operaciones de base de datos no estarán disponibles.")
                self.__warning_shown = True
            return None

        try:
            if self.connection and self.connection.is_connected():
                return self.connection

            self.connection = mysql.connector.connect(
                host=self.__config.host,
                database=self.__config.database,
                user=self.__config.user,
                password=self.__config.password,
                autocommit=False
            )
            return self.connection
        except Error as e:
            print(f"Error al conectar a MySQL: {e}")
            return None

    def ensure_table(self, table_name="tabla1"):
        conn = self.connect()
        if conn is None:
            return

        try:
            cursor = conn.cursor()
            sql = f"""
                CREATE TABLE IF NOT EXISTS {table_name} (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    value DOUBLE NOT NULL,
                    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    session_id VARCHAR(50),
                    description VARCHAR(255)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
            """
            cursor.execute(sql)
            conn.commit()
            cursor.close()
        except Error as e:
            print(f"Error al asegurar la tabla '{table_name}': {e}")

    def close(self):
        if self.connection and self.connection.is_connected():
            self.connection.close()
            self.connection = None
