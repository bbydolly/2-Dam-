import java.io.Serializable;

public class Persona implements Serializable{
    public String namePers;
    public String apellidoPers;
    public String dni;

    public void setNamePers(String namePers){
        this.namePers=namePers;
    }
    public String getNamePers(){
        return this.namePers;
    }
    public void setApellidoPers(String apellidoPers){
        this.apellidoPers=apellidoPers;
    }
    public String getApellidoPers(){
        return this.apellidoPers;
    }
    public void setDni(String dni){
        this.dni=dni;
    }
    public String getDni(){
        return this.dni;
    }

    public Persona(String namePers, String apellidoPers, String dni){
        this.namePers=namePers;
        this.apellidoPers=apellidoPers;
        this.dni=dni;
    }
    public Persona(){

    }
}
