namespace Cliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.Ip_server = "127.0.0.1";
            cliente.Puerto = 31010;
            cliente.conexionServidor();
        }
    }
}