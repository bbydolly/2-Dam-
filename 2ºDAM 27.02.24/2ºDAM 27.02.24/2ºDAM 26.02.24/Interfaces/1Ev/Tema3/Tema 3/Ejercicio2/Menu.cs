using System;
namespace Ejercicio2
{
	public class Menu
	{
		Aula a;
		
		public Menu()
		{
			//código fuente no disponible
			string[] nombres= { "Pedro", "Laura", "Juan", "Santi" };
			this.a = new Aula(nombres);
		}
        public void mostrarTabla()
        {
			string[] asignaturas = Enum.GetNames(typeof(Aula.NombreAsignaturas));
			Console.Write("{0,10}", "");
			foreach (string a in asignaturas)
			{
				Console.Write("{0,10}", a);

            }
			Console.WriteLine();


			//Imprimir las cabeceras de las filas y de las columnas

			// Console.Write("{0,10}", ""); //mete 5 espacios
			// foreach (var i in Enum.GetValues(typeof(NombreAsignaturas)))
			//{
			//    Console.Write("{0,10} ", i);
			//}
			// Console.WriteLine();
			

            for (int i = 0; i < a.notas.GetLength(0); i++) //0 es la primera coordenada del array, 1 la segunda 
            {
                Console.Write("{0,7}",
                a.nombresAlumnos[i]);
                for (int j = 0; j < a.notas.GetLength(1); j++)
                {
                    Console.Write("{0,10}", a.notas[i, j]);
                }
                Console.WriteLine();
            }

        }

        public void opcionesMenu()
		{
			int opc=0;
			try
			{

			do
			{

				Console.WriteLine("-----------M--E--N--Ú-----------");
				Console.WriteLine("Seleccione una opción:");
				Console.WriteLine("1.Calcular la media de notas de toda la tabla\n" +
					"2.Media de un alumno\n" +
					"3.Media de una asignatura\n" +
					"4.Visualizar notas de un alumno\n" +
					"5.visualizar notas de una asignatura\n" +
					"6.Nota máxima y mínima de un alumno\n" +
					"7.Visualizar tabla completa\n");
				opc = Convert.ToInt32(Console.ReadLine());
			} while (opc < 7);
			}
			catch (System.FormatException)
			{
				Console.WriteLine("Dato introducido erróneo\nIntroduzca un número porfavor");
			}
			switch (opc)
			{
				case 1:
					a.obtenerMediasTabla();
					break;
                case 2:
					a.mediaAlumno("Pedro");
                    break;
                case 3:
					a.mediaAsignatura("Quidditc");
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
					//a.maxYmin(); Cómo uso esto????
                    break;
                case 7:
					mostrarTabla();
                    break;
            }

		}
	}
}

