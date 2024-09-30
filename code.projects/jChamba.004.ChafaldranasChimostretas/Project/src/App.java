public class App {
    public static void main(String[] args) throws Exception {
        
        //Declaracion
        double c = 0.0000000;
        double ch = 0.000000;
        double ñ = 0;

        //Proceso
        ñ = (((25 * 55) * 2) - ((35 * 35) * 2));
        c = (((1250 * 55) * 2) - ((2750 * 35) * 2)) / ñ;
        ch = (((25 * 2750) * 2) - ((1250 * 35) * 2)) / ñ;

        //Salida
        System.out.println("Precio de chafaldranas: " + c);
        System.out.println("Precio de chimostretas: " + ch);  

    }
}