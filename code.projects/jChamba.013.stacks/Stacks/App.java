import java.util.Stack;

public class App {
    public static void main(String[] args)  {
        Stack S = new Stack();

        S.push(5);
        S.push(6);
        S.push(9);
        S.push(3);
        S.push(7);

        System.out.println("Size: " + S.size());

        System.out.println(S.pop());

        System.out.println("Size: " + S.size());

        System.out.println("Item: " + S.peek());

        System.out.println("Empty: " + S.isEmpty());

        System.out.println("Size: " + S.size());

        System.out.println("Item #2: " + S.get(0));

        }
    }