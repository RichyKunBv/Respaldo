#!/bin/bash

LOG="reporte_red_30s.txt"

echo "Capturando tráfico 30 seg, aguanta..."

echo "--- REPORTE DE RED ---" > $LOG
date >> $LOG
echo "" >> $LOG

echo "[Puertos abiertos]" >> $LOG
sudo ss -tulnp >> $LOG
echo "" >> $LOG

echo "[Conexiones y RTT]" >> $LOG
sudo ss -tnpi >> $LOG
echo "" >> $LOG

echo "[Trafico por app - 30s]" >> $LOG
# 30 ciclos de 1 seg
sudo nethogs -t -d 1 -c 30 >> $LOG

echo "$LOG"