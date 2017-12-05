using PagoAgilFrba.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class EditorFactura : EditorBase
    {
        private Factura Factura;
        private DataGridViewButtonColumn EliminarItem;

        public EditorFactura(Factura Factura): base(Factura)
        {
            this.Factura = Factura;
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();

            comboBoxCliente.DisplayMember = "Text";
            comboBoxCliente.ValueMember = "Value";
            foreach (Tuple<int, string> o in Cliente.ListarClientes())
            {
                comboBoxCliente.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }
            comboBoxCliente.SelectedText = Factura.DniCliente;
            comboBoxCliente.SelectedValue = Factura.IdCliente;

            comboBoxEmpresa.DisplayMember = "Text";
            comboBoxEmpresa.ValueMember = "Value";
            foreach (Tuple<int, string> o in Empresa.ListarEmpresas())
            {
                comboBoxEmpresa.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }
            comboBoxEmpresa.SelectedText = Factura.CuitEmpresa;
            comboBoxEmpresa.SelectedValue = Factura.IdEmpresa;

            textNumero.Text = Factura.Numero;

            if (Factura.FechaVencimiento!=null) dtpVencimiento.Value = Factura.FechaVencimiento.GetValueOrDefault();

            EliminarItem = new DataGridViewButtonColumn();
            EliminarItem.DefaultCellStyle.NullValue = "Eliminar";
            dvgItemsFactura.Columns.Add(EliminarItem);

            if (Factura.Id != null)
            {
                DataTable DataTable = ItemFactura.ListarPorIdFac(Factura.Id.GetValueOrDefault(-1));

                Factura.Items = new List<ItemFactura>();
                foreach (DataRow d in DataTable.Rows)
                {
                    int Id = d.Field<int>("ID");
                    decimal Monto = d.Field<decimal>("Monto");
                    decimal Cantidad = d.Field<decimal>("Cantidad");
                    ItemFactura ItemFac = new ItemFactura(Id, Monto, Cantidad, Factura.Id.GetValueOrDefault());
                    Factura.Items.Add(ItemFac);
                }

                dvgItemsFactura.DataSource = DataTable;
                foreach (DataGridViewColumn col in dvgItemsFactura.Columns)
                {
                    if (col.Name.ToUpper().EndsWith("ID"))
                        col.Visible = false;
                }
            }

            if (Factura.IdPago != null || Factura.IdRendicion != null)
                btnGuardar.Visible = false;
        }

        protected override void Guardar()
        {
            try
            {
                Factura.IdCliente = (comboBoxCliente.SelectedItem as dynamic).Value;
            }
            catch (Exception) { }

            try
            {
                Factura.IdEmpresa = (comboBoxEmpresa.SelectedItem as dynamic).Value;
            }
            catch (Exception) { }

            Factura.Numero = textNumero.Text;
            Factura.FechaVencimiento = dtpVencimiento.Value;

            Factura.Guardar();
        }

        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();

            try
            {
                if ((comboBoxCliente.SelectedItem as dynamic).Value == null) sbErrores.AppendLine("Ingresar el cliente.");
            }
            catch (Exception)
            {
                if (Factura.IdCliente == null) sbErrores.AppendLine("Ingresar el cliente.");
            }

            try
            {
                if ((comboBoxEmpresa.SelectedItem as dynamic).Value == null) sbErrores.AppendLine("Ingresar la empresa.");
            }
            catch (Exception)
            {
                if (Factura.IdEmpresa == null) sbErrores.AppendLine("Ingresar la empresa.");
            }
            if (String.IsNullOrEmpty(textNumero.Text)) sbErrores.AppendLine("Ingresar el numero.");
            System.Text.RegularExpressions.Regex regexNumero = new System.Text.RegularExpressions.Regex(@"[0-9]+");
            if (!regexNumero.IsMatch(textNumero.Text)) sbErrores.AppendLine("El numero ser numerico.");

            // Traigo la fecha del config y la convierto a DateTime.
            var today = DateTime.Parse(ConfigurationManager.AppSettings.Get("SystemDate"), new CultureInfo("es-ES", true));

            if (dtpVencimiento.Value.CompareTo(today) < 0) sbErrores.AppendLine("Ingresar una fecha de vencimiento posterior a la de hoy.");

            if (Factura.Items.Count <= 0) sbErrores.AppendLine("Ingresar al menos un item.");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpVencimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dvgItemsFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex == EliminarItem.Index)
                {
                    Factura.DeletedItems.Add(Factura.Items[e.RowIndex]);
                    Factura.Items.RemoveAt(e.RowIndex);
                    loadItemsFacturaList();
                }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            StringBuilder errs = new StringBuilder();

            System.Text.RegularExpressions.Regex regexNumero = new System.Text.RegularExpressions.Regex(@"[0-9]+");
            if (String.IsNullOrEmpty(textBoxCantidad.Text)) 
            {
                errs.AppendLine("Ingrese la cantidad");
            }
            else
            {
                if (!regexNumero.IsMatch(textBoxCantidad.Text)) errs.AppendLine("La cantidad debe ser numerica");
            }
            

            if (String.IsNullOrEmpty(textBoxMonto.Text)) 
            {
                errs.AppendLine("Ingrese el monto");
            }
            else
            {
                if (!regexNumero.IsMatch(textBoxMonto.Text)) errs.AppendLine("El monto debe ser numerico");
            }

            if (errs.Length > 0) Generico.MostrarAdvertencia(errs.ToString());

            ItemFactura ItemFactura = new ItemFactura(int.Parse(textBoxMonto.Text), int.Parse(textBoxCantidad.Text), Factura.Id.GetValueOrDefault());
            Factura.Items.Add(ItemFactura);
            Factura.AddedItems.Add(ItemFactura);

            loadItemsFacturaList();
        }

        private void loadItemsFacturaList()
        {
            List<object> source = new List<object>();
            foreach (ItemFactura i in Factura.Items)
            {
                source.Add(new { Cantidad = i.Cantidad, Monto = i.Monto });
            }
            dvgItemsFactura.DataSource = source;
        }
       
    }
}
