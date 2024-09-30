import java.util.Scanner;
public class App {
    public static void main(String args[]) {
        int tope = 0;
        Scanner S = new Scanner(System.in);

        try {
            System.out.print("Valor del Tope: ");
            tope = S.nextInt();
        } catch(Exception ex) {
       // System.err.println(ex.getMessage());
        if(tope <= 1 || tope > 30) {
            System.out.println("webos");
            System.exit(0);
        }
        S.close();
        System.out.println("webos");
        System.exit(0);
        }

        int numero = 1;
            for(int i = 1; i <= tope; i++) {
                for(int j = 1; j <= tope; j++) {
                    if((i == 1 && j == 1 ) || (i == 1 && j == tope) ||
                        (i == tope && j == 1) || (i == tope && j == tope))
                    System.out.print("  ");
                else if((2 <= i && i <= tope - 1) &&
                        (2 <= j && j <= tope - 1)){
                    System.out.print(numero + " ");
                    numero ++;
                    if(numero == 10) numero = 0;
                }
                else
                    System.out.print("* ");
                }
                System.out.println();
            }
        }
    }