import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class ficheros {

    public void leeFichero(File fichero) throws IOException {
        FileReader fichIn = null;
        try {
            fichIn = new FileReader(fichero);
            int i;
            while ((i = fichIn.read()) != -1) {
                System.out.print((char) i);
            }
        } finally {
            if (fichIn != null) {
                fichIn.close();
            }
        }
    }
}