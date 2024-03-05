using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    internal class ServidorProtocolo
    {
        //hilo cliente--> atencion al cliente, forma parte del servidor
        static Socket s;

        public void Init()
        {
            //telnet 127.0.0.1 31010
            // sin dos puntos al separar el puerto
            bool aux = true;
            int pLibre;
            do
            {
                int port = 31010;

                //Puerto ocupado para hacer pruebas---> Entra en bucle infinito
                // int port = 135;

                //IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);// IP+PUERTO
                const string IP_SERVER = "127.0.0.1";
                // const string IP_SERVER = "192.168.20.2";//CLASE
                //const string IP_SERVER = "192.168.1.131";





                IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), port);// IP+PUERTO


                port++;

                //Creamos el socket
                try
                {
                    using (s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {

                        pLibre = port;
                        aux = false;
                        s.Bind(ie); //enlace socket-puerto
                        s.Listen(10);//clientes en espera---> tengo que tener un bucle que vuelva al accept

                        Socket sCliente;
                        while (true)
                        {
                            sCliente = s.Accept(); //aceptamos la conexión del cliente
                            Thread atencion_cliente = new Thread(atencionCliente_Protocolo_Comunicacion);
                            atencion_cliente.Start(sCliente);//inicializo el hilo pasándole el socket


                        }

                    }
                }
                catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse) //Cuando se produce esa excepción y es del tipo Puerto ya en uso, Ambas clases forman parte de la clase Socket
                {
                    //Salta exc si el pueto está ocupado
                    Console.WriteLine(e.Message);

                    aux = true;

                }
                catch (SocketException sexception)
                {

                    Console.WriteLine("Cierre del servidor");
                    Console.ReadKey();
                }

            } while (aux);
        }



        //
        public void atencionCliente_Protocolo_Comunicacion(object socket)
        {
            try
            {

                string mensaje;
                using (Socket cliente = (Socket)socket)
                {


                    IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;
                    Console.WriteLine("Cliente conectado:\nIP:{0}\n{1}Puerto:",
                                ieCliente.Address, ieCliente.Port);

                    using (NetworkStream ms = new NetworkStream(cliente))//los datos se envían a la red
                    using (StreamReader sr = new StreamReader(ms))
                    using (StreamWriter sw = new StreamWriter(ms))
                    {
                        String msgBienvenida = "Bienvenido al servidor";
                        sw.WriteLine(msgBienvenida);
                        sw.Flush(); //Fuerza el volcado a disco
                        String aux;
                        aux = DateTime.Now.ToString();


                        try
                        {
                            mensaje = sr.ReadLine();

                            if (mensaje == "date")
                            {
                                sw.WriteLine(aux.Substring(0, 10));



                            }
                            else if (mensaje == "time")
                            {
                                sw.WriteLine(aux.Substring(10, 9));


                            }
                            else if (mensaje == "all")
                            {
                                sw.WriteLine(DateTime.Now);


                            }
                            else if (mensaje.StartsWith("close "))
                            {
                                String close = "close ";
                                //Verificar contraseña---> estará guardada en un archivo en C:\ProgramData
                                String programdata = Environment.GetEnvironmentVariable("PROGRAMDATA"); //programdata es una ruta ///expandEnviroment
                                                                                                        //C:\ProgramData
                                String nArchivo = "contraseña.txt";
                                String line;
                                String[] p2_cadena = mensaje.Split(" ");
                                //                                                     directorio   +     nArchivo
                                using (StreamReader archContraseña = new StreamReader(programdata + "\\" + nArchivo))
                                {

                                    line = archContraseña.ReadLine();
                                    Console.WriteLine(line);
                                    //sw.WriteLine("Mensaje: " + mensaje);
                                    //sw.WriteLine("Leo del archivo: " + line);
                                    if (mensaje.StartsWith(close + line)) //que no sea una contraseña fija
                                    {
                                        //StarWhizh y equals con ==
                                        sw.WriteLine("La contrasenia es válida\nFinalizando servidor");
                                        sw.Flush();
                                        //Cierro el SERVIDOR, el socket
                                        s.Close();

                                    }

                                    else if (mensaje.StartsWith(close))
                                    {

                                        if (mensaje.Length > close.Length)
                                        {
                                            sw.WriteLine("Contraseña no válida");
                                            sw.Flush();

                                        }
                                        else
                                        {
                                            sw.WriteLine("Contraseña vacía");
                                            sw.Flush();
                                        }


                                    }

                                }

                            }
                            else
                            {
                                sw.WriteLine("Error en la posición del comando");
                                sw.Flush();


                            }



                        }
                        catch (IOException e)
                        {
                            Debug.WriteLine(e.Message);

                        }
                    }
                }
            }
            catch (SocketException ui)
            {

                Console.WriteLine(ui.Message);
            }




        }
    }
}
