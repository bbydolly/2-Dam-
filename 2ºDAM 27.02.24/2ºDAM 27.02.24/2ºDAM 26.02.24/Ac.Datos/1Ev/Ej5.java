import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

public class Ej5 {
    //     5. Dado un fichero muestre las líneas donde aparece una cadena de texto, pasada
    // como parámetro, junto con el número de línea en la que aparece.
    public void mostrarLineas(File fichero, String cadenaTexto) throws IOException{
        Scanner sc=null;
        int i=0;
        // cadenaTexto=cadenaTexto.toLowerCase();
        //El sc lee de retorno de carro a retorno de carro
        try  {
            sc=new Scanner(fichero);
            while(sc.hasNext()){
                // sc.nextLine().contains(cadenaTexto); //Si en mi línea está la cadena
                while(sc.nextLine().contains(cadenaTexto)){
                    i++;
                    System.out.println("Línea: "+i+sc.nextLine());
                    // System.out.println( sc.nextLine().contains(cadenaTexto));
              
               }
            }
            
      
        } finally{
            if(sc!=null){
                sc.close();
            }
        }
       
       
       
       
       
       
       
       
        // FileReader fichIn=null;
        // char buffer[]=new char[50];
        // try  {
        //      fichIn = new FileReader(fichero);
        //     int i=0;
            
        //     // for (int j = 0; j < cadenaTexto.length(); j++) {
        //     //     i+=j;
        //     // }
        //     while((i= fichIn.read(buffer))!= -1){
        //         System.out.println(new String(buffer,0,i)); //
        //         // System.out.println("Número de línea: " +i);
        //         //i numcaracteres que lee el buffer
        //        // numlinea: desde esa posición

        //     }
            
      
        // } finally{
        //     if(fichIn!=null){
        //         fichIn.close();
        //     }
        // }
        
    }



    public static void main(String[] args) throws IOException {
        File fichero=new File("C:\\Users\\Cristina\\Desktop\\2ºDAM\\Ac.Datos\\hola.txt");
        Ej5 ej5=new Ej5();
        ej5.mostrarLineas(fichero,"Hola");
    }
}
