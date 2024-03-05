import java.io.File;

public class Ej2 {
    // TODO todo en maven?
    // Recursividad
    public void emular(File dire){
        if(dire.isDirectory()){
            File[] archivos= dire.listFiles();
            // System.out.println(dire.listFiles());
         for (int i = 0; i < archivos.length; i++) {
            if (archivos[i].isDirectory()){
                
                emular(archivos[i]);
                //mostrar también los archivos dentro del directorio
            }
            System.out.println("Es un archivo "+archivos[i]);
         }   
        }
    }
   
    public static void main(String[] args) {
        Ej2 ej2=new Ej2();
        ej2.emular(new File("/Users/cris/Desktop/Vivas"));
    }
}
