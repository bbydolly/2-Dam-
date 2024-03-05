import java.io.File;
// VALIDADO
public class Ej2 {
   
    // Recursividad
    public void emular(File dire) {
        if (dire.isDirectory()) {
            File[] archivos = dire.listFiles();
           
            for (int i = 0; i < archivos.length; i++) {
                System.out.println( archivos[i]);
                if (archivos[i].isDirectory()) {

                    emular(archivos[i]);
                    // mostrar también los archivos dentro del directorio
                }
            }
        }
    }

    public static void main(String[] args) {
        Ej2 ej2 = new Ej2();
        ej2.emular(new File("/Users/cris/Desktop/Vivas"));
    }
}
