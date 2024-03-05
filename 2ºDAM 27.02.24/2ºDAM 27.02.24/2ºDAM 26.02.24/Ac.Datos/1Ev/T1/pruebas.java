import java.io.File;
import java.util.ArrayList;

//Refactorizamos nuestros nombres unicamente
//*  */

public class pruebas {
    public void getDatos(File fich){
        File[] lista=fich.listFiles();
        

        for (File f:lista){
            if (f.isFile()) System.out.println(f.getAbsolutePath());
            //acceder a disco f.isFile + recursos que con una variable booleana
            //que se guarda en memoria
        }
        for (File f:lista){
            if (f.isDirectory()) System.out.println(f.getAbsolutePath());

        }
        


    }
    public static void main(String[] args) {
        pruebas t1=new pruebas();
        t1.getDatos(new File(""));
    }
}