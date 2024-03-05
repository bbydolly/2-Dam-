using System;
namespace Ej1_POO
{
	public class Directivo : Persona, IPastaGansa  //IMPLEMENTAR IU
	{
        private string nombreDepart; 
        private double pBeneficios; 
        private int nPersonasAcargo;
        private int pastaGansa;

        public int NPersonasAcargo //"propiedad, set y get"
        {
            set
            {
                nPersonasAcargo = value;
                if(nPersonasAcargo<=10 && nPersonasAcargo > 0)
                {
                    pBeneficios = 2;
                }else if(nPersonasAcargo>10 && nPersonasAcargo < 50)
                {
                    pBeneficios = 3.5;

                }else
                {
                    pBeneficios = 4;
                }
                

            }
            get
            {
                return nPersonasAcargo;
            }
        }
        public string NombreDepart
        {
            set
            {
                nombreDepart = value;
            }
            get
            {
                return nombreDepart;
            }
        }
        public double PBeneficios
        {
            get
            {
                return pBeneficios;
            }
        }

        //Curro
        public static Directivo operator--(Directivo dire) //Devuelvo un obj tipo Directivo  porque asigno "Llamar a la función pero con el operador: dire--;
        {
            // -- es el NOMBRE DE MI FUNCIÓN
            if (dire.pBeneficios >= 1)
            {
                dire.pBeneficios = dire.pBeneficios --;
            }
            return dire;
        }


        public static Directivo decrementaDirectivo(Directivo dire)
        {
            if (dire.pBeneficios >= 1)
            {
                dire.pBeneficios = dire.pBeneficios--;
            }

            return dire;
        }

        public void foo(int a)
        {
            if (a < 0)
            {
                Directivo d = this;
                d--;
               // decrementaDirectivo(d);
            }

        }
    
        public override void MostrarCampos()
        {
            base.MostrarCampos();
            Console.WriteLine("El nombre del departamento es: {0}\nEl porcentaje de beneficios es: {1}%\nEl número de personas a cargo es: {2}\n",this.nombreDepart,this.pBeneficios,this.nPersonasAcargo); //no es necesario 
        }
        public override void IntroducirCampos() //Comprobar los datos??
        {
            base.IntroducirCampos();
            Console.WriteLine("Introduzca el nombre del departamento");
            nombreDepart = Console.ReadLine();

            Console.WriteLine("Introduzca el número de personas a cargo");
            nPersonasAcargo = Convert.ToInt32(Console.ReadLine());

            
        }

        public Directivo(string nombre, string apellidos, int edad, string dni, string nombreDepart,int nPersonaACargo ) //voy añadiendo las propiedades de las distintas clases al constructor
            :base (nombre, apellidos, edad, dni)
		{
            NPersonasAcargo = nPersonaACargo;
            NombreDepart = nombreDepart;



        }
        public Directivo()
            :this("","",0,"","",0)
        {
        }

        public override double? Hacienda()
        {
            return 0.3 * pastaGansa;
        }

        double IPastaGansa.GanarPasta(double benTotalEmpresa)
        {
            
            if (benTotalEmpresa < 0)
            {
                Directivo d = this;
                pastaGansa = 0;
                d--; //Decremento los beneficios del directivo
            }
                
            return benTotalEmpresa * pBeneficios/100;
        }
    }
}

