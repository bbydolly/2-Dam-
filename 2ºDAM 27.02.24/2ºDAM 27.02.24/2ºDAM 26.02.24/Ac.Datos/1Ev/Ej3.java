import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Ej3 {
    // sobrecarga de read()

    public void leerOcurrencias(char i) throws IOException {
        FileReader fich = new FileReader("C:\\Users\\Cristina\\Desktop\\2ºDAM\\Ac.Datos\\hola.txt");
        try {
           

            int cont = 0;
            int i2;
            int caracterANumero = (int) i;
            while ((i2 = fich.read()) != -1) {
             if (i2 == caracterANumero){

                 // cont = 0;
                 cont++;
                //  System.err.println("imprimo");
    
                }
                
            }
            System.out.println(cont);
        } finally {
            
            if (fich != null) {
                fich.close();
            }
        }
    }

    public static void main(String[] args) throws IOException {
        Ej3 ej3 = new Ej3();
        char letra = 'e';
        ej3.leerOcurrencias(letra);
        

    }
}
