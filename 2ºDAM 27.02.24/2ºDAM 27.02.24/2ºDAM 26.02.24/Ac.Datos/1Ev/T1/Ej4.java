import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Collections;
import java.util.HashMap;

public class Ej4 {

    public void caracterMasRepetido(FileReader archivo) throws IOException {

        HashMap<Character, Integer> lista = new HashMap<Character, Integer>();
        // clave-char
        // valor-int

        int i = 0;

        try {

            while ((i = archivo.read()) != -1) {
                char letraLeida = (char) (i);
                if (lista.containsKey(letraLeida)) {
                    lista.put(letraLeida, lista.get(letraLeida) + 1);
                } else {
                    lista.put(letraLeida, 1);

                }
            }
            
            int maxi = Collections.max(lista.values());
           
            for (char ch : lista.keySet()) {
                // ch es mi clave, keySet me coge clave-valor
                // y al hacer el get cojo el valor que tiene la clave
                // recorro todad??
                // System.out.println(ch+ " "+ lista.get(ch));
                if (lista.get(ch) == maxi) {

                    System.out.println(ch + " " + lista.get(ch));
                }
               
            }

        } finally {
            if (archivo != null) {
                archivo.close();
            }
        }

    }

    public static void main(String[] args) throws IOException {
        FileReader archivo = new FileReader("C:\\Users\\Cristina\\Desktop\\2ºDAM\\Ac.Datos\\hola.txt");
        Ej4 ej4 = new Ej4();
        ej4.caracterMasRepetido(archivo);
    }
}
