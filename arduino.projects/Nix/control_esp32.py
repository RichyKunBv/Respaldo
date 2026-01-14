import serial
import pyautogui
import time
from ctypes import cast, POINTER
from comtypes import CLSCTX_ALL
from pycaw.pycaw import AudioUtilities, IAudioEndpointVolume

# --- CONFIGURACIÓN ---
ESP32_PORT = 'COM3' # <-- Revisa que este sea el puerto COM correcto
BAUD_RATE = 115200

print("--- Script de Control Nix v2.0 ---")
print(f"Escuchando en el puerto {ESP32_PORT} a {BAUD_RATE} baudios.")
print("Presiona Ctrl+C para detener.")

pyautogui.FAILSAFE = True

def get_volume_control():
    devices = AudioUtilities.GetSpeakers()
    interface = devices.Activate(IAudioEndpointVolume._iid_, CLSCTX_ALL, None)
    return cast(interface, POINTER(IAudioEndpointVolume))

def connect_to_esp32():
    while True:
        try:
            ser = serial.Serial(ESP32_PORT, BAUD_RATE, timeout=1)
            print(f"¡Conexión establecida con el ESP32 en {ESP32_PORT}!")
            return ser
        except serial.SerialException:
            print(f"Error: No se pudo conectar al puerto {ESP32_PORT}. Reintentando en 5 segundos...")
            time.sleep(5)

def main():
    ser = connect_to_esp32()
    
    while True:
        try:
            if ser.in_waiting > 0:
                command = ser.readline().decode('utf-8').strip()
                if command:
                    print(f"-> Comando: '{command}'")
                    if command == "PLAY_PAUSE": pyautogui.press('playpause')
                    elif command == "NEXT_TRACK": pyautogui.press('nexttrack')
                    elif command == "PREV_TRACK": pyautogui.press('prevtrack')
                    elif command == "VOL_UP":
                        pyautogui.press('volumeup')
                    elif command == "VOL_DOWN":
                        pyautogui.press('volumedown')
        except serial.SerialException:
            print("Error: Se perdió la conexión con el ESP32.")
            ser.close()
            ser = connect_to_esp32()
        except KeyboardInterrupt:
            print("\nDeteniendo el script.")
            break
        except Exception as e:
            print(f"Ocurrió un error inesperado: {e}")
            time.sleep(2)

    if ser.is_open: ser.close()
    print("Script finalizado.")

if __name__ == "__main__":
    main()