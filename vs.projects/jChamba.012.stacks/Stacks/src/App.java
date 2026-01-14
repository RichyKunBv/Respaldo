import java.util.Stack;

public class App {
    public static void main(String[] args) throws Exception {
        Stack S = new Stack();

        S.push(5);
        S.push(1);
        S.push(4);

        System.out.println("Size: " + S.size());

        System.out.println(S.pop());

        System.out.println("Size: " + S.size());

        System.out.println("Item: " + S.peek());

        System.out.println("Empty: " + S.isEmpty());

        System.out.println("Size: " + S.size());

        System.out.println("Item #2: " + S.get(0));

    }
}
