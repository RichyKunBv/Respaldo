public class App {
    public static void main(String[] args) throws Exception {
        //Autores: RicardoEscamillaMedina y AlanGarciaRocha
        
        //Declaracion
        final int a = 1;
        final int b = 3;
        final int c = 2;
        
        //Proceso
        if( a > b && b > c && a > c) {
            System.out.println(a + " "+ b + " " + c);            
        } else if(c > b && b > a && a > c) {
            System.out.println(c + " "+ b + " " + c);
        } else if( b > c && c > a && b > a){
            System.out.println(b + " "+ c + " " + a);
        }
    }  
}