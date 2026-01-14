public class App {
    public static void steMessage(String text) {
        System.out.println(text);
        System.out.println(sumaValores(3, 6));
    }

    public static double sumaValores(double x, double y) {
        double resultado = 0;
        resultado = x + y;
        return resultado;
    }

    public static void getIntValue(String message) {
        try{
            do{
                System.out.print(message);
                return (new java.util.Scanner(System.in)).nextInt();
            }while(true);
        } catch(Exception ex) {
            System.out.println(ex.getMessage());
        }
    }

    public static void main(String[] args) throws Exception {
        steMessage("Hola mundo");
        double x = 5;
        double y = 10;
        double z = 0;

        z = suma 

    }
}
