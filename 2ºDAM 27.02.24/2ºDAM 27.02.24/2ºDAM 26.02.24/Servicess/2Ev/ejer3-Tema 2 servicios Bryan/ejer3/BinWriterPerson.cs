using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
    internal class BinWriterPerson : BinaryWriter
    {
        public BinWriterPerson(Stream str) : base(str)
        {
            //El constructor de BinaryWriter(Stream str);
            //Stream-->FileStream

        }

        public void Write(Directive directive)
        {
            //base se usa para acceder a miembros/métodos
            //de la clase de la que hereda
            //En este caso acceso a Write(); de BinaryWriter
            base.Write(directive.FirstName);
            base.Write(directive.LastName);
            base.Write(directive.Age);
            base.Write(directive.Dni);
            base.Write(directive.Departament);
            base.Write(directive.NumPersons);
           


        }
        public void Write(Employee employee)
        {
            base.Write(employee.FirstName);
            base.Write(employee.LastName);
            base.Write(employee.Age);
            base.Write(employee.Dni);
            base.Write(employee.Salary);
            base.Write(employee.Phone);

        }
        
        public void Write(EspecialEmployee especialEmployee)
        {
            base.Write(especialEmployee.FirstName);
            base.Write(especialEmployee.LastName);
            base.Write(especialEmployee.Age);
            base.Write(especialEmployee.Dni);
            base.Write(especialEmployee.Salary);
            base.Write(especialEmployee.Phone);

        }
    }
}
