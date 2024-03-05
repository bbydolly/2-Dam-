using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3
{
    internal class BinReaderPerson : BinaryReader
    {
        //Contructor con Stream-->new FileStream (directory+nArchivo);
        public BinReaderPerson(Stream stream) : base(stream) { }
        //: base es para acceder a la clase de la que hereda
        //BinaryReader(Stream str), de ahí que le pasemos el mismo parámetro
        //Vamos a leer los datos de un archivo binario --> .dat

     
        public Directive ReadDirective()
        {
  
            Directive directive = new Directive();

            directive.FirstName = base.ReadString();
            directive.LastName = base.ReadString();
            directive.Age = base.ReadInt16();
            directive.Dni=base.ReadString();
            directive.Departament=base.ReadString();
            directive.NumPersons = base.ReadInt16();

            return directive;
        }
  
        public Employee ReadEmployee()
        {
            Employee employee = new Employee();

            employee.FirstName = base.ReadString(); 
            employee.LastName = base.ReadString();
            employee.Age = base.ReadInt16();
            employee.Dni=base.ReadString();
            employee.Salary=base.ReadInt16();
            employee.Phone=base.ReadString();

            return employee;
        }
        
        public EspecialEmployee ReadEspecialEmployee()
        {
            EspecialEmployee employee = new EspecialEmployee();
            employee.FirstName = base.ReadString();
            employee.LastName = base.ReadString();
            employee.Age = base.ReadInt16();
            employee.Dni=base.ReadString();
            employee.Salary=base.ReadInt16();
            employee.Phone=base.ReadString();

            return employee;
        }
    }
}
