#!/usr/bin/env Rscript

# Suprimir mensajes de carga para mantener limpia la salida
suppressPackageStartupMessages({
  library(readxl)
  library(jsonlite)
})

# Obtener la ruta del archivo pasado como argumento desde Python
args <- commandArgs(trailingOnly = TRUE)
archivo_excel <- ifelse(length(args) > 0, args[1], "Datos.xlsx")

# Leer exactamente la hoja denominada "Datos"
datos <- read_excel(archivo_excel, sheet = "Datos")

# Calcular promedio y desviación estándar
promedio <- mean(datos$Valor, na.rm = TRUE)
desviacion <- sd(datos$Valor, na.rm = TRUE)
total_datos <- nrow(datos)

# Crear estructura de resultados (incluyendo 2σ y 3σ)
resultados <- list(
  promedio = promedio,
  sigma1 = desviacion,
  sigma2 = 2 * desviacion,
  sigma3 = 3 * desviacion,
  total = total_datos
)

# Imprimir en formato JSON hacia la salida estándar (stdout)
cat(toJSON(resultados, auto_unbox = TRUE))
