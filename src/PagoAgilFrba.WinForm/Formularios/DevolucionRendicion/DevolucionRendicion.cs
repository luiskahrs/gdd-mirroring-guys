using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class DevolucionRendicion : FormListaBase
    {
        public DevolucionRendicion()
        {
            InitializeComponent();
            btnNuevo.Visible = false;
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.DefaultCellStyle.NullValue = "Devolver";
            Eliminar.Visible = false;
        }
        
        protected override DataTable RecuperarDatos()
        {
            return Factura.getRendidas("");
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            string Id = dr.Cells["id"].Value.ToString();

            Factura.DesRendir(int.Parse(Id));

            Generico.MostrarInformacion("Se guardaron correctamente los datos.");
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
            string Nro = txtNroFactura.Text;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[0-9]+");
            if (!regex.Match(Nro).Success && Nro != "ALL")
            {
                Generico.MostrarAdvertencia("El Numero de factura debe ser numerico o 'ALL' para ver todas");
                return;
            }

            if (Nro == "ALL")
            {
                dgv.DataSource = Factura.getRendidas("ALL");
            }
            else
            {
                dgv.DataSource = Factura.getRendidas(Nro);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
