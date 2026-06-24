import oracledb

# Parámetros de conexión
username = "webo"
password = "escamilla13XD"

host = "192.168.215.2"  # la IP del sintenedor

port = 1521          # Puerto de OracleDB
service_name = "FREEPDB1" # pa que no se me olvide FREEPDB1 es el de los pobres (por que es la verzion grati)

dsn = oracledb.makedsn(host, port, service_name=service_name)

try:
    connection = oracledb.connect(user=username, password=password, dsn=dsn)
    print("Si jaló la conecsion pa")

    with connection.cursor() as cursor:
        cursor.execute("SELECT 'oli' FROM DUAL")
        result = cursor.fetchone()
        print("Resultado de prueba:", result[0])

except oracledb.Error as e:
    print("No jaló w la cagaste :VVV tenemos 0", e)

finally:
    if 'connection' in locals():
        connection.close()
        print("Conexión cerrada.")