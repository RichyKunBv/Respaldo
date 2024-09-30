import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
    //Autores: RicardoEscamillaMedina y AlanGarciaRocha

    
Scanner scanner = new Scanner(System.in);
System.out.println("Ingrese la temperatura en grados Celsius:");
double celsius = scanner.nextDouble();

double kelvin = celsius + 273.15;
double fahrenheit = (celsius * 9 / 5) + 32;

System.out.println(celsius + " grados Celsius son equivalentes a:");
System.out.println(kelvin + " grados Kelvin");
System.out.println(fahrenheit + " grados Fahrenheit");

scanner.close();
}
}