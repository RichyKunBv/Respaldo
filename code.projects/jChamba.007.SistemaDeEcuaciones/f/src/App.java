import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
//Autores: RicardoEscamillaMedina y AlanGarciaRocha    
    
            //Declaracion
    Scanner scanner = new Scanner(System.in);
    System.out.println("Ingrese X:");
    double X = scanner.nextDouble();
    
    Scanner scanneri = new Scanner(System.in);
    System.out.println("Ingrese Y:");
    double Y = scanneri.nextDouble();
   
    double r = 0;

            //Proceso
    if( X > 0) {
        r = (1 / ( 3 * (Math.pow ( Y, 3)))) + 3 * (Math.pow (X, 2) - 1);
        System.out.println(r);            
    } else if(X == 0) {
        r = (3 * Math.pow(Y, X) + 6 * Math.pow(Y, 2) + 2 * Math.pow(Y, 3)) / (5 * Math.pow(Y, X) + 7 * Math.pow(Y, 4) + 9 * Math.pow(Y, 6));
        System.out.println(r);
     } else if(X < 0) {
        System.out.println("Syntax Error (no se puede XD)");
        }
    }
}