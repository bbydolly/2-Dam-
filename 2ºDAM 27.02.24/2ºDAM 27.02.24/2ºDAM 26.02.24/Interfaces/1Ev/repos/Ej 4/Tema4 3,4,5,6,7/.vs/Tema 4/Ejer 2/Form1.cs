using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsT4Ejer2
{
    public partial class Form1 : Form //Icono, titulo,---check
                                      //etiquetas desciptivas---Listo
                                      //text button3---listo
                                      //orden tab---listo
                                      //cambio acceptbutton
                                      //no cambia color con tab ---listo
                                      //color negro--Listo
                                      //comprobación imagen--Listo
    {
        Color a;
        public Form1()
        {
            InitializeComponent();
            a = BackColor;
    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Mi Aplicación",
              MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
              == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        //Si hago click en cualquier textbox se cambia de toco, por qué?
        private void button2_Click(object sender, EventArgs e)
        {
            string c1 = textBox1.Text;
            string c2 = textBox2.Text;
            string c3 = textBox3.Text;
            int tx1;
            int tx2;
            int tx3;

            bool bandera = int.TryParse(c1, out tx1);
            bandera = int.TryParse(c2, out tx2);
            bandera = int.TryParse(c3, out tx3);

            if (bandera)
            {
                if ((tx1 >= 0 && tx1 <= 255) && (tx2 >= 0 && tx2 <= 255) && (tx3 >= 0 && tx3 <= 255))

                {
                    this.BackColor = Color.FromArgb(tx1, tx2, tx3);

                }
            }
        }



        private void enterCambiarColor(object sender, EventArgs e)
        {
            this.AcceptButton = textBox4.Focused ? button3 : button2; //a que botón le doy el foco?
            
            string c1 = textBox1.Text;
            string c2 = textBox2.Text;
            string c3 = textBox3.Text;
            int tx1;
            int tx2;
            int tx3;

            bool bandera = int.TryParse(c1, out tx1);
            bandera = int.TryParse(c2, out tx2);
            bandera = int.TryParse(c3, out tx3);

            if (bandera)
            {
                if ((tx1 > 0 && tx1 <= 255) && (tx2 > 0 && tx2 <= 255) && (tx3 > 0 && tx3 <= 255))

                {
                    this.BackColor = Color.FromArgb(tx1, tx2, tx3);

                }
            }
            
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
            

        }
        //TODO acept button a color y button3
        //como hacer para guardar una ruta que me pasa el usuario como recurso:,no interesa hacerlo"no se puede" 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String ruta = textBox4.Text;
                if (ruta != "")
                {
                    //pictureBox1.Image=Image.FromFile(ruta);
                    this.BackgroundImage = Image.FromFile(ruta);
                }

            }
            catch (System.OutOfMemoryException ex) //puede ser por la extensión del archivo ,por el tamaño de la imagen...
            {
                Debug.WriteLine("Memoria insuficiente");

            }
            catch (System.IO.FileNotFoundException)
            {

            }
            catch (System.ArgumentException)
            {

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = "";
                }
            }
            this.BackgroundImage = null;
            this.BackColor = default; 


        }

        private void mouseEnterCambiarColor(object sender, EventArgs e)
        {


            ((Button)sender).BackColor = Color.Yellow;
        }

        private void mouseLeaveCambiarColor(object sender, EventArgs e)
        {
            
             //((Button)sender).BackColor = Color.White;
            ((Button)sender).BackColor = a;
        }
    }
}
