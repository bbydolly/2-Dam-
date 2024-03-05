using System;
using System.Collections;

namespace Tema_3  //Overflow, salir, informar al eliminar, claves repetidas,
{
    public class Ej1
    {
        Hashtable ipsRam = new Hashtable(); //ips,ram ojo con inicializar un objeto en un bucle

        public void menu()
        {


            int opc = 0;
            do
            {
                try
                {

                    Console.WriteLine("-------MENÚ-------");
                    Console.WriteLine("1: Introducir datos\n2:Eliminar un dato por clave\n3:Mostrar la colección\n4:Mostrar un elemento de la colección\n5:Salir");
                    Console.WriteLine("------------------");
                    opc = Convert.ToInt32(Console.ReadLine());



                    switch (opc)
                    {
                        case 1:
                            IntroducirDatos();
                            break;
                        case 2:
                            Console.WriteLine("Qué ip quieres eliminar?");
                            string ip = Console.ReadLine();
                            ipsRam = EliminarDatoPorClave(ipsRam, ip);
                            break;
                        case 3:
                            MostrarColeccion(ipsRam);
                            break;
                        case 4:
                            Console.WriteLine("¿Qué conjunto de valores quieres ver?, dime la IP");
                            string ip2 = Console.ReadLine();
                            Mostrar1ElementoColeccion(ipsRam, ip2);
                            break;
                        case 5:
                            Console.WriteLine("Adiós");
                            break;


                    }
                }
                catch (System.FormatException ex)
                {

                }
                catch (OverflowException e)
                {

                }
            } while (opc < 4 && opc > 1);
        }
        public void IntroducirDatos() //ip válida RAM entero positivo
        {
            // ipsRam = new Hashtable();
            try
            {

                string ip;
                do
                {
                    Console.WriteLine("Introduce una IP");
                    ip = Console.ReadLine();


                } while (!VerificarIp(ip)); //4 grupos entre 0 y 255, separados por puntos
                int ramV;
                string ram;
                do
                {
                    Console.WriteLine("Introduce la cantidad de RAM");
                    ram = Console.ReadLine();

                } while (!VerificarRam(ram)); //verificado

                ramV = Convert.ToInt32(ram);
                ipsRam.Add(ip, ramV); //clave, valor
            }
            catch (System.FormatException ex) //valor no numérico
            {

            }

        }
        public bool VerificarIp(string ip)
        {

            string[] fragmIp = ip.Split("."); //devuelve un array //separo por cada punto y compruebo el rango de cada uno de los substrings

            for (int i = 0; i < 4; i++) //como un while puede nonentrar
            {
                if (fragmIp.Length >= 3)
                {
                    Console.WriteLine("Ip no válida, una IP se compone de 4 octetos");
                    break;
                }
                int nIp;
                try
                {
                    nIp = Convert.ToInt32(fragmIp[i]);
                    if (nIp < 0 || nIp > 255)
                    {
                        Console.WriteLine("La ip no cumple con el fromato correspondiente,debe ser mayor a 0 cada uno de los grupos y menor a 255");
                        return false;
                    }

                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("La ip debe contener únicamente números");
                    return false;

                }


            }
            return true;


        }
        public bool VerificarRam(string ram)
        {
            try
            {
                int ramV = Convert.ToInt32(ram);

                if (ramV % 2 == 0 && ramV > 0)
                {
                    return true;
                }
                return false;




            }
            catch (System.FormatException ex)
            {

                Console.WriteLine("La RAM introducida no es válida ,debe ser un número mayor a 0 y divisible entre 2");
                return false;
            }


        }
        public Hashtable EliminarDatoPorClave(Hashtable ipsRam, string ip) //clave:ip
        {

            foreach (DictionaryEntry de in ipsRam)
            {
                if (ipsRam.ContainsKey(ip))
                {
                    Console.WriteLine("Se ha eliminado:\nIP: {0}	RAM:{1}", de.Key, de.Value);
                    ipsRam.Remove(ip);
                }



            }
            return ipsRam;
        }
            public void MostrarColeccion(Hashtable ipsRam)
            {
                if (ipsRam.Count != 0)
                {
                    foreach (DictionaryEntry de in ipsRam)
                    {
                        Console.WriteLine("IP: {0}	RAM:{1}", de.Key, de.Value); //EN PLURAL???
                    }

                }
                else
                {
                    Console.WriteLine("La colección está vacía, introduzca datos en la opción 1\n");
                }

            }
            public void Mostrar1ElementoColeccion(Hashtable ipsRam, string ip2)
            {

                //se indexa como un array

                if (ipsRam.Contains(ip2))
                {
                    Console.WriteLine("IP: {0}	RAM:{1}", ip2, ipsRam[ip2]);  //Funciona?

                }
                else
                {
                    Console.WriteLine("Añada {0} a la colección, no puedo mostrarte la cantidad de GB de RAM porque no se encuentra en ella", ip2);
                }





            }
            public Ej1()
            {
            }
        }
    }

