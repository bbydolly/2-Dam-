using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCris
{
    internal class ClienteCris
    {
        public void InitCliente()
        {
            const string IP_SERVER = "127.0.0.1";
            //const string IP_SERVER = "192.168.20.2";

            
            string msg;
            string userMsg;
            // Indicamos servidor al que nos queremos conectar y puerto
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), 31010);
            Console.WriteLine("Starting client. Press a key to init connection");
            Console.ReadKey();
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // El cliente inicia la conexión haciendo petición con Connect
                server.Connect(ie);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Error connection: {0}\nError code: {1}({2})",
                e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
                Console.ReadKey();
                return;
            }
            // Información del servidor
            IPEndPoint ieServer = (IPEndPoint)server.RemoteEndPoint;
            Console.WriteLine("Server on IP:{0} at port {1}", ieServer.Address,
            ieServer.Port);

            // Si la conexión se ha establecido se crean los Streams
            // y se inicial la comunicación siguiendo el protocolo
            // establecido en el servidor
            using (NetworkStream ns = new NetworkStream(server))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                // Leemos mensaje de bienvenida ya que es lo primero que envía el
                //servidor
                msg = sr.ReadLine();
                Console.WriteLine(msg);
                while (true)
                {
                    // Lo siguiente es pedir un mensaje al usuario
                    userMsg = Console.ReadLine();
                    //Enviamos el mensaje de usuario al servidor
                    // que que el servidor está esperando que le envíen algo

                    //TODO 
                    //Colección de clientes, para enviar y escribir los datos a todos los clientes
                    sw.WriteLine(userMsg);
                    sw.Flush();
                    //Recibimos el mensaje del servidor
                    msg = sr.ReadLine();
                    Console.WriteLine(msg);
                }
            }
            Console.WriteLine("Ending connection");
            //Indicamos fin 
        }
    }
}
