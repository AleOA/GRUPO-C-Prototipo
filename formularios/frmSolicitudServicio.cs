using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_WinForms.formularios
{
    public partial class frmSolicitudServicio : Form
    {
        List<string> listaCiudades = new List<string>();
        //NO VA, LOS PUSE EN FORM PRINCIPAL COMO STATIC PARA QUE SEA IGUAL EN TODO EL SISTEMA List<Int32> listaSolicitudesEnvio = new List<Int32>(); // Prototipo un solo usuario, agrego las solicitudes en la lista
        //NO VA,LOS PUSE EN FORM PRINCIPAL COMO STATIC PARA QUE SEA IGUAL EN TODO EL SISTEMAint nroSolicitud = 1; // En un archivo fuera del prototipo
        
        float tarifa = 0.00f;
        // Protipo a cada ciudad le asigno una tarifa en variables
        float tarifaBsAs = 150.5f;
        float tarifaCordoba = 334.50f;
        float tarifaRosario = 200.33f;
        float tarifaMardelPlata = 450f;
        public frmSolicitudServicio()
        {
            InitializeComponent();
        }

        private void frmSolicitudServicio_Load(object sender, EventArgs e)
        {
            CargarCiudades();
            CargarListaSolicitudes();
        }

        private void CargarListaSolicitudes()
        {
            foreach(int solicitud in frmPrototipo.listaSolicitudesEnvio)
            {
                lstSolicitudesCancelar.Items.Add(solicitud);
            }
        }

        private void CargarCiudades()
        {
            // Prototipo carga las ciudades en una lista (sin archivo) (solo nacionales)
            listaCiudades.Add("Buenos Aires");
            listaCiudades.Add("Córdoba");
            listaCiudades.Add("Rosario");
            listaCiudades.Add("Mar del Plata");

            // las agrega al combobox cmbCiudadOrigen y cmbCiudadDsetino para que aparezcan para seleccionar
            foreach (string ciudad in listaCiudades)
            {
                cmbCiudadDestino.Items.Add(ciudad); // en la version final, este combobox lo llenamos con el archivo
                cmbCiudadOrigen.Items.Add(ciudad); // en la version final, este combobox lo llenamos con el archivo
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CargarSolicitud();
        }

        private void CargarSolicitud()
        {
            string errores = "";

            // VALIDAR TIPO DE ENVIO, En el prototipo solo son Nacionales
            if (cmbTipoEnvio.SelectedIndex == -1)
            {
                errores += "Debe seleccionar un Tipo de Envío." + "\n";
            }
            // VALIDAR CIUDAD ORIGEN
            if (cmbCiudadOrigen.SelectedIndex == -1)
            {
                errores += "Debe seleccionar una Ciudad de Origen." + "\n";
            }
            // VALIDAR CIUDAD DESTINO
            if (cmbCiudadDestino.SelectedIndex == -1)
            {
                errores += "Debe seleccionar una Ciudad de Destino." + "\n";
            }
            // VALIDAR DIRECCION, FALTA VALIDAR que no haya otros simbolos distintos de letras
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                errores += "Debe escribir una Dirección." + "\n";
            }

            // VALIDAR NUMERO
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                errores += "Debe escribir un Número en la dirección." + "\n";
            }
            else
            {
                string numeroIngresado = txtNumero.Text;
                bool flagNumero;
                int numero;
                flagNumero = Int32.TryParse(numeroIngresado, out numero);

                if (!flagNumero)
                {
                    errores += "El campo Número (Domicilio) debe ser numérico." + "\n";
                }
            }
            // VALIDAR CODIGO POSTAL
            if (string.IsNullOrEmpty(txtCodigoPostal.Text))
            {
                errores += "Debe escribir un Código Postal." + "\n";
            }
            else
            {
                string codigoIngresado = txtCodigoPostal.Text;
                bool flagCodigo;
                int codigo;
                flagCodigo = Int32.TryParse(codigoIngresado, out codigo);

                if (!flagCodigo)
                {
                    errores += "El campo Código Postal debe ser numérico." + "\n";
                }
            }
            // VALIDAR CORRESPONDENCIA / ENCOMIENDA
            if (cmbCorrespEncom.SelectedIndex == -1)
            {
                errores += "Debe seleccionar Tipo de Producto." + "\n";
            } else
            {
                string correspEncomSeleccionado = cmbCorrespEncom.Text;
            }

            // VALIDAR PESO
            if (string.IsNullOrEmpty(txtPeso.Text))
            {
                errores += "Debe escribir un Peso (KG)." + "\n";
            } else
            {
                string pesoIngresado = txtPeso.Text;
                bool flagPeso;
                float peso;
                flagPeso = Single.TryParse(pesoIngresado, out peso);

                if (!flagPeso)
                {
                    errores += "El peso ingresado debe ser numérico (KG)" + "\n";
                }
                else
                {
                    if (cmbCorrespEncom.Text == null)
                    {
                        errores += "Debe seleccionar Tipo de Producto." + "\n";
                    }
                    if (cmbCorrespEncom.Text == "Correspondencia" && (peso > 0.5f || peso <= 0.0f))
                    {
                        errores += "La correspondencia debe ser superior a 0 KG y hasta 0.5 KG." + "\n";
                    }
                    if (cmbCorrespEncom.Text == "Encomienda" && (peso <= 0.5f || peso > 30.0f))
                    {
                        errores += "La Encomienda debe ser superior a 0.5 KG y hasta 30 KG." + "\n";
                    }
                }

            }

            // VALIDAR PRIORIDAD
            if (cmbPrioridad.SelectedIndex == -1)
            {
                errores += "Debe seleccionar Prioridad (No Urgente / Urgente)." + "\n";
            }
            // VALIDAR PUERTA/SUCURSAL
            if (cmbPuertaSucursal.SelectedIndex == -1)
            {
                errores += "Debe seleccionar Modalidad." + "\n";
            }


            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error");
            }
            else
            {
                float tarifa = ObtenerTarifa();
                string mensajeExitosoSolServicio = "Se cargo la solicitud con éxito!." + "\n" +
                    "Tarifa: $" + tarifa + "\n" + 
                    "Número de Solicitud: " + frmPrototipo.ultimaSolicitud;

                frmPrototipo.listaSolicitudesEnvio.Add(frmPrototipo.ultimaSolicitud); // Prototipo un solo usuario, cargo las solicitudes en la lista
                lstSolicitudesCancelar.Items.Add(frmPrototipo.ultimaSolicitud); // Prototipo la cargo directo al ListBox de Cancelar Envios
                frmPrototipo.ultimaSolicitud++; // para el prox numero de solicitud

                MessageBox.Show(mensajeExitosoSolServicio, "Éxito");
            }
        }

        // en el prototipo calculo la tarifa por Ciudad de destino
        private float ObtenerTarifa()
        {
            if (cmbCiudadDestino.Text == "Buenos Aires"){
                tarifa = tarifaBsAs;
            } else if (cmbCiudadDestino.Text == "Córdoba")
            {
                tarifa = tarifaCordoba;
            } else if (cmbCiudadDestino.Text == "Rosario")
            {
                tarifa = tarifaRosario;
            } else if (cmbCiudadDestino.Text == "Mar del Plata")
            {
                tarifa = tarifaMardelPlata;
            }
            return tarifa;
        }

        private void btnCancelarEnvio_Click(object sender, EventArgs e)
        {
            if (lstSolicitudesCancelar.Items.Count == 0) {
                MessageBox.Show("No hay solicitudes en su cuenta", "Error");
            }
            else if(lstSolicitudesCancelar.SelectedIndex == -1)
            {
                MessageBox.Show("Error, debe seleccionar una solicitud", "Error");
            }
            else
            {
                string solicitudSeleccionada = lstSolicitudesCancelar.Text;
                int indiceSeleccionado = lstSolicitudesCancelar.SelectedIndex;

                frmPrototipo.listaSolicitudesEnvio.Remove(Convert.ToInt32(solicitudSeleccionada)); // elimino de la listaa
                lstSolicitudesCancelar.Items.RemoveAt(indiceSeleccionado); // elimino del listbox
                MessageBox.Show("Se canceló la solicitud " + solicitudSeleccionada + " con éxito!", "Éxito!");
            }
        }

        private void cmbCiudadDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCiudadDestino.SelectedItem.ToString() == listaCiudades[0]){
                lblTarifa.Text = "Tarifa: $" + tarifaBsAs;
            }
            if (cmbCiudadDestino.SelectedItem.ToString() == listaCiudades[1])
            {
                lblTarifa.Text = "Tarifa: $" + tarifaCordoba;
            }
            if (cmbCiudadDestino.SelectedItem.ToString() == listaCiudades[2])
            {
                lblTarifa.Text = "Tarifa: $" + tarifaRosario;
            }
            if (cmbCiudadDestino.SelectedItem.ToString() == listaCiudades[3])
            {
                lblTarifa.Text = "Tarifa: $" + tarifaMardelPlata;
            }
        }
    }
}
