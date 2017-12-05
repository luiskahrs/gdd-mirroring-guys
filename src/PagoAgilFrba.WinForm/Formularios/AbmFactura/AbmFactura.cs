using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

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
            EditorFactura EditorFactura = new EditorFactura(new Factura());
            return EditorFactura.ShowDialog() == DialogResult.OK;
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            int Id = int.Parse(dr.Cells["id"].Value.ToString());
            string Numero = dr.Cells["Numero"].Value.ToString();
            DateTime Fecha = DateTime.ParseExact(dr.Cells["fecha"].Value.ToString(), "yyyy-MM-dd", new CultureInfo("es-ES", true));
            DateTime FechaVencimiento = DateTime.ParseExact(dr.Cells["Vencimiento"].Value.ToString(), "yyyy-MM-dd", new CultureInfo("es-ES", true));
            int IdCliente = int.Parse(dr.Cells["Cliente ID"].Value.ToString());
            //string ClienteNombre = dr.Cells["Nombre Cliente"].Value.ToString();
            //string ClienteApellido = dr.Cells["Apellido Cliente"].Value.ToString();
            string ClenteDni = dr.Cells["Cliente DNI"].Value.ToString();
            int IdEmpresa = int.Parse(dr.Cells["Empresa ID"].Value.ToString());
            //string NombreEmpresa = dr.Cells["Nombre Empresa"].Value.ToString();
            string CuitEmpresa = dr.Cells["Cuit Empresa"].Value.ToString();
            
            int? IdPago = null;
            if (!String.IsNullOrEmpty(dr.Cells["Pago ID"].Value.ToString()))
                IdPago = int.Parse(dr.Cells["Pago ID"].Value.ToString());

            int? IdRendicion = null;
            if (!String.IsNullOrEmpty(dr.Cells["Rendicion ID"].Value.ToString()))
                IdRendicion = int.Parse(dr.Cells["Rendicion ID"].Value.ToString());

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
