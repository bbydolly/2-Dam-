
// alumnos. por duplicado en dos bases de datos distintas, una MySQL y otra
// SQLite. Realiza un único método que nos permita realizar esta acción.
// 8. Realiza un método que nos permita buscar por el nombre (o parte de él) de
// aula de forma simultánea en una base de datos MySQL y SQLite. ¿Qué
// diferencia ves entre las búsquedas en MySQL y SQLite?

//TODO chekear la carpeta que he abierto¡¡¡
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
//Las tabals se guardan en la ruta que le he pasado, cuando las creo por línea de comandos o x, se
//almacenan ahí 
import java.sql.Statement;

public class SQLite {
    private Connection conexion;
    private Connection conexion2;
    private PreparedStatement ps = null;

    public void abrirConexion(String ruta) {

        try {
            Class.forName("org.sqlite.JDBC");
        } catch (ClassNotFoundException e) {

            e.printStackTrace();
        }
        try {

            String url = String.format("jdbc:sqlite://" + ruta);
            // Establecemos la conexión con la BD
            this.conexion = DriverManager.getConnection(url);

            if (this.conexion != null) {
                System.out.println("Conectado a ");
            } else {
                System.out.println("No conectado a ");
            }
        } catch (SQLException e) {
            System.out.println("SQLException: " + e.getLocalizedMessage());
            System.out.println("SQLState: " + e.getSQLState());
            System.out.println("Código error: " + e.getErrorCode());
        }
    }

    public void cerrarConexion() {
        try {
            this.conexion.close();
        } catch (Exception e) {
            System.out.println("Error al cerrar la conexión");
        }
    }

    public void abrirConexionSQL(String bd, String servidor, String usuario,
            String password) {

        try {
            String url = String.format("jdbc:mariadb://%s:3306/%s", servidor, bd);
            // String url = String.format("jdbc:mysql://%s:3306/%s", servidor, bd);

            // Establecemos la conexión con la BD
            // true-->para establecer sentencias preparadas
            this.conexion2 = DriverManager.getConnection(url + "?useServerPrepStmts=true", usuario, password);

            if (this.conexion2 != null) {
                System.out.println("Conectado a " + bd + " en " + servidor);
            } else {
                System.out.println("No conectado a " + bd + " en " + servidor);
            }
        } catch (SQLException e) {
            System.out.println("SQLException: " + e.getLocalizedMessage());
            System.out.println("SQLState: " + e.getSQLState());
            System.out.println("Código error: " + e.getErrorCode());
        }
    }

    public void cerrarConexionSQL() {
        try {
            this.conexion.close();
        } catch (Exception e) {
            System.out.println("Error al cerrar la conexión");
        }
    }

    // 1. Migra las tablas y la vista de la base de datos ADD a SQLite.
    // 2. Migra los datos de las tablas de la base de datos ADD a SQLite.

    public void migrar_tablas_vistas() {

        /*
         * Se trata de convertir las tablas a formato sqlite
         * 2 Opciones;
         * 1--> Descargar el archivo(las tablas sqlite), y añado el archivo
         * a sqlite-tools-win-x64-3440200
         * 
         * 2-->Cojo el archivo de Mysql con las tablas, veo la sintaxis para modificar
         * los tipos
         * de datos necesarios, modifico la estructura e inserto las tabals
         * 
         * -->Para consultar datos, se realizan consultas normales
         * 
         */

    }

    // Ejercicio 3 Ejecuta desde consola una consulta que nos permita listar la
    // segunda y
    // tercera
    // clase con más puestos.
    public void listarClases() {
        try (Statement stm = this.conexion.createStatement()) {
            String query = "SELECT * FROM aulas ORDER BY puestos DESC LIMIT 3;";
            ResultSet rs = stm.executeQuery(query);

            while (rs.next()) {
                System.out.println(rs.getInt("numero") + " " + rs.getString("nombreAula") + " " + rs.getInt("puestos"));
            }
        } catch (Exception e) {
            e.getMessage();
        }
    }

