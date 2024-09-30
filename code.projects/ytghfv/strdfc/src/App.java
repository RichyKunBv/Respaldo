
import java.util.Scanner;
import java.util.Stack;
import java.util.EmptyStackException;

public class App {
    public static void main(String args[]) {
        Scanner scanner = new Scanner(System.in);
        Stack<Integer> stack = new Stack<>();

        System.out.println("Ingrese valores para la pila (ingrese un valor no numérico para detener):");
        while (scanner.hasNextInt()) {
            stack.push(scanner.nextInt());
        }

        System.out.println("Size: " + stack.size());

        try {
            System.out.println("Popped item: " + stack.pop());
        } catch (EmptyStackException e) {
            System.out.println("La pila está vacía, no se puede hacer pop.");
        }

        System.out.println("Size: " + stack.size());

        try {
            System.out.println("Item at the top: " + stack.peek());
        } catch (EmptyStackException e) {
            System.out.println("La pila está vacía, no se puede hacer peek.");
        }

        System.out.println("Empty: " + stack.isEmpty());

        System.out.println("Size: " + stack.size());

        if (!stack.isEmpty()) {
            System.out.println("Item #2: " + stack.get(0));
        } else {
            System.out.println("La pila está vacía.");
        }

        scanner.close();
    }
}