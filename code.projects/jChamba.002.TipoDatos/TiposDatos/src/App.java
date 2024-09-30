public class App {
    public static void main(String[] args) throws Exception {
        // Declaración 
        double x = 10;
        double y = 25;
        double z = 18;
        double r = 0;

        // Proceso
        r = x / z + y / x;
        r = r + z / y + z / x;

        // Salida
        System.out.println(r);
    }
}