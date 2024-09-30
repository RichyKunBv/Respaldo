import java.util.ArrayList;
import java.util.Collections;

public class App {
    @SuppressWarnings("unchecked")   
    public static void main(String[] args) throws Exception {
        @SuppressWarnings("rawtypes")
        ArrayList lista = new ArrayList();

        lista.add(6);   //0
        lista.add(4);   //1
        lista.add(1);   //2
        lista.add(3);   //3
        lista.add(5);   //4
        lista.add(2);   //5

        System.out.println("Tamaño: " +
            lista.size());

        for( Object value: lista){
            System.out.print((int) value + "\t");
        }
        System.out.println();

        System.out.println("Item [2]: " +
            lista.get(1));

        System.out.println("Item [5]: " +
            lista.get(4));

        lista.remove(4);
        System.out.println("Tamanio: " +
        lista.size());

        for (Object value : lista) {
            System.out.print((int) value + "\t");
        }
        System.out.println();

        Collections.sort(lista);        
        for (Object value : lista) {
            System.out.print((int) value + "\t");
        }
        System.out.println();




    }
}