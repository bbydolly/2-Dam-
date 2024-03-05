using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Ejercicio 2 T3 Servicios
namespace Ej_2
{
    //PASOS:
    //Set, get ip, puerto, usuario
    //Establecer el evento click
    //establecer la conexion y el protocolo con el servidor
    //visualizar los datos
    //Guardar la configuración de los datos en un archivo 
    //cerrar el socket server porque no se cierra automáticamente, no está dentro de un using


    public partial class Form1 : Form  //----Directorios absolutos,
                                       //archivo corrupto (no cumple mi formato ip espacio...)
                                       //---append archivo
                                       //----appdata usuario
                                       //programdata confoiguracion equipo
    {
        public string comando;
        public string msg = " ";

        String[] ip_puerto_usuario;
        static String nombrearchivo = "Config_ip_puerto_usuario.txt";
        //string directorio = "C:\\Users\\Cristina\\Desktop\\2ºDAM 20.02.24";  //"appdata"
        static string directorio = "%APPDATA%";
        String directArchivo = Environment.ExpandEnvironmentVariables(directorio + "\\" + nombrearchivo);



        private String ip;

        public String Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private int puerto;

        public int Puerto
        {
            get { return puerto; }
            set
            {
                if (puerto > IPEndPoint.MinPort && puerto < IPEndPoint.MaxPort)
                {
                    puerto = value;

                }
                else
                {
                    puerto = value;

                }
            }
        }
        private String usuario;

        public String Usuario ///user+dni
        {
            get { return usuario; }
            set { usuario = value; }
        }


        public Form1()
        {

            InitializeComponent(); String cadFile;

            //Compruebo si existe el archivo de configuración con I, Puerto, Usuario
            if (File.Exists(directArchivo))
            {
                using (StreamReader srFile = new StreamReader(directArchivo))
                {
                    Console.WriteLine(directArchivo);
                    try
                    {

                        //Si existe meto la configuración en los campos
                        cadFile = srFile.ReadToEnd();
                        ip_puerto_usuario = cadFile.Split(' ');
                        txtIP.Text = ip_puerto_usuario[0];
                        Ip = ip_puerto_usuario[0];

                        txtPuerto.Text = ip_puerto_usuario[1];
                        Puerto = Convert.ToInt16(ip_puerto_usuario[1]);

                        txtUsuario.Text = ip_puerto_usuario[2];
                        Usuario = ip_puerto_usuario[2];
                    }
                    catch (IndexOutOfRangeException indexout)
                    {
                        lbl6.Visible = true;
                        lbl6.ForeColor = Color.Red;
                        lbl6.Text = "El archivo está corrupto";


                        Console.WriteLine("El archivo está corrupto");

                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            //TODO
            //Flujo guardar en archivo de texto 
            //coger los campos y hacer los sets
            using (StreamWriter swarch = new StreamWriter(directArchivo))
            {
                Ip = txtIP.Text;
                Puerto = Convert.ToInt32(txtPuerto.Text);
                Usuario = txtUsuario.Text;

                swarch.Write(Ip + " " + Puerto + " " + Usuario);
            }
            txtInformativo.Text = "";
            lbl6.Visible = false;

            comando = ((Button)sender).Tag.ToString();
            try
            {
                Ip = txtIP.Text;
                Puerto = Convert.ToInt32(txtPuerto.Text);
                Usuario = txtUsuario.Text;
                conexion_servidor(comando);

            }
            catch (OverflowException o)
            {
                txtInformativo.Text = o.ToString();
                Console.WriteLine("Overflow");
            }
            catch (FormatException f)
            {
                txtInformativo.Text = f.Message;
                Console.WriteLine("Error de formato");
            }


        }
        private void conexion_servidor(String comando)
        {
            if (comando == null || Ip == null || Usuario == null)
            {

            }
            else
            {
                //Establezco la conexión con el servidor (Ip, puerto)
                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(Ip), Puerto);//set en mayusc
                //Pruebas para comprobar los datos guardados
                Console.WriteLine("Puerto: " + puerto);
                Console.WriteLine("Ip: " + ip);
                Console.WriteLine("Usuario: " + usuario);

                //Declaración del Socket del servidor
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //server-->para relacionarse con el servidor desde el cliente, donde estoy

                //Intentamos la conexion
                try
                {
                    //Si se ha establecido la conexión(ip, puerto)
                    server.Connect(ie);
                }
                catch (SocketException so)
                {

                    Console.WriteLine("Error de conexión " + so.Message);
                }
                catch (IOException io)
                {
                    Console.WriteLine("Error de e/s datos");
                }
                try
                {
                    //protocolo de comunicación
                    using (NetworkStream ns = new NetworkStream(server))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        try
                        {

                            sw.WriteLine("user " + Usuario); //user
                            Console.WriteLine(Usuario);
                            sw.Flush();
                            String ok = sr.ReadLine();
                            txtInformativo.Text = ok;

                            if (ok.Equals("OK"))
                            {

                                sw.WriteLine(comando);//list o add
                                sw.Flush();
                                String cadInformativa = sr.ReadToEnd();
                                txtInformativo.Text = cadInformativa;
                                Console.WriteLine(txtInformativo);
                                //Equals sobrecarga, segundo parámetro la región 




                            }

                        }
                        catch (IOException io)
                        {
                            Console.WriteLine(io.Message);

                        }

                    }
                    server.Close(); //libero al socket y lo cierro

                }
                catch (IOException ioex)
                {
                    Console.WriteLine("Error E/S datos");

                }
            }

        }
    }
}

