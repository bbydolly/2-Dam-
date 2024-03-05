using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteModoGrafico
{
    public partial class FormPuertoIP : Form
    {
        public FormPuertoIP()
        {
            InitializeComponent();
        }
        public FormPuertoIP(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
        private Form1 form1;

        public Form1 Form1
        {
            get { return form1; }
            set
            {
                form1 = value;
            }
        }


        private void FormPuertoIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = false;
            string ipCorrecta = "";
            String ip = "";


            if (MessageBox.Show("¿Quiere guardar los datos?", "Configuración IP/puerto",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true; //Se cancela el cierre del formulario
            }
            else
            {
                ip = textBox1.Text;

                try
                {
                    if (IPAddress.Parse(ip) != null)
                    {
                        Console.WriteLine("ip correcta: " + ip);
                        form1.IP_server = ip;


                    }
                    String puerto = textBox2.Text;
                    int puertoCorrecto;
                    if (Convert.ToInt16(puerto) > IPEndPoint.MinPort && Convert.ToInt16(puerto) < IPEndPoint.MaxPort)//RANGO DE PUERTO MAX Y MIN
                    {
                        puertoCorrecto = Convert.ToInt16(puerto);
                        form1.Puerto = puertoCorrecto;
                        Console.WriteLine("puerto "+puertoCorrecto);
                    }

                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                   

                }



            }


        }

    }
}
//Este código funciona->Comprobación de rango de la ipo
// String[] secciones_ip = ip.Split('.');//sepaaro por puntos

//for (int i = 0; i < secciones_ip.Length; i++)
//{
//if (secciones_ip.Length == 3)//4 grupos
//{


//    if (Convert.ToInt16(secciones_ip[i]) >= 0 && Convert.ToInt16(secciones_ip[i]) <= 255)//TODO IPAddress.Parse(IP_SERVER)
//    {
//        flag = true;


//    }
//    else
//    {
//        flag = false;
//        break;

//    }

//}


