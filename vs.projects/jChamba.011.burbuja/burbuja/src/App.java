public class App {
    public static void main(String[] args) throws Exception {
        int A[] = new int [] {5, 1, 3, 2, 6, 4};
        boolean isChange = false;

        int temp= 0;
        int index =0;

        for(int value: A) {
            System.out.print(value + " \t ");
        }
        System.out.println();

        while(!isChange) {
            isChange = true;
            index = 0;
            while(index < A.length - 1) {
                if(A[index] >= A [index + 1]) {
                    temp = A[index + 1];
                    A[index + 1] = A [index];
                    A[index] = temp;
                    isChange = false;              
                    }
                index++;
                }  
            for (int value : A) {
            System.out.print(value + " \t ");
            }
        System.out.println();
        }
    }
}