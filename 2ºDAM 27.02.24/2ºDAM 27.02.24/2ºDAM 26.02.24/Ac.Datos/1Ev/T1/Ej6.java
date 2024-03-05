import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

//añadir ficheros al arrayList
public class Ej6 {
    public void divNcaracteres(File fich, int nChar) {

        try (FileReader fichIn = new FileReader(fich)) {
            char buffer[] = new char[nChar];
            int i;
            int j = 0;
            while ((i = fichIn.read(buffer)) != -1) {

                try (FileWriter fr = new FileWriter(fich.getAbsolutePath() + "j" + ".txt")) {

                    j++;

                    fr.write(buffer, 0, i);

                } catch (IOException e) {
                    e.printStackTrace();
                    System.out.println(e.getLocalizedMessage());
                }

            }

        } catch (IOException e) {

        }

    }

    public void divNlineas(File fich, int nLineas) {
        int d = 0;
        try (Scanner sc = new Scanner(fich)) {

            while (sc.hasNext()) {
                for (int i = 0; i < nLineas && sc.hasNext(); i++) {
                    try (PrintWriter pw = new PrintWriter(fich.getAbsolutePath() + "d" + ".txt")) {

                        d++;

                        pw.println(sc.next());

                    } catch (IOException e) {

                    }

                }
            }
        } catch (Exception e) {

        }

    }

    public void concatenarFicheros(ArrayList<File> ficheros, File ficheroFinal) {

        try (PrintWriter pw = new PrintWriter(new FileWriter(ficheroFinal))) { // true, append

            for (File ficheroLeo : ficheros) {

                try (Scanner sc = new Scanner(ficheroLeo)) {
                    while (sc.hasNext()) {
                        pw.println(sc.nextLine()); // escribo lo que leo con el escaner en el PrintWriter
                    }

                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    public static void main(String[] args) {
        Ej6 ej6 = new Ej6();
        File fileIn = new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/T1/A.txt");
        File fileOut = new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/FicheroOut.txt");
       File fileIn2=new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/T1/b.txt");
        ej6.divNcaracteres(fileIn, 1);
        ej6.divNlineas(fileIn, 3);
        ArrayList<File> ficheros=new ArrayList<>();
        ficheros.add(fileIn);
        ficheros.add(fileIn2);
        ej6.concatenarFicheros(ficheros, fileOut);
    }

}
