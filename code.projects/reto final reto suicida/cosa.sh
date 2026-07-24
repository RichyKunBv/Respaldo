#!/bin/bash

set -o pipefail
set -o nounset

IP="192.168.0.116" 
PARALELO=30
CANTIDAD_PUERTOS=5000
REPORTE="puertos_abiertos.txt"
INTENTOS=3

> "$REPORTE"

echo "Iniciando $IP..."

checar_puerto() {
    local puerto=$1
    
    for i in $(seq 1 $INTENTOS); do
        if nc -z -w 1 "$IP" "$puerto" 2>/dev/null; then
            echo "Puerto $puerto: ABIERTO" >> "$REPORTE"
            echo "Puerto $puerto: ABIERTO"
            return 0 
        fi
        sleep 0.5
    done
}

for (( p=1; p<=$CANTIDAD_PUERTOS; p++ )); do
    
    checar_puerto "$p" &
    
    if (( p % PARALELO == 0 )); then
        wait
    fi
done

wait
echo "$REPORTE."