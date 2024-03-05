import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
// VALIDADO


public class Ej3 {
 
    public int leerOcurrencias(FileReader fich,char i) throws IOException {
        try {

            int cont = 0;
            int i2;
            int caracterANumero = (int) i;
            while ((i2 = fich.read()) != -1) {
                if (i2 == caracterANumero) {
                    cont++;
                }

            }
            System.out.println(cont);
            return cont;
        } finally {

            if (fich != null) {
                fich.close();
            }
        }
        
    }

    public static void main(String[] args) throws IOException {
        Ej3 ej3 = new Ej3();
        char letra = 'e';
        FileReader fich = new FileReader("C:\\Users\\Cristina\\Desktop\\2ºDAM\\Ac.Datos\\hola.txt");
        
        ej3.leerOcurrencias(fich,letra);

    }
}
