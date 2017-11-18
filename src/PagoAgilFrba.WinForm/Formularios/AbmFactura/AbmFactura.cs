﻿using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class AbmFactura : FormListaBase
    {
        public AbmFactura()
        {
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.DefaultCellStyle.NullValue = "Modificar";
            Eliminar.Visible = false;

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
        }
        
        protected override DataTable RecuperarDatos()
        {
            return Factura.ListarParaAbm();
        }

        public override bool AgregarElemento()
        {
            return false;
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            int Id = int.Parse(dr.Cells["id"].Value.ToString());
            string Numero = dr.Cells["Numero"].Value.ToString();
            DateTime Fecha = DateTime.Parse(dr.Cells["fecha"].Value.ToString());
            DateTime FechaVencimiento = DateTime.Parse(dr.Cells["Vencimiento"].Value.ToString());
            int IdCliente = int.Parse(dr.Cells["Cliente ID"].Value.ToString());
            //string ClienteNombre = dr.Cells["Nombre Cliente"].Value.ToString();
            //string ClienteApellido = dr.Cells["Apellido Cliente"].Value.ToString();
            string ClenteDni = dr.Cells["Cliente DNI"].Value.ToString();
            int IdEmpresa = int.Parse(dr.Cells["Empresa ID"].Value.ToString());
            //string NombreEmpresa = dr.Cells["Nombre Empresa"].Value.ToString();
            string CuitEmpresa = dr.Cells["Cuit Empresa"].Value.ToString();
            int IdPago = int.Parse(dr.Cells["Pago ID"].Value.ToString());
            int IdRendicion = int.Parse(dr.Cells["Rendicion ID"].Value.ToString());

            Factura Factura = new Factura(Id, Numero, Fecha, FechaVencimiento, IdCliente, ClenteDni, IdEmpresa, CuitEmpresa, IdPago, IdRendicion);

            EditorFactura editor = new EditorFactura(Factura);
            
            if (editor.ShowDialog() == DialogResult.OK)
                CargarGrilla();
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
            int? idCliente = comboBoxCliente.SelectedItem == null ? null : (comboBoxCliente.SelectedItem as dynamic).Value;
            int? idEmpresa = comboBoxEmpresa.SelectedItem == null ? null : (comboBoxEmpresa.SelectedItem as dynamic).Value;
            string Numero = textNumero.Text;

            dgv.DataSource = Factura.Buscar(idCliente, idEmpresa, Numero);
        }

        private void AbmFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
