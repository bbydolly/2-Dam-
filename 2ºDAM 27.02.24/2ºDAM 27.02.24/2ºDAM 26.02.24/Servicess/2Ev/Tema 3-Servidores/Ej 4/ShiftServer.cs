using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ej_4
{
    internal class ShiftServer
    {
        public bool aux = true;
        public bool auxCierre = true;
        public bool auxEnlaLista = false;
        public int pin;
        private int puerto;
        public static String listaNombres = "Ana;Lucas;Maria;Pepe;Adri;Bryan;Javi;Luis";
        public static String rutaArchivoUsers = Environment.ExpandEnvironmentVariables("%homepath%" + "\\nombresUsers.txt");

        public int Puerto
        {
            get { return puerto; }
            set
            {
                if (puerto > IPEndPoint.MinPort && puerto < IPEndPoint.MaxPort)
                {
                    puerto = value;

                }

                if (puerto == IPEndPoint.MaxPort)
                {
                    //App finaliza
                    auxCierre = false;
                    

                }


            }
        }

        public List<string> users = new List<string>();
        public List<string> waitQueue = new List<string>();


        public void ReadNames(String ruta)//directory+nombrearchivo.txt
        {
            if (File.Exists(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    String usuarios = sr.ReadToEnd();
                    String[] usuariosArray = usuarios.Split(';');
                    for (int i = 0; i < usuariosArray.Length; i++)
                    {
                        users.Add(usuariosArray[i]);

                    }
                }

            }
        }
        public int ReadPin(String ruta)
        {

            if (File.Exists(ruta))
            {

                using (BinaryReader br = new BinaryReader(new FileStream(ruta, FileMode.Open)))
                {

                    int n = br.ReadInt16();//leo 4 bits
                    while (n != -1)
                    {
                        if (n >= 1000 && n <= 9999)
                        {
                            return n;

                        }

                    }


                }
            }
            return -1;


        }
        //*
        //Función que a partir de un string y un int crea un archivo binario
        //@param string ruta
        //@param int contraseña
        //*

        public void ArchivoPin(String ruta, int contraseña)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(ruta, FileMode.Create)))
            {
                bw.Write(contraseña);



            }

        }
        //*
        //Función que crear un archivo de texto y permite insertar un string
        //@param ruta
        //@param listaNombres
        //*
        public void ArchivoUsers(String ruta, String listaNombres)
        {
            using (StreamWriter sr = new StreamWriter(ruta))
            {
                sr.WriteLine(listaNombres);
            }
        }

        public void Init()//inicia el servidor
        {


            ArchivoUsers(rutaArchivoUsers, listaNombres);

            do
            {

                puerto = 31416;
                //String ip_server = "127.0.0.1";

                IPEndPoint ie = new IPEndPoint(IPAddress.Any, Puerto);//a donde se va a conectar 

                try
                {
                    using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {


                        s.Bind(ie);//ENLAZO PUERTO+SOCKET (tipo de comunicación +vía de comunicación)
                        s.Listen();//Escucho
                        //Console.WriteLine("Puerto: " + Puerto);
                        Console.WriteLine("Ip: " + ie.Address);
                        Console.WriteLine("Puerto: " + ie.Port);
                        Socket sCliente;

                        while (true)
                        {
                            sCliente = s.Accept();//acepto la conexión del cliente
                            Thread cliente = new Thread(hilo_atencion_cliente);
                            cliente.Start(sCliente);
                        }
                    }

                }
                catch (SocketException)
                {
                    if (aux)
                    {
                        Puerto = 1024;
                        aux = false;
                    }
                    else
                    {
                        Puerto++;//esto está bien??
                    }




                }



            } while (auxCierre);
        }
        public void hilo_atencion_cliente(Object socket)//protocolo se comunicacion
        {
            string comando;
            try
            {
                using (Socket sCliente = (Socket)socket)
                {
                    try
                    {
                        IPEndPoint ie = (IPEndPoint)sCliente.RemoteEndPoint; //ip+puerto del cliente
                        using (NetworkStream ns = new NetworkStream(sCliente))
                        using (StreamReader sr = new StreamReader(ns))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            try
                            {
                                sw.WriteLine("Bienvenido al servidor");
                                sw.Flush();
                                sw.WriteLine("Introduce tu nombre");
                                sw.Flush();
                                String name = sr.ReadLine();

                                if (name != null)
                                {

                                    if (name.Equals("admin"))
                                    {
                                        sw.WriteLine("Introduce el pin");
                                        sw.Flush();
                                        pin = Convert.ToInt32(sr.ReadLine());
                                        String ruta = Environment.ExpandEnvironmentVariables("%userprofile%" + "\\pin.bin");
                                        int n = ReadPin(ruta);
                                        ArchivoPin(ruta, 1234);
                                        sw.WriteLine("El pin es: " + n);
                                        sw.Flush();

                                        if (n == -1)
                                        {
                                            sw.WriteLine(n); //pin = 1234;
                                        }
                                        else if (pin == n)
                                        {
                                            pin = n;
                                            sw.Write("Contraseña correcta");
                                            sw.Flush();
                                        }
                                        else
                                        {
                                            sCliente.Close();
                                        }



                                    }
                                    else
                                    {
                                        ReadNames(rutaArchivoUsers);
                                        for (int i = 0; i <= users.Count; i++)
                                        {
                                            if (users.Count > 0)
                                            {

                                                if (users[i].Equals(name))
                                                {
                                                    auxEnlaLista = true;
                                                    //está en la lista
                                                    comando = sr.ReadLine();

                                                    if (comando != null)
                                                    {

                                                        switch (comando)
                                                        {
                                                            case "list":
                                                                for (int j = 0; i < waitQueue.Count; i++)
                                                                {
                                                                    sw.WriteLine(i + ": " + waitQueue[i]);
                                                                    sw.Flush();
                                                                }
                                                                sCliente.Close();
                                                                break;
                                                            case "add":
                                                                if (waitQueue.Contains(name))
                                                                {
                                                                    //TODO:
                                                                    //Tengo que gestionar los splits
                                                                    sw.WriteLine("Usuario ya en la lista");
                                                                }
                                                                else
                                                                {
                                                                    waitQueue.Add(name+" " + DateTime.Now.ToString());
                                                                    sw.WriteLine("OK");
                                                                    sw.Flush();
                                                                }
                                                                break;
                                                        }
                                                    }


                                                }
                                            }
                                            else
                                            {
                                                sw.WriteLine("Usuario desconocido");
                                                sw.Flush();
                                                sCliente.Close();
                                            }
                                        }
                                    }

                                }
                            }
                            catch (IOException io)
                            {

                            }
                        }
                    }
                    catch (IOException io)
                    {

                    }


                }
            }
            catch (Exception)
            {


            }

        }
    }
}
