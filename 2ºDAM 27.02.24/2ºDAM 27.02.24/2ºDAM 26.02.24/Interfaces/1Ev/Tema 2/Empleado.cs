using System;
namespace Ej1_POO
	//VALIDADO
{
	public class Empleado : Persona
		//public o internal; si es internal la clase que hereda tiene que serlo, de mayor a menor visivilidad, nunca de menor a mayor si hereda¡¡
	{
		public double? salario;
		private int irpf;
		public string nTel;

		public double? Salario
		{
			set
			{
				salario = value;
				if (salario < 600 && salario>0)
				{
					irpf = 7;
				}else if( salario <= 3000)
				{
					irpf = 15;
				}else
				{
					irpf = 20;
				}

			}
			get
			{
				return salario;

			}
		}
		public int Irpf
		{
			get
			{
				return irpf;
			}
		}
		public string Ntel
		{
			set
			{
				nTel = value;
			}
			get
			{
				return "+34" + nTel;
			}
		}



        public override void MostrarCampos() //Sobreescritura
        {
            base.MostrarCampos();
			Console.WriteLine("El salario es de: {0}€\nEl irpf es del: {1}%\nEl número de teléfono es: {2}\n", Salario,Irpf,Ntel);
        }
		public void MostrarCampos(int num) // Sobrecarga: varias funciones funciones con distinta lista de parámetros
		{
			switch (num)
			{
				case 0:
					Console.WriteLine(num+":" + base.Nombre); //base se usa cuando hay dos propiedades que se llaman igual, una en la clase padre y otra en la clase que hereda
					break;

				case 1:
					Console.WriteLine(num + ":" + base.Apellidos);
					break;

                case 2:
					Console.WriteLine(num + ":" + base.Edad);
					break;

                case 3:
					Console.WriteLine(num + ":" + base.Dni);
					break;

                case 4:
					Console.WriteLine(num + ":" + Salario); 
					break;

                case 5:
					Console.WriteLine(num + ":" + Irpf+"%");
					break;

                case 6:
					Console.WriteLine(num + ":" + Ntel);
					break;

            }
		}
		

        public override double? Hacienda()
        {
			//ternaria para comprobar si es null salario
			 Salario= salario ?? 0.0;
			
			return Irpf * Salario / 100;
        }

		//Constructores---Inicializo los campos a vacío y con paso de params
		public Empleado(string nombre, string apellidos, int edad, string dni,double? salario, string? nTel)  //? acepta valores null
			//añadir todas las propiedades de la clase Persona y pasárselas al constructor
			: base(nombre, apellidos, edad, dni)
		{

			Salario = salario;
			Ntel = nTel;
			
		}
		public Empleado()
			:this("","",0 ,"", null,null)
		{

		}
    }
}

