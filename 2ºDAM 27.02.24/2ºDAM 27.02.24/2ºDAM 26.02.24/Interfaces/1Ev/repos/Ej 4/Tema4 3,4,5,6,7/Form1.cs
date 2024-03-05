using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tema4_3_4_5_6_7.Properties;

namespace Tema4_3_4_5_6_7
{
    //Ejercicio 3, Tema 4
    public partial class Form1 : Form  //título, icono (princ y sec),--check
                                       //fallo al cancelar--check
                                       //invertir modal---check
                                       //comprobación imagen válida--check creo
                                       //label para informar de los errores/oculta/visible
    {
       
        public Form1()
        {
            InitializeComponent();
            this.Text = "Formulario";
            this.Icon = Resources.curro; //Según la estructura de recursos
        }

        private void nuevaimagen_Click(object sender, EventArgs e) ///crea OpenFileDialog
        {
            string filePath = "";
            
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.InitialDirectory = "c:\\";
            dialogo.Filter = "png |*.png|jpg|*.jpg|All files|*.*";
            dialogo.FilterIndex = 0;
            dialogo.RestoreDirectory = true;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                filePath = dialogo.FileName;

            }
            this.Text = "Visor de imágenes";
            Form2 f2 = new Form2();
            try
            {
                f2.pictureBox1.Image = Image.FromFile(filePath);

                //String tittle=filePath.Substring(filePath.LastIndexOf('\\')); //cle sumo la barra
                f2.Text = dialogo.SafeFileName; //Try-catch con la ruta?
                f2.Icon = Resources.curro;

                if (this.modal.Checked == true)
                {

                    f2.ShowDialog(); //modificadores a publico, change propierties
                    this.label1.Visible= false;

                }
                else
                {
                    f2.Show();
                    this.label1.Visible = false;


                }
            }
            catch (System.ArgumentException)
            {
                this.label1.Visible = true;
                this.label1.Text = "El archivo no es válido";
                this.label1.ForeColor = Color.Red;
            }
            catch (System.OutOfMemoryException)
            {
                this.label1.Visible = true;
                this.label1.Text = "El archivo es demasiado grande";
                this.label1.ForeColor = Color.Red;
            }
            catch(System.StackOverflowException) 
            { 

            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Está seguro de que desea cerrar la aplicación", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }




        }

        private void modal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.modal.Checked) //true
            {
                this.modal.ForeColor = Color.Red;

            }
            else
            {
                this.modal.ForeColor = Color.Black;

            }
        }
    }
}
