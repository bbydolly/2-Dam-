import java.util.Scanner;

public class Funciones {
   static int[][] creaMatriz(int nMagos) {
        int matriz[][] = new int[nMagos][4];

        for (int i = 0; i < matriz.length; i++) {
            for (int j = 0; j < matriz[i].length; j++) {
                matriz[i][j] = (int) Math.random() * 1 + 6;
            }
        }
        return matriz;
    }
    static void mostrarMatriz(int [][]matriz){
        char[]letras={'A','F','E','W'};
        for (int t = 0; t < letras.length; t++) {
            System.out.printf("%5c",letras[t]);
            
        }
        for (int i = 0; i < matriz.length; i++) {

            for (int j = 0; j < matriz[i].length; j++) {
                
            }
        }

    }
    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
            //Funciones f= new Funciones();
            int [][]matriz=creaMatriz(6);
            mostrarMatriz(matriz);
    }
}