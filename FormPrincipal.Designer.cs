namespace LocoMomo
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.botonIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonIniciar
            // 
            this.botonIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonIniciar.Location = new System.Drawing.Point(294, 159);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(78, 30);
            this.botonIniciar.TabIndex = 0;
            this.botonIniciar.Text = "Iniciar";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(658, 446);
            this.ControlBox = false;
            this.Controls.Add(this.botonIniciar);
            this.Name = "FormPrincipal";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonIniciar;
    }
}

