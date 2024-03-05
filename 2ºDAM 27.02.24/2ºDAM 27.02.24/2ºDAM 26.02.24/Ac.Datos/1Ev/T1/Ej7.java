import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
// TODO simplificar código 

public class Ej7 {

    public static  ArrayList<String> leeFich(File fich) {
        ArrayList<String> ordenar =new ArrayList<>();
        try (Scanner sc = new Scanner(fich)) {

            while (sc.hasNextLine()) {
                ordenar.add(sc.nextLine());
                
            }
        } catch(IOException e){
            e.printStackTrace();
        }  
           return ordenar;
    }
    public static void escribir(File fichero, ArrayList<String> ordenar){
        
        try (FileWriter fw = new FileWriter(fichero)) {
        

             for (int i = 0; i < ordenar.size(); i++) { // size, tamaño de mi arrayList
            fw.append(ordenar.get(i)); // añado a mi fw palabras
            System.out.println(ordenar.get(i));
             }
        }catch(IOException e){
            e.getStackTrace();
            System.out.println(e.getLocalizedMessage());
        }
    }
    

    public static void elegirOpcion(String nombreArchivo, String opc) {
        try {
            File fichero = new File(nombreArchivo);
            int contLineas = 0;
            int contpalabras = 0;

            if (fichero.exists()) {
                ArrayList<String> ordenar = new ArrayList<String>();

                switch (opc) {

                    case "n":
                        
                    
                    try (Scanner sc = new Scanner(fichero)) {
                            while (sc.hasNextLine()) {// hay otra linea?
                                // coge la siguiente

                                contLineas++;
                                Scanner scc = new Scanner(sc.nextLine()); // NECESITO 2 SCANNERS

                                while (scc.hasNext()) {
                                    scc.next();
                                    contpalabras++;
                                }
                            }
                            System.out.println("La cantidad de líneas del archivo:  " + contLineas);
                            System.out.println("La cantidad de palabras es: " + contpalabras);
                        } catch (FileNotFoundException e) {

                        }

                        break;

                    case "A":

                            ordenar = leeFich(fichero);
                            Collections.sort(ordenar); // ordena A---Z, a---z     
                            escribir(new File(fichero.getParentFile().getAbsolutePath() + "/" + opc + ".txt"), ordenar);
                            
                        break;
                    case "D":
                        try (Scanner sc = new Scanner(fichero)) {

                            while (sc.hasNextLine()) {
                                ordenar.add(sc.nextLine());
                                Collections.sort(ordenar);
                                // abrir flujo de escritura y volcar datos en el fichero nuevo

                            }
                            try (FileWriter ffw = new FileWriter(
                                    fichero.getParentFile().getAbsolutePath() + "/" + opc + ".txt")) {

                                Collections.reverse(ordenar); // ord.descendente
                                for (int i = 0; i < ordenar.size(); i++) {// recorro arrayList
                                    ffw.append(ordenar.get(i));// añado al archivo
                                    System.out.println(ordenar.get(i));
                                }
                            }
                        }
                        break;
                    case "a":
                        try (Scanner sc = new Scanner(fichero)) {

                            while (sc.hasNextLine()) {
                                ordenar.add(sc.nextLine());
                                Collections.sort(ordenar); // ordena A---Z, a---z
                                // abrir flujo de escritura y volcar datos en el fichero nuevo

                            }
                            try (FileWriter ffw = new FileWriter(
                                    fichero.getParentFile().getAbsolutePath() + "/" + opc + ".txt")) {

                                Collections.sort(ordenar, String.CASE_INSENSITIVE_ORDER); // ord.descendente
                                for (int i = 0; i < ordenar.size(); i++) {// recorro arrayList
                                    ffw.append(ordenar.get(i));// añado al archivo
                                    System.out.println(ordenar.get(i));
                                }
                            } catch (Exception e) {

                            }
                        }
                        break;
                    case "d":
                    try (Scanner sc = new Scanner(fichero)) {

                        while (sc.hasNextLine()) {
                            ordenar.add(sc.nextLine());
                            Collections.sort(ordenar,String.CASE_INSENSITIVE_ORDER);
                            // abrir flujo de escritura y volcar datos en el fichero nuevo

                        }
                        try (FileWriter ffw = new FileWriter(
                                fichero.getParentFile().getAbsolutePath() + "/" + opc + ".txt")) {

                            Collections.reverse(ordenar); // ord.descendente
                            for (int i = 0; i < ordenar.size(); i++) {// recorro arrayList
                                ffw.append(ordenar.get(i));// añado al archivo
                                System.out.println(ordenar.get(i));
                            }
                        }
                    }
                        break;

                }
            } else {
                System.out.println("Fichero no válido");
            }
        } catch (Exception e) {
            // TODO: handle exception
        }

    }

    public static void main(String[] args) {

        // Scanner sc = new Scanner(System.in);
        // System.out.println("Elije una opción:");
        // System.out.println(
        // "n.Contar el número de líneas del archivo\nA.Crear un nuevo archivo con las
        // líneas del archivo inicil ordenadas de forma ascendente\nD.Crear un nuevo
        // archivo con las líneas del archivo inicial ordenadas de forma
        // descendente\na.Crear un nuevo archivo con las lineas de archivo inicial
        // ordenadas de forma ascendente no sensible al casod.Crear un nuevo archivo con
        // las líneas del archivo inicial ordenadas de forma desdendente,no sensible al
        // caso\n");
        // String opc = sc.nextLine();

        Ej7.elegirOpcion("/Users/cris/Desktop/2ºDAM/Ac.Datos/hola.txt", "D");
    }
}
