using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Ej5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AcceptButton = button1; //añadir
        }

        private void button1_Click(object sender, EventArgs e)
        {
          String textoAñadir=textBox1.Text;

            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
                if (!listBox1.Items.Contains(textoAñadir))
                {
                    listBox1.Items.Add(textoAñadir);

                }
            //}
        }

        private void button2_Click(object sender, EventArgs e) //eliminar seleccionados
        {
            
            ListBox.SelectedIndexCollection seleccionados= listBox1.SelectedIndices;
            
           
            for (int i = 0; i < seleccionados.Count; i++)
            {
                listBox1.Items.RemoveAt(i);
            }
            

        }
    }
}
