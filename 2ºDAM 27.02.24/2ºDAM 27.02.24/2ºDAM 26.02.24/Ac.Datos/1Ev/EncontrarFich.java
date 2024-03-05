import java.io.File;

public class EncontrarFich {
    private void getDatos(File fich, String cad){
        File[] files=fich.listFiles();
        for(File f:files){
            if(f.getName().contains(cad)) System.out.println(f.getAbsolutePath());
            if(f.isDirectory()) getDatos(fich, cad);
        }
    }
    public static void main(String[] args) {
        EncontrarFich ef=new EncontrarFich();
        ef.getDatos(null, null);
    }
}
