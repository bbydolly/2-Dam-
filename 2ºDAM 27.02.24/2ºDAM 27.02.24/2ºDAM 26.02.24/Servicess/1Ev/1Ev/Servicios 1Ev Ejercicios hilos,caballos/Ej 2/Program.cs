using System.Collections;

namespace Ej_2;
public delegate void MyDelegate(); //realiza una tarea completa,no devuelve nada,
                                   // el delegado es una clase, una referencia(puntero) a una función

// *Menú
// *Control de excepciones

class Program
{
    static bool MenuGenerator(String[] nombreOpciones, MyDelegate[] MyDelegate) //Mydelegate son las funciones
    {
        // Necesito un vector intermedio
        Hashtable opcionFuncion = new Hashtable();
        String op;

        if (nombreOpciones.Length == MyDelegate.Length && nombreOpciones != null && MyDelegate != null)
        {
            try
            {

                for (int i = 0; i < nombreOpciones.Length; i++)
                {

                    opcionFuncion.Add(nombreOpciones[i], MyDelegate[i]);


                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Sorry. The items are already in the collection");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Sorry. The input out of range");
            }
            do
            {

                Console.WriteLine("Select an opcion: ");
                for (int i = 0; i < nombreOpciones.Length; i++)
                {

                    Console.WriteLine(nombreOpciones[i]);
                }
                Console.WriteLine("Exit");
                op = Console.ReadLine();

                if (!opcionFuncion.Contains(op))
                {
                    Console.WriteLine("Invalidad option");
                    
                }
                else
                {
                    ((MyDelegate)opcionFuncion[op]).Invoke();
                    //o sin el invoke poner paréntesis
                    //Lo que invoco es una función que está contenida en el Hashtable
                    //Hastable es como un array indexo por la clave
                }




            } while (op != "Exit");

            return true;
        }
        else
        {
            return false;
        }

    }
    // FALTA pasar las funciones a expresiones lamda
    static void Main(string[] args)
    {
     
        MenuGenerator(new string[] { "Op1", "Op2", "Op3" },
        //new MyDelegate[] { f1, f2, f3 });
        new MyDelegate[] { ()=> Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C") });

        Console.ReadKey();
    }

}

