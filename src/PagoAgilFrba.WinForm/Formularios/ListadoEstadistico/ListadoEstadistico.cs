using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class ListadoEstadistico : FormListaBase
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            comboBoxTipoListado.Items.Add("Porcentaje de facturas cobradas por empresa");
            comboBoxTipoListado.Items.Add("Empresas con mayor monto rendido");
            comboBoxTipoListado.Items.Add("Clientes con mas pagos");
            comboBoxTipoListado.Items.Add("clientes cumplidores");

            comboBoxTrimestre.Items.Add("1er");
            comboBoxTrimestre.Items.Add("2do");
            comboBoxTrimestre.Items.Add("3ro");
            comboBoxTrimestre.Items.Add("4to");
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.Visible = false; 
            Eliminar.Visible = false;
            btnNuevo.Visible = false;
            btnLimpiar.Visible = false;
        }
        
        protected override DataTable RecuperarDatos()
        {
            return null;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ckEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected override void btnBuscar_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex regexYear = new System.Text.RegularExpressions.Regex(@"[0-9]{4}");
            if (!regexYear.Match(txtAnio.Text).Success)
            {
                Generico.MostrarAdvertencia("El año debe ser tener 4 numeros");
                return;
            }

            switch (comboBoxTipoListado.Text)
            {
                case "Porcentaje de facturas cobradas por empresa":
                    switch (comboBoxTrimestre.Text)
                    {
                        case "1er":
                            dgv.DataSource = Listado.PorcentajeFacturasCobradasPorEmpresa(int.Parse(txtAnio.Text), 1, 2, 3);
                            break;
                        case "2do":
                            dgv.DataSource = Listado.PorcentajeFacturasCobradasPorEmpresa(int.Parse(txtAnio.Text), 4, 5, 6);
                            break;
                        case "3ro":
                            dgv.DataSource = Listado.PorcentajeFacturasCobradasPorEmpresa(int.Parse(txtAnio.Text), 7, 8, 9);
                            break;
                        default:
                            dgv.DataSource = Listado.PorcentajeFacturasCobradasPorEmpresa(int.Parse(txtAnio.Text), 10, 11, 12);
                            break;
                    }
                    break;
                case "Empresas con mayor monto rendido":
                    switch (comboBoxTrimestre.Text)
                    {
                        case "1er":
                            dgv.DataSource = Listado.EmpresasMayorMontoRendido(int.Parse(txtAnio.Text), 1, 2, 3);
                            break;
                        case "2do":
                            dgv.DataSource = Listado.EmpresasMayorMontoRendido(int.Parse(txtAnio.Text), 4, 5, 6);
                            break;
                        case "3ro":
                            dgv.DataSource = Listado.EmpresasMayorMontoRendido(int.Parse(txtAnio.Text), 7, 8, 9);
                            break;
                        default:
                            dgv.DataSource = Listado.EmpresasMayorMontoRendido(int.Parse(txtAnio.Text), 10, 11, 12);
                            break;
                    }
                    break;
                case "Clientes con mas pagos":
                    switch (comboBoxTrimestre.Text)
                    {
                        case "1er":
                            dgv.DataSource = Listado.ClientesConMasPagos(int.Parse(txtAnio.Text), 1, 2, 3);
                            break;
                        case "2do":
                            dgv.DataSource = Listado.ClientesConMasPagos(int.Parse(txtAnio.Text), 4, 5, 6);
                            break;
                        case "3ro":
                            dgv.DataSource = Listado.ClientesConMasPagos(int.Parse(txtAnio.Text), 7, 8, 9);
                            break;
                        default:
                            dgv.DataSource = Listado.ClientesConMasPagos(int.Parse(txtAnio.Text), 10, 11, 12);
                            break;
                    }
                    break;
                default:
                    switch (comboBoxTrimestre.Text)
                    {
                        case "1er":
                            dgv.DataSource = Listado.ClientesConMayorPorcentajeDeFacturasPagas(int.Parse(txtAnio.Text), 1, 2, 3);
                            break;
                        case "2do":
                            dgv.DataSource = Listado.ClientesConMayorPorcentajeDeFacturasPagas(int.Parse(txtAnio.Text), 4, 5, 6);
                            break;
                        case "3ro":
                            dgv.DataSource = Listado.ClientesConMayorPorcentajeDeFacturasPagas(int.Parse(txtAnio.Text), 7, 8, 9);
                            break;
                        default:
                            dgv.DataSource = Listado.ClientesConMayorPorcentajeDeFacturasPagas(int.Parse(txtAnio.Text), 10, 11, 12);
                            break;
                    }
                    break;
                    break;
            }
        }





    }
}
