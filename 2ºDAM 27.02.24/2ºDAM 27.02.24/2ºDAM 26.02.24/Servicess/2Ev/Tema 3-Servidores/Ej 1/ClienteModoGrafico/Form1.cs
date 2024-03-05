using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteModoGrafico
{
    public partial class Form1 : Form
    {
        //las constantes estaban en conexion_servidor
        //public const string IP_SERVER = "127.0.0.1";
        //public const int puerto = 31010;

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
                    puerto = 31010;
                }
            }
        }

        private string ip_server;

        public string IP_server
        {
            get { return ip_server; }
            set
            {
                if (value==null) //si el valor que meto es nulo por defecto tiene esa ip y si no guarda el valor introducido
                {
                    ip_server = "127.0.0.1";
                }
                else
                {
                    ip_server = value;

                }

            }
        }


        public Form1()
        {
            InitializeComponent();

        }



        private void button_Click_4botones(object sender, EventArgs e)
        {
            Console.WriteLine("Entro en el click");
            String comando = null;
            if ((sender).Equals(button1))
            {
                comando = "time";

            }
            else if ((sender).Equals(button2))
            {
                comando = "date";

            }
            else if (sender.Equals(button3))
            {
                comando = "all";
            }
            else if (sender.Equals(button4))
            {
                comando = "close " + textBox1.Text;
                Console.WriteLine(comando);
            }
            conexion_servidor(comando);




        }
        public void conexion_servidor(String comando)
        {

            textBox1.Text = "";
            if (comando == null)
            {

            }
            else
            {

                Console.WriteLine("Entro en la función conexion_servidor");

                String msgAux;
                
                IP_server = "127.0.0.1";
                Puerto = 31010;
                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_server), Puerto); //EL SET VA EN MAYUSC
                Console.WriteLine("Starting client. Press a key to init connection");
                Console.WriteLine("puerto " + puerto);
                Console.WriteLine("ip " + ip_server);
                //Console.ReadKey();
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // msgAux=Console.ReadLine();

                try
                {
                    //Inicia la conexion Cliente haciendo la petición
                    server.Connect(ie);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.ErrorCode + "\n" + ex.Message);


                }
                catch (IOException ioexc)
                {
                    Console.WriteLine("En la ip introducida no hay ningún servidor disponible");
                }

                //TODO peta si no hay ningún servidor en esa ip----->IOException
                try
                {

                using (NetworkStream ns = new NetworkStream(server))//CONEXION EN RED CON EL SERVIDOR
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    msgAux = sr.ReadLine();//Leo msg que me envia el servidor
                    Console.WriteLine(msgAux);//escribo en consola el mensaje leído

                    try
                    {
                        //escribo el comando gestionado a partir de button_click
                        sw.WriteLine(comando);
                        sw.Flush();
                        //leo el resultado del comando+lo pongo en la label
                        msgAux = sr.ReadLine();
                        label2.Text = msgAux;
                        Console.WriteLine(msgAux);//ESCRIBO EL MENSAJE EN CONSOLA
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                }
                server.Close();//libera los recursos->es un objeto
                }
                catch (IOException)
                {

                    Console.WriteLine("Error I/O");
                }
            }

        }



        private void button5_Click(object sender, EventArgs e)
        {
            FormPuertoIP fpip = new FormPuertoIP(this);
            fpip.ShowDialog();

        }
    }
}
