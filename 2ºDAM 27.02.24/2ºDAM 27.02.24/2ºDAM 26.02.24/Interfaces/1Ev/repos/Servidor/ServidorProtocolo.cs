using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    internal class ServidorProtocolo
    {
        //hilo cliente--> atencion al cliente, forma parte del servidor

        public void Init()
        {
            //telnet 127.0.0.1 31010
            // sin dos puntos al separar el puerto
            bool aux = true;
            int pLibre;
            do
            {
                int port = 31010;
               // IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);// IP+PUERTO

                const string IP_SERVER = "192.168.20.2";//
                
               IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), port);// IP+PUERTO

                
                port++;

                //Creamos el socket
                try
                {
                    using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
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
                catch (Exception e)
                {
                    //Salta exc si el pueto está ocupado
                    Console.WriteLine(e.Message);
                    aux = true;

                }
            } while (aux);
        }



        //
        public void atencionCliente_Protocolo_Comunicacion(object socket)
        {
            String mensaje;
            Socket cliente = (Socket)socket;
            IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;
            Console.WriteLine("Cliente conectado:\nIP:{0}\n{1}Puerto:",
                        ieCliente.Address, ieCliente.Port);

            using (NetworkStream ms = new NetworkStream(cliente))
            using (StreamReader sr = new StreamReader(ms))
            using (StreamWriter sw = new StreamWriter(ms))
            {
                String msgBienvenida = "Bienvenido al servidor de Cris <3";
                sw.WriteLine(msgBienvenida);
                sw.Flush(); //Fuerza el volcado a disco
                String aux;
                aux = DateTime.Now.ToString();


                try
                {
                    while (true)
                    {
                        mensaje = sr.ReadLine(); //El servidor l
                        sw.WriteLine();
                        sw.Flush();//sw.WriteLine("ALEX, NO SOY UNA GENIA ");
                        //AUTOFLUCH
                        // falta el volcado .Flush();

                    }
                    //if (mensaje == "time")
                    //{
                    //    sw.WriteLine(aux.Substring(0, 8));

                    //}
                    //else if (mensaje == "date")
                    //{
                    //    sw.WriteLine(aux.Substring(10, 8));

                    //}
                    //else if (mensaje == "all")
                    //{
                    //    sw.WriteLine(DateTime.Now);

                    //}
                    //else if (mensaje.Contains("close "))
                    //{

                    //}
                    //else
                    //{
                    //    cliente.Close();
                    //}

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);

                }



            }

        }
    }
}
