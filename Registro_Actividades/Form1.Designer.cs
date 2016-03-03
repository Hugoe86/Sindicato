namespace Registro_Actividades
{
    partial class Frm_Registros
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Registros));
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Mnt_Cal_Fecha = new System.Windows.Forms.MonthCalendar();
            this.Grp_Actividad = new System.Windows.Forms.GroupBox();
            this.Lbl_Fecha_Seleccionada = new System.Windows.Forms.Label();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Txt_Actividades = new System.Windows.Forms.RichTextBox();
            this.Lbl_Actividad = new System.Windows.Forms.Label();
            this.Btn_Agregar_Imagen = new System.Windows.Forms.Button();
            this.Btn_Quitar = new System.Windows.Forms.Button();
            this.Btn_Agregar = new System.Windows.Forms.GroupBox();
            this.Grp_Reporte = new System.Windows.Forms.GroupBox();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Dtp_Fecha_Fin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Inicio = new System.Windows.Forms.DateTimePicker();
            this.Pct_Box_Foto = new System.Windows.Forms.PictureBox();
            this.Grid_Fotos = new System.Windows.Forms.DataGridView();
            this.No_Media = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pct_Box_Empresa = new System.Windows.Forms.PictureBox();
            this.Pct_Box_Sindicato = new System.Windows.Forms.PictureBox();
            this.Grp_Actividad.SuspendLayout();
            this.Btn_Agregar.SuspendLayout();
            this.Grp_Reporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Box_Foto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Fotos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Box_Empresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Box_Sindicato)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(6, 25);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(37, 13);
            this.Lbl_Fecha.TabIndex = 1;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Mnt_Cal_Fecha
            // 
            this.Mnt_Cal_Fecha.Location = new System.Drawing.Point(77, 25);
            this.Mnt_Cal_Fecha.Name = "Mnt_Cal_Fecha";
            this.Mnt_Cal_Fecha.TabIndex = 2;
            this.Mnt_Cal_Fecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Mnt_Cal_Fecha_DateChanged);
            // 
            // Grp_Actividad
            // 
            this.Grp_Actividad.Controls.Add(this.Lbl_Fecha_Seleccionada);
            this.Grp_Actividad.Controls.Add(this.Btn_Modificar);
            this.Grp_Actividad.Controls.Add(this.Txt_Actividades);
            this.Grp_Actividad.Controls.Add(this.Lbl_Actividad);
            this.Grp_Actividad.Controls.Add(this.Lbl_Fecha);
            this.Grp_Actividad.Controls.Add(this.Mnt_Cal_Fecha);
            this.Grp_Actividad.Location = new System.Drawing.Point(12, 114);
            this.Grp_Actividad.Name = "Grp_Actividad";
            this.Grp_Actividad.Size = new System.Drawing.Size(446, 548);
            this.Grp_Actividad.TabIndex = 3;
            this.Grp_Actividad.TabStop = false;
            this.Grp_Actividad.Text = "Actividad";
            // 
            // Lbl_Fecha_Seleccionada
            // 
            this.Lbl_Fecha_Seleccionada.AutoSize = true;
            this.Lbl_Fecha_Seleccionada.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Fecha_Seleccionada.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Fecha_Seleccionada.Location = new System.Drawing.Point(74, 200);
            this.Lbl_Fecha_Seleccionada.Name = "Lbl_Fecha_Seleccionada";
            this.Lbl_Fecha_Seleccionada.Size = new System.Drawing.Size(0, 16);
            this.Lbl_Fecha_Seleccionada.TabIndex = 5;
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modificar.Image")));
            this.Btn_Modificar.Location = new System.Drawing.Point(339, 131);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(52, 56);
            this.Btn_Modificar.TabIndex = 2;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Txt_Actividades
            // 
            this.Txt_Actividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Actividades.Location = new System.Drawing.Point(74, 228);
            this.Txt_Actividades.Name = "Txt_Actividades";
            this.Txt_Actividades.Size = new System.Drawing.Size(366, 314);
            this.Txt_Actividades.TabIndex = 4;
            this.Txt_Actividades.Text = "";
            // 
            // Lbl_Actividad
            // 
            this.Lbl_Actividad.AutoSize = true;
            this.Lbl_Actividad.Location = new System.Drawing.Point(6, 228);
            this.Lbl_Actividad.Name = "Lbl_Actividad";
            this.Lbl_Actividad.Size = new System.Drawing.Size(62, 13);
            this.Lbl_Actividad.TabIndex = 3;
            this.Lbl_Actividad.Text = "Actividades";
            // 
            // Btn_Agregar_Imagen
            // 
            this.Btn_Agregar_Imagen.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Agregar_Imagen.Image")));
            this.Btn_Agregar_Imagen.Location = new System.Drawing.Point(0, 25);
            this.Btn_Agregar_Imagen.Name = "Btn_Agregar_Imagen";
            this.Btn_Agregar_Imagen.Size = new System.Drawing.Size(41, 39);
            this.Btn_Agregar_Imagen.TabIndex = 1;
            this.Btn_Agregar_Imagen.UseVisualStyleBackColor = true;
            this.Btn_Agregar_Imagen.Click += new System.EventHandler(this.Btn_Agregar_Imagen_Click);
            // 
            // Btn_Quitar
            // 
            this.Btn_Quitar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Quitar.Image")));
            this.Btn_Quitar.Location = new System.Drawing.Point(0, 70);
            this.Btn_Quitar.Name = "Btn_Quitar";
            this.Btn_Quitar.Size = new System.Drawing.Size(41, 40);
            this.Btn_Quitar.TabIndex = 2;
            this.Btn_Quitar.UseVisualStyleBackColor = true;
            this.Btn_Quitar.Click += new System.EventHandler(this.Btn_Quitar_Click);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Controls.Add(this.Grp_Reporte);
            this.Btn_Agregar.Controls.Add(this.Pct_Box_Foto);
            this.Btn_Agregar.Controls.Add(this.Grid_Fotos);
            this.Btn_Agregar.Controls.Add(this.Btn_Quitar);
            this.Btn_Agregar.Controls.Add(this.Btn_Agregar_Imagen);
            this.Btn_Agregar.Location = new System.Drawing.Point(476, 12);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(672, 650);
            this.Btn_Agregar.TabIndex = 4;
            this.Btn_Agregar.TabStop = false;
            this.Btn_Agregar.Text = "Fotos";
            // 
            // Grp_Reporte
            // 
            this.Grp_Reporte.Controls.Add(this.Btn_Reporte);
            this.Grp_Reporte.Controls.Add(this.Dtp_Fecha_Fin);
            this.Grp_Reporte.Controls.Add(this.label1);
            this.Grp_Reporte.Controls.Add(this.Dtp_Fecha_Inicio);
            this.Grp_Reporte.Location = new System.Drawing.Point(437, 19);
            this.Grp_Reporte.Name = "Grp_Reporte";
            this.Grp_Reporte.Size = new System.Drawing.Size(218, 136);
            this.Grp_Reporte.TabIndex = 6;
            this.Grp_Reporte.TabStop = false;
            this.Grp_Reporte.Text = "Reporte";
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Reporte.Image")));
            this.Btn_Reporte.Location = new System.Drawing.Point(90, 90);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(41, 40);
            this.Btn_Reporte.TabIndex = 5;
            this.Btn_Reporte.UseVisualStyleBackColor = true;
            this.Btn_Reporte.Click += new System.EventHandler(this.Btn_Reporte_Click);
            // 
            // Dtp_Fecha_Fin
            // 
            this.Dtp_Fecha_Fin.Location = new System.Drawing.Point(1, 64);
            this.Dtp_Fecha_Fin.Name = "Dtp_Fecha_Fin";
            this.Dtp_Fecha_Fin.Size = new System.Drawing.Size(211, 20);
            this.Dtp_Fecha_Fin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A";
            // 
            // Dtp_Fecha_Inicio
            // 
            this.Dtp_Fecha_Inicio.Location = new System.Drawing.Point(1, 21);
            this.Dtp_Fecha_Inicio.Name = "Dtp_Fecha_Inicio";
            this.Dtp_Fecha_Inicio.Size = new System.Drawing.Size(211, 20);
            this.Dtp_Fecha_Inicio.TabIndex = 0;
            // 
            // Pct_Box_Foto
            // 
            this.Pct_Box_Foto.Location = new System.Drawing.Point(7, 196);
            this.Pct_Box_Foto.Name = "Pct_Box_Foto";
            this.Pct_Box_Foto.Size = new System.Drawing.Size(659, 448);
            this.Pct_Box_Foto.TabIndex = 4;
            this.Pct_Box_Foto.TabStop = false;
            // 
            // Grid_Fotos
            // 
            this.Grid_Fotos.AllowUserToAddRows = false;
            this.Grid_Fotos.AllowUserToDeleteRows = false;
            this.Grid_Fotos.AllowUserToResizeRows = false;
            this.Grid_Fotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Fotos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No_Media,
            this.Fecha,
            this.imagen});
            this.Grid_Fotos.Location = new System.Drawing.Point(47, 19);
            this.Grid_Fotos.Name = "Grid_Fotos";
            this.Grid_Fotos.Size = new System.Drawing.Size(374, 150);
            this.Grid_Fotos.TabIndex = 3;
            this.Grid_Fotos.SelectionChanged += new System.EventHandler(this.Grid_Fotos_SelectionChanged);
            // 
            // No_Media
            // 
            this.No_Media.DataPropertyName = "No_Media";
            this.No_Media.HeaderText = "No_Media";
            this.No_Media.Name = "No_Media";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // imagen
            // 
            this.imagen.DataPropertyName = "imagen";
            this.imagen.HeaderText = "imagen";
            this.imagen.Name = "imagen";
            // 
            // Pct_Box_Empresa
            // 
            this.Pct_Box_Empresa.Location = new System.Drawing.Point(21, 12);
            this.Pct_Box_Empresa.Name = "Pct_Box_Empresa";
            this.Pct_Box_Empresa.Size = new System.Drawing.Size(160, 95);
            this.Pct_Box_Empresa.TabIndex = 5;
            this.Pct_Box_Empresa.TabStop = false;
            // 
            // Pct_Box_Sindicato
            // 
            this.Pct_Box_Sindicato.Location = new System.Drawing.Point(292, 12);
            this.Pct_Box_Sindicato.Name = "Pct_Box_Sindicato";
            this.Pct_Box_Sindicato.Size = new System.Drawing.Size(160, 95);
            this.Pct_Box_Sindicato.TabIndex = 6;
            this.Pct_Box_Sindicato.TabStop = false;
            // 
            // Frm_Registros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 669);
            this.Controls.Add(this.Pct_Box_Sindicato);
            this.Controls.Add(this.Pct_Box_Empresa);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.Grp_Actividad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Registros";
            this.Text = "Registro de actividades";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Grp_Actividad.ResumeLayout(false);
            this.Grp_Actividad.PerformLayout();
            this.Btn_Agregar.ResumeLayout(false);
            this.Grp_Reporte.ResumeLayout(false);
            this.Grp_Reporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Box_Foto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Fotos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Box_Empresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Box_Sindicato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.MonthCalendar Mnt_Cal_Fecha;
        private System.Windows.Forms.GroupBox Grp_Actividad;
        private System.Windows.Forms.RichTextBox Txt_Actividades;
        private System.Windows.Forms.Label Lbl_Actividad;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Agregar_Imagen;
        private System.Windows.Forms.Button Btn_Quitar;
        private System.Windows.Forms.GroupBox Btn_Agregar;
        private System.Windows.Forms.PictureBox Pct_Box_Empresa;
        private System.Windows.Forms.PictureBox Pct_Box_Sindicato;
        private System.Windows.Forms.DataGridView Grid_Fotos;
        private System.Windows.Forms.PictureBox Pct_Box_Foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Media;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagen;
        private System.Windows.Forms.Label Lbl_Fecha_Seleccionada;
        private System.Windows.Forms.GroupBox Grp_Reporte;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Fin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio;
        private System.Windows.Forms.Button Btn_Reporte;
    }
}

