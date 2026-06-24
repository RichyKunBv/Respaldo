import random
import time
import os
import csv
from datetime import datetime

def limpiar_pantalla():
    os.system('cls' if os.name == 'nt' else 'clear')

def dibujar_bar():
    return [
        "  ________  ",
        " | MOE'S | ",
        " |_______| ",
        "    ||     ",
        "  __||__   "
    ]

def dibujar_casa():
    return [
        "   ______   ",
        "  /      \\  ",
        " /________\\ ",
        " |  [ ]  |  ",
        " |  _|_  |  ",
        " |_______|  "
    ]

def dibujar_muneco(col, ancho_total):
    cuerpo = ["", "", ""]
    linea0 = [" "] * ancho_total
    if 0 <= col < ancho_total:
        linea0[col] = 'O'
    cuerpo[0] = ''.join(linea0)
    linea1 = [" "] * ancho_total
    if col-1 >= 0: linea1[col-1] = '/'
    if col < ancho_total: linea1[col] = '|'
    if col+1 < ancho_total: linea1[col+1] = '\\'
    cuerpo[1] = ''.join(linea1)
    linea2 = [" "] * ancho_total
    if col-1 >= 0: linea2[col-1] = '/'
    if col+1 < ancho_total: linea2[col+1] = '\\'
    cuerpo[2] = ''.join(linea2)
    return cuerpo

def combinar_escenario(posicion, meta, ancho_total=80):
    bar = dibujar_bar()
    casa = dibujar_casa()
    bar_ancho = len(bar[0])
    casa_ancho = len(casa[0])
    camino_inicio = bar_ancho + 1
    camino_fin = ancho_total - casa_ancho - 1
    camino_ancho = camino_fin - camino_inicio

    if camino_ancho > 0:
        escala = camino_ancho / meta
        col_camino = int(posicion * escala)
        col_camino = max(0, min(col_camino, camino_ancho - 1))
        col_absoluta = camino_inicio + col_camino
    else:
        col_absoluta = camino_inicio

    muneco = dibujar_muneco(col_absoluta, ancho_total)
    max_altura = max(len(bar), len(casa), len(muneco))
    while len(bar) < max_altura: bar.append(" " * bar_ancho)
    while len(casa) < max_altura: casa.append(" " * casa_ancho)
    while len(muneco) < max_altura: muneco.append(" " * ancho_total)

    resultado = []
    for i in range(max_altura):
        linea = [" "] * ancho_total
        for j, ch in enumerate(bar[i]):
            if j < ancho_total: linea[j] = ch
        for j, ch in enumerate(muneco[i]):
            if ch != ' ' and j < ancho_total: linea[j] = ch
        casa_inicio = ancho_total - casa_ancho
        for j, ch in enumerate(casa[i]):
            if casa_inicio + j < ancho_total: linea[casa_inicio + j] = ch
        resultado.append(''.join(linea))

    suelo = ['_'] * ancho_total
    if casa_inicio + 2 < ancho_total:
        suelo[casa_inicio + 2] = 'H'
    resultado.append(''.join(suelo))
    resultado.append(f"Posición: {posicion} / {meta} pasos")
    return resultado

def formatear_tiempo(segundos):
    minutos = int(segundos // 60)
    segs = int(segundos % 60)
    if minutos > 0:
        return f"{minutos}m {segs:02d}s"
    return f"{segs}s"

def simular():
    meta = 750
    posicion = 0
    pasos = 0
    movimientos = [1, 2, 0, -1]
    probabilidades = [0.25, 0.25, 0.25, 0.25]

    inicio = datetime.now()
    # Crear archivo CSV para guardar todos los movimientos
    nombre_csv = f"simulacion_borracho_{inicio.strftime('%Y%m%d_%H%M%S')}.csv"
    archivo_csv = open(nombre_csv, 'w', newline='', encoding='utf-8')
    escritor = csv.writer(archivo_csv)
    # Escribir cabecera
    escritor.writerow(['Paso', 'Timestamp', 'Movimiento', 'Posicion'])
    # Registrar paso inicial (posición 0)
    escritor.writerow([0, inicio.strftime('%Y-%m-%d %H:%M:%S'), 'inicio', 0])
    archivo_csv.flush()  # Asegurar que se escribe en disco

    print("Simulación del borracho: desde MOE'S hasta su casa")
    print(f"HORA DE INICIO: {inicio.strftime('%H:%M:%S')}")
    print(f"Registro detallado guardado en: {nombre_csv}")
    print("Presiona Ctrl+C para detener la simulación\n")
    time.sleep(2)

    try:
        while posicion < meta:
            limpiar_pantalla()
            escenario = combinar_escenario(posicion, meta, ancho_total=80)
            for linea in escenario:
                print(linea)
            ahora = datetime.now()
            transcurrido = (ahora - inicio).total_seconds()
            print(f"Hora inicio: {inicio.strftime('%H:%M:%S')}  |  Hora actual: {ahora.strftime('%H:%M:%S')}  |  Transcurrido: {formatear_tiempo(transcurrido)}")

            # Elegir movimiento
            avance = random.choices(movimientos, weights=probabilidades)[0]
            posicion += avance
            pasos += 1

            # Registrar en CSV: paso, timestamp, movimiento, nueva posición
            escritor.writerow([pasos, ahora.strftime('%Y-%m-%d %H:%M:%S'), avance, posicion])
            archivo_csv.flush()  # Guardar inmediatamente para no perder datos si se interrumpe

            # Opcional: evitar posición negativa (descomentar si se desea)
            # posicion = max(0, posicion)
            time.sleep(0.1)
    except KeyboardInterrupt:
        print("\n\nSimulación detenida por el usuario.")
        fin = datetime.now()
        duracion = (fin - inicio).total_seconds()
        print(f"HORA DE INICIO: {inicio.strftime('%H:%M:%S')}")
        print(f"HORA DE FINALIZACIÓN (interrupción): {fin.strftime('%H:%M:%S')}")
        print(f"Duración total: {formatear_tiempo(duracion)}")
        # Registrar interrupción en el CSV
        escritor.writerow(['INTERRUPCION', fin.strftime('%Y-%m-%d %H:%M:%S'), 'usuario', posicion])
        archivo_csv.close()
        print(f"Registro guardado en {nombre_csv}")
        return

    # Llegada a la meta
    limpiar_pantalla()
    escenario = combinar_escenario(meta, meta, ancho_total=80)
    for linea in escenario:
        print(linea)
    fin = datetime.now()
    duracion = (fin - inicio).total_seconds()
    print(f"\n¡Llegó a casa después de {pasos} pasos!")
    print(f"HORA DE INICIO: {inicio.strftime('%H:%M:%S')}")
    print(f"HORA DE FINALIZACIÓN: {fin.strftime('%H:%M:%S')}")
    print(f"Duración total: {formatear_tiempo(duracion)}")

    # Registrar finalización en CSV
    escritor.writerow(['FIN', fin.strftime('%Y-%m-%d %H:%M:%S'), 'meta_alcanzada', posicion])
    archivo_csv.close()
    print(f"Registro detallado guardado en {nombre_csv}")

if __name__ == "__main__":
    simular()