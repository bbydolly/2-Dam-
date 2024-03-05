using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Ej_4
{
    
    public partial class Form1 : Form
    {

    public delegate double Operation(double a, double b); //declaracón genérica de una función, es una interfaz para la función
        Dictionary<String, Operation> operations;
            int cont=0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Operaciones";
            this.Icon = Properties.Resources.curro;
            Timer timer = new Timer();
            timer.Start();
            timer.Interval = 1000;
            timer.Tick += funcionContarSegundios;




            AcceptButton = button1;
            operations = new Dictionary<String, Operation>();   
            operations.Add(radioButton1.Text, (a,b)=>a+b);
            operations.Add(radioButton2.Text, (a, b) => a - b);
            operations.Add(radioButton3.Text, (a, b) => a * b);
            operations.Add(radioButton4.Text, (a, b) => a / b);




        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            bool error=double.TryParse(textBox1.Text,out a);
            bool error2=double.TryParse(textBox2.Text, out b);

            if (error&&error2) 
            {
                label3.Text = operations[label1.Text].Invoke(a, b).ToString();
            }
           
        }

      

        private void CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = ((RadioButton)sender).Text;

        }

        private void TextChanged(object sender, EventArgs e)
        {
            Debug.Write("entro");

            if (!double.TryParse(((TextBox)sender).Text, out double j))
            {
                Debug.Write("entro");
                ((TextBox)sender).ForeColor = Color.Red;

            }
            else
            {
                ((TextBox)sender).ForeColor = default;

            }

        }

        public void funcionContarSegundios(object sender, EventArgs e) 
        {
            cont += 1;
            this.Text = $"{(cont/3600)%24:D2}:{(cont/60)%60:D2}:{cont%60:D2}";
            //horas minutos y segundos
            
        }

   
    }
}
