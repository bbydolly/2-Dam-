import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

public class Ej5 {
    // 5. Dado un fichero muestre las líneas donde aparece una cadena de texto,
    // pasada
    // como parámetro, junto con el número de línea en la que aparece.
    public void mostrarLineas(File fichero, String cadenaTexto) throws IOException {
        Scanner sc = null;
        int i = 0;
        // El sc lee de retorno de carro a retorno de carro
        try {
            sc = new Scanner(fichero);
            while (sc.hasNext()) {
                String cad= sc.nextLine();
                if (cad.contains(cadenaTexto)) {
                    i++;
                    System.out.println("Línea: " + i +cad);
                }
            }

        } finally {
            if (sc != null) {
                sc.close();
            }
        }
    }

    public static void main(String[] args) throws IOException {
        File fichero = new File("C:\\Users\\Cristina\\Desktop\\2ºDAM\\Ac.Datos\\hola.txt");
        Ej5 ej5 = new Ej5();
        ej5.mostrarLineas(fichero, "Hola");
    }
}
