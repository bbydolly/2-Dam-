import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;

public class Ej10 {
  
  Persona p1 = new Persona("Cris", "López", "53820352F");
  Persona p2 = new Persona("Juan", "Sánchez", "5234352C");
  Persona p3 = new Persona("lucas", "López", "5398237h");
  Persona p4 = new Persona("André", "López", "53976542f");
  Persona p5 = new Persona("Víctor", "López", "53098628Q");
  ArrayList<Persona> personas = new ArrayList<>();

  public void iniPersonas() {
    personas.add(p1); // Todo lo que sea realizar acciones tienen que ir dentro de una función
    personas.add(p2);
    personas.add(p3);
    personas.add(p4);
    personas.add(p5);
  }

  Depart d1 = new Depart("Contabilidad", 10);
  Depart d2 = new Depart("Recursos Humanos", 9);
  Depart d3 = new Depart("Ingeniería", 60);
  Depart d4 = new Depart("Calidad", 10);
  Depart d5 = new Depart("Atención al cliente", 15);
  ArrayList<Depart> departamento = new ArrayList<>();

  public void iniDepars() {
    departamento.add(d1);
    departamento.add(d2);
    departamento.add(d3);
    departamento.add(d4);
    departamento.add(d5);
  }

  public void addDepart(Depart d) {
    departamento.add(d);
  }
  public void addPersona(Persona p){
    personas.add(p);
  }

  public static void escribirObjeto(File fich, ArrayList<Persona> personas, ArrayList<Depart> departs ) {
    try (FileOutputStream fOut = new FileOutputStream(fich);
        ObjectOutputStream out = new ObjectOutputStream(fOut)) {
      for (Persona p : personas) {
        out.writeObject(p);
      }
      for (Depart d : departs) {
        out.writeObject(d);
      }

    } catch (Exception e) {

    }

  }
  public static void consultarDatos(File fich) throws FileNotFoundException, IOException{
    try (FileInputStream fin = new FileInputStream(fich);
      ObjectInputStream in=new ObjectInputStream( fin)){
      try {

        
        
        while(true){
          Object tipo=in.readObject();

          if(tipo.getClass()==Persona.class){
           Persona p=(Persona)tipo;
            System.out.printf("Nombre:\nApellido:\nDni",p.getNamePers(),p.getApellidoPers(),p.getDni());
          }
          if(tipo.getClass()==Depart.class){
            Depart d=(Depart)tipo;
            System.out.printf("Nombre departamento:\nCantidad de trabajadores:\n",d.getNameDepart(),d.getCantPersons());
          }
          
          
          
          
          
        }
        
      } catch (EOFException e) {
      }
      catch(ClassNotFoundException i){

      }
    }
  }
  public static void main(String[] args) {
    escribirObjeto(null, null, null);
  }

}
