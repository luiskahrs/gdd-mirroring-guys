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
            decimal dni;

            if (string.IsNullOrEmpty(txtDni.Text))
            {
                dni = 0;
            }
            else if (!decimal.TryParse(txtDni.Text, out dni))
            {
                throw new PagoAgilException("El DNI debe ser un valor numerico.");
            }
            else
            {
            }

            return Cliente.Listar(txtNombre.Text, txtApellido.Text, dni);
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            var cliente = CrearClienteDesdeDataRow(dr);
            var editor = new EditorCliente(cliente);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        protected override void EliminarElemento(DataGridViewRow dr)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar el cliente?", "Eliminar cliente", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cliente cliente = CrearClienteDesdeDataRow(dr);
                cliente.Eliminar();
                this.CargarGrilla();
            }
        }

        public override bool AgregarElemento()
        {
            EditorCliente editor = new EditorCliente(new Cliente());
            return editor.ShowDialog() == DialogResult.OK;
        }

        public Cliente CrearClienteDesdeDataRow(DataGridViewRow dr)
        {
            Cliente cliente = Cliente.Obtener(Convert.ToInt32(dr.Cells["Id"].Value));
            return cliente;
        }     
    }
}
