using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    internal class Cliente
    {
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
                    //adri puerto = 12357;

                }
            }
        }
        private String ip_server;

        public String Ip_server
        {
            get { return ip_server; }
            set
            {
                if (value == null)
                {
                    ip_server = "127.0.0.1";
                    //adri ip_server = "192.168.0.41";

                }
                else
                {
                    ip_server = value;

                }
            }
        }

        public void conexionServidor()
        {
            string msg;
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(Ip_server), Puerto);//Ip+puerto servidor
            Socket sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sServer.Connect(ie); //Me intento conectar al servidor
            }
            catch (SocketException sex)
            {

                Console.WriteLine(sex.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            try
            {
                using (NetworkStream ns = new NetworkStream(sServer))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    msg = sr.ReadLine(); //Leo el mensaje que me envía el servidor
                                         //Console.WriteLine(msg); //escribo el mensaje que acabo de leer
                    if (msg != null)
                    {
                        sw.WriteLine(msg);
                        msg = sr.ReadLine();//indicar user
                        sw.WriteLine(msg);//leo el usuario

                    }

                    try
                    {
                        while (true)
                        {
                            if (msg != null)
                            {
                                msg = sr.ReadToEnd();
                                sw.WriteLine(msg);
                                sw.Flush();

                            }

                        }
                    }
                    catch (ArgumentException arge)
                    {

                        Console.WriteLine(arge.Message);
                    }
                    catch (IOException io)
                    {
                        Console.WriteLine(io.Message);
                    }




                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
