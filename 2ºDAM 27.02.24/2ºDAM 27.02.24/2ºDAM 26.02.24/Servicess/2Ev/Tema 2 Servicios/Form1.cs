using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace Tema_2_Servicios
{
    //20/2
    //Curro: al poner \ y darle ..,..,.. me saltya a diferentes caches, cómo lo gestiono?
    public partial class Form1 : Form
    {
        //control+K+D identar
        String directorioActual;
        public FileInfo fich;
        //List<String> directoriosRuta;


        public Form1()
        {
            InitializeComponent();
            //textBox1.Text = "C:\\Users\\mcris\\OneDrive\\Escritorio\\2ºDAM";
            textBox1.Text = "C:\\Users\\Cristina\\Desktop\\2ºDAM 17.02.24\\2ºDAM 16.02.24";
            //directoriosRuta = new List<String>();



        }

        private void button1_Click(object sender, EventArgs e)
        {//al hacer click se cambiará a ese directorio
            listBox1.Items.Clear();

            String directorio;

            if (textBox1.Text != "")
            {
                directorio = textBox1.Text;
                //compruebo el directorio si existe o no
                if (directorio.Contains("%"))
                {

                    if (directorio.StartsWith("%") && directorio.EndsWith("%"))
                    {
                        lbl2.Visible = true;
                        directorio = directorio.Substring(1, directorio.Length - 2);

                        if (directorio.Contains("%"))
                        {
                            lbl2.Visible = true;
                            lbl2.ForeColor = Color.Red;
                            lbl2.Text = "Curro no me vaciles, no cuela";
                        }
                        else
                        {

                            if (Directory.Exists(directorio))
                            {
                                Debug.WriteLine(directorio);
                                string systemRoot = Environment.GetEnvironmentVariable(directorio);
                                Console.WriteLine(systemRoot);
                                directorio = systemRoot;
                                textBox1.Text = directorio;
                                lbl2.Text = "Es una variable de entorno";
                                Directory.SetCurrentDirectory(systemRoot);
                            }
                            else
                            {
                                //TODO
                                //Peta
                                //DirectoryNotFoundException: 'No se puede encontrar una parte de la ruta de acceso 'C: \Users\Cristina\Desktop\2ºDAM 17.02.24\2ºDAM 16.02.24\Servicess\2Ev\Tema 2 Servicios\bin\Debug\Windows_NT'.'
                                string rutaVariableEntorno = Environment.ExpandEnvironmentVariables("%" + directorio + "%"); //Me proporciona la ruta 
                                Console.WriteLine(rutaVariableEntorno);
                                directorio = rutaVariableEntorno;
                                textBox1.Text = directorio;
                                lbl2.Text = "No es una variable de entorno";
                                // Directory.SetCurrentDirectory(rutaVariableEntorno);
                            }

                        }






                    }

                }
                if (Directory.Exists(directorio))
                {
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
                    try
                    {
                        Directory.SetCurrentDirectory(directorio); //debe cambiar al directorio
                        DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
                        listBox1.Items.Add("..");

                        foreach (DirectoryInfo fi in d.GetDirectories())
                        {

                            listBox1.Items.Add(fi.Name);//añado los directorios
                        }

                    }
                    catch (SecurityException s)
                    {
                        lbl2.Visible = true;
                        lbl2.Text = "No tiene permisos para acceder al directorio";
                        lbl2.ForeColor = Color.Red;
                    }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa



                }
                else
                {
                    lbl2.Visible = true;
                    lbl2.Text = "La ruta no se encuentra en el sistema\nEl directorio no existe";
                    lbl2.ForeColor = Color.Red;
                }

            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl2.Visible = false;
            string index0 = "";
            //Todo: corregir la ruta en el textbox1
            listBox1.Items.Add("..");
            if (listBox1.SelectedIndex != -1)
            {


                if (listBox1.Items[listBox1.SelectedIndex].ToString() == "..")
                {
                    index0 = textBox1.Text;
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
                    try
                    {

                        directorioActual = index0.Substring(0, index0.LastIndexOf("\\")).Substring(0, index0.LastIndexOf("\\"));
                    }
                    catch (ArgumentOutOfRangeException outRan)
                    {
                        lbl2.Visible = true;
                        lbl2.Text = "La longitud no puede ser inferior a cero.\r\nNombre del parámetro: length'\r\n";
                        lbl2.ForeColor = Color.Red;
                    }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa


                }

                else
                {
                    string subd = listBox1.Items[listBox1.SelectedIndex].ToString();
                    directorioActual = textBox1.Text + "\\" + subd;

                }
                textBox1.Text = directorioActual;

                String subdirectorio = directorioActual;
                DirectoryInfo d;
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
                try
                {
                    d = new DirectoryInfo(subdirectorio + "\\");



                    if (listBox1.SelectedIndex == 0)
                    {
                        if (listBox1.Items[listBox1.SelectedIndex].ToString() == "..")
                        {
                            directorioActual = index0.Substring(0, index0.LastIndexOf("\\")).Substring(0, index0.LastIndexOf("\\"));

                        }
                        else
                        {

                            directorioActual = subdirectorio.Substring(0, subdirectorio.LastIndexOf("\\"));

                            textBox1.Text = directorioActual;
                        }

                    }
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
                    try
                    {
                        Directory.SetCurrentDirectory(directorioActual);

                        listBox1.Items.Clear();
                        listBox1.Items.Add("..");
                        listBox2.Items.Clear();

                        Console.WriteLine(directorioActual.Length);
                        foreach (DirectoryInfo directoryInfo in d.GetDirectories())
                        {

                            // directoriosRuta.Add(directoryInfo.FullName);
                            listBox1.Items.Add(directoryInfo.Name);

                        }

                        foreach (FileInfo fi in d.GetFiles())
                        {
                            listBox2.Items.Add(fi.Name);
                            directorioActual = fi.FullName;
                            Debug.WriteLine(directorioActual);
                        }
                    }
                    catch (ArgumentException argException)
                    {
                        lbl2.Visible = true;
                        lbl2.Text = "La ruta UNC debe tener el siguiente formato \\servidor\recurso compartido";
                        lbl2.ForeColor = Color.Red;


                    }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
                }
                catch (System.UnauthorizedAccessException)
                {
                    lbl2.Visible = true;
                    lbl2.Text = "No tienes permiso para acceder al directorio \n" + directorioActual;
                    lbl2.ForeColor = Color.Red;

                    //Console.WriteLine("No tienes permiso para acceder al directorio " + directorioActual);
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    lbl2.Visible = true;
                    lbl2.Text = "No es posible acceder al directorio";
                    lbl2.ForeColor = Color.Red;

                }
                catch (ArgumentException argExc)
                {
                    lbl2.Visible = true;
                    lbl2.Text = "No es válido uno de los argumentos proporcionados";
                    lbl2.ForeColor = Color.Red;
                }
                catch (IOException ioex)
                {
                    lbl2.Visible = true;
                    lbl2.Text = "Error entrada y salida de datos";
                    lbl2.ForeColor = Color.Red;
                }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            }

        }

        //última parte del Ej_1

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO con algunos archivos no funciona
            //Todavía no he comprobado que entra en GB

            try
            {

            String fichero = listBox2.Items[listBox2.SelectedIndex].ToString();
            String directorio = Directory.GetCurrentDirectory();
            fich = new FileInfo(directorio + "\\" + fichero);
            if (File.Exists(fichero))
            {
                //Ruta completa o setCurrentDirectory
                Console.WriteLine("El directorio+nombre del archivo es: " + fich);

                double kilobyte;
                int cont = 0;
                do
                {
                    if (fich.Length >= 1024)
                    {

                        kilobyte = fich.Length;
                        while (kilobyte >= 1024)
                        {
                            cont++;
                            kilobyte = kilobyte / 1024;

                        }
                        cont--;

                        Console.WriteLine("Tamaño " + fich.Length + " " + cont + " " + kilobyte);

                    }
                    else
                    {
                        //cont--;
                        kilobyte = fich.Length;
                    }
                    //cont++;
                    // guardo la variable anterior

                } while (kilobyte >= 1024);
                //cont--;
                switch (cont)
                {
                    case 0:
                            //CORRECCIÓN de formato
                            lblTamanio.Text=String.Format("%d bytes", kilobyte);
                       // lblTamanio.Text = kilobyte + " bytes";
                        // Console.WriteLine("Entro en bytes " + kilobyte);
                        break;
                    case 1:
                        lblTamanio.Text = kilobyte + " KB";
                        // Console.WriteLine("Entro en kb");
                        break;
                    case 2:
                        lblTamanio.Text = kilobyte + " MB";
                        break;
                    case 3:
                        lblTamanio.Text = kilobyte + " GB";
                        break;



                }



                if (fichero.EndsWith(".txt"))
                {
                    FormModal fm = new FormModal(this);
                    // fm.textBoxFormModal.Size = fm.Size; 
                    //Con la propiedad Dock y a multiline el text
                    fm.Text = fich.Name.Substring(0, fich.Name.LastIndexOf("."));
                    StreamReader sr;

                    using (sr = new StreamReader(fichero))
                    {
                        fm.textBoxFormModal.Text += sr.ReadToEnd();
                    }
                    //modificar el archivo
                    //sacas dialogo--T4->dialogo
                    //String fich_Modify = fm.textBoxFormModal.Text;
                    //if (fich_Modify != fichero)
                    //{

                    //        //label extensión + Size
                    //}
                    fm.ShowDialog();

                }
                //leer el fichero y escribirlo en el txtBoxFormModal





            }
            }
            catch (ArgumentOutOfRangeException clicarEnBlanco)
            {

                ;
            }

        }
    }
}
