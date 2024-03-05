public class App {

    // Sqlite necesita 2 jars en lib
    // capturas base de datos, como crearla
    public static void main(String[] args)  {
        // C:\\Users\\Cristina\\Downloads\\sqlite-tools-win-x64-3440200\\bd2

        SQLite sql = new SQLite();
        sql.abrirConexion("C:\\Users\\Cristina\\Downloads\\sqlite-tools-win-x64-3440200\\bd2");
        System.out.println();
        //sql.listarClases();
        System.out.println();
        //sql.consultasPreparadas(1, 1);
        System.out.println("------------------");
        //TODO javi help
        sql.consultasPreparadas(1, 2);
        System.out.println("------------------");
        
        
        
        
        //SQLite 
        
        sql.abrirConexionSQL("add", "localhost", "root", "");
        sql.insertarAulas_2conexiones( "Contabilidad Numerica", 13);

        sql.cerrarConexion();
        sql.cerrarConexionSQL();




    }
    
}
