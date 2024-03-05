import java.io.BufferedOutputStream;
import java.io.DataInputStream;
import java.io.DataOutput;
import java.io.DataOutputStream;
import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
// 9. Realiza un programa que permita almacenar, de forma binaria, los datos de unos
// alumnos en el fichero alumnos.dat (guarda los datos de forma individual, no
// como un objeto). Los datos de cada alumno serán: código como entero, nombre
// como cadena de texto, altura como un número con dos decimales. El programa
// debe realizar las siguientes tareas:
// Ø Dar de alta nuevos alumnos.
// Ø Consultar alumnos.
// Ø Modificar alumnos.
// Ø Borrar alumnos.
// El programa deberá avisar de posibles problemas encontrados como puede ser el
// intentar borrar un alumno que no exista.

public class Ej9 {
    ArrayList<Integer> codigo = new ArrayList<Integer>();
    ArrayList<String> nombres = new ArrayList<String>();
    ArrayList<Double> altura = new ArrayList<Double>();

    public void darDeAltaAlumnos(int cod, String nombre, Double altu) {
        codigo.add(cod);
        nombres.add(nombre);
        altura.add(altu);
    }
    public void modificarDatos(int cod, String nombre, Double altu){

    }

    public void inicializarColeccion() {
        codigo.add(1);
        codigo.add(2);
        codigo.add(3);
        codigo.add(4);
        codigo.add(5);
        codigo.add(6);
        codigo.add(7);

        nombres.add("Ana");
        nombres.add("Sena");
        nombres.add("Lucia");
        nombres.add("Iñaqui");
        nombres.add("Javi");
        nombres.add("Luca");
        nombres.add("Perico");

        altura.add(1.70);
        altura.add(1.45);
        altura.add(1.56);
        altura.add(1.85);
        altura.add(1.55);
        altura.add(1.76);
        altura.add(1.67);
    }

    public void guardarDatosAlumnosBinario() throws IOException {

        try (DataOutputStream d = new DataOutputStream(
                new FileOutputStream(new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/alumnos.dat")))) {

            if (codigo.size() == nombres.size() && codigo.size() == altura.size()) {

                for (int i = 0; i < codigo.size(); i++) {

                    d.write(codigo.get(i));
                    d.writeUTF(nombres.get(i));
                    d.writeDouble(altura.get(i));

                }
            } else {
                System.out.println("Debe meter los siguientes datos para un alumno:\nNombre\nCodigo\nAltura");
            }
        } catch (NullPointerException | FileNotFoundException e) {

        }

    }

    public void consultarAlumnos(File alumnos) throws FileNotFoundException, IOException { // TODO leer el archivo
        try (FileInputStream fin = new FileInputStream(alumnos);
                DataInputStream in = new DataInputStream(fin)) {
                    
                    //en in están los datos de mi fichero de entrada
            try { // Los datos se recuperan en el mismo orden en que se guardaron
                while (true) {
                    System.out.printf("Código: %d Nombre: %s Altura: %f \n",
                             in.readInt(),in.readUTF(), in.readFloat());
                }
            } catch (EOFException e) {
                System.out.println("Fin de fichero");
            }
        }

    }
    // TODO como modifico los datos?
    // Lee el fichero
    // Compruebo que existe el dato
    // Borro el dato y lo escribo ?
    public void modificarAlumnos(int cod,String nombreNuevo,double alturaNueva) throws FileNotFoundException, IOException {
        try (DataInputStream d=new DataInputStream(new FileInputStream("/Users/cris/Desktop/2ºDAM/Ac.Datos/alumnos.dat"))) {
            DataOutputStream s = new DataOutputStream(
                new FileOutputStream(new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/alumnos2.dat"),true));

            
            try{
                // TODO como borro datos?
                while(true){
                    if(d.readInt()== cod){ //escribo los datos nuevos
                        s.writeInt(cod);
                        s.writeUTF(nombreNuevo);
                        s.writeDouble(alturaNueva);
                        
                    }
                }
            
             } catch (Exception e) {
             }
            // TODO: handle exception
        }
    }

    public void borrarAlumnos() {

    }

    public static void main(String[] args) throws IOException {
        // int []codigo={1,2,3,4,5,6,7};

        Ej9 ej9 = new Ej9();
        ej9.inicializarColeccion();
        ej9.darDeAltaAlumnos(3, "Ann", 1.73);
        ej9.guardarDatosAlumnosBinario();
        File alumnos= new File("/Users/cris/Desktop/2ºDAM/Ac.Datos/alumnos.dat");
        ej9.consultarAlumnos(alumnos);


    }
}
