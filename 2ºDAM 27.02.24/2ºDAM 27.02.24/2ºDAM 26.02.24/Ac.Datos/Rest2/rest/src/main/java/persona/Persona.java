package persona;

import java.io.Serializable;

public class Persona implements Serializable{
    int id;
    String nombre;
    boolean casado;
    String sexo;

    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getNombre() {
        return nombre;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public void setCasado(boolean casado) {
        this.casado = casado;
    }
    public boolean isCasado() {
        return casado;
    }

    public String getSexo() {
        return sexo;
    }
    public void setSexo(String sexo) {
        this.sexo = sexo;
    }
    public Persona(){

    }
    
}
