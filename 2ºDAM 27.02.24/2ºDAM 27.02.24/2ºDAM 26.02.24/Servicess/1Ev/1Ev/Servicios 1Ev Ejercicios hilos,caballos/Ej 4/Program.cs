namespace Ej_4;

//Ejercicio acabado 

class Program
{
    public static bool finished = false; //booleana auxiliar  para hacer comprobaciones
    static readonly object l = new object(); //Defino el testigo
    
    public static int n = 0;
    public static bool findG = false;
    public static bool findGn = false;


    static void Main(string[] args)
    {
        

        Thread h1 = new Thread(() =>
        {
            while (!finished)
            {

                lock (l)
                {

                    if (!finished)
                    {
                        n += 1;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(n);

                        if (n == 500)
                        {

                            Console.ForegroundColor = ConsoleColor.Cyan;
                           
                            finished = true;
                            findG = true;
                           //conflicto entre hilos, Pulse va siempre dentro de un lock
                            //y se usa desde otro hilo externo, no puede pararse y ejecutarse al mismo tiempo
                            
                                Monitor.Pulse(l);
                            


                        }

                    }


                }
            }
        });
        Thread h2 = new Thread(() =>
        {
            while (!finished)
            {

                lock (l)
                {
                    if (!finished)
                    {
                        n -= 1;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(n);

                        if (n == -500)
                        {
                            finished = true;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            // Console.WriteLine("Hilo 2 es el ganador"); //Esto en el main
                            findG = false;
                           //conflicto entre hilos
                            
                                Monitor.Pulse(l);
                            

                        }

                    }

                }


            }
        });
         h1.Start();
         h2.Start();
         lock (l)
        {
             Monitor.Wait(l); //gestionar que hilo ha acabado mediante una bool o un contador
            //lock (l) //conflicto entre hilos
            //{
            //    Monitor.Pulse(l);
            //}
            if (findG) //gestiono el hilo que ha acabado mediante una bool auxiliar que me permite saber que hilo ha acabado 
            {
                Console.WriteLine("Hilo 1 ganador");
            }
            else 
            {
                Console.WriteLine("Hilo 2 ganador");


        }
            }




    }
}










