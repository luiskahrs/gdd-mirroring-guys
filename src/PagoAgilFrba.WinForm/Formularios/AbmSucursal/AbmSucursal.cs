namespace PagoAgilFrba
{
    using Core;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class AbmSucursal : FormListaBase
    {
        public AbmSucursal()
        {
            InitializeComponent();
        }
        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
        }
        protected override DataTable RecuperarDatos()
        {
            int codPostal;

            if (!string.IsNullOrEmpty(txtCodigoPostal.Text) && !int.TryParse(txtCodigoPostal.Text, out codPostal))
            {
                throw new PagoAgilException("El Codigo Postal debe ser un valor numerico.");
            }
            else
            {
            }

            return Sucursal.Listar(txtNombre.Text, txtDireccion.Text, txtCodigoPostal.Text);
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            var sucursal = CrearSucursalDesdeDataRow(dr);
            var editor = new EditorSucursal(sucursal);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        protected override void EliminarElemento(DataGridViewRow dr)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar la sucursal? Se deshabilitaran todos los usuarios asociados.", "Eliminar sucursal", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var sucursal = CrearSucursalDesdeDataRow(dr);
                sucursal.Eliminar();
                this.CargarGrilla();
            }
        }

        public override bool AgregarElemento()
        {
            EditorSucursal editor = new EditorSucursal(new Sucursal());
            return editor.ShowDialog() == DialogResult.OK;
        }

        public Sucursal CrearSucursalDesdeDataRow(DataGridViewRow dr)
        {
            var sucursal = Sucursal.Obtener(Convert.ToInt32(dr.Cells["Id"].Value));
            return sucursal;
        }     
    }
}
