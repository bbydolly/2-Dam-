using System.Collections.ObjectModel;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Threading.Channels;

namespace Ej_3
{
    internal class Servidor
    {
        Collection<StreamWriter> mensajes = new Collection<StreamWriter>();
        static readonly private object l = new object(); //Defino el testigo
        static readonly private object lWrite = new object(); //Defino el testigo

        static bool finished = false;
        static bool finishedWrite = false;
        static List<string> users = new List<string>();//Los paréntesis


        //puerto
        //ip 127.0.0.1
        public void InitServidor()
        {
            bool aux = true;
            do
            {
                Console.WriteLine("Servidor");
                string ip_server = "127.0.0.1";
                int port = 31010;

                //Realizar la conexión
                // IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ip_server), port);
                IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);

                //o
                //IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);

                try
                {
                    //Defino el socket de conexión
                    using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        s.Bind(ie); //enlazo el puerto con el socket en cualquier interfaz de red
                        s.Listen(); //socket queda escuchando
                        //Línea de prueba
                        Console.WriteLine("puerto: " + port);

                        Socket sCliente;

                        while (true)
                        {
                            sCliente = s.Accept(); //acepta la conexión del cliente, devuelve el socket cliente

                            Thread at_cliente = new Thread(atencionClinte_procotocoloComunicacion); //clase que permite la ejecución de forma concurrente (a la vez)
                            at_cliente.Start(sCliente); //inicializo el hilo pasándole el socket del cliente
                        }

                    }

                }
                catch (SocketException s)
                {
                    //Salta si el puerto está ocupado
                    Console.WriteLine(s.Message);
                    port++;
                }
                catch (ObjectDisposedException objexc)
                {
                    Console.WriteLine(objexc.Message);
                }
                catch (InvalidOperationException inv)
                {
                    Console.WriteLine(inv.Message);
                }

            } while (aux); //mientras sea true hace bucle

        }

        //Protocolo de comunicación del servidor
        //Se ejecuta de forma concurrete para cada Socket de un cliente
        public void atencionClinte_procotocoloComunicacion(object sCliente)
        {
            String mensaje = "";
            try
            {

                using (Socket cliente = (Socket)sCliente)
                {


                    IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint; //ip, puerto del cliente

                    //ieCliente.Address;//DIRECCIÓN IP DEL CLIENTE
                    using (NetworkStream ns = new NetworkStream(cliente))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        // dentro de un lock el add porque van a acceder multiples clientes y puede causar conflicto
                        //es el recurso común


                        //Protocolo
                        sw.WriteLine("Bienvenido al chat");
                        sw.Flush();
                        sw.WriteLine("Indique el nombre de usuario:");
                        sw.Flush();
                        String userName = sr.ReadLine();

                        //Es esta estructura-Sí
                        lock (l)//si tiene el testigo añade a la colección 
                        {
                            //mISMA POSICIÓN
                            mensajes.Add(sw);//añado a la coleccion el streamwritter
                            String user = userName + "@" + ieCliente.Address.ToString();
                            users.Add(user);
                            //La recorro para indicar que usuario/s se acaban de conectar
                            foreach (StreamWriter swit in mensajes)
                            {
                                if (swit != sw)
                                {
                                    swit.WriteLine("Usuario conectado: " + userName + "@" + ieCliente.Address);
                                    swit.Flush();


                                }

                            }
                        }

                        //PRUEBAS FRONTERA 

                        while (true)
                        {


                            mensaje = sr.ReadLine();
                            if (mensaje != null)
                            {
                                //
                                lock (lWrite)//si tiene el testigo escribe
                                {
                                    if (mensaje.Equals("#exit"))
                                    {
                                        //foreach (StreamWriter swDesconectado in mensajes)//No se puede eliminar con un foreach
                                        //{
                                            for (int i = 0; i < mensajes.Count; i++)
                                            {
                                                if (mensajes[i] != sw)
                                                {
                                                mensajes[i].WriteLine("Usuario desconectado: " + userName + "@" + ieCliente.Address);
                                                mensajes[i].Flush();

                                                }
                                                else
                                                {

                                                    users.Remove(userName + "@" + ieCliente.Address);//No puedo hacer un remove por la posición??

                                                    mensajes.Remove(sw);

                                                }

                                           

                                        }
                                        cliente.Close();//cierro el socket del cliente ??
                                    }
                                    else
                                    {

                                        if (mensaje.Equals("#lista"))//users conectados
                                        {

                                            sw.WriteLine("Usuarios conectados: ");
                                            sw.Flush();

                                            for (int i = 0; i < users.Count; i++)
                                            {
                                                if (users[i] != userName + "@" + ieCliente.Address)
                                                {
                                                    sw.WriteLine(users[i]);
                                                    sw.Flush();

                                                }
                                            }

                                        }

                                        //En otro lock>?????
                                        foreach (StreamWriter swit in mensajes)
                                        {

                                            if (swit != sw)
                                            {

                                                //                                                System.ObjectDisposedException: 'Cannot write to a closed TextWriter.
                                                //ObjectDisposed_ObjectName_Name'

                                                swit.WriteLine(userName + "@" + ieCliente.Address + ": " + mensaje);
                                                swit.Flush();

                                            }




                                        }
                                    }
                                }



                            }

                        }

                    }

                    //remove de la lista
                }

            }
            catch (ArgumentNullException rg)//----> No se deben capturar los null
            {
                // Console.WriteLine("Uuario desconectado: " + userName + "@" + ieCliente.Address));

            }
            catch (ArgumentException ar)
            {
                Console.WriteLine(ar.Message);

            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }
    }
}
