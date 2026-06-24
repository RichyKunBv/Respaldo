import os

class DBConfig:
    def __init__(self):
        self.host = os.getenv('DB_HOST', 'localhost')
        self.database = os.getenv('DB_NAME', 'code')
        self.user = os.getenv('DB_USER', 'pruba')
        self.password = os.getenv('DB_PASSWORD', '3c@mc59X#')

    def __repr__(self):
        return (
            f"DBConfig(host={self.host}, database={self.database}, "
            f"user={self.user})"
        )
