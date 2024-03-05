using System.Diagnostics;

namespace Tema_1_Process;
public delegate int Operation(int a); //definir un delegado ,es una "clase"

class Program
{
    
    public static bool pass(int num)
    {
        return num >= 5;
    }

    static void Main(string[] args)
    {
        int[] v = { 2, 2, 6, 7, 1, 10, 3 };
         // para cada uno de mis elementos de v haz:

                Array.ForEach(v, item =>
                {
                    if (item >= 5)
                    {
                       
                    Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"Student grade: {item,3}.");

                    Console.ResetColor();
                });

        Array.FindLastIndex(v, item =>
        {
            Console.WriteLine($"Student grade: {item,3}.");
            return item>=5;

        });
        Array.ForEach(v, item =>
        {
            double value = 1.0 / item; //convertir uno a double poner .0 o .F
           // Console.WriteLine($"The reverse of "+item+ " is {0:0.00} " ,value);
            Console.WriteLine($"The reverse of " + item + " is {0:F2} ", value);

            // {0:0.00 } //para imprimir dos decimales
            //primer 0 es el índice de la variable {0},{1}
        });

          
       
        

    }
}

