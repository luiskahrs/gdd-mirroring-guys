namespace PagoAgilFrba
{
    using PagoAgilFrba.Core;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class AbmCliente : FormListaBase
    {
        public AbmCliente()
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
                dni = 0;
            }

            return Cliente.Listar(txtNombre.Text, txtApellido.Text, dni);
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            Rol rol = CrearRolDesdeDataRow(dr);
            EditorRol editor = new EditorRol(rol);
            if (editor.ShowDialog() == DialogResult.OK)
                CargarGrilla();
        }

        public override bool AgregarElemento()
        {
            EditorRol editor = new EditorRol(new Rol());
            return editor.ShowDialog() == DialogResult.OK;
        }
        public Rol CrearRolDesdeDataRow(DataGridViewRow dr)
        {
            return new Rol()
            {
                Id = Convert.ToInt32(dr.Cells["Id"].Value),
                Habilitado = Convert.ToBoolean(dr.Cells["Habilitado"].Value),
                Nombre = dr.Cells["Nombre"].Value.ToString()
            };
        }     
    }
}
