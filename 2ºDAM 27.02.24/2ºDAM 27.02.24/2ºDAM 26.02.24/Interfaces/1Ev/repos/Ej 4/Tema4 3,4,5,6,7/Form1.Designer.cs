namespace Tema4_3_4_5_6_7
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
            this.nuevaimagen = new System.Windows.Forms.Button();
            this.modal = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nuevaimagen
            // 
            this.nuevaimagen.Location = new System.Drawing.Point(85, 70);
            this.nuevaimagen.Name = "nuevaimagen";
            this.nuevaimagen.Size = new System.Drawing.Size(139, 29);
            this.nuevaimagen.TabIndex = 0;
            this.nuevaimagen.Text = "Nueva imagen";
            this.nuevaimagen.UseVisualStyleBackColor = true;
            this.nuevaimagen.Click += new System.EventHandler(this.nuevaimagen_Click);
            // 
            // modal
            // 
            this.modal.AutoSize = true;
            this.modal.Location = new System.Drawing.Point(271, 77);
            this.modal.Name = "modal";
            this.modal.Size = new System.Drawing.Size(55, 17);
            this.modal.TabIndex = 1;
            this.modal.Text = "Modal";
            this.modal.UseVisualStyleBackColor = true;
            this.modal.CheckedChanged += new System.EventHandler(this.modal_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modal);
            this.Controls.Add(this.nuevaimagen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuevaimagen;
        private System.Windows.Forms.CheckBox modal;
        private System.Windows.Forms.Label label1;
    }
}

