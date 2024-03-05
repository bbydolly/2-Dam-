package ProgramPrimero;

public class Planeta extends Astro{
    public boolean habitabilidad;

    public void setHabitabilidad(boolean habitabilidad){
        this.habitabilidad=habitabilidad;
    }
    //TODO llamadas entre constructores
    public Planeta(String nombre, double radio, boolean habitabilidad) {
        super(nombre, radio); 
        this.habitabilidad=habitabilidad;
        
    }
    public Planeta(){
        this("",0.0,true);
        
    }
    
    @Override
    public void muestraDatos() {
        
        super.muestraDatos();
        System.out.printf("La habitabilidad es: %0",this.habitabilidad);
    }
    
}
