using PagoAgilFrba.Core;
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
            string Id = dr.Cells["id"].Value.ToString();
            string Nombre = dr.Cells["Nombre"].Value.ToString();
            string Cuit = dr.Cells["CUIT"].Value.ToString();
            bool IsActiva = dr.Cells["Esta Activa"].Value.ToString() == "si";
            string DiaRedencion = dr.Cells["Dia de rendencion"].Value.ToString();
            string IdDireccion = dr.Cells["Direccion ID"].Value.ToString();
            string Direccion = dr.Cells["Direccion"].Value.ToString();
            string CodigoPostal = dr.Cells["Codigo Postal"].Value.ToString();
            string Rubro = dr.Cells["Rubro"].Value.ToString();
            string IdRubro = dr.Cells["Rubro ID"].Value.ToString();

            Empresa Empresa = new Empresa(int.Parse(Id), Nombre, Cuit, int.Parse(IdDireccion), Direccion, CodigoPostal, Rubro, int.Parse(IdRubro), IsActiva, DiaRedencion);

            EditorEmpresa editor = new EditorEmpresa(Empresa);
            
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
