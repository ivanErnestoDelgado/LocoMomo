namespace LocoMomo
{
    partial class formRegistro
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
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.botonEscoger = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduce tu nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(29, 46);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(217, 20);
            this.textNombre.TabIndex = 1;
            // 
            // botonEscoger
            // 
            this.botonEscoger.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEscoger.Location = new System.Drawing.Point(87, 72);
            this.botonEscoger.Name = "botonEscoger";
            this.botonEscoger.Size = new System.Drawing.Size(93, 42);
            this.botonEscoger.TabIndex = 2;
            this.botonEscoger.Text = "Escoger";
            this.botonEscoger.UseVisualStyleBackColor = true;
            this.botonEscoger.Click += new System.EventHandler(this.botonEscoger_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(150, 144);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(81, 32);
            this.botonVolver.TabIndex = 3;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // formRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 197);
            this.ControlBox = false;
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonEscoger);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label1);
            this.Name = "formRegistro";
            this.Text = "Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button botonEscoger;
        private System.Windows.Forms.Button botonVolver;
    }
}