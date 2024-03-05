using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
    internal class PeopleManager
    {
        //Persona contiene distintos tipos
        public List<Person> people = new List<Person>();

        public int Position(int age)
        {
            int aux = 0;
            for (int i = 0; i < people.Count; i++)
            {
                if (age > people[i].Age)
                {
                    aux = i;
                }
            }
            return 0;
        }

        public int Position(string lastName)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].LastName.ToLower().StartsWith(lastName.ToLower()))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Delete(int max, int min = 0)
        {
            try
            {
                for (int i = people.Count - 1; i >= 0; i--)
                {
                    if (i <= max && i >= min)
                    {
                        people.RemoveAt(i);
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
        public void AddPerson(Person person)
        {

            people.Insert(Position(person.Age), person);
            Write();
        }
        public void Write()
        {

            BinWriterPerson bwp;
            String directory = Environment.ExpandEnvironmentVariables("%appdata%");
            string name = "WriteColeccion.dat";
            //Curro-->Me dice que el fichero está siendo usado por otro proceso
            if (File.Exists(directory + "\\" + name))
            {

                bwp = new BinWriterPerson(new FileStream(directory + "\\" + name, FileMode.Append));

            }
            else
            {
                bwp = new BinWriterPerson(new FileStream(directory + "\\" + name, FileMode.CreateNew));

            }

            foreach (Person person in people)
            {
                if (person is Employee)
                {
                    bwp.Write((Employee)person);

                }
                else if (person is EspecialEmployee)
                {
                    bwp.Write((EspecialEmployee)person);

                }
                else if (person is Directive)
                {
                    bwp.Write((Directive)person);
                }
            }
            bwp.Close();
        }
        public void Read()
        {
            BinReaderPerson brp;
            String directory = Environment.ExpandEnvironmentVariables("%appdata%");
            string name = "WriteColeccion.dat";

            if (File.Exists(directory + "\\" + name))
            {

                brp = new BinReaderPerson(new FileStream(directory + "\\" + name,FileMode.Open));
               //TODO:leer según el tipo de objeto(???)
               //cON METADATOS, ESCRIBIR ENTRE SEPARACIONES DE OBJETOS 
                
                brp.ReadEmployee();
                brp.ReadEspecialEmployee();
                brp.ReadDirective();

            }

        }
        //public BinWriterPerson Fich()
        //{
        //    BinWriterPerson bwp;
        //    String directory = Environment.ExpandEnvironmentVariables("%appdata%");
        //    string name = "WriteColeccion.dat";
        //    if (File.Exists(directory + "\\" + name))
        //    {

        //        bwp = new BinWriterPerson(new FileStream(directory + "\\" + name, FileMode.Append));
        //        return bwp;
        //    }
        //    else
        //    {
        //        bwp = new BinWriterPerson(new FileStream(directory + "\\" + name, FileMode.CreateNew));
        //        return bwp;
        //    }

        //}
    }
}
