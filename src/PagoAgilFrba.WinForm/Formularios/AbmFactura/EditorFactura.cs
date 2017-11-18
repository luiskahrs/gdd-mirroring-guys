using PagoAgilFrba.Core;
using System;
using System.Collections.Generic;
using System.Data;
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

            dtpVencimiento.Value = Factura.FechaVencimiento;

            if (Factura.Id != null)
            {
                dvgItemsFactura.DataSource = ItemFactura.ListarPorIdFac(Factura.Id.GetValueOrDefault(-1));
                foreach (DataGridViewColumn col in dvgItemsFactura.Columns)
                {
                    if (col.Name.ToUpper().EndsWith("ID"))
                        col.Visible = false;
                }
            }
            else
            {
                dvgItemsFactura.Columns.AddRange(EliminarItem);
            }
        }

        protected override void Guardar()
        {
            throw new NotImplementedException("No está implementada la función Eliminar");
        }

        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();
            
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
                    DataGridViewRow DataGridViewRow = dvgItemsFactura.Rows[e.RowIndex];
                    int ItemId = int.Parse(DataGridViewRow.Cells["id"].Value.ToString());
                    (new ItemFactura(ItemId)).Borrar();
                    dvgItemsFactura.DataSource = ItemFactura.ListarPorIdFac(Factura.Id.GetValueOrDefault(-1));
                    foreach (DataGridViewColumn col in dvgItemsFactura.Columns)
                    {
                        if (col.Name.ToUpper().EndsWith("ID"))
                            col.Visible = false;
                    }
                }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }
       
    }
}
