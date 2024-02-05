
namespace SimuladorBacterias
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnNuevaSimulacion = new System.Windows.Forms.Button();
            this.imgMicroscopio = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgMicroscopio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevaSimulacion
            // 
            this.btnNuevaSimulacion.BackColor = System.Drawing.SystemColors.Window;
            this.btnNuevaSimulacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaSimulacion.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaSimulacion.Location = new System.Drawing.Point(1114, 481);
            this.btnNuevaSimulacion.Name = "btnNuevaSimulacion";
            this.btnNuevaSimulacion.Size = new System.Drawing.Size(364, 151);
            this.btnNuevaSimulacion.TabIndex = 0;
            this.btnNuevaSimulacion.Text = "Nueva Simulacion";
            this.btnNuevaSimulacion.UseVisualStyleBackColor = false;
            this.btnNuevaSimulacion.Click += new System.EventHandler(this.btnNuevaSimulacion_Click);
            // 
            // imgMicroscopio
            // 
            this.imgMicroscopio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.imgMicroscopio.Image = ((System.Drawing.Image)(resources.GetObject("imgMicroscopio.Image")));
            this.imgMicroscopio.Location = new System.Drawing.Point(12, -48);
            this.imgMicroscopio.Name = "imgMicroscopio";
            this.imgMicroscopio.Size = new System.Drawing.Size(682, 1135);
            this.imgMicroscopio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgMicroscopio.TabIndex = 1;
            this.imgMicroscopio.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Window;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1114, 778);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(364, 151);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.SystemColors.Control;
            this.Titulo.Location = new System.Drawing.Point(837, 180);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(965, 112);
            this.Titulo.TabIndex = 3;
            this.Titulo.Text = "Simulador Bacterias";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.imgMicroscopio);
            this.Controls.Add(this.btnNuevaSimulacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "SIMULADOR BACTERIAS";
            ((System.ComponentModel.ISupportInitialize)(this.imgMicroscopio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaSimulacion;
        private System.Windows.Forms.PictureBox imgMicroscopio;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label Titulo;
    }
}