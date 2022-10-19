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
    public partial class frmEstadoCuenta : Form
    {
        public frmEstadoCuenta()
        {
            InitializeComponent();
        }

        // CLAVE:VALOR -> Num de envio - Tarifa PARA EL PROTOTIPO
        //Dictionary<int, float> FacturasPagadas = new Dictionary<int, float>(); // CLAVE:VALOR -> Num de envio - Tarifa PARA EL PROTOTIPO
        //Dictionary<int, float> FacturasPendientesPago = new Dictionary<int, float>();
        //Dictionary<int, float> EnviosPendientesFacturar = new Dictionary<int, float>();
        //float saldoTotal;
        private void frmEstadoCuenta_Load(object sender, EventArgs e)
        {
            CargarEstadoCuenta();
        }

        private void CargarEstadoCuenta()
        {
            if (frmPrototipo.testPrimeraVez == true) // solo en prototipo porque no se pueden usar metodos ni archivos, y quiero que guarde el estado del sistema en la sesion, es decir solo los cargo la primera vez y despues uso las mismas.
            {
                // Protipo estado inicial: facturas 1 y 3 estan pagadas, factura 2 esta pendiente de pago, y envio 4 esta pendiente de facturar
                frmPrototipo.FacturasPagadas.Add(1, 500.00f);
                frmPrototipo.FacturasPagadas.Add(3, 300.50f);

                frmPrototipo.FacturasPendientesPago.Add(2, 300.75f);
                frmPrototipo.FacturasPendientesPago.Add(5, 100.00f);

                frmPrototipo.EnviosPendientesFacturar.Add(4, 250.00f);
                frmPrototipo.testPrimeraVez = false;
            }

            foreach (KeyValuePair<int, float> factura in frmPrototipo.FacturasPagadas)
            {
                lvwFacturasPagadas.Items.Add("Factura: " + factura.Key + " - $" + factura.Value);
            }

            foreach (KeyValuePair<int, float> factura in frmPrototipo.FacturasPendientesPago)
            {
                lstFacturasAPagar.Items.Add("Factura: " + factura.Key + " - $" + factura.Value);
            }

            foreach (KeyValuePair<int, float> envio in frmPrototipo.EnviosPendientesFacturar)
            {
                lvwPendienteFacturar.Items.Add("Envio: " + envio.Key + " - $" + envio.Value);
            }

            if (frmPrototipo.FacturasPendientesPago.Count == 0)
            {
                lblSaldoEstadodeCuenta.Text = "Estado: No tiene facturas pendientes de pago.";
            }
            else
            {
                frmPrototipo.saldoTotal = 0;
                frmPrototipo.saldoTotal = CalcularSaldo(frmPrototipo.saldoTotal);
                lblSaldoEstadodeCuenta.Text = "Estado: Tiene facturas pendientes de pago por un total de: $" + frmPrototipo.saldoTotal;
            }
        }

        private float CalcularSaldo(float saldoTotal)
        {
            foreach(KeyValuePair<int, float> factura in frmPrototipo.FacturasPendientesPago)
            {
                saldoTotal += factura.Value;
            }

            return saldoTotal;
        }

        private void btnFacturasAPagar_Click(object sender, EventArgs e)
        {
            if (lstFacturasAPagar.Items.Count == 0)
            {
                MessageBox.Show("No hay facturas a pagar en su cuenta.", "Error.");
            }
            else if (lstFacturasAPagar.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una factura a pagar.", "Error.");
            } else
            {
                string facturaSeleccionada = lstFacturasAPagar.Text;
                int indiceSeleccionado = lstFacturasAPagar.SelectedIndex;

                int indexguion = facturaSeleccionada.IndexOf("-");
                int lengthfacturanum = indexguion - 1 - 9;

                int numFactura = Convert.ToInt32(facturaSeleccionada.Substring(9, lengthfacturanum));
                float valorFactura = Convert.ToSingle(facturaSeleccionada.Substring(facturaSeleccionada.IndexOf("$")+1));

                frmPrototipo.FacturasPendientesPago.Remove(numFactura);
                lstFacturasAPagar.Items.RemoveAt(indiceSeleccionado);
                frmPrototipo.FacturasPagadas.Add(numFactura, valorFactura);
                lvwFacturasPagadas.Items.Add(facturaSeleccionada);

                if(frmPrototipo.FacturasPendientesPago.Count == 0)
                {
                    lblSaldoEstadodeCuenta.Text = "Estado: No tiene facturas pendientes de pago.";
                } else if (frmPrototipo.FacturasPendientesPago.Count >= 0)
                {
                    frmPrototipo.saldoTotal -= valorFactura;
                    lblSaldoEstadodeCuenta.Text = "Estado: Tiene facturas pendientes de pago por un total de: $" + frmPrototipo.saldoTotal;
                }

                MessageBox.Show("Se pagó la factura " + numFactura +" de valor $" + valorFactura + " con éxito!", "Éxito!");
            }
        }
    }
}
