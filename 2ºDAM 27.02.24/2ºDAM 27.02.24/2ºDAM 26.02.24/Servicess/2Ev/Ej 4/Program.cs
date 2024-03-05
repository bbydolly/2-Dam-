namespace Ej_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string directorio = "C:\\Users\\mcris\\Downloads\\"; CASA
            string directorio = "C:\\Users\\Cristina\\Desktop\\2ºDAM 20.02.24";// CLASE
            FileInfo[] arc_bmp = null;
            bool aux = false;

            try
            {
                Directory.SetCurrentDirectory(directorio);
                DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
                //DirectoryInfo [] directorios=di.GetDirectories();


                foreach (DirectoryInfo direct in di.GetDirectories())
                {
                    Console.WriteLine("");
                    Console.WriteLine(direct.Name);
                    FileInfo[] archivos = direct.GetFiles();

                    foreach (FileInfo archivo in archivos)
                    {
                        Console.Write("\t\t");
                        Console.Write(archivo.FullName);
                        arc_bmp = direct.GetFiles("*.bmp");
                    }



                    if (arc_bmp != null)
                    {
                        foreach (FileInfo bmp in arc_bmp)
                        {
                            Console.WriteLine("Files bmp");
                            Console.WriteLine(bmp?.FullName);
                        }
                    }




                }

                try
                {
                    Console.WriteLine("Introduzca la ruta de un archivo");

                    String path = Console.ReadLine();
                    if (path != null)
                    {
                        BMP bmp1 = new BMP(path);

                        aux = bmp1.IsBmp();
                        //Console.WriteLine("auxiliar es: " + aux);

                        if (aux)
                        {

                            ObjectoBMP obBMP = (ObjectoBMP)bmp1.InfoBmp();
                            obBMP.MostrarDatos();
                            Console.WriteLine("Es un bmp válido");

                        }
                        else
                        {
                            Console.WriteLine("No se trata de un archivo bmp válido");
                        }

                    }

                }
                catch (FileNotFoundException)
                {

                    Console.Write("File not found ");
                }



            }
            catch (System.UnauthorizedAccessException i)
            {

                Console.WriteLine("Access unauthorized");
            }
            catch (DirectoryNotFoundException dnotfound)
            {
                Console.WriteLine("Directory not found");
            }


        }
    }

}