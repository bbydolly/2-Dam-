using System;
namespace Ejercicio2
{
    public class Aula
    {
        public int[,] notas;
        public string[] nombresAlumnos;

        //clase indexada?

        public int this[int fila, int columna]
        {
            set
            {
                notas[fila, columna] = value;
            }
            get
            {
                return notas[fila, columna];
            }
        }


        public enum NombreAsignaturas
        {
            Pociones,
            Quidditch,
            Criaturas,
            ArtesOscuras
        }
        public Aula()
        {

        }


        public Aula(string nombres)
        {
            this.nombresAlumnos = nombres.Split(','); //devuelve un array de steing
            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                nombresAlumnos[i] = nombresAlumnos[i].Trim().ToUpper();
            }
            this.nombresAlumnos = nombresAlumnos;

        }
        public Aula(string[] nombresAlumnos)
        {
            this.notas = new int[nombresAlumnos.Length, 4]; //nombresAlumnos fijas, enum Columnas
            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                nombresAlumnos[i] = nombresAlumnos[i].Trim().ToUpper();
            }
            this.nombresAlumnos = nombresAlumnos;
            rellenarConAleatorios();


        }
        public int[,] rellenarConAleatorios()
        {
            int[,] notas = new int[nombresAlumnos.Length, 4];
            Random random = new Random();

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                for (int J = 0; J < notas.GetLength(1); J++)
                {
                    notas[i, J] = random.Next(0, 10);
                }
                this.notas = notas;
            }
            return notas;
        }
        

        
        public void obtenerMediasTabla()
        {
            int acu = 0;
            double aux = 0.0;
            for (int i = 0; i < notas.GetLength(0); i++) //0 es la primera coordenada del array, 1 la segunda 
            {

                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    acu += notas[i, j];
                }
                aux = acu / (notas.GetLength(0) * notas.GetLength(1));

            }
            Console.WriteLine("La media de las notas de toda la tabla es: {0,2:F2}", aux); //Corregir decimales

        }
        public void maxYmin(ref int max, ref int min, string alumno) //corregir,no va bien
        {
            //Intento comparar el nombre del alumno, coger el índice y recorrer esa fila


            max = notas[0, 0];
            min = notas[0, 0];
            for (int t = 0; t < nombresAlumnos.Length; t++)
            {
                if (nombresAlumnos[t] == alumno)
                {
                    for (int i = 0; i < notas.GetLength(t); i++) //t/0 indica el num de filas
                    {
                        for (int j = 1; j < notas.GetLength(1); j++) //1 indics el num de columns
                        {



                            if (max < notas[t, j])
                            {
                                max = notas[t, j];
                            }
                            if (min > notas[t, j])
                            {
                                min = notas[t, j];

                            }

                        }


                    }

                }



            }
            Console.WriteLine("min " + min);
            Console.WriteLine("max " + max);



        }
        public int mediaAlumno(string alumno)
        {
            int acu = 0;
            int media = 0;
            for (int i = 0; i < nombresAlumnos.Length; i++)
            {
                if (nombresAlumnos[i] == alumno)
                {

                    for (int j = 0; j < notas.GetLength(i); j++)
                    {
                        for (int x = 0; x < notas.GetLength(1); x++)
                        {
                            acu += notas[i, j];

                        }

                    }
                    media = acu / 4;
                }
            }
            return media;

        }
        public int mediaAsignatura(string asignatura)
        {
            int acu = 0;
            int media = 0;
            foreach (var i in Enum.GetValues(typeof(NombreAsignaturas)))
            {
                if ((string)i == asignatura)
                {
                    for (int j = 0; j < notas.GetLength(0); j++)
                    {
                        for (int v = 0; v < notas.GetLength((int)i); v++)
                        {
                            acu += notas[j, v];
                        }
                    }
                }
            }
            media = acu / nombresAlumnos.Length;
            Console.WriteLine("La media es" + media);

            return media;
        }

    }

}

