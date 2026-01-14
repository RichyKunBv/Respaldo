import java.util.Scanner;

public class App {

    public static String getFigure(int value) {
        StringBuilder figure = new StringBuilder();
        if (value == 1) {
            return "*";
        }
        for (int x = 1; x <= value; x++) {
            for (int y = 1; y <= x; y++) {
                figure.append(" *");
            }
            figure.append("\n");
        }
        return figure.toString();
    }

    // Función que lee datos del usuario
    public static int getIntegerValue(String message) {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            try {
                System.out.print(message);
                return scanner.nextInt();
            } catch (Exception exception) {
                System.out.println("Error: " + exception.getMessage());
                scanner.next(); // Limpiar el buffer del scanner
            }
        }
    }

    public static void main(String[] args) {
        int value;
        while (true) {
            value = getIntegerValue("Ingresa la base (entre 1 y 30): ");
            if (value >= 1 && value <= 30) {
                break;
            } else {
                System.out.println("La base debe estar entre 1 y 30.");
            }
        }

        String result = getFigure(value);
        System.out.println(result);
    }
}
