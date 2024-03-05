namespace Servidor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServidorProtocolo servidor = new ServidorProtocolo();
            servidor.Init();
        }
    }
}