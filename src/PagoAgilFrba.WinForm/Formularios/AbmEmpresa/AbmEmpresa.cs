using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class AbmEmpresa : FormListaBase
    {
        public AbmEmpresa()
        {
            InitializeComponent();
            comboBoxRubro.DisplayMember = "Text";
            comboBoxRubro.ValueMember = "Value";
            foreach (Tuple<int, string> o in Rubro.ListarDescripciones())
            {
                comboBoxRubro.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.DefaultCellStyle.NullValue = "Modificar";
            Eliminar.Visible = false; 
        }
        
        protected override DataTable RecuperarDatos()
        {
            return Empresa.Listar();
        }

        public override bool AgregarElemento()
        {
            EditorEmpresa editor = new EditorEmpresa(new Empresa());
            return editor.ShowDialog() == DialogResult.OK;
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
            int idRubro = comboBoxRubro.SelectedItem == null ? -1 : (comboBoxRubro.SelectedItem as dynamic).Value;
            dgv.DataSource = Empresa.Listar(txtNombre.Text, textCuit.Text, idRubro);
        }
    }
}
