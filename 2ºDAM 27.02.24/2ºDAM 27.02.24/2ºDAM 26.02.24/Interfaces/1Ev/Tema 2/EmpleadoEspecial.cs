using System;
namespace Ej1_POO
{
	public class EmpleadoEspecial: Empleado,IPastaGansa

        //REVISAR CONSTRUCTORES DE CADA CLASE ,CON HERENCIA COMO FUNCIONAN???
	{
		public EmpleadoEspecial(string nombre, string apellidos, int edad, string dni, double? salario, string? nTel)
            : base(nombre,apellidos,edad,dni,salario,nTel)
		{ 
		}
        public EmpleadoEspecial()
            :this ("","",0,"",0.0,"")
        {

        }
       

        double IPastaGansa.GanarPasta(double benTotalEmpresa)
        {
            return 0.005 * benTotalEmpresa;
        }
        public override double? Hacienda()
        {
            double? dineroBase= base.Hacienda();
            double? gananciaextra = dineroBase * 0.005;
            return dineroBase + gananciaextra;
                ; //base.Hacienda() es la función que está en Empleado, obtengo lo que devuelve y le sumo una ganancia extra
        }
    }
}

