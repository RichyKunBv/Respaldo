public class app2 {
    public static void main(String args[] ) {
        int tope = 8;
        for(int i = 1; i <= tope; i++){
            for(int k = tope - i; k >= 1; k--) {
                System.out.print(' ');
            }
            for(int j = 1; j <= i; j++) {
                System.out.print('*');
            }
            System.out.println();
        }
    }
}