import java.util.Scanner;
import java.util.Stack;
import java.util.Queue;
import java.util.LinkedList;

public class App {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Ingresa un número entero positivo mayor o igual a 1: ");
        int number = scanner.nextInt();
        if (number < 1) {
            System.out.println("El número debe ser mayor o igual a 1.");
            return;
        }

        System.out.print("Ingresa la base (entre 2 y 9): ");
        int base = scanner.nextInt();
        if (base < 2 || base > 9) {
            System.out.println("La base debe estar entre 2 y 9.");
            return;
        }

        convertAndShowProcess(number, base);
    }

    public static void convertAndShowProcess(int number, int base) {
        Stack<Integer> stack = new Stack<>();
        Queue<Integer> queue = new LinkedList<>();

        int originalNumber = number;

        System.out.println("Proceso de conversión:");

        while (number > 0) {
            queue.add(number); 
            int remainder = number % base; 
            stack.push(remainder); 
            number = number / base; 
        }

        while (!queue.isEmpty()) {
            int currentNumber = queue.poll();
            int remainder = stack.get(stack.size() - queue.size() - 1); 
            System.out.println("Dividendo: " + currentNumber + ", Divisor: " + base + ", Cociente: "
                    + (currentNumber / base) + ", Residuo: " + remainder);
        }

        StringBuilder result = new StringBuilder();
        while (!stack.isEmpty()) {
            result.append(stack.pop());
        }

        System.out.println("El número " + originalNumber + " en base " + base + " es: " + result);
    }
}