    // Ejercicio 4 Realiza un método, en java, que sin y con consultas preparadas
    // que permita
    // consultar las aulas que tengan un número mínimo de puestos.
    public void consultasPreparadas(int n, int opc) {
        try {
            if (opc == 1) { // consulta preparada
                String query = "SELECT * from aulas  WHERE puestos> ?";
                if (this.ps == null) {
                    this.ps = this.conexion.prepareStatement(query);
                    // meto valores al p`rocedimiento (pos, valor)
                    ps.setInt(1, n);
                    // ejecuto ps
                    ResultSet rs = ps.executeQuery();

                    while (rs.next()) {
                        System.out.println(
                                rs.getInt("numero") + " " + rs.getString("nombreAula") + " " + rs.getInt("puestos"));

                    }
                }
            } else if (opc == 2) {
                try (Statement stm = this.conexion.createStatement()) {
                    String query2 = "SELECT * from aulas  WHERE puestos>1";
                    ResultSet rs = stm.executeQuery(query2);

                    while (rs.next()) {
                        System.out.println(
                                rs.getInt("numero") + " " + rs.getString("nombreAula") + " "
                                        + rs.getInt("puestos"));
                    }
                } catch (Exception e) {
                    e.getMessage();
                }
            }

        } catch (Exception e) {
            System.out.println("Se ha producido un error: " + e.getLocalizedMessage());

        }
    }

    // 5. Realiza un método en java que permita insertar datos de aulas.
    public void insertarAulas(int numero, String nAula, int puestos) {
        this.ps = null;
        try {
            String query = "Insert into aulas VALUES (?,?,?)";
            if (this.ps == null) {
                this.ps = this.conexion.prepareStatement(query);// paso la consulta a preparar
            }

            // Metemos los datos al ps
            ps.setInt(1, numero);
            ps.setString(2, nAula);
            ps.setInt(3, puestos);

            // ejecuto query del prepared statement
            // devuelve un result set
            int n = ps.executeUpdate();
            // devuelve el n de filas afectadas

        } catch (Exception e) {
            e.printStackTrace();
            // TODO: handle exception
        }

    }

    // Ejercicio 6. Realiza un método que permita insertar datos en
    // aulas en función de su código
    public void insertarAula(int codNumero, String nombreAula, int puestos) {
        boolean aux = false;
        try (Statement stm = this.conexion.createStatement()) {
            String query = String.format("Select %d from aulas", codNumero);
            ResultSet rs = stm.executeQuery(query);
            while (aux = rs.next()) {
                if (aux) { // si es true existe

                    try (Statement st = this.conexion.createStatement()) {
                        String query2 = String.format("Replace into aulas values(%d,%s,%d)", codNumero, nombreAula,
                                puestos);
                        ResultSet rs2 = st.executeQuery(query2);

                        while (rs.next()) {
                            System.out.println(
                                    rs.getInt("numero") + " " + rs.getString("nombreAula") + " "
                                            + rs.getInt("puestos"));
                        }
                    } catch (Exception e) {
                        // TODO: handle exception
                    }
                } else {
                    insertarAula(codNumero, nombreAula, puestos);
                }
            }

        } catch (Exception e) {
            // TODO: handle exception
        }
    }

    // 7. Por motivos de seguridad queremos realizar las inserciones en la tabla
    public void insertarAulas_2conexiones( String nAula, int puestos) {
        this.ps = null;
        try {
            String query = "Insert into aulas VALUES (null,?,?)";
            if (this.ps == null) {
                this.ps = this.conexion.prepareStatement(query);// paso la consulta a preparar
            }

            // Metemos los datos al ps
            // ps.setInt(1, numero);
            ps.setString(1, nAula);
            ps.setInt(2, puestos);

            // ejecuto query del prepared statement
            // devuelve un result set
            int n = ps.executeUpdate();
            // devuelve el n de filas afectadas

        } catch (Exception e) {
            e.printStackTrace();
            // TODO: handle exception
        }
        this.ps = null;
        try {
            String query = "Insert into aulas VALUES (null,?,?)";
            if (this.ps == null) {
                this.ps = this.conexion2.prepareStatement(query);// paso la consulta a preparar
            }

            // Metemos los datos al ps
            // ps.setInt(1, numero);
            ps.setString(1, nAula);
            ps.setInt(2, puestos);

            // ejecuto query del prepared statement
            // devuelve un result set
            int n = ps.executeUpdate();
            // devuelve el n de filas afectadas
System.out.println("estoy 2");
        } catch (Exception e) {
            e.printStackTrace();
            // TODO: handle exception
        }

    }

    // 8. Realiza un método que nos permita buscar por el nombre (o parte de él) de
    // aula de forma simultánea en una base de datos MySQL y SQLite. ¿Qué
    // diferencia ves entre las búsquedas en MySQL y SQLite?
    public void patronNombre(Connection conexion,String patron){
        try {
            String query="Select nombreAula from aula where nombreAula like ?";
            if(this.ps==null){
                this.ps=conexion.prepareStatement(query);
            }
        } catch (Exception e) {
            // TODO: handle exception
        }
    }
}
