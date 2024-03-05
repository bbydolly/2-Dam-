package ProgramPrimero;

import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.Scanner;

public class Funciones {
    static int[][] creaMatriz(int nMagos) {
        int matriz[][] = new int[nMagos][4];

        for (int i = 0; i < matriz.length; i++) {
            for (int j = 0; j < matriz[i].length; j++) {
                matriz[i][j] = (int) (Math.random() * (5 - 1 + 1)) + 1;
            }
        }
        return matriz;
    }

    static void mostrarMatriz(int[][] matriz) {
        if (matriz != null) {

            char[] letras = { 'A', 'F', 'E', 'W' };
            char espacio = ' ';
            System.out.printf("%3c", espacio);
            for (int t = 0; t < letras.length; t++) {
                System.out.printf("%5c", letras[t]);

            }
            System.out.println();
            for (int i = 0; i < matriz.length; i++) {
                // System.out.print(i+1);
                System.out.printf("%3d", i + 1); //para numrar las filas desde 1

                for (int j = 0; j < matriz[i].length; j++) {
                    System.out.printf("%5d", matriz[i][j]);
                }
                System.out.println();
            }
        }

    }

    public static int poderMago(int[][] matriz, int fila) {
        int acu = 0;
        if (fila > matriz.length) {
            throw new WizardException();
        } else {
            int cont = 0;
            for (int[] filas : matriz) { // mi fila es un array de valores,

                if (cont == fila) {

                    for (int valor : filas) { // valor es matriz[i][j]
                        acu += valor;
                        // System.out.printf("%5d",valor);

                    }
                    // System.out.println();
                }
                cont++;
            }
            return acu;
        }
    }

    public static void intercambiarFilas(int[][] matriz, int f1, int f2) {
        //int[][] m2 = new int[matriz.length][matriz.length];
        int[][]m2=new int[matriz.length][4];

      // mostrarMatriz(matriz);
        // intercambio las filas creando una matriz auxiliar
        for (int i = 0; i < matriz.length; i++) {
            for (int j = 0; j < matriz[i].length; j++) {
                if (i == f1) {

                    m2[f1][j] = matriz[f2][j];

                }
                if (i == f2) {
                    m2[f2][j] = matriz[f1][j]; // en 0,0 está mi primera fila

                }
                if (i != f1 && i != f2) {
                    m2[i][j] = matriz[i][j];
                }
            }
        }
        System.out.println();
        mostrarMatriz(m2);

    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        int[][] matriz = creaMatriz(11);
        mostrarMatriz(matriz);
        intercambiarFilas(matriz, 1, 10);
        intercambiarFilas(matriz, 1, 10);
        //TODO control de excepciones con petición de dato
        int n = 0;
        //no sé como gestionar volver a pedir un dato
       // do {
            
            // System.out.println("Dime un número");
            // try {
            //     do {
            //         n = sc.nextInt();
                    
            //     } while (n <= 0 || n > matriz.length);
                
            //     System.out.println("El poder total del mago es " + poderMago(matriz, n));
                
            //     // } catch (IndexOutOfBoundsException e) {
                //booleana a false o a true y meter todo en un while
            //         //     System.out.println("Fuera de rango, introduce un valor entre 1 y 11, ambos incluidos");
                    
            //     } catch (InputMismatchException i) {
            //         System.out.println("dato icorrecto, escribe un número");
            //     }catch(WizardException w){
                    
                    
            // }
                
       // } while (n!=0);
       
        //intercambiarFilas(matriz, 1, 10);
       //mostrarMatriz(matriz);

    }
}