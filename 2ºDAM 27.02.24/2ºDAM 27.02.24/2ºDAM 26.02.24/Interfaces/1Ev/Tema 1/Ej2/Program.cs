#define FRASE
//Esta directiva indica si cierto identificador está definido

//TODO como activo/desactivo la directiva DEFINE?
namespace Ej2
    //VALIDADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dime una frase");
            string f1 = Console.ReadLine();
            Console.WriteLine("Dime otra frase");
            string f2 = Console.ReadLine();



#if FRASE
            Console.WriteLine("\"{0}\" \\{1}\\\n", f1, f2);
#else
                 Console.WriteLine("{0}\t {1}\n{0}\n{1}\n",f1,f2);
#endif


        }
    }
}