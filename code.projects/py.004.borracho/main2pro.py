#!/usr/bin/env python3
"""
Simulación del Borracho Estocástico - Edición Deluxe (stdlib)
1 borracho, avance realista, puro espectáculo.
"""
import random
import time
import os
import csv
import sys
from datetime import datetime
from collections import deque

# ----------------------------------------------------------------------
# 1. HABILITAR ANSI Y COLORES
# ----------------------------------------------------------------------
def init_terminal():
    """Activa el procesamiento de secuencias ANSI en Windows."""
    if os.name == 'nt':
        try:
            import ctypes
            kernel32 = ctypes.windll.kernel32
            kernel32.SetConsoleMode(kernel32.GetStdHandle(-11), 7)
        except Exception:
            pass

init_terminal()

# Colores ANSI
FG = {
    'reset': '\033[0m',
    'negro': '\033[30m', 'rojo': '\033[31m', 'verde': '\033[32m',
    'amarillo': '\033[33m', 'azul': '\033[34m', 'magenta': '\033[35m',
    'cyan': '\033[36m', 'blanco': '\033[37m', 'gris': '\033[90m',
    'rojo_claro': '\033[91m', 'verde_claro': '\033[92m',
    'amarillo_claro': '\033[93m', 'azul_claro': '\033[94m',
    'magenta_claro': '\033[95m', 'cyan_claro': '\033[96m',
}
BG = {
    'negro_bg': '\033[40m', 'rojo_bg': '\033[41m', 'verde_bg': '\033[42m',
    'amarillo_bg': '\033[43m', 'azul_bg': '\033[44m', 'magenta_bg': '\033[45m',
    'cyan_bg': '\033[46m', 'blanco_bg': '\033[47m',
}

