import java.io.FileNotFoundException;

import org.w3c.dom.Document;


public class Main {
    public static void main(String[] args) throws ClassNotFoundException, InstantiationException, IllegalAccessException, FileNotFoundException {
        EjerciciosDOM e=new EjerciciosDOM();
        Document d=e.creaArbol("C:\\Users\\Cristina\\Downloads\\peliculas.xml");
        // e.mostrarTitulos(d);
        // e.mostrarDatos(d);
        //  e.recorrerRecursivo(d,0);
         //e.mostrarPeliculas(d, 2);
        //  e.generosPeliculas(d);
        //  e.addAtributo(d, "El señor de los anillos", "ventas");
        //  e.añadirPeli(d, "John", "Tiernan","Depredador");
        //  e.grabarDOM(d, "prueba");
         e.cambiarNombre(d, "Larry", "Lana","Wachowski");
    }
}
