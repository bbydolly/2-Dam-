package pruebaspoo;

public class Ejercicio2aEv {
    private int matriz[][];

    // al ser un prop. privada para acceder a ella necesito el getMatriz

    // public int[][] getMatriz(){
    // return matriz;
    // }
    // public void setMatriz(int n, int m){

    // matriz = new int [n][m];
    // }

    public Ejercicio2aEv(int n, int m) {
        // this.matriz= new int[n][m];
        matriz = new int[n][m];
        int numRandom;

        for (int i = 0; i < matriz.length; i++) {
            // Contar cuantas vueltas da el bucle , 0, y es menor que si .lenght
            for (int j = 0; j < matriz[i].length; j++) {
                if (i % 2 == 0 || i == 0) {
                    numRandom = (int) (Math.random() * 21 + 0);
                } else {
                    numRandom = (int) (Math.random() * 11 + 90);

                }
                matriz[i][j] = numRandom; // 1 celda 1 valor
            }
        }

    }

    public Ejercicio2aEv() {
        // super(); Se usa cuando llamo a un constructor desde la clase hija
        this(15, 15); // This para llamar a otro constructor en la misma clase

    }

    public void visualizarMatriz(int m[][]) {
        // int var = m.length;

        String cabecera = "";

        System.out.printf("%70s", "VISUALIZAR MATRIZ BONITA");
        // TODO ¿cómo pongo las cabeceras de la A-Z sin que se repitan y la fila 00 sin que me salga?
        // for (int k = 0; k < m[i][j]; k++) {
            
        //     System.out.printf(" %4s ", "az");
        // }
        // System.out.println();

        for (int i = 0; i < m.length; i++) {
            if (i >= 9 && i < 99) {
                cabecera = "FILA0";
            } else if (i <= 9) {
                cabecera = "FILA00";
            } else if (i >= 99) {
                cabecera = "FILA";
                // TODO corregit
            }
            System.out.println();
            System.out.printf("%7s", cabecera + (i + 1));

            for (int j = 0; j < m[i].length; j++) {
                System.out.printf(" %4d ", m[i][j]);
            }
        }
    }

    public static void main(String[] args) {
        // Stati permite el acceso a metodos, variabkes de clase sin
        // necesidad de instanciar un objeto de dicha clase
        Ejercicio2aEv ej1 = new Ejercicio2aEv(10, 5);
        int[][] m = ej1.matriz;
        ej1.visualizarMatriz(m);

    }
}
