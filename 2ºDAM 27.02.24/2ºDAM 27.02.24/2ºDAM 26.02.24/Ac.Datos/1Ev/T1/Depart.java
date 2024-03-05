import java.io.Serializable;
import java.util.Set;

public class Depart implements Serializable {
    public String nameDepart;
    public int cantPersons;

    public void setNameDepart(String nameDepart){
        this.nameDepart=nameDepart;
    }
    public String getNameDepart(){
        return this.nameDepart;
    }
    public void setCantPersons(int cantPersons){
        this.cantPersons=cantPersons;
    }
    public int getCantPersons(){
        return this.cantPersons;
    }
    

    public Depart(){

    }
    public Depart(String nameDepart,int cantPersons){
        this.nameDepart=nameDepart;
        this.cantPersons=cantPersons;
    }
    public void mostrarDatos(){
        System.out.println("El departamento es "+this.nameDepart);
        System.out.println("La cantidad de Personas que trabaja en el departamento es "+this.cantPersons);

    }

}
