public class App {
    public static void main(String[] args) throws Exception {
        String text = "Tres tristes tigres tragaban trigo en un trigal";

        System.out.println("Texto: " + text);

        char letters[] = text.toCharArray();

        for(char letter: letters) {
            System.out.print(letter);
        }
        System.out.println();

        for(char letter: letters) {
            System.out.print((int) letter + " ");
        }

    }
}
