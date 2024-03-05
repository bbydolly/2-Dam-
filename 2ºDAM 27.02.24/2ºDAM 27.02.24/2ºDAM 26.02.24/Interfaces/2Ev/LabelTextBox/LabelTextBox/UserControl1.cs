using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace LabelTextBox
{
    
    [DefaultProperty("TextLbl"),DefaultEvent("Load")]  
    //propiedad por defecto
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
            TextLbl = Name;
            TextTxt = "";
            recolocar();
        }

        
        public enum EPosicion
        {
            IZQUIERDA, DERECHA
        }
        private EPosicion posicion = EPosicion.IZQUIERDA;
        [Category("Appearance")] //van en la misma línea
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")] //en una misma línea o da error
        public EPosicion Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(EPosicion), value))
                {
                    posicion = value;
                    recolocar();
                    //cuando se cambia la posición lanzo la función asociada al evento
                    OnPosicionCambiada(EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }
       
        //Pixeles de separación entre label y textbox
        private int separacion = 0;
        [Category("Mis Propiedades")] // O se puede meter en categoría Design.
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    recolocar();
                    //lanzo el método cuando se produce el evento:
                    //el cambio en el valor de la sepación
                    OnSeparacionCambiada(EventArgs.Empty);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }

        }
        [Category("Mis Propiedades")] // O se puede meter en categoría Appearance.
        [Description("Texto asociado a la Label del control")]
        //Es un set/get del texto de la label, pero no es necesario definir la variable como privada
        //porque ya lo hace internamente
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Mis Propiedades")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }
        private void recolocar()
        {
            switch (posicion)
            {
                case EPosicion.IZQUIERDA:
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(0, 0);
                    // Establecemos posición componente txt
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    //Establecemos ancho del Textbox
                    //(la label tiene ancho por autosize)
                    txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case EPosicion.DERECHA:
                    //Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    //Establecemos ancho del Textbox
                    txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    //Establecemos altura del componente (Puede sacarse del switch)
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }
        // Esta función has de enlazarla con el evento SizeChanged.
        // Sería necesario también tener en cuenta otros eventos como FontChanged
        // que aquí nos saltamos.
        //private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        //{
        //    recolocar();
        //}
        //RECOMENDACIÓN- sobreescribir el evento OnXX si existe, en vez de escribir el método asociado
        //porque herencia
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            recolocar();
        }

        //para enlazar los eventos visibles de nuestro nuevo control con
        //los ocultos en los controles internos txt y lbl.
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this es mi objeto ;LabelTextBox-mi clase
            //avisar de que se produce el evtno, cuando el text box detecta
            //el evento, le dije al componente que lo contiene que se ha detectado 
            //ese evento
            //provoco que en mi componente se produzca el mismo evento
            this.OnKeyPress(e);

        }


       // autosizeChange se lanza en el set de autosize que es una propiedad,
       // y el change es el evento
       //luego se enlaza con el método que quiero que se ejecute cuando mi PROPIEDAD
       //sea modificada





        //las propiedades se ponen antes de lo que quiero que afecte
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event System.EventHandler PosicionCambiada;

       
        //evento es una variable que apunta a una función
        //accion que ejecuta metodos += añado a la colección fnciones a ejecutarse cuando 
        //pase el evento (un Click por ejemplo)
        //click variable, + evento 

        //desde esta funcion que creo voy a lanzar el evento
        protected virtual void OnPosicionCambiada(EventArgs e)
        {
        //    if(PosicionCambiada != null) {
        //        PosicionCambiada(this, e); //lanzo el evento
        //    }

            PosicionCambiada?.Invoke(this, e); //Invoke lanza el evento
            //? comprueba si no es null el objeto
            //.   accede al metodo/propiedad del objeto 
           


        }


        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Separacion cambia")]
        //creo el evento
        public event System.EventHandler SeparacionCambiada;

        //creo el método asociado al evento
        protected virtual void OnSeparacionCambiada(EventArgs e)
        {
            SeparacionCambiada?.Invoke(this, e);
            
          
        }
//        c) Haz que el evento KeyUp del LabelTextbox sea lanzado cuando suceda un
//evento KeyUp de txt.Haz prueba de funcionamiento.

        //Entra en esta función cuando la tecla en el txt se libera
        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            //this es mi LabelTextBox

            //Por tanto ejecuta la función tecla liberada del LabelTextBox
            // e es la información
            this.OnKeyUp(e);

        }
    }
}
