import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
    //Autores: RicardoEscamillaMedina y AlanGarciaRocha
        
    Scanner scanner = new Scanner(System.in);
    System.out.println("Ingrese la temperatura en grados Celsius:");
    double celsius = scanner.nextDouble();
    
    double kelvin = celsius + 273.15;
    double fahrenheit = (celsius * 9 / 5) + 32;
   

    System.out.println("Ingrese la temperatura en Kelvin:");
    double kevin = scanner.nextDouble();
    
    double celsiu = kevin - 273.15;
    double fahrenhei = (kevin * 9 / 5) - 459.67;
    

    System.out.println("Ingrese la temperatura en grados fahrenheit:");
    double farenjai = scanner.nextDouble();
    
    double kalvin = (((farenjai + 273.15)* 5)/9);
    double c = ((farenjai - 32) * 5) / 9;
    

    System.out.println(celsius + " grados Celsius son equivalentes a:");
    System.out.println(kelvin + " grados Kelvin");
    System.out.println(fahrenheit + " grados Fahrenheit");
    System.out.println("   ");

    System.out.println(celsiu + " grados Celsius son equivalentes a:");
    System.out.println(kevin + " grados Kelvin");
    System.out.println(fahrenhei + " grados Fahrenheit");
    System.out.println("   ");

    System.out.println(c + " grados Celsius son equivalentes a:");
    System.out.println(kalvin + " grados Kelvin");
    System.out.println(farenjai + " grados Fahrenheit");
    System.out.println("   ");

    scanner.close();
    }
    }