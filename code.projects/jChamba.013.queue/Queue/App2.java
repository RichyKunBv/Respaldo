import java.util.LinkedList;
import java.util.Queue;
import java.util.Random;
import java.util.concurrent.ThreadLocalRandom;

public class App2 {
    public static void main(String[] args) {
        Queue<Integer> queue = new LinkedList<>();

        int min = 15;
        int max = 20;

        int numeroAleatorio = ThreadLocalRandom.current().nextInt(min, max + 1);
        System.out.println("Número aleatorio entre " + min + " y " + max + ": " + numeroAleatorio);

        int man = 1;
        int mix = 10;

        for (int i = 0; i < numeroAleatorio; i++) {
            int randomNumber = ThreadLocalRandom.current().nextInt(man, mix);
            queue.add(randomNumber);
        }

        System.out.print("Cola inicial: [");
        for (int num : queue) {
            System.out.print(num + " ");
        }
        System.out.println("]");

        while (!queue.isEmpty()) {
            System.out.print("[");
            for (int num : queue) {
                System.out.print(num + " ");
            }
            System.out.print("] ");
            Queue<Integer> nuevaCola = new LinkedList<>();
            for (int num : queue) {
                if (num > 3) {
                    nuevaCola.add(num - 1);
                }
            }
            queue = nuevaCola;
            for (int num : queue) {
                System.out.print(num + " ");
            }
            System.out.println();
        }
        System.out.println("Is Empty");
    }
}
