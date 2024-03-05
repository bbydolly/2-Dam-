import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;

public class Ej8 {
    public int n=400;
    //set y get
    public void copiarArchivos(File fichIn, File fileOut){
        //n=200;
        
        try (FileInputStream in=new FileInputStream(fichIn);
             FileOutputStream out =new FileOutputStream(fileOut,true)) {
            int i;
            byte[] buffer=new byte[n];
            while((i=in.read(buffer))!= -1){
                out.write(buffer,0,i);
            }
            // out.close();
            // in.close(); se cierra solo
        } catch (Exception e) {
           
        }
    }
    public static void main(String[] args) {
        Ej8 ej8=new Ej8();
        File fileIn=new File("/Users/cris/Desktop/Foto1.png");
        File fileOut=new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/copia.png");
        ej8.copiarArchivos(fileIn, fileOut);
    }
}
