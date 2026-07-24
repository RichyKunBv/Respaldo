# simulacion.R

# numeros aleatorioz
generar_datos <- function(n) {
  
  # los numeros aleatorios de las funciones del poderoso excel
  demanda <- rnorm(n, mean = 10000, sd = 2000)
  precio_venta <- runif(n, min = 50, max = 70)
  costo <- rnorm(n, mean = 30, sd = 5)
  
  # Calcular la ganancia
  ganancia <- demanda * (precio_venta - costo)
  
  # Crear un Data Frame con los resultados
  df <- data.frame(Demanda = demanda, 
                   Precio_de_Venta = precio_venta, 
                   Costo = costo, 
                   Ganancia = ganancia)
  
  return(df)
}