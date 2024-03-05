namespace Prueba1Componentes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelTextBox1 = new LabelTextBox.LabelTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cambiar posición";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Separación";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.Location = new System.Drawing.Point(12, 28);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Posicion = LabelTextBox.LabelTextBox.EPosicion.IZQUIERDA;
            this.labelTextBox1.Separacion = 20;
            this.labelTextBox1.Size = new System.Drawing.Size(299, 20);
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.TextLbl = "lbl";
            this.labelTextBox1.TextTxt = "";
            this.labelTextBox1.PosicionCambiada += new System.EventHandler(this.labelTextBox1_PosicionCambiada);
            this.labelTextBox1.SeparacionCambiada += new System.EventHandler(this.labelTextBox1_SeparacionCambiada);
            this.labelTextBox1.Load += new System.EventHandler(this.labelTextBox1_Load);
            this.labelTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labelTextBox1_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LabelTextBox.LabelTextBox labelTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

