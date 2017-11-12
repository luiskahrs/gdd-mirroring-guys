namespace PagoAgilFrba
{
    using Core;
    using System;

    public partial class EditorSucursal : EditorBase
    {
        Sucursal _sucursal;

        public EditorSucursal(Sucursal sucursal) : base(sucursal)
        {
            _sucursal = sucursal;
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();

            if (_sucursal.EsNuevo())
            {
                LimpiarFormulario();
            }
            else
            {
                CargarFormulario(_sucursal);
            }
        }

        protected override void Guardar()
        {
            _sucursal.Nombre = txtNombre.Text;
            _sucursal.Direccion.Calle = txtDireccion.Text;
            _sucursal.Direccion.Codigo_Postal = txtCodPostal.Text;
            _sucursal.Habilitado = ckHabilitado.Checked;

            _sucursal.Guardar();
        }

        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();
            decimal decPrueba;

            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                sbErrores.AppendLine("Debe indicar el nombre de la sucursal.");
            }

            if (!_sucursal.ValidarCodigoPostal(txtCodPostal.Text))
            {
                sbErrores.AppendLine("Ya existe una sucursal asociada al codigo postal en la base de datos. Ingrese uno distinto.");
            }

            if (String.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                sbErrores.AppendLine("Debe indicar la dirección de la sucursal.");
            }

            if (String.IsNullOrWhiteSpace(txtCodPostal.Text))
            {
                sbErrores.AppendLine("Debe indicar el codigo postal de la sucursal.");
            }
            else
            { 
                if (!decimal.TryParse(txtCodPostal.Text, out decPrueba))
                {
                    sbErrores.AppendLine("El codigo postal tiene que ser numérico.");
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            ckHabilitado.Checked = true;
        }

        private void CargarFormulario(Sucursal sucursal)
        {
            txtNombre.Text = sucursal.Nombre;
            txtDireccion.Text = sucursal.Direccion.Calle;
            txtCodPostal.Text = sucursal.Direccion.Codigo_Postal;
            ckHabilitado.Checked = sucursal.Habilitado;
        }
    }
}
