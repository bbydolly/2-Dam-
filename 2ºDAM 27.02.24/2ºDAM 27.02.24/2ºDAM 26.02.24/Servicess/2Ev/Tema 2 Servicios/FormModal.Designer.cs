namespace Tema_2_Servicios
{
    partial class FormModal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFormModal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxFormModal
            // 
            this.textBoxFormModal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFormModal.Location = new System.Drawing.Point(0, 0);
            this.textBoxFormModal.Multiline = true;
            this.textBoxFormModal.Name = "textBoxFormModal";
            this.textBoxFormModal.Size = new System.Drawing.Size(800, 450);
            this.textBoxFormModal.TabIndex = 0;
            this.textBoxFormModal.TextChanged += new System.EventHandler(this.textBoxFormModal_TextChanged);
            // 
            // FormModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxFormModal);
            this.Name = "FormModal";
            this.Text = "FormModal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormModal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxFormModal;
    }
}