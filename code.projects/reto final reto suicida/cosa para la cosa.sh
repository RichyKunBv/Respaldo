#!/bin/bash

IP="192.168.150.128"
REPORTE="puertos_abiertos.txt"
DATOS_SALIDA="datos_simulacion.csv"

MAX_BYTES=0
PUERTO=0

echo "Leyendo de $REPORTE..."

PUERTOS=$(grep -o -E '[0-9]+' "$REPORTE")

for puerto in $PUERTOS; do
    echo "esperando a que el $puerto haga algo :VVV..."

    BYTES=$(timeout 3 nc "$IP" "$puerto" 2>/dev/null | wc -c)
    
    echo "    -> Tráfico recibido: $BYTES bytes"

    if (( BYTES > MAX_BYTES )); then
        MAX_BYTES=$BYTES
        PUERTO=$puerto
    fi
done

echo "------------------------------------------------"
echo "PUERTO: $PUERTO Tráfico: $MAX_BYTES bytes"
echo "------------------------------------------------"

echo "Guardando $DATOS_SALIDA..."

timeout 5 nc "$IP" "$PUERTO" > "$DATOS_SALIDA"

