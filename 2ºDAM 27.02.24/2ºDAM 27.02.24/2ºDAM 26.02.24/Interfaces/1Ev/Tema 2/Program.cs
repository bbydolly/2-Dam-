namespace Ej1_POO
{
    internal class Program
        //VALIDADO
    {
        
        public static double PastaGansa(IPastaGansa obj )//obej= Empleasdo o dIRECTIVO repasar¡
        {
            
            Console.WriteLine("¿Cuales son los beneficios de la Empresa?");
            double benTotalEmpresa = Convert.ToDouble(Console.ReadLine());
            
            return obj.GanarPasta(benTotalEmpresa); 
        }



        static void Main(string[] args)
        {
            Empleado em = new Empleado("Cris","lopez",23,"53820352",3800.0,"682745102");
            Directivo d = new Directivo("Maria","Guimerans",25,"739642937","Contabilidad",388488);
            EmpleadoEspecial ee = new EmpleadoEspecial("Adri","Patatilla",25,"549275945",300.0, "648926565");

            int opc;
            do
            {

               

                    Console.WriteLine("Opción 1: Visualizar los datos del Directivo\nOpción 2: Visualizar los datos Empleado\nOpción 3: Visualizar los datos del Empleado Especial\nOpción 4: Salir");
                    opc = Convert.ToInt32(Console.ReadLine());
               
                //con doble tabulación salen los snippets
                switch (opc)
                {

                    case 1:
                        d.MostrarCampos();
                        
                        Console.WriteLine("Los beneficios totales del directivo son {0}\n", PastaGansa(d));


                        break;
                    case 2:
                        em.MostrarCampos();

                        break;
                    case 3:
                        ee.MostrarCampos();
                        Console.WriteLine("Los beneficios totales del empleado son de {0}€\n", PastaGansa(ee)); //Con formato

                        break;
                    case 4:
                        break;

                }
            } while (opc!=4);


        }
    }
}