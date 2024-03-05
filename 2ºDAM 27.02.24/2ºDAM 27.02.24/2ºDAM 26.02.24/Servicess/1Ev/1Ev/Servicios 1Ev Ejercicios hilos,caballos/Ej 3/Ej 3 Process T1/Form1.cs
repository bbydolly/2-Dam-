using System.Diagnostics;

namespace Ej_3_Process_T1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses(); //Devuelve un array de object process
            const string FORMAT = "{0,20}{1,7}{2,20}";
            textBox1.Text += string.Format(FORMAT, "PID", "Name", "Title"); //formateo con string format
            foreach (Process p in processes)
            {
                textBox1.Text += String.Format(FORMAT, p.ProcessName, p.Id, this.Name);
            }
        }
    }
}