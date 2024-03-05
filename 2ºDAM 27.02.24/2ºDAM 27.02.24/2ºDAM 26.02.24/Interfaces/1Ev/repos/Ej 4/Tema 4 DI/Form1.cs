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

namespace Tema_4_DI
{
    public partial class MouseTester : Form
    {
        public MouseTester()
        {
            InitializeComponent();
        }

        private void MouseTester_MouseEnter(object sender, EventArgs e)
        {
           //Point pos=new Point(Container.Location.X, this.Location.Y);
           // Container.
           // this.Text = pos.ToString();
             
        }

        private void MouseTester_Load(object sender, EventArgs e)
        {

        }

        private void MouseTester_MouseLeave(object sender, EventArgs e)
        {

        }

        private void MouseTester_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.X.ToString()) ; //cojo la posición del ratón 
        }
    }
}
