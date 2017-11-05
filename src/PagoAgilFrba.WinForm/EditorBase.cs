using PagoAgilFrba.Core;
using System;
using System.Text;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class EditorBase : Form
    {
        EntidadBase _entidad;
        public StringBuilder sbErrores = new StringBuilder();
        private EditorBase() : this(null) { }
        protected EditorBase(EntidadBase entidad)
        {
            _entidad = entidad;
            InitializeComponent();
        }

        private void EditorBase_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                if (_entidad == null)
                    throw new Exception("No se ha indicado la entidad");
                this.Text = _entidad.EsNuevo() ? "Nuevo registro" : "Consulta";

                InicializarFormulario();
            }
            catch (Exception ex)
            {
                Generico.MostrarError(ex);
                this.Close();
            }
        }

        protected virtual void InicializarFormulario()
        {
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            try
            {
                RealizarValidaciones();
                if (sbErrores.Length > 0)
                    throw new PagoAgilException(sbErrores.ToString());

                Guardar();

                Generico.MostrarInformacion("Se guardaron correctamente los datos.");
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

        protected virtual void RealizarValidaciones()
        { }

        protected virtual void Guardar()
        {
            _entidad.Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
