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
            this.botonSalir = new System.Windows.Forms.Button();
            this.imgRecords = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgInstrucciones = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInstrucciones)).BeginInit();
            this.SuspendLayout();
            // 
            // botonIniciar
            // 
            this.botonIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonIniciar.Location = new System.Drawing.Point(295, 161);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(78, 30);
            this.botonIniciar.TabIndex = 0;
            this.botonIniciar.Text = "Iniciar";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSalir.Location = new System.Drawing.Point(295, 197);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(78, 28);
            this.botonSalir.TabIndex = 1;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // imgRecords
            // 
            this.imgRecords.BackColor = System.Drawing.Color.Transparent;
            this.imgRecords.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgRecords.BackgroundImage")));
            this.imgRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgRecords.Location = new System.Drawing.Point(499, 290);
            this.imgRecords.Name = "imgRecords";
            this.imgRecords.Size = new System.Drawing.Size(84, 61);
            this.imgRecords.TabIndex = 2;
            this.imgRecords.TabStop = false;
            this.imgRecords.Click += new System.EventHandler(this.imgRecords_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(480, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Puntajes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(23, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Instrucciones";
            // 
            // imgInstrucciones
            // 
            this.imgInstrucciones.BackColor = System.Drawing.Color.Transparent;
            this.imgInstrucciones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgInstrucciones.BackgroundImage")));
            this.imgInstrucciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgInstrucciones.Location = new System.Drawing.Point(78, 290);
            this.imgInstrucciones.Name = "imgInstrucciones";
            this.imgInstrucciones.Size = new System.Drawing.Size(62, 47);
            this.imgInstrucciones.TabIndex = 5;
            this.imgInstrucciones.TabStop = false;
            this.imgInstrucciones.Click += new System.EventHandler(this.imgInstrucciones_Click);
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
            this.Controls.Add(this.imgInstrucciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgRecords);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.botonIniciar);
            this.Name = "FormPrincipal";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInstrucciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.PictureBox imgRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox imgInstrucciones;
    }
}

