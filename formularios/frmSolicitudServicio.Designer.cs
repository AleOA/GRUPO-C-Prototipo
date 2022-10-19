namespace Test_WinForms.formularios
{
    partial class frmSolicitudServicio
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
            this.cmbTipoEnvio = new System.Windows.Forms.ComboBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.lblSolicitarEnvio = new System.Windows.Forms.Label();
            this.lblCancelarEnvio = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblPisoDepto = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.btnCargarSolicitud = new System.Windows.Forms.Button();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblModalidad = new System.Windows.Forms.Label();
            this.cmbPuertaSucursal = new System.Windows.Forms.ComboBox();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.cmbCorrespEncom = new System.Windows.Forms.ComboBox();
            this.lblIngresarNumSolicitud = new System.Windows.Forms.Label();
            this.btnCancelarEnvio = new System.Windows.Forms.Button();
            this.lstSolicitudesCancelar = new System.Windows.Forms.ListBox();
            this.lblCiudadOrigen = new System.Windows.Forms.Label();
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Envío";
            // 
            // cmbTipoEnvio
            // 
            this.cmbTipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEnvio.FormattingEnabled = true;
            this.cmbTipoEnvio.Items.AddRange(new object[] {
            "Nacional"});
            this.cmbTipoEnvio.Location = new System.Drawing.Point(177, 45);
            this.cmbTipoEnvio.Name = "cmbTipoEnvio";
            this.cmbTipoEnvio.Size = new System.Drawing.Size(150, 28);
            this.cmbTipoEnvio.TabIndex = 1;
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(30, 131);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(132, 20);
            this.lblCiudad.TabIndex = 2;
            this.lblCiudad.Text = "Ciudad de Destino";
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(177, 128);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(150, 28);
            this.cmbCiudadDestino.TabIndex = 3;
            this.cmbCiudadDestino.SelectedIndexChanged += new System.EventHandler(this.cmbCiudadDestino_SelectedIndexChanged);
            // 
            // lblSolicitarEnvio
            // 
            this.lblSolicitarEnvio.AutoSize = true;
            this.lblSolicitarEnvio.Location = new System.Drawing.Point(161, 9);
            this.lblSolicitarEnvio.Name = "lblSolicitarEnvio";
            this.lblSolicitarEnvio.Size = new System.Drawing.Size(150, 20);
            this.lblSolicitarEnvio.TabIndex = 4;
            this.lblSolicitarEnvio.Text = "Solicitar Nuevo Envío";
            // 
            // lblCancelarEnvio
            // 
            this.lblCancelarEnvio.AutoSize = true;
            this.lblCancelarEnvio.Location = new System.Drawing.Point(685, 9);
            this.lblCancelarEnvio.Name = "lblCancelarEnvio";
            this.lblCancelarEnvio.Size = new System.Drawing.Size(106, 20);
            this.lblCancelarEnvio.TabIndex = 5;
            this.lblCancelarEnvio.Text = "Cancelar Envío";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(58, 168);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(72, 20);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(192, 168);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(63, 20);
            this.lblNumero.TabIndex = 7;
            this.lblNumero.Text = "Número";
            // 
            // lblPisoDepto
            // 
            this.lblPisoDepto.AutoSize = true;
            this.lblPisoDepto.Location = new System.Drawing.Point(304, 168);
            this.lblPisoDepto.Name = "lblPisoDepto";
            this.lblPisoDepto.Size = new System.Drawing.Size(84, 20);
            this.lblPisoDepto.TabIndex = 8;
            this.lblPisoDepto.Text = "Piso/Depto";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(405, 168);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(101, 20);
            this.lblCodigoPostal.TabIndex = 9;
            this.lblCodigoPostal.Text = "Código Postal";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(29, 191);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PlaceholderText = "Ingrese Dirección";
            this.txtDireccion.Size = new System.Drawing.Size(132, 27);
            this.txtDireccion.TabIndex = 10;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(177, 191);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PlaceholderText = "Ingrese Número";
            this.txtNumero.Size = new System.Drawing.Size(98, 27);
            this.txtNumero.TabIndex = 11;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(292, 191);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.PlaceholderText = "Ingrese Piso/Depto";
            this.txtPiso.Size = new System.Drawing.Size(96, 27);
            this.txtPiso.TabIndex = 12;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(405, 191);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.PlaceholderText = "Ingrese Código Postal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(99, 27);
            this.txtCodigoPostal.TabIndex = 13;
            // 
            // btnCargarSolicitud
            // 
            this.btnCargarSolicitud.Location = new System.Drawing.Point(161, 446);
            this.btnCargarSolicitud.Name = "btnCargarSolicitud";
            this.btnCargarSolicitud.Size = new System.Drawing.Size(180, 54);
            this.btnCargarSolicitud.TabIndex = 14;
            this.btnCargarSolicitud.Text = "Cargar Solicitud";
            this.btnCargarSolicitud.UseVisualStyleBackColor = true;
            this.btnCargarSolicitud.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(29, 289);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(71, 20);
            this.lblPeso.TabIndex = 15;
            this.lblPeso.Text = "Peso (KG)";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Location = new System.Drawing.Point(30, 340);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(70, 20);
            this.lblPrioridad.TabIndex = 16;
            this.lblPrioridad.Text = "Prioridad";
            // 
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Location = new System.Drawing.Point(30, 389);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(82, 20);
            this.lblModalidad.TabIndex = 17;
            this.lblModalidad.Text = "Modalidad";
            // 
            // cmbPuertaSucursal
            // 
            this.cmbPuertaSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuertaSucursal.FormattingEnabled = true;
            this.cmbPuertaSucursal.Items.AddRange(new object[] {
            "Puerta",
            "Sucursal"});
            this.cmbPuertaSucursal.Location = new System.Drawing.Point(177, 389);
            this.cmbPuertaSucursal.Name = "cmbPuertaSucursal";
            this.cmbPuertaSucursal.Size = new System.Drawing.Size(150, 28);
            this.cmbPuertaSucursal.TabIndex = 18;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Items.AddRange(new object[] {
            "No Urgente",
            "Urgente"});
            this.cmbPrioridad.Location = new System.Drawing.Point(177, 337);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(150, 28);
            this.cmbPrioridad.TabIndex = 19;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(177, 286);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.PlaceholderText = "Ingrese Peso (KG)";
            this.txtPeso.Size = new System.Drawing.Size(150, 27);
            this.txtPeso.TabIndex = 20;
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(30, 240);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(124, 20);
            this.lblTipoProducto.TabIndex = 21;
            this.lblTipoProducto.Text = "Tipo de Producto";
            // 
            // cmbCorrespEncom
            // 
            this.cmbCorrespEncom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCorrespEncom.FormattingEnabled = true;
            this.cmbCorrespEncom.Items.AddRange(new object[] {
            "Correspondencia",
            "Encomienda"});
            this.cmbCorrespEncom.Location = new System.Drawing.Point(177, 237);
            this.cmbCorrespEncom.Name = "cmbCorrespEncom";
            this.cmbCorrespEncom.Size = new System.Drawing.Size(150, 28);
            this.cmbCorrespEncom.TabIndex = 22;
            // 
            // lblIngresarNumSolicitud
            // 
            this.lblIngresarNumSolicitud.AutoSize = true;
            this.lblIngresarNumSolicitud.Location = new System.Drawing.Point(632, 59);
            this.lblIngresarNumSolicitud.Name = "lblIngresarNumSolicitud";
            this.lblIngresarNumSolicitud.Size = new System.Drawing.Size(226, 20);
            this.lblIngresarNumSolicitud.TabIndex = 23;
            this.lblIngresarNumSolicitud.Text = "Seleccionar Número de Solicitud";
            // 
            // btnCancelarEnvio
            // 
            this.btnCancelarEnvio.Location = new System.Drawing.Point(657, 212);
            this.btnCancelarEnvio.Name = "btnCancelarEnvio";
            this.btnCancelarEnvio.Size = new System.Drawing.Size(152, 29);
            this.btnCancelarEnvio.TabIndex = 24;
            this.btnCancelarEnvio.Text = "Cancelar Envío";
            this.btnCancelarEnvio.UseVisualStyleBackColor = true;
            this.btnCancelarEnvio.Click += new System.EventHandler(this.btnCancelarEnvio_Click);
            // 
            // lstSolicitudesCancelar
            // 
            this.lstSolicitudesCancelar.FormattingEnabled = true;
            this.lstSolicitudesCancelar.ItemHeight = 20;
            this.lstSolicitudesCancelar.Location = new System.Drawing.Point(659, 82);
            this.lstSolicitudesCancelar.Name = "lstSolicitudesCancelar";
            this.lstSolicitudesCancelar.Size = new System.Drawing.Size(150, 124);
            this.lstSolicitudesCancelar.TabIndex = 25;
            // 
            // lblCiudadOrigen
            // 
            this.lblCiudadOrigen.AutoSize = true;
            this.lblCiudadOrigen.Location = new System.Drawing.Point(29, 91);
            this.lblCiudadOrigen.Name = "lblCiudadOrigen";
            this.lblCiudadOrigen.Size = new System.Drawing.Size(126, 20);
            this.lblCiudadOrigen.TabIndex = 26;
            this.lblCiudadOrigen.Text = "Ciudad de Origen";
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(177, 88);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(150, 28);
            this.cmbCiudadOrigen.TabIndex = 27;
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Location = new System.Drawing.Point(343, 131);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(13, 20);
            this.lblTarifa.TabIndex = 28;
            this.lblTarifa.Text = " ";
            // 
            // frmSolicitudServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 560);
            this.Controls.Add(this.lblTarifa);
            this.Controls.Add(this.cmbCiudadOrigen);
            this.Controls.Add(this.lblCiudadOrigen);
            this.Controls.Add(this.lstSolicitudesCancelar);
            this.Controls.Add(this.btnCancelarEnvio);
            this.Controls.Add(this.lblIngresarNumSolicitud);
            this.Controls.Add(this.cmbCorrespEncom);
            this.Controls.Add(this.lblTipoProducto);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.cmbPuertaSucursal);
            this.Controls.Add(this.lblModalidad);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.btnCargarSolicitud);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblCodigoPostal);
            this.Controls.Add(this.lblPisoDepto);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblCancelarEnvio);
            this.Controls.Add(this.lblSolicitarEnvio);
            this.Controls.Add(this.cmbCiudadDestino);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.cmbTipoEnvio);
            this.Controls.Add(this.label1);
            this.Name = "frmSolicitudServicio";
            this.Text = "Solicitud de Envio";
            this.Load += new System.EventHandler(this.frmSolicitudServicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbTipoEnvio;
        private Label lblCiudad;
        private ComboBox cmbCiudadDestino;
        private Label lblSolicitarEnvio;
        private Label lblCancelarEnvio;
        private Label lblDireccion;
        private Label lblNumero;
        private Label lblPisoDepto;
        private Label lblCodigoPostal;
        private TextBox txtDireccion;
        private TextBox txtNumero;
        private TextBox txtPiso;
        private TextBox txtCodigoPostal;
        private Button btnCargarSolicitud;
        private Label lblPeso;
        private Label lblPrioridad;
        private Label lblModalidad;
        private ComboBox cmbPuertaSucursal;
        private ComboBox cmbPrioridad;
        private TextBox txtPeso;
        private Label lblTipoProducto;
        private ComboBox cmbCorrespEncom;
        private Label lblIngresarNumSolicitud;
        private Button btnCancelarEnvio;
        private ListBox lstSolicitudesCancelar;
        private Label lblCiudadOrigen;
        private ComboBox cmbCiudadOrigen;
        private Label lblTarifa;
    }
}