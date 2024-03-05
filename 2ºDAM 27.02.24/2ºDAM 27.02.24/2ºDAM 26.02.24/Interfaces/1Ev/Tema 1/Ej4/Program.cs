using System.Numerics;
using System.Runtime.CompilerServices;
//control+K+D     IDENTAR

//Arrastrar la carpera con los ej.Res a donde quiera
//VALIDADO

namespace Ej4
{
    internal class Program  //Control rangos en dados, Adiso solo al salir, posibilidad de repetir cada juego, aleatorios +1, alineación en columas, falta quini en jugar a todos
    {
        public void TirarDado(int numCaras, int numAAcertar)
        {

            Random generador = new Random();
            int acu = 0;

            for (int i = 0; i < 10; i++)
            {
                int valor = generador.Next(1, numCaras+1);
                Console.WriteLine("El resultado de la {0} tirada es {1} ", i, valor);
                if (valor == numAAcertar)
                {
                    acu++;
                }
            }

            Console.WriteLine("Has acertado {0} veces", acu);
        }
        public void AdivinaNumero()
        {
            Random generador = new Random();
            int numAleatorio = generador.Next(1, 101);
            int nIntAcertar;

            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine("Tienes {0} intentos", i);
                do
                {
                    Console.WriteLine("Dime un número positivo mayor a 0 y menor a 100");


                        nIntAcertar = Convert.ToInt32(Console.ReadLine());

                } while (nIntAcertar < 0 || nIntAcertar > 100);

                if (nIntAcertar > numAleatorio)
                {
                    Console.WriteLine("El número que has introducido es mayor");
                }
                if (nIntAcertar < numAleatorio)
                {
                    Console.WriteLine("El número que has introducido es menor");
                }
                if (nIntAcertar == numAleatorio)
                {
                    Console.WriteLine("Enhorabuena has acertado el número en {0} intentos", i);
                    break;
                }
                if (i == 1)
                {

                    Console.WriteLine("El número a adivinar era {0}", numAleatorio);
                }
            }


        }
        public string GeneradorNumsQuiniela(int numRandom)
        {
            switch (numRandom)
            {
                case > 0 and <= 60:
                    return "1";

                case > 60 and <= 85:

                    return "X";

                case > 85 and <= 100:
                    return "2";

                default:
                    return "Sin número";



            }
        }
        public void Quiniela()
        {
            Program p1 = new Program();
            Random generador = new Random();

            string numeritoQuiniela = "";

            for (int i = 1; i <= 14; i++)
            {

                int numRandom = generador.Next(1, 101);
                numeritoQuiniela = p1.GeneradorNumsQuiniela(numRandom);
                Console.WriteLine("Número {0,2}: {1,3}", i, numeritoQuiniela); //formato corregido?


            }


        }

        static void Main(string[] args)
        {
            string opc;
            int repetir;
            do
            {
                Console.WriteLine("Opción 1. Tirar dado:\nOpción 2. Juego adivina un número\nOpción 3. Realizar una quiniela:\nOpción 4. Jugar a todos.\nOpción 5. Salir");
                opc = Console.ReadLine();
                
                int nCaras;
                int nAcertar;
                string numCaras;
                Program p = new Program();




                switch (opc)
                {
                    case "1":
                        do
                        {


                           // do
                            //{
                                do
                                {


                                    Console.WriteLine("Número de caras del dado en rango 1-100");
                                    numCaras = Console.ReadLine();
                                    nCaras = Convert.ToInt32(numCaras);
                                    if (nCaras<=0 || nCaras >100)
                                    {
                                        Console.WriteLine("El número de caras introducido no es válido, introduzca un número positivo >=1 y <=100");
                                    }

                                } while (nCaras <= 0 ||nCaras>100); //TRUE
                                do
                                {
                                    Console.WriteLine("Número que quieres acertar, debe ir del 1-{0} (caras del dado), ambos incluídos",numCaras);
                                    string numAcertar = Console.ReadLine();
                                    nAcertar = Convert.ToInt32(numAcertar);
                                    if(nAcertar<=0 || nAcertar > nCaras)
                                    {
                                        Console.WriteLine("El número para acertar no es válido, introduzca un número positivo y menor o igual al número de caras del dato");
                                    }

                                } while (nAcertar <= 0 || nAcertar > nCaras);


                                p.TirarDado(nCaras, nAcertar);


                                //TODO + usabilidad, indicar al usuario si está fuera de rango



                           // } while (nAcertar > nCaras || nAcertar < 0);
                            Console.WriteLine("\n¿Quieres repetir el juego?\n1: si\n2: no\n");
                            repetir = Convert.ToInt32(Console.ReadLine());
                        } while (repetir == 1);
                            if (opc == "4")
                            {
                                goto case "2";
                            }
                            else
                            {
                                break;

                            }
                    case "2":
                        do
                        {

                            p.AdivinaNumero();
                            Console.WriteLine("¿Quieres repetir el juego?\n1: si\n2: no");
                            repetir = Convert.ToInt32(Console.ReadLine());
                        } while (repetir == 1);
                        if (opc == "4")
                        {
                            goto case "3";
                        }
                        else
                        {
                            break;

                        }

                    case "3":
                      
                            do
                            {
                                p.Quiniela();
                                Console.WriteLine("¿Quieres repetir el juego?\n1: si\n2: no\n");
                                repetir = Convert.ToInt32(Console.ReadLine());

                            } while (repetir == 1);

                       
                           break;

                      

                    case "4":
                        goto case "1";

                    case "5":
                        Console.WriteLine("Adiós¡");
                        break;



                }
            } while (opc != "5");
        }
    }
}

