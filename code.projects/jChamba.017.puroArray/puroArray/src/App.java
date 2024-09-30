import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

class Entry {
    int cantidad;
    String concepto;
    int PU;
    int totalCtd;

    Entry(int cantidad, String concepto, int PU) {
        this.cantidad = cantidad;
        this.concepto = concepto;
        this.PU = PU;
        this.totalCtd = cantidad * PU;
    }
}

public class App {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        ArrayList<Entry> entries = new ArrayList<>();

        boolean continuar = true;
        while (continuar) {
            System.out.println("\nOpciones:");
            System.out.println("1. Agregar entrada");
            System.out.println("2. Eliminar entrada");
            System.out.println("3. Mostrar y guardar en txt");
            System.out.println("4. Salir");
            System.out.print("Seleccione una opción: ");
            int opcion = Integer.parseInt(scanner.nextLine());

            switch (opcion) {
                case 1:
                    System.out.print("Ingrese cantidad: ");
                    int cantidad = 0;
                    try {
                        cantidad = Integer.parseInt(scanner.nextLine());
                    } catch (NumberFormatException e) {
                        System.out.println("Error: Ingrese un número entero válido para la cantidad.");
                        continue;
                    }

                    System.out.print("Ingrese concepto: ");
                    String concepto = scanner.nextLine();

                    System.out.print("Ingrese precio unitario: ");
                    int PU = 0;
                    try {
                        PU = Integer.parseInt(scanner.nextLine());
                    } catch (NumberFormatException e) {
                        System.out.println("Error: Ingrese un número entero válido para el precio unitario.");
                        continue;
                    }

                    entries.add(new Entry(cantidad, concepto, PU));
                    break;

                case 2:
                    System.out.print("Ingrese el índice de la entrada a eliminar: ");
                    int index = Integer.parseInt(scanner.nextLine());
                    if (index >= 0 && index < entries.size()) {
                        entries.remove(index);
                        System.out.println("Entrada eliminada.");
                    } else {
                        System.out.println("Índice inválido.");
                    }
                    break;

                case 3:
                    mostrarYGuardarEnTxt(entries);
                    break;

                case 4:
                    continuar = false;
                    break;

                default:
                    System.out.println("Opción no válida.");
            }
        }

        scanner.close();
    }

    private static void mostrarYGuardarEnTxt(ArrayList<Entry> entries) {
        // Calculate total and IVA
        int totalSinIVA = 0;
        for (Entry entry : entries) {
            totalSinIVA += entry.totalCtd;
        }
        double IVA = totalSinIVA * 0.16;

        System.out.println("\nDatos ingresados:");
        for (Entry entry : entries) {
            System.out.println("Cantidad: " + entry.cantidad + ", Concepto: " + entry.concepto + ", P.U: " + entry.PU + ", Total Ctd: " + entry.totalCtd);
        }

        // Manual sorting by cantidad (insertion sort)
        for (int i = 1; i < entries.size(); i++) {
            Entry key = entries.get(i);
            int j = i - 1;
            while (j >= 0 && entries.get(j).cantidad > key.cantidad) {
                entries.set(j + 1, entries.get(j));
                j = j - 1;
            }
            entries.set(j + 1, key);
        }

        // Display sorted list
        System.out.println("\nDatos ordenados por cantidad:");
        for (Entry entry : entries) {
            System.out.println("Cantidad: " + entry.cantidad + ", Concepto: " + entry.concepto + ", P.U: " + entry.PU + ", Total Ctd: " + entry.totalCtd);
        }

        // Display total and IVA
        System.out.println("\nTotal sin IVA: " + totalSinIVA);
        System.out.println("IVA (16%): " + IVA);
        System.out.println("Total con IVA: " + (totalSinIVA + IVA));

        // Save to txt
        try (FileWriter writer = new FileWriter("entries.txt")) {
            writer.write("Cantidad\tConcepto\tP.U\tTotal Ctd\n");
            for (Entry entry : entries) {
                writer.write(entry.cantidad + "\t" + entry.concepto + "\t" + entry.PU + "\t" + entry.totalCtd + "\n");
            }
            writer.write("\nTotal sin IVA: " + totalSinIVA + "\n");
            writer.write("IVA (16%): " + IVA + "\n");
            writer.write("Total con IVA: " + (totalSinIVA + IVA) + "\n");
            System.out.println("Datos guardados en entries.txt");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}