public class App {
    public static void main(String[] args) throws Exception {
        // Declaración 
        double x = 5;
        double y = 8;
        double z = 2;
        double r = 0;
        double temp = 0;
        
        // Proceso
        temp = Math.pow(x, y-1) + Math.pow(y, z-2) + Math.pow(z, x+y);
        r = temp / (x / temp + y / temp + z / temp);
        r = r + 2 * x - 5 * y + 8 * z;
        r = r / 2 * temp;

        // Proceso2
        r = r / x + r / y + r / z;
        x = 2 * r;
        y = 4 * r;
        z = 3 * r;

        // Salida
        System.out.println(x);
        System.out.println(y);
        System.out.println(z);
        System.out.println(r);
    }
}