using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_POO
    //VALIDADO
{
    public abstract class Persona
    {
        public string nombre;
        public string apellidos;
        public int edad;
        public string dni;
        char letra;


        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public string Apellidos
        {
            set
            {
                apellidos = value;
            }
            get
            {
                return apellidos;
            }
        }
        public int Edad
        {
            set
            {
                if (value > 0)
                {

                    edad = value;
                }
                else
                {
                    edad = 0;
                }
            }
            get
            {
                return edad;
            }
        }
        public string Dni
        {
            set
            {
                dni = value;
            }
            get
            {
                //Calcular la letra del DNI, va por rangos
                string letras = "TRWAGMYFPDXBNJZSQVHLCKE"; //arraydechars
                int dniAnum = Convert.ToInt32(dni) ;// (int)Convert.ToDouble(dni);
                int restoDni = dniAnum % 23;

                return dni + letras[restoDni] ;
            }
        }


        public Persona(string nombre, string apellidos, int edad, string dni)
        {
            //propiedad=parámetro
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Dni = dni;
        }
        public Persona()
            : this(" ", " ", 0, " ")
        {
        }
        public virtual void MostrarCampos()
        {
            //Mostrar los campos
            Console.WriteLine("El nombre es: {0}\nEl apellido es: {1}\nLa edad es: {2} años\nEl dni es: {3}",Nombre,Apellidos,Edad,Dni);
        }
        public virtual void IntroducirCampos()
        {
            
            Console.WriteLine("Introduzca el nombre");
            Nombre = Console.ReadLine();
          
            Console.WriteLine("Introduzca los apellidos");
            Apellidos = Console.ReadLine();
            
            Console.WriteLine("Introduzca la edad");
            Edad = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine("Introduce el dni");
            Dni = Console.ReadLine();
           

        }
        public abstract double? Hacienda(); //declaración
       


    }
}

