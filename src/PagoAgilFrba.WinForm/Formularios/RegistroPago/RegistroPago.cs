using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    using System.Collections.Generic;

    public partial class RegistroPago : FormListaBase
    {

        private List<Factura> Facturas = new List<Factura>();
        public Sucursal Suc;
        private int? IdFormaPago;

        public RegistroPago()
        {
            InitializeComponent();
            btnBuscar.Text = "Agregar Pago";
            btnNuevo.Text = "Confirmar";
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.Visible = false;

            comboBoxCliente.DisplayMember = "Text";
            comboBoxCliente.ValueMember = "Value";
            foreach (Tuple<int, string> o in Cliente.ListarClientes())
            {
                comboBoxCliente.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }

            comboBoxEmpresa.DisplayMember = "Text";
            comboBoxEmpresa.ValueMember = "Value";
            foreach (Tuple<int, string> o in Empresa.ListarEmpresas())
            {
                comboBoxEmpresa.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }

            comboBoxFormaPago.DisplayMember = "Text";
            comboBoxFormaPago.ValueMember = "Value";
            foreach (Tuple<int, string> o in Pago.FormaDePago())
            {
                comboBoxFormaPago.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }
        }

        public override bool AgregarElemento()
        {
            EditorFactura EditorFactura = new EditorFactura(new Factura());
            return EditorFactura.ShowDialog() == DialogResult.OK;
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

        protected override DataTable RecuperarDatos()
        {
            return null;
        }

        protected override void btnBuscar_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex RegexNumero = new System.Text.RegularExpressions.Regex(@"[0-9]+");
            string Numero = textNumero.Text;
            if (!RegexNumero.Match(Numero).Success)
            {
                Generico.MostrarAdvertencia("El Numero de factura debe ser numerico");
                return;
            }

            DataTable DataTable = Factura.Buscar(null, null, Numero);

            if (DataTable.Rows.Count <= 0)
            {
                Generico.MostrarAdvertencia("No se encontro la factura ingresada");
                return;
            }

            int? idEmpresa = comboBoxEmpresa.SelectedItem == null ? null : (comboBoxEmpresa.SelectedItem as dynamic).Value;
            if (idEmpresa == null)
            {
                Generico.MostrarAdvertencia("Seleccione La empresa");
                return;
            }

            if (DataTable.Rows.Count > 1)
            {
                DataTable = Factura.Buscar(null, idEmpresa, Numero);
            }

            Factura Fac = new Factura(
                DataTable.Rows[0].Field<int>("id"),
                DataTable.Rows[0].Field<decimal>("Numero").ToString(),
                DataTable.Rows[0].Field<DateTime>("fecha"),
                DataTable.Rows[0].Field<DateTime>("Vencimiento"),
                DataTable.Rows[0].Field<int>("Cliente ID"),
                DataTable.Rows[0].Field<decimal>("Cliente DNI").ToString(),
                DataTable.Rows[0].Field<int>("Empresa ID"),
                DataTable.Rows[0].Field<string>("Cuit Empresa"),
                DataTable.Rows[0].Field<int?>("Pago ID"),
                DataTable.Rows[0].Field<int?>("Rendicion ID"));
            Fac.Importe = DataTable.Rows[0].Field<decimal>("Importe");

            if (Fac.IdPago != null)
            {
                Generico.MostrarAdvertencia("La factura ya esta paga");
                return;
            }

            if (idEmpresa != Fac.IdEmpresa)
            {
                Generico.MostrarAdvertencia("La empresa ingresada no coincide con la empresa de la factura guardada");
                return;
            }

            int? idCliente = comboBoxCliente.SelectedItem == null ? null : (comboBoxCliente.SelectedItem as dynamic).Value;
            if (idCliente == null)
            {
                Generico.MostrarAdvertencia("Seleccione el cliente");
                return;
            }
            if (idCliente != Fac.IdCliente)
            {
                Generico.MostrarAdvertencia("El cliente ingresado no coincide con el cliente de la factura guardada");
                return;
            }

            if (IdFormaPago == null)
            {
                int? idFormaPago = comboBoxFormaPago.SelectedItem == null ? null : (comboBoxFormaPago.SelectedItem as dynamic).Value;
                if (idFormaPago == null)
                {
                    Generico.MostrarAdvertencia("Seleccione la forma de pago");
                    return;
                }
                IdFormaPago = idFormaPago;
                comboBoxFormaPago.Enabled = false;
            }
            

            DateTime DateTime = dtpVencimiento.Value;
            if (DateTime.ToString("yyyy-MM-dd") != Fac.FechaVencimiento.Value.ToString("yyyy-MM-dd"))
            {
                Generico.MostrarAdvertencia("La fecha de vencimiento ingresada no coincide con la de la factura guardada");
                return;
            }

            System.Text.RegularExpressions.Regex RegexImporte = new System.Text.RegularExpressions.Regex(@"[0-9]+\,[0-9]+");
            string Importe = textBoxImporte.Text;
            if (!RegexImporte.Match(Importe).Success)
            {
                Generico.MostrarAdvertencia("El importe de factura debe ser numerico con ,");
                return;
            }
            if (Importe != Fac.Importe.ToString())
            {
                Generico.MostrarAdvertencia("El importe ingresado no coincide con el de la factura guardada");
                return;
            }

            if (Facturas.Find(f => f.Id == Fac.Id) != null)
            {
                Generico.MostrarAdvertencia("La factura ya fue ingresada");
                return;
            }

            if (Facturas.Find(f => f.IdCliente != Fac.IdCliente) != null)
            {
                Generico.MostrarAdvertencia("El cliente de la factura no coincide con las ya ingresadas");
                return;
            }

            Facturas.Add(Fac);

            dgv.DataSource = null;
            dgv.Update();
            dgv.Refresh();
            dgv.DataSource = Facturas;
            
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name.ToUpper().StartsWith("ID"))
                    col.Visible = false;
            }
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            Pago.Pagar(Facturas, Suc, IdFormaPago.GetValueOrDefault());
            Generico.MostrarInformacion("La operacion fue exitosa");
            dgv.DataSource = null;
            dgv.Update();
            dgv.Refresh();
            Facturas = new List<Factura>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        override public  void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex == Eliminar.Index)
                {
                    Facturas.RemoveAt(e.RowIndex);
                    dgv.DataSource = null;
                    dgv.Update();
                    dgv.Refresh();
                    dgv.DataSource = Facturas;
                }
        }




    }
}
