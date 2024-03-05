using System;
using System.IO;
using System.Windows.Forms;

namespace Tema_2_Servicios
{
    public partial class FormModal : Form
    {

        private String fich;
        public Form1 form1;
        public string cadFormulario = "";

        public String Fich
        {
            set
            {
                this.fich = value;
            }
            get { return this.fich; }
        }
        private bool aux = true;
        public bool Aux
        {
            set { aux = value; }
            get { return aux; }
        }


        public FormModal(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;


        }
        public FormModal(String fich)
        {
            InitializeComponent();
            this.fich = fich;

        }

        private void FormModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //No puedo comparar estas dos cosas, el tamaño del fichero 
            Console.WriteLine("#1 " + textBoxFormModal.Text + "#");
            Console.WriteLine("#2 " + cadFormulario + " " + cadFormulario.Length + " " + textBoxFormModal.Text.Length + "#");
            if (cadFormulario.Length != textBoxFormModal.Text.Length)//comparo la primera cadena con la cadena del textBox
            {


                if (MessageBox.Show("Desea guardar los cambios efectuados en el documento?", "Documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    String nArchivo = form1.listBox2.Items[form1.listBox2.SelectedIndex].ToString();
                    String directory = form1.textBox1.Text;


                    String cadTxtFormModal = textBoxFormModal.Text;
                    Console.WriteLine(cadTxtFormModal);
                    if (fich != cadTxtFormModal)
                    {
                        using (StreamWriter sw = new StreamWriter(directory + "\\" + nArchivo))
                        {


                            // Console.WriteLine("ESTOY EN EL SWRITER" + cadTxtFormModal);
                            sw.Write(cadTxtFormModal);
                        }
                    }


                    e.Cancel = false;

                }
                else
                {
                    e.Cancel = false;
                }


            }



        }
        private void textBoxFormModal_TextChanged(object sender, EventArgs e)
        {

            if (aux)
            {
                cadFormulario = textBoxFormModal.Text; //Guardo la primera cadena
                Console.WriteLine("La cadena es " + cadFormulario);
                aux = false;

            }
            //Lineas de depuración
            //Console.WriteLine("Se produce el text change");
            //Console.WriteLine("Formulario modal " + cadFormulario);

        }
    }
}
