import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
// TODO hacer con FileOutputStream con un buffer


public class Ej11 {
    
    public void copiarArchivos(File fileIn, File fileOut) {
       
      
        try (FileInputStream in = new FileInputStream(fileIn)) {
            //lectura fichero binario
            FileOutputStream out = new FileOutputStream(fileOut);
            int c;
            while ((c = in.read()) != -1) {
                out.write(c);

            }

        } catch (NullPointerException | IOException y) {
        }

    }
    public void copiarArchivosBuffer(File fin, File fout){
        
        try (BufferedInputStream bi=new BufferedInputStream(new FileInputStream(fin));
        
            BufferedOutputStream bo=new BufferedOutputStream(new FileOutputStream(fout))) {
            //trabaja con un FileOutput, un archivo con un tamaño de buffer
            // TODO bo escribe la secuencia guardada en el buffer (es decir la información que ha guarado)
            
            int i;
            while((i =bi.read()) != -1){   
                bo.write(i);
            }
          
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public static void main(String[] args) {
        Ej11 ej8=new Ej11();
        File fileIn=new File("/Users/cris/Desktop/Capturas/Foto1.png");
        File fileOut=new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/copiabinario.png"); //si no existe me lo crea
        ej8.copiarArchivos(fileIn, fileOut);
        ej8.copiarArchivosBuffer(fileIn, fileOut);
    }
}
