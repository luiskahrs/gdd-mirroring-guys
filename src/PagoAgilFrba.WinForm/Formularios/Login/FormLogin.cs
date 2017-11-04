using PagoAgilFrba.Core;
using System;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class FormLogin : Form
    {
        private Usuario _usuario;
        public Usuario Usuario { get { return _usuario; } } //nose porque no me reconoce la clase cliente :S 
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtUsuario.Text))
                    throw new PagoAgilException("Debe ingresar el nombre de usuario.");
                if (String.IsNullOrWhiteSpace(txtPassword.Text))
                    throw new PagoAgilException("Debe ingresar su contraseña.");

                _usuario = Usuario.Loguear(txtUsuario.Text, txtPassword.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (PagoAgilException exN)
            {
                Generico.MostrarAdvertencia(exN.Message);
            }
            catch (Exception ex)
            {
                Generico.MostrarError(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
