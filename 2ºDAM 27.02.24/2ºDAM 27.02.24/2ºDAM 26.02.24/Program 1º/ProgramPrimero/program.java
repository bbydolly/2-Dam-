package ProgramPrimero;

public class program {
    public static void main(String[] args) {
        Astro a= new Astro("cris",3.4);
        a.muestraDatos();
        System.out.println();
        System.out.println(a.getNombre('_'));

    }
}
