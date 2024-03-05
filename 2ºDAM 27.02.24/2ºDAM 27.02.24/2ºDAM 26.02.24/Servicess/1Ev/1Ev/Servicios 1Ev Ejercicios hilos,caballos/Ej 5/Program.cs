namespace Ej_5;

class Program
{
    //Sólo había que borrar la carpeta bin y obj de la carpeta del ejercicio 
    public static bool finished = false; //bool aux para hacer comprobaciones
    static readonly object l = new object(); //defino el testigo

    static string caballo = "x";
    static int cont = 0;
    public static int apuesta;
    public static int caballoGanador = 0;
    public static bool auxbool = false;

    static void escribirEstrelals(object y)
    {
        int i = 0;
        Random r = new Random();
        Random time = new Random();

        int cont = 0;
        while (!finished)
        {
            int aux = 1;// r.Next(1, 5);
            cont += aux;
            Thread.Sleep(100);
            lock (l)
            {
                caballoGanador = (int)y - 3;
                if (!finished)
                {
                    Console.SetCursorPosition(cont, (int)y);
                    Console.Write($"{caballo}");
                    //Thread.Sleep(time.Next(100, 1000));

                    i++;

                    if (cont >= 50)
                    {
                        Console.Write("  Soy el ganador   ");
                        finished = true;
                        Console.Write("El caballo ganador es el " + caballoGanador + "\n");
                        auxbool = true;
                    }
                }

            }

        }
    }

    static void Main(string[] args)
    {
        //Por que caballo quieres apostar? 1-5
        //si el caballo gana le pregunto si quiere volver a jugar
        bool rep = true;
        auxbool = true;
        do
        {



            if (auxbool)
            {

                Console.WriteLine("Compiten 5 caballos \n¿Por qué caballo quieres apostar?");
                //control excepciones apuesta

                apuesta = Convert.ToInt16(Console.ReadLine());
                auxbool = false;
            }

            Thread[] caballos = new Thread[5];
            Random whoHorse = new Random();
            int horse = whoHorse.Next(0, 4);
            int i;
            i = 0;
            while (i < caballos.Length)
            {
                caballos[i] = new Thread(escribirEstrelals);

                i++;
            }
            i = 0;

            while (i <= 4)
            {
                caballos[i].Start(i + 3); //3,4,5,6,7
                i++;
            }

            //join
           // Thread[0].Join()
            if (auxbool)
            {
                Console.SetCursorPosition(1, 10);

                Console.WriteLine("¿Quieres repetir el juego?\ntrue or false");
                rep = Convert.ToBoolean(Console.ReadLine());
                //TODO cómo cojo la ultima posición en la pantalla?
                //Console.Clear();
                finished = false;
                if (rep)
                {
                    auxbool = true;
                }
            }
        } while (rep);

        


    }
}

