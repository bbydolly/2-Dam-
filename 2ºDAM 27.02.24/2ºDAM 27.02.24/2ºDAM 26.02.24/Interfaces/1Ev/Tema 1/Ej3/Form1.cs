//#define RESTA
namespace Ej3
{
    public partial class Form1 : Form
    {
        int dineroBase;
        public Form1()
        {
            InitializeComponent();
            dineroBase = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int costoPartida = 2;
            int dineroPremio = 0;
            int dineroRestante = dineroBase - costoPartida;
            

            Random aleatorio1 = new Random();
            int n1 = aleatorio1.Next(1, 8);
            textBox1.Text = n1.ToString();

            
            int n2 = aleatorio1.Next(1, 8);
            textBox2.Text = n2.ToString();

           
            int n3 = aleatorio1.Next(1, 8);
            textBox3.Text = n3.ToString();

            if (n1 == n2 && n1 == n3)
            {
                label2.Text = "Hay premio de 20$";
                dineroPremio = 20;
                dineroBase = dineroRestante + dineroPremio;

            }
            else if (n1 == n2  || n1 == n3 || n2 == n3)
            {
#if RESTA
                dineroBase = dineroRestante- dineroPremio;

#else
                label2.Text = "Hay premio de 5$";
                dineroPremio = 5;
                dineroBase = dineroRestante + dineroPremio;
#endif

            }
            else
            {
                label2.Text = "Hay premio de 0$";
                dineroBase = dineroRestante;

            }
                label1.Text = "Te quedan " + dineroBase.ToString() + "$";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            int credito = 10;
            dineroBase += credito;
            label1.Text="Te quedan "+ dineroBase.ToString()+"$";
        }
    }
}