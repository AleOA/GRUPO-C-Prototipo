namespace Test_WinForms
{
    public partial class frmPrototipo : Form
    {
        // SOLICITUD DE SERVICIO
        public static List<Int32> listaSolicitudesEnvio;
        public static int ultimaSolicitud;

        //ESTADO DE CUENTA
        // CLAVE:VALOR -> Num de envio - Tarifa PARA EL PROTOTIPO
        public static Dictionary<int, float> FacturasPagadas; // CLAVE:VALOR -> Num de envio - Tarifa PARA EL PROTOTIPO
        public static Dictionary<int, float> FacturasPendientesPago;
        public static Dictionary<int, float> EnviosPendientesFacturar;
        public static float saldoTotal;
        public static bool testPrimeraVez; // solo en prototipo

        // LOGIN
        string usuario = "cai";
        string pass = "cai";

        public frmPrototipo()
        {
            listaSolicitudesEnvio = new List<Int32>(); // ES LA LISTA DE SOLICITUDES DEL USUARIO QUE USA EL SISTEMA. PARA EL PROTOTIPO HAY UN USUARIO SOLO, POR ESO ES IGUAL EN TODO EL SISTEMA
            ultimaSolicitud = 1; // Inicia el sistema, el numero de solicitud es 1
            FacturasPagadas = new Dictionary<int, float>();
            FacturasPendientesPago = new Dictionary<int, float>();
            EnviosPendientesFacturar = new Dictionary<int, float>();
            testPrimeraVez = true;
            InitializeComponent();
        }

        private void SolicitudCancelacionEnvioMenu_Click(object sender, EventArgs e)
        {
            formularios.frmSolicitudServicio frmSolicitudServicio = new formularios.frmSolicitudServicio();
            frmSolicitudServicio.Show();
        }

        private void EstadoServicioMenuItem_Click(object sender, EventArgs e)
        {
            formularios.frmEstadoServicio frmEstadoServicio = new formularios.frmEstadoServicio();
            frmEstadoServicio.Show();
        }
        private void estadoDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios.frmEstadoCuenta frmEstadoCuenta = new formularios.frmEstadoCuenta();
            frmEstadoCuenta.Show();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string errores = "";
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errores += "Debe ingresar un nombre de usuario" + "\n";
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errores += "Debe ingresar una contraseña" + "\n";
            }

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error.");
            }
            else if ((txtUsuario.Text != usuario) || (txtPassword.Text != pass))
            {
                MessageBox.Show("El usuario o contraseña ingresados son incorrectos.", "Error");
            }
            else
            {
                MessageBox.Show("Inicio de sesión correcto.", "Sesión iniciada");
                HabilitarMenu();

                // Hago invisible los labels, textbox y botones de login
                lblUsuario.Visible = false;
                lblContraseña.Visible = false;
                txtUsuario.Visible = false;
                txtPassword.Visible = false;
                btnIniciarSesion.Visible = false;
                btnRegistrarse.Visible = false;
                lblBienvenida.Text = "Bienvenido/a al Sistema: " + usuario;
                lblBienvenida.Visible = true;

            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No implementado.", "No Implementado");
        }

        public void HabilitarMenu()
        {
            SolicitudCancelacionEnvioMenu.Enabled = true;
            EstadoDelServicioMenu.Enabled = true;
            EstadoDeCuentaMenu.Enabled = true;
        }

        public void DeshabilitarMenu()
        {
            SolicitudCancelacionEnvioMenu.Enabled = false;
            EstadoDelServicioMenu.Enabled = false;
            EstadoDeCuentaMenu.Enabled = false;
        }
    }
}