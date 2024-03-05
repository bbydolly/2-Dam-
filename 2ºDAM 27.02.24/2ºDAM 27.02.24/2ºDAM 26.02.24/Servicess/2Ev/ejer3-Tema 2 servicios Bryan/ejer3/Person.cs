using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
    internal abstract class Person
    {
        private int age;
        private string dni;
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public Person(string firstName, string lastName, int age, string dni)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Dni = dni;
        }
        public Person() : this("", "", 0, "") { }

        public int Age
        {
            set
            {
                age = value > 0 ? value : 0;
            }
            get
            {
                return age;
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
                string aux = "TRWAGMYFPDXBNJZSQVHLCKE";
                return dni + aux[Convert.ToInt32(dni) % 23];
            }
        }
        public virtual void ShowData()
        {
            Console.WriteLine($"Full name: {FirstName} {LastName}.\n" +
                $"Age: {Age}.\n" +
                $"DNI: {Dni}.");
        }

        public virtual void AskData()
        {
            bool flag;
            Console.Write("Type the first names: ");
            FirstName = Console.ReadLine();
            Console.Write("Type the last names: ");
            LastName = Console.ReadLine();
            int auxAge;
            do
            {
                Console.Write("Type the age: ");

                if (!(flag = int.TryParse(Console.ReadLine(), out auxAge)))
                {
                    Console.WriteLine("You have to type an integer number.");
                }
            } while (!flag);
            Age = auxAge;
            Console.Write("Type the DNI: ");
            dni = Console.ReadLine();
        }
        public abstract double Taxes();
    }
}
