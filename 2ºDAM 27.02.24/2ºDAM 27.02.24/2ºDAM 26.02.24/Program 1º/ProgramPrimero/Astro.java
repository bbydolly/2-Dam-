package ProgramPrimero;
public class Astro {
    private String nombre;
    public double radio;

    public void setNombre(String nombre){
        this.nombre=nombre.toUpperCase().trim();
    }
    public String getNombre(){
        return nombre;
    }
    public String getNombre(char c){
        String sobrecarga="";
        for (int i = 0; i < nombre.length(); i++) {
            sobrecarga+=nombre.charAt(i);
            sobrecarga+=c;
            
        }
        nombre=sobrecarga;
       return nombre.substring(0, sobrecarga.length()-1);
        // return nombre;
    }
    public void setRadio(double radio){
        this.radio=radio;
    }
    public double getRadio(){
        return radio;
    }
    public void muestraDatos(){
        System.out.println("El nombre del Astro es: "+getNombre());
        System.out.printf("El radio del Astro es: %.2f ",this.radio);

    }
    public Astro(String nombre, double radio){
        this.nombre=nombre;
        this.radio=radio;
    }


}
