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

namespace Prueba1Componentes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(labelTextBox1.TextTxt);//es mi get del txt
        }

        private void labelTextBox1_Load(object sender, EventArgs e)
        {

        }
        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = "Letra: " + e.KeyChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(labelTextBox1.Posicion == LabelTextBox.LabelTextBox.EPosicion.IZQUIERDA)
            {
                labelTextBox1.Posicion = LabelTextBox.LabelTextBox.EPosicion.DERECHA;
                this.Text = "Derecha";
            }
            else
            {
                labelTextBox1.Posicion = LabelTextBox.LabelTextBox.EPosicion.IZQUIERDA;
                this.Text = "Izquierda";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(labelTextBox1.Posicion == LabelTextBox.LabelTextBox.EPosicion.IZQUIERDA)
            {

            labelTextBox1.Separacion += 5;
              
            }
            else
            {
                labelTextBox1.Separacion -= 5;

            }
        }

        private void labelTextBox1_PosicionCambiada(object sender, EventArgs e)
        {
            //los mensajes
            //QUIERO VER QUE SE EJECUTE 
            Debug.WriteLine("Posición cambiada");
        }

        private void labelTextBox1_SeparacionCambiada(object sender, EventArgs e)
        {
            Debug.WriteLine("Separación cambiada");

        }
    }
}
