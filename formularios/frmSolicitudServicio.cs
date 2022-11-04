using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Test_WinForms.formularios
{
    public partial class frmSolicitudServicio : Form
    {
        //NO VA, LOS PUSE EN FORM PRINCIPAL COMO STATIC PARA QUE SEA IGUAL EN TODO EL SISTEMA List<Int32> listaSolicitudesEnvio = new List<Int32>(); // Prototipo un solo usuario, agrego las solicitudes en la lista
        //NO VA,LOS PUSE EN FORM PRINCIPAL COMO STATIC PARA QUE SEA IGUAL EN TODO EL SISTEMAint nroSolicitud = 1; // En un archivo fuera del prototipo

        float tarifatotal;

        // TODAS LAS TARIFAS IRIA A CONSULTARLAS EN EL ARCHIVO EN EL TP FINAL
        // Tarifas misma Localidad
        float tarifaLocalLocalhasta500gr = 350.00f;
        float tarifaLocalLocalhasta10kg = 3500.00f;
        float tarifaLocalLocalhasta20kg = 4200.00f;
        float tarifaLocalLocalhasta30kg = 5250.00f;

        // Tarifas misma Provincia
        float tarifaProvincialProvincialhasta500gr = 550.00f;
        float tarifaProvincialProvincialhasta10kg = 5500.00f;
        float tarifaProvincialProvincialhasta20kg = 6600.00f;
        float tarifaProvincialProvincialhasta30kg = 8250.00f;

        // Tarifas misma Region
        float tarifaRegionalRegionalhasta500gr = 750.00f;
        float tarifaRegionalRegionalhasta10kg = 7500.00f;
        float tarifaRegionalRegionalhasta20kg = 9000.00f;
        float tarifaRegionalRegionalhasta30kg = 11250.00f;

        // Tarifas Nacional
        float tarifaNacionalNacional500gr = 950.00f;
        float tarifaNacionalNacionalhasta10kg = 9500.00f;
        float tarifaNacionalNacionalhasta20kg = 11400.00f;
        float tarifaNacionalNacionalhasta30kg = 14250.00f;


        // TARIFAS INTERNACIONALES

        // Prototipo solo Europa
        float tarifaEuropa500gr = 8200.00f;
        float tarifaEuropa10kg = 82000.00f;
        float tarifaEuropa20kg = 98400.00f;
        float tarifaEuropa30kg = 123000.00f;

        // TARIFAS ADICIONALES
        float porcUrgente = 1.50f; // 50%
        float topeUrgente = 15000.00f;
        float RetiroPuerta = 3500f;
        float EntregaPuerta = 1500f;

        public frmSolicitudServicio()
        {
            InitializeComponent();
        }

        private void frmSolicitudServicio_Load(object sender, EventArgs e)
        {
            CargarRegionesOrigenNacional();
            CargarPaisesDestino();
        }
        private void CargarRegionesOrigenNacional()
        {
            cmbRegionOrigen.Items.Add("Metropolitana");
            cmbRegionOrigen.Items.Add("Sur");
        }
        private void CargarPaisesDestino()
        {
            cmbPaisDestino.Items.Add("Argentina");
            cmbPaisDestino.Items.Add("España");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CargarSolicitud();
        }

        private void CargarSolicitud()
        {
            string errores = "";

            // VALIDAR REGION ORIGEN
            if (cmbRegionOrigen.SelectedIndex == -1)
            {
                errores += "Debe seleccionar una Region de Origen." + "\n";
            }
            // VALIDAR PROVINCIA ORIGEN
            if (cmbProvinciaOrigen.SelectedIndex == -1)
            {
                errores += "Debe seleccionar una Provincia de Origen." + "\n";
            }
            // VALIDAR LOCALIDAD ORIGEN
            if (cmbLocalidadOrigen.SelectedIndex == -1)
            {
                errores += "Debe seleccionar una Localidad de Origen." + "\n";
            }
            // VALIDAR MODALIDAD DE ORIGEN
            if (cmbModalidadOrigen.SelectedIndex == -1)
            {
                errores += "Debe seleccionar Modalidad de Origen." + "\n";
            }

            // VALIDO DIRECCION DE ORIGEN SOLO SI LA MODALIDAD DE ORIGEN ES PUERTA
            if(cmbModalidadOrigen.Text == "Puerta")
            {
                // VALIDAR DIRECCION ORIGEN
                if (string.IsNullOrEmpty(txtDireccionOrigen.Text))
                {
                    errores += "Debe escribir una Dirección de Origen." + "\n";
                }

                // VALIDAR NUMERO ORIGEN
                if (string.IsNullOrEmpty(txtNumeroOrigen.Text))
                {
                    errores += "Debe escribir un Número en la Dirección de Origen." + "\n";
                }
                else
                {
                    string numeroIngresado = txtNumeroOrigen.Text;
                    bool flagNumero;
                    int numero;
                    flagNumero = Int32.TryParse(numeroIngresado, out numero);

                    if (!flagNumero)
                    {
                        errores += "El campo Número (Domicilio de Origen) debe ser numérico." + "\n";
                    }
                }
                // VALIDAR CODIGO POSTAL
                if (string.IsNullOrEmpty(txtCodigoPostalOrigen.Text))
                {
                    errores += "Debe escribir un Código Postal de Origen." + "\n";
                }
            }


            //VALIDAR DATOS

            // VALIDAR PESO
            if (cmbPeso.SelectedIndex == -1)
            {
                errores += "Debe seleccionar un Peso." + "\n";
            }
            // VALIDAR PRIORIDAD
            if (cmbPrioridad.SelectedIndex == -1)
            {
                errores += "Debe seleccionar Prioridad (No Urgente / Urgente)." + "\n";
            }


            // VALIDAR DESTINO

            // VALIDAR PAIS DESTINO
            if (cmbPaisDestino.SelectedIndex == -1)
            {
                errores += "Debe seleccionar un Pais de Destino." + "\n";
            }
            // VALIDAR REGION DESTINO
            if (cmbRegionDestino.SelectedIndex == -1)
            {
                errores += "Debe seleccionar una Region de Destino." + "\n";
            }

            //SI EL PAIS DE DESTINO ES ARGENTINA VALIDO PROVINCIA, LOCALIDAD y MODALIDAD
            if (cmbPaisDestino.Text.ToLower() == "argentina")
            {
                // VALIDAR PROVINCIA DESTINO
                if (cmbProvinciaDestino.SelectedIndex == -1)
                {
                    errores += "Debe seleccionar una Provincia de Destino." + "\n";
                }
                // VALIDAR LOCALIDAD DESTINO
                if (cmbLocalidadDestino.SelectedIndex == -1)
                {
                    errores += "Debe seleccionar una Localidad de Destino." + "\n";
                }
                // VALIDAR MODALIDAD DE DESTINO (EN INTERNACIONAL NO ES NECESARIO MODALIDAD, solo que el usuario ingrese pais y la direccion como texto dijo en la correccion)
                if (cmbModalidadDestino.SelectedIndex == -1)
                {
                    errores += "Debe seleccionar Modalidad de Destino." + "\n";
                }
            }


            // VALIDAR DIRECCION SI (EL PAIS ES ARGENTINA Y LA MODALIDAD ES PUERTA) O (EL DESTINO ES INTERNACIONAL)
            if ((cmbPaisDestino.Text.ToLower() == "argentina" && cmbModalidadDestino.Text == "Puerta") || (cmbPaisDestino.Text.ToLower() != "argentina"))
            {
                // VALIDAR DIRECCION DESTINO
                if (string.IsNullOrEmpty(txtDireccionDestino.Text))
                {
                    errores += "Debe escribir una Dirección de Destino." + "\n";
                }

                // VALIDAR NUMERO DESTINO
                if (string.IsNullOrEmpty(txtNumeroDestino.Text))
                {
                    errores += "Debe escribir un Número en la Dirección de Destino." + "\n";
                }
                else
                {
                    string numeroIngresado = txtNumeroDestino.Text;
                    bool flagNumero;
                    int numero;
                    flagNumero = Int32.TryParse(numeroIngresado, out numero);

                    if (!flagNumero)
                    {
                        errores += "El campo Número (Domicilio de Destino) debe ser numérico." + "\n";
                    }
                }
                // VALIDAR CODIGO POSTAL DESTINO
                if (string.IsNullOrEmpty(txtCodigoPostalDestino.Text))
                {
                    errores += "Debe escribir un Código Postal de Destino." + "\n";
                }
            }

            // SI LA VARIABLE ERRORES NO ESTA VACIA, MUESTRO LOS ERRORES
            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error");
            }
            // Si no, cargo la solicitud
            else
            {
                float tarifa = CalcularTarifas();
                string mensajeExitosoSolServicio = "Se cargo la solicitud con éxito!." + "\n" +
                    "Tarifa: $" + tarifa + "\n" + 
                    "Número de Solicitud: " + frmPrototipo.ultimaSolicitud; // AGREGAR TARIFA

                frmPrototipo.listaSolicitudesEnvio.Add(frmPrototipo.ultimaSolicitud); // Prototipo un solo usuario, cargo las solicitudes en la lista
           
                frmPrototipo.ultimaSolicitud++; // para el prox numero de solicitud

                MessageBox.Show(mensajeExitosoSolServicio, "Éxito");
            }
        }

        private void cmbModalidadOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si elige opcion Puerta muestro controles direccion,numero,piso/depto,codigo postal
            if(cmbModalidadOrigen.Text == "Puerta")
            {
                //muestro labels direccion
                lblDireccionOrigen.Visible = true;
                lblNumeroOrigen.Visible = true;
                lblPisoDeptoOrigen.Visible = true;
                lblCodigoPostalOrigen.Visible = true;

                // muestro textbox direccion
                txtDireccionOrigen.Visible = true;
                txtNumeroOrigen.Visible = true;
                txtPisoOrigen.Visible = true;
                txtCodigoPostalOrigen.Visible = true;


            }

            if (cmbModalidadOrigen.Text == "Sucursal")
            {
                //no muestro labels direccion
                lblDireccionOrigen.Visible = false;
                lblNumeroOrigen.Visible = false;
                lblPisoDeptoOrigen.Visible = false;
                lblCodigoPostalOrigen.Visible = false;

                //no muestro textbox direccion
                txtDireccionOrigen.Clear();
                txtDireccionOrigen.Visible = false;
                txtNumeroOrigen.Clear();
                txtNumeroOrigen.Visible = false;
                txtPisoOrigen.Clear();
                txtPisoOrigen.Visible = false;
                txtCodigoPostalOrigen.Clear();
                txtCodigoPostalOrigen.Visible = false;
            }
        }

        private void cmbPeso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeso.SelectedIndex == 0)
            {
                lblMostrarTipo.Text = "Correspondencia";
                lblMostrarTipo.Visible = true;
            }
            else if(cmbPeso.SelectedIndex == 1 || cmbPeso.SelectedIndex == 2 || cmbPeso.SelectedIndex == 3)
            {
                lblMostrarTipo.Text = "Encomienda";
                lblMostrarTipo.Visible = true;
            }
        }

        private void cmbPaisDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            // como selecciono un pais nuevo, borro las regiones cargadas por si habia alguna y demas combobox
            cmbRegionDestino.Items.Clear();
            cmbProvinciaDestino.Items.Clear();
            cmbLocalidadDestino.Items.Clear();

            // Si el pais de destino es Argentina, activo combobox provincia
            if (cmbPaisDestino.Text.ToLower() == "argentina")
            {
                cmbProvinciaDestino.Enabled = true;
                cmbLocalidadDestino.Enabled = true;
                cmbModalidadDestino.Enabled = true;
                CargarRegionesDestinoNacional();
            }
            if (cmbPaisDestino.Text.ToLower() != "argentina")
            {
                cmbProvinciaDestino.Items.Clear();
                cmbProvinciaDestino.Enabled = false;
                cmbLocalidadDestino.Items.Clear();
                cmbLocalidadDestino.Enabled = false;
                cmbModalidadDestino.SelectedIndex = -1;
                cmbModalidadDestino.Enabled = false;

                MostrarControlesDireccionDestino();

                // Prototipo solo funciona con España Internacional
                CargarRegionesInternacional(cmbPaisDestino.Text.ToLower());
            }
        }

        // Prototipo solo funciona para Internacional: España
        private void CargarRegionesInternacional(string pais)
        {
            if (pais == "españa")
            {
                cmbRegionDestino.Items.Add("Europa");
            }
        }

        // Solo region metropolitana y sur en prototipo
        private void CargarRegionesDestinoNacional()
        {
            cmbRegionDestino.Items.Add("Metropolitana");
            cmbRegionDestino.Items.Add("Sur");
        }

        private void cmbRegionDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargo provincias nacionales de prueba en base a region elegida, consultaria archivo en tp final

            // borro provincias y localidades cargadas anteriores si ya habian
            cmbProvinciaDestino.Items.Clear();
            cmbLocalidadDestino.Items.Clear();
            if (cmbRegionDestino.Text == "Metropolitana")
            {
                cmbProvinciaDestino.Items.Add("Buenos Aires");
                cmbProvinciaDestino.Items.Add("CABA");
            }

            if (cmbRegionDestino.Text == "Sur")
            {
                cmbProvinciaDestino.Items.Add("Río Negro");
                cmbProvinciaDestino.Items.Add("Santa Cruz");
            }
        }

        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargo localidades provinciales de prueba en base a provincia elegida, consultaria archivo en tp final

            // borro localidades cargadas anteriores si ya habian
            cmbLocalidadDestino.Items.Clear();
            if (cmbProvinciaDestino.Text == "Buenos Aires")
            {
                cmbLocalidadDestino.Items.Add("Tandil");
                cmbLocalidadDestino.Items.Add("Lujan");
            }

            if (cmbProvinciaDestino.Text == "CABA")
            {
                cmbLocalidadDestino.Items.Add("CABA"); // Considero a todo CABA como misma localidad
            }
            if (cmbProvinciaDestino.Text == "Río Negro")
            {
                cmbLocalidadDestino.Items.Add("San Carlos de Bariloche");
                cmbLocalidadDestino.Items.Add("Viedma");
            }
            if (cmbProvinciaDestino.Text == "Santa Cruz")
            {
                cmbLocalidadDestino.Items.Add("Río Gallegos");
                cmbLocalidadDestino.Items.Add("El Calafate");
            }
        }

        private void cmbModalidadDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModalidadDestino.Text == "Puerta")
            {
                // Si elige opcion Puerta muestro controles direccion,numero,piso/depto,codigo postal
                MostrarControlesDireccionDestino();

            }
            if (cmbModalidadDestino.Text == "Sucursal")
            {
                //no muestro labels direccion
                lblDireccionDestino.Visible = false;
                lblNumeroDestino.Visible = false;
                lblPisoDeptoDestino.Visible = false;
                lblCodigoPostalDestino.Visible = false;

                //no muestro textbox direccion
                txtDireccionDestino.Clear();
                txtDireccionDestino.Visible = false;
                txtNumeroDestino.Clear();
                txtNumeroDestino.Visible = false;
                txtPisoDestino.Clear();
                txtPisoDestino.Visible = false;
                txtCodigoPostalDestino.Clear();
                txtCodigoPostalDestino.Visible = false;
            }
        }

        private void MostrarControlesDireccionDestino()
        {
            //muestro labels direccion
            lblDireccionDestino.Visible = true;
            lblNumeroDestino.Visible = true;
            lblPisoDeptoDestino.Visible = true;
            lblCodigoPostalDestino.Visible = true;

            // muestro textbox direccion
            txtDireccionDestino.Visible = true;
            txtNumeroDestino.Visible = true;
            txtPisoDestino.Visible = true;
            txtCodigoPostalDestino.Visible = true;
        }

        private void cmbRegionOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargo provincias nacionales de prueba en base a region elegida, consultaria archivo en tp final

            // borro provincias y localidades cargadas anteriores si ya habian
            cmbProvinciaOrigen.Enabled = true;
            cmbProvinciaOrigen.Items.Clear();
            cmbLocalidadOrigen.Items.Clear();
            if (cmbRegionOrigen.Text == "Metropolitana")
            {
                cmbProvinciaOrigen.Items.Add("Buenos Aires");
                cmbProvinciaOrigen.Items.Add("CABA");
            }

            if (cmbRegionOrigen.Text == "Sur")
            {
                cmbProvinciaOrigen.Items.Add("Río Negro");
                cmbProvinciaOrigen.Items.Add("Santa Cruz");
            }
        }

        private void cmbProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargo localidades provinciales de prueba en base a provincia elegida, consultaria archivo en tp final

            // borro localidades cargadas anteriores si ya habian
            cmbLocalidadOrigen.Enabled = true;
            cmbLocalidadOrigen.Items.Clear();

            if (cmbProvinciaOrigen.Text == "Buenos Aires")
            {
                cmbLocalidadOrigen.Items.Add("Tandil");
                cmbLocalidadOrigen.Items.Add("Lujan");
            }

            if (cmbProvinciaOrigen.Text == "CABA")
            {
                cmbLocalidadOrigen.Items.Add("CABA"); // Considero a todo CABA como misma localidad
            }
            if (cmbProvinciaOrigen.Text == "Río Negro")
            {
                cmbLocalidadOrigen.Items.Add("San Carlos de Bariloche");
                cmbLocalidadOrigen.Items.Add("Viedma");
            }
            if (cmbProvinciaOrigen.Text == "Santa Cruz")
            {
                cmbLocalidadOrigen.Items.Add("Río Gallegos");
                cmbLocalidadOrigen.Items.Add("El Calafate");
            }
        }

        // CALCULAR TARIFAS

        private float CalcularTarifas()
        {
            tarifatotal = 0.00f;
            // Datos Ingresados Origen
            string regionOrigen = cmbRegionOrigen.Text;
            string provinciaOrigen = cmbProvinciaOrigen.Text;
            string localidadOrigen = cmbLocalidadOrigen.Text;
            string modalidadOrigen = cmbModalidadOrigen.Text;

            // Datos Ingresados Destino
            string paisDestino = cmbPaisDestino.Text;
            string regionDestino = cmbRegionDestino.Text;
            string provinciaDestino;
            string localidadDestino;
            string modalidadDestino;

            // Datos ingresados de envio
            int indicepeso = cmbPeso.SelectedIndex;
            string prioridad = cmbPrioridad.Text;

            if (paisDestino.ToLower() == "argentina")
            {
                provinciaDestino = cmbProvinciaDestino.Text;
                localidadDestino = cmbLocalidadDestino.Text;
                modalidadDestino = cmbModalidadDestino.Text;
            }
            else
            {
                provinciaDestino = "INT";
                localidadDestino = "INT";
                modalidadDestino = "INT";
            }

            // Si coinciden en origen y destino region, provincia y localidad - El envio es misma Localalidad
            if((regionOrigen==regionDestino && provinciaOrigen == provinciaDestino && localidadOrigen == localidadDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifatotal += tarifaLocalLocalhasta500gr;
                }
                if (indicepeso == 1)
                {
                    tarifatotal += tarifaLocalLocalhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifatotal += tarifaLocalLocalhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifatotal += tarifaLocalLocalhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if(prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifatotal * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifatotal;

                    if (recargo <= topeUrgente)
                    {
                        tarifatotal = tarifatotal * porcUrgente;
                    } else if(recargo > topeUrgente)
                    {
                        tarifatotal += topeUrgente;
                    }
                }

                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifatotal += RetiroPuerta;
                }

                // Servicio adicional: Entrega en Puerta (Destino)
                if (modalidadDestino == "Puerta")
                {
                    tarifatotal += EntregaPuerta;
                }
            }


            // Si coinciden en origen y destino region, provincia - El envio es misma Provincia
            else if ((regionOrigen == regionDestino && provinciaOrigen == provinciaDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifatotal += tarifaProvincialProvincialhasta500gr;
                }
                if (indicepeso == 1)
                {
                    tarifatotal += tarifaProvincialProvincialhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifatotal += tarifaProvincialProvincialhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifatotal += tarifaProvincialProvincialhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifatotal * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifatotal;

                    if (recargo <= topeUrgente)
                    {
                        tarifatotal = tarifatotal * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifatotal += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifatotal += RetiroPuerta;
                }

                // Servicio adicional: Entrega en Puerta (Destino)
                if (modalidadDestino == "Puerta")
                {
                    tarifatotal += EntregaPuerta;
                }
            }


            // Si coinciden en origen y destino region - El envio es misma Region
            else if ((regionOrigen == regionDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifatotal += tarifaRegionalRegionalhasta500gr;
                }
                if (indicepeso == 1)
                {
                    tarifatotal += tarifaRegionalRegionalhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifatotal += tarifaRegionalRegionalhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifatotal += tarifaRegionalRegionalhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifatotal * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifatotal;

                    if (recargo <= topeUrgente)
                    {
                        tarifatotal = tarifatotal * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifatotal += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifatotal += RetiroPuerta;
                }

                // Servicio adicional: Entrega en Puerta (Destino)
                if (modalidadDestino == "Puerta")
                {
                    tarifatotal += EntregaPuerta;
                }
            }

            // Si no coinciden en origen y destino region pero el Pais es Argentina el envio es Nacional
            else if ((regionOrigen != regionDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifatotal += tarifaNacionalNacional500gr;
                }
                if (indicepeso == 1)
                {
                    tarifatotal += tarifaNacionalNacionalhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifatotal += tarifaNacionalNacionalhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifatotal += tarifaNacionalNacionalhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifatotal * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifatotal;

                    if (recargo <= topeUrgente)
                    {
                        tarifatotal = tarifatotal * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifatotal += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifatotal += RetiroPuerta;
                }

                // Servicio adicional: Entrega en Puerta (Destino)
                if (modalidadDestino == "Puerta")
                {
                    tarifatotal += EntregaPuerta;
                }
            }


            // CALCULAR INTERNACIONAL: SI pais Destino != Argentina 
            // Prototipo solo Europa
            else if (paisDestino.ToLower() != "argentina" && regionDestino.ToLower() == "europa")
            {
                // Primero hasta CABA segun peso, y luego le sumo la europea
                if (indicepeso == 0)
                {
                    tarifatotal = CalcularTarifaACABAParaInternacionales();
                    tarifatotal += tarifaEuropa500gr;
                }
                if (indicepeso == 1)
                {
                    tarifatotal = CalcularTarifaACABAParaInternacionales();
                    tarifatotal += tarifaEuropa10kg;
                }
                if (indicepeso == 2)
                {
                    tarifatotal = CalcularTarifaACABAParaInternacionales();
                    tarifatotal += tarifaEuropa20kg;
                }
                if (indicepeso == 3)
                {
                    tarifatotal = CalcularTarifaACABAParaInternacionales();
                    tarifatotal += tarifaEuropa30kg;
                }

                // Servicio adicional internacionales solo Urgente y si Mosalidad Origen es Puerta
                // Recargo Urgente Internacional
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifatotal * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifatotal;

                    if (recargo <= topeUrgente)
                    {
                        tarifatotal = tarifatotal * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifatotal += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta solo (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifatotal += RetiroPuerta;
                }
            }

            return tarifatotal;
        }

        private float CalcularTarifaACABAParaInternacionales()
        {
            float tarifaACABA = 0.00f;
            // Datos Ingresados Origen
            string regionOrigen = cmbRegionOrigen.Text;
            string provinciaOrigen = cmbProvinciaOrigen.Text;
            string localidadOrigen = cmbLocalidadOrigen.Text;
            string modalidadOrigen = cmbModalidadOrigen.Text;

            // Datos Ingresados Destino
            string paisDestino = "Argentina";
            string regionDestino = "Metropolitana";
            string provinciaDestino = "CABA";
            string localidadDestino = "CABA";

            // Datos ingresados de envio
            int indicepeso = cmbPeso.SelectedIndex;
            string prioridad = cmbPrioridad.Text;

            // Si coinciden en origen y destino region, provincia y localidad - El envio es misma Localalidad
            if ((regionOrigen == regionDestino && provinciaOrigen == provinciaDestino && localidadOrigen == localidadDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifaACABA += tarifaLocalLocalhasta500gr;
                }
                if (indicepeso == 1)
                {
                    tarifaACABA += tarifaLocalLocalhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifaACABA += tarifaLocalLocalhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifaACABA += tarifaLocalLocalhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifaACABA * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifaACABA;

                    if (recargo <= topeUrgente)
                    {
                        tarifaACABA = tarifaACABA * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifaACABA += topeUrgente;
                    }
                }

                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifaACABA += RetiroPuerta;
                }

            }


            // Si coinciden en origen y destino region, provincia - El envio es misma Provincia
            else if ((regionOrigen == regionDestino && provinciaOrigen == provinciaDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifaACABA += tarifaProvincialProvincialhasta500gr;
                }
                if (indicepeso == 1)
                {
                    tarifaACABA += tarifaProvincialProvincialhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifaACABA += tarifaProvincialProvincialhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifaACABA += tarifaProvincialProvincialhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifaACABA * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifaACABA;

                    if (recargo <= topeUrgente)
                    {
                        tarifaACABA = tarifaACABA * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifaACABA += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifaACABA += RetiroPuerta;
                }
            }


            // Si coinciden en origen y destino region - El envio es misma Region
            else if ((regionOrigen == regionDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifaACABA += tarifaRegionalRegionalhasta500gr;
                }
                if (indicepeso == 1)
                {
                    tarifaACABA += tarifaRegionalRegionalhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifaACABA += tarifaRegionalRegionalhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifaACABA += tarifaRegionalRegionalhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifaACABA * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifaACABA;

                    if (recargo <= topeUrgente)
                    {
                        tarifaACABA = tarifaACABA * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifaACABA += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifaACABA += RetiroPuerta;
                }
            }

            // Si no coinciden en origen y destino region pero el Pais es Argentina el envio es Nacional
            else if ((regionOrigen != regionDestino) && paisDestino.ToLower() == "argentina")
            {
                if (indicepeso == 0)
                {
                    tarifaACABA += tarifaNacionalNacional500gr;
                }
                if (indicepeso == 1)
                {
                    tarifaACABA += tarifaNacionalNacionalhasta10kg;
                }
                if (indicepeso == 2)
                {
                    tarifaACABA += tarifaNacionalNacionalhasta20kg;
                }
                if (indicepeso == 3)
                {
                    tarifaACABA += tarifaNacionalNacionalhasta30kg;
                }

                // Servicio adicional: Recargo Urgente
                if (prioridad == "Urgente")
                {
                    float calculotarifaconrecargo = tarifaACABA * porcUrgente; // para luego validar que el recargo sea <= al tope establecido en archivo
                    float recargo = calculotarifaconrecargo - tarifaACABA;

                    if (recargo <= topeUrgente)
                    {
                        tarifaACABA = tarifaACABA * porcUrgente;
                    }
                    else if (recargo > topeUrgente)
                    {
                        tarifaACABA += topeUrgente;
                    }
                }
                // Servicio adicional: Retiro en Puerta (Origen)
                if (modalidadOrigen == "Puerta")
                {
                    tarifaACABA += RetiroPuerta;
                }
            }
            return tarifaACABA;
        }

        private void frmSolicitudServicio_MouseEnter(object sender, EventArgs e)
        {
            lblDetalleTarifas.Text = "$"+Convert.ToString(CalcularTarifas());
        }

        private void frmSolicitudServicio_MouseLeave(object sender, EventArgs e)
        {
            lblDetalleTarifas.Text = "$" + Convert.ToString(CalcularTarifas());
        }
    }
}