# ----------------------------------------------------------------------
# 2. PANTALLA DE CARGA
# ----------------------------------------------------------------------
def pantalla_carga():
    os.system('cls' if os.name == 'nt' else 'clear')
    print(FG['amarillo'] + "Cargando simulación..." + FG['reset'])
    barra = "█" * 0
    for i in range(101):
        time.sleep(0.02)
        barra = "█" * (i // 2) + "░" * (50 - i // 2)
        sys.stdout.write(f"\r{FG['verde']}[{barra}] {i}%{FG['reset']}")
        sys.stdout.flush()
    time.sleep(0.5)

# ----------------------------------------------------------------------
# 3. DIBUJOS ASCII MEJORADOS
# ----------------------------------------------------------------------
def dibujar_bar():
    return [
        f"  {FG['amarillo']}________{FG['reset']}  ",
        f" | {FG['rojo']}MOE'S{FG['reset']} | ",
        f" |_______| ",
        "    ||     ",
        "  __||__   "
    ]

def dibujar_casa():
    return [
        f"            {FG['amarillo']}______{FG['reset']}   ",
        f"           /      \\  ",
        f" /________\\ ",
        f" |  [ ]  |  ",
        f" |  _|_  |  ",
        f" |_______|  ",
    ]

def dibujar_muneco(col, ancho_total, direccion):
    if direccion == 1:
        cabeza, torso, piernas = '☺', '|', '/\\'
        brazo_izq, brazo_der = '/', '\\'
    elif direccion == -1:
        cabeza, torso, piernas = 'o', '|', '/\\'
        brazo_izq, brazo_der = '\\', '/'
    else:
        cabeza, torso, piernas = 'ö', '|', '/\\'
        brazo_izq, brazo_der = '/', '\\'

    cuerpo = ["", "", ""]
    linea0 = [" "] * ancho_total
    if 0 <= col < ancho_total:
        linea0[col] = cabeza
    cuerpo[0] = ''.join(linea0)

    linea1 = [" "] * ancho_total
    if col-1 >= 0: linea1[col-1] = brazo_izq
    if col < ancho_total: linea1[col] = torso
    if col+1 < ancho_total: linea1[col+1] = brazo_der
    cuerpo[1] = ''.join(linea1)

    linea2 = [" "] * ancho_total
    if col-1 >= 0: linea2[col-1] = '/'
    if col+1 < ancho_total: linea2[col+1] = '\\'
    cuerpo[2] = ''.join(linea2)
    return cuerpo

def crear_cielo(ancho_total, ciclo):
    linea = [' '] * ancho_total
    hora = ciclo * 24
    if 6 <= hora < 18:
        sol_col = int((hora - 6) / 12 * ancho_total) % ancho_total
        if 0 <= sol_col < ancho_total:
            linea[sol_col] = f"{FG['amarillo']}☀{FG['reset']}"
        fondo = BG['cyan_bg']
    else:
        luna_col = int(((hora + 6) % 24) / 12 * ancho_total) % ancho_total
        if 0 <= luna_col < ancho_total:
            linea[luna_col] = f"{FG['blanco']}☽{FG['reset']}"
        random.seed(int(ciclo * 1000))
        for _ in range(20):
            pos = random.randint(0, ancho_total-1)
            linea[pos] = f"{FG['gris']}·{FG['reset']}"
        fondo = BG['negro_bg']
    return ''.join(linea), fondo

# ----------------------------------------------------------------------
# 4. OBSTÁCULOS FIJOS
# ----------------------------------------------------------------------
def generar_mapa(meta, semilla=42):
    rng = random.Random(semilla)
    obstaculos = {}
    for _ in range(5):
        pos = rng.randint(10, meta-10)
        obstaculos[pos] = {'tipo': 'charco', 'simbolo': '≈'}
    for _ in range(3):
        pos = rng.randint(10, meta-10)
        obstaculos[pos] = {'tipo': 'atajo', 'simbolo': '»'}
    return obstaculos

# ----------------------------------------------------------------------
# 5. COMBINAR ESCENARIO (1 BORRACHO)
# ----------------------------------------------------------------------
def combinar_escenario(posicion, meta, obstaculos, ciclo, historial, ancho_total=100):
    bar = dibujar_bar()
    casa = dibujar_casa()
    bar_ancho = len(bar[0])
    casa_ancho = len(casa[0])
    camino_inicio = bar_ancho + 1
    camino_fin = ancho_total - casa_ancho - 1
    camino_ancho = camino_fin - camino_inicio
    escala = camino_ancho / meta if camino_ancho > 0 else 0

    max_altura = max(len(bar), len(casa)) + 3
    escena = [[' ' for _ in range(ancho_total)] for _ in range(max_altura)]

    # Bar
    for i, linea in enumerate(bar):
        for j, ch in enumerate(linea):
            if j < ancho_total:
                escena[i][j] = ch

    # Casa
    casa_inicio = ancho_total - casa_ancho
    for i, linea in enumerate(casa):
        for j, ch in enumerate(linea):
            if casa_inicio + j < ancho_total:
                escena[i][casa_inicio + j] = ch

    # Obstáculos en el suelo
    for pos, obs in obstaculos.items():
        col = int(pos * escala) + camino_inicio
        if 0 <= col < ancho_total:
            escena[-1][col] = f"{FG['cyan']}{obs['simbolo']}{FG['reset']}"

    # Estela
    for i, (pos, _) in enumerate(historial):
        col = int(pos * escala) + camino_inicio
        if 0 <= col < ancho_total:
            intensidad = max(0, 1.0 - i / len(historial))
            if intensidad > 0.7:
                char = f"{FG['rojo']}●{FG['reset']}"
            elif intensidad > 0.4:
                char = f"{FG['gris']}○{FG['reset']}"
            else:
                char = f"{FG['gris']}·{FG['reset']}"
            escena[-1][col] = char

    # Muñeco
    col = int(posicion * escala) + camino_inicio
    col = max(0, min(col, ancho_total-1))
    if historial:
        dir_actual = 1 if posicion > historial[0][0] else -1 if posicion < historial[0][0] else 0
    else:
        dir_actual = 0
    muneco = dibujar_muneco(col, ancho_total, dir_actual)
    offset_filas = len(bar)
    for i, linea in enumerate(muneco):
        fila = offset_filas + i
        if fila < max_altura:
            for j, ch in enumerate(linea):
                if ch != ' ':
                    escena[fila][j] = f"{FG['rojo']}{ch}{FG['reset']}"

    # Suelo
    suelo = ['_' for _ in range(ancho_total)]
    if escena[-1][casa_inicio+2] == ' ':
        suelo[casa_inicio+2] = f"{FG['amarillo']}H{FG['reset']}"
    suelo[bar_ancho] = f"{FG['rojo']}M{FG['reset']}"
    escena[-1] = ''.join(suelo)

    # Cielo
    cielo, fondo_cielo = crear_cielo(ancho_total, ciclo)
    linea_cielo = f"{fondo_cielo}{cielo}{FG['reset']}"

    lineas_final = [''.join(fila) for fila in escena]
    lineas_final.insert(0, linea_cielo)
    return lineas_final

# ----------------------------------------------------------------------
# 6. SIMULACIÓN PRINCIPAL
# ----------------------------------------------------------------------
def simular():
    pantalla_carga()
    meta = 750
    posicion = 0
    pasos = 0
    historial = deque(maxlen=20)
    obstaculos = generar_mapa(meta, semilla=int(time.time()) % 1000)
    ciclo = 0.0

    inicio = datetime.now()
    nombre_csv = f"simulacion_deluxe_{inicio.strftime('%Y%m%d_%H%M%S')}.csv"
    archivo_csv = open(nombre_csv, 'w', newline='', encoding='utf-8')
    escritor = csv.writer(archivo_csv)
    escritor.writerow(['Paso', 'Timestamp', 'Movimiento', 'Posicion'])
    archivo_csv.flush()

    print(f"{FG['verde']}Simulación del borracho: de MOE'S a casa ({meta} pasos){FG['reset']}")
    print(f"Inicio: {inicio.strftime('%H:%M:%S')}")
    print("Presiona Ctrl+C para detener.\n")
    time.sleep(1)

    try:
        while posicion < meta:
            # Movimiento (favorece avance)
            movimientos = [3, 2, 1, 0, -1, -20]  
            pesos =       [0.05, 0.3, 0.3, 0.24, 0.1, 0.01] 
            avance = random.choices(movimientos, weights=pesos)[0]
            posicion += avance
            posicion = max(0, posicion)
            pasos += 1

            historial.appendleft((posicion, time.time()))

            ahora = datetime.now()
            escritor.writerow([pasos, ahora.strftime('%Y-%m-%d %H:%M:%S'), avance, posicion])
            archivo_csv.flush()

            ciclo = (time.time() % 60) / 60.0

            os.system('cls' if os.name == 'nt' else 'clear')
            escenario = combinar_escenario(posicion, meta, obstaculos, ciclo, historial, ancho_total=100)
            for linea in escenario:
                print(linea)

            transcurrido = (ahora - inicio).total_seconds()
            print(f"{FG['blanco']}Hora inicio: {inicio.strftime('%H:%M:%S')} | Hora actual: {ahora.strftime('%H:%M:%S')} | Transcurrido: {transcurrido:.1f}s{FG['reset']}")
            print(f"Pasos: {pasos} | Posición: {posicion}/{meta}")
            # Barra de progreso
            progreso = posicion / meta
            barra_len = 40
            lleno = int(barra_len * progreso)
            print(f"[{'█'*lleno}{'░'*(barra_len-lleno)}] {progreso*100:.0f}%")

            time.sleep(0.08)

    except KeyboardInterrupt:
        fin = datetime.now()
        print("\n\nSimulación interrumpida.")
        print(f"Inicio: {inicio.strftime('%H:%M:%S')}")
        print(f"Fin:    {fin.strftime('%H:%M:%S')}")
        print(f"Duración: { (fin-inicio).total_seconds():.1f} segundos")
    else:
        fin = datetime.now()
        duracion = (fin - inicio).total_seconds()
        print(f"\n🎉 ¡Llegó a casa en {pasos} pasos! ({duracion:.1f} segundos)")
        print(f"Inicio: {inicio.strftime('%H:%M:%S')}")
        print(f"Fin:    {fin.strftime('%H:%M:%S')}")
    finally:
        archivo_csv.close()
        print(f"Registro guardado en {nombre_csv}")

    print(f"{FG['verde']}Fin de la simulación.{FG['reset']}")

if __name__ == "__main__":
    simular()