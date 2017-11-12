using PagoAgilFrba.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class EditorCliente : EditorBase
    {
        Cliente _cliente;

        public EditorCliente(Cliente cliente) : base(cliente)
        {
            _cliente = cliente;
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();

            if (_cliente.EsNuevo())
            {
                LimpiarFormulario();
            }
            else
            {
                CargarFormulario(_cliente);
            }   
        }

        protected override void Guardar()
        {
            _cliente.Nombre = txtNombre.Text;
            _cliente.Apellido = txtApellido.Text;
            _cliente.DNI = decimal.Parse(txtDNI.Text);
            _cliente.Email = txtMail.Text;
            _cliente.Telefono = txtTelefono.Text;
            _cliente.Direccion.Calle = txtDireccion.Text;
            _cliente.Direccion.Codigo_Postal = txtCodPostal.Text;
            _cliente.Fecha_Nacimiento = dtpFecNac.Value;

            _cliente.Guardar();
        }

        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();
            decimal decPrueba;

            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                sbErrores.AppendLine("Debe indicar el nombre del cliente.");
            }

            if (String.IsNullOrWhiteSpace(txtApellido.Text))
            {
                sbErrores.AppendLine("Debe indicar el apellido del cliente.");
            }

            if (String.IsNullOrWhiteSpace(txtDNI.Text))
            {
                sbErrores.AppendLine("Debe indicar el DNI del cliente.");
            }

            if (!decimal.TryParse(txtDNI.Text, out decPrueba))
            {
                sbErrores.AppendLine("El DNI tiene que ser numérico.");
            }

            if (String.IsNullOrWhiteSpace(txtMail.Text))
            {
                sbErrores.AppendLine("Debe indicar el mail del cliente.");
            }

            if (String.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                sbErrores.AppendLine("Debe indicar el telefono del cliente.");
            }

            if (String.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                sbErrores.AppendLine("Debe indicar la dirección del cliente.");
            }

            if (String.IsNullOrWhiteSpace(txtCodPostal.Text))
            {
                sbErrores.AppendLine("Debe indicar el codigo postal del cliente.");
            }

            if (!decimal.TryParse(txtCodPostal.Text, out decPrueba))
            {
                sbErrores.AppendLine("El codigo postal tiene que ser numérico.");
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            dtpFecNac.Value = DateTime.Now;
        }

        private void CargarFormulario(Cliente cliente)
        {
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtDNI.Text = cliente.DNI.ToString();
            txtMail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            txtDireccion.Text = cliente.Direccion.Calle;
            txtCodPostal.Text = cliente.Direccion.Codigo_Postal;
            dtpFecNac.Value = cliente.Fecha_Nacimiento;
        }
    }
}
