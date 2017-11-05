using PagoAgilFrba.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class EditorRol : EditorBase
    {
        Rol _rol;
        public EditorRol(Rol rol) : base(rol)
        {
            _rol = rol;
            InitializeComponent();
        }
        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            DataTable dt = _rol.ObtenerFuncionalidades();
            txtNombre.Text = _rol.EsNuevo()? "Nuevo rol" : _rol.Nombre;
            ckHabilitado.Checked = _rol.Habilitado;

            //Cargo los privilegios
            foreach (DataRow dr in dt.Rows)
                dgFuncionalidades.Rows.Add(dr.ItemArray);
        }
        protected override void Guardar()
        {
            _rol.Nombre = txtNombre.Text;
            _rol.Habilitado = ckHabilitado.Checked;
            _rol.Funcionalidades = new List<int>();
            
            List<DataGridViewRow> filasCheckeadas = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgFuncionalidades.Rows)
            {
                //Si la primer columna de los checks, está en true, guardo los privilegios
                if (Convert.ToInt16(row.Cells[0].Value) == 1)
                    _rol.Funcionalidades.Add(Convert.ToInt32(row.Cells[2].Value));
            }
            _rol.Guardar();
        }
        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
                sbErrores.AppendLine("Debe indicar el nombre del rol.");
            bool tildoAlguno = false;
            //Recorro los privilegios y veo si tildo al menos uno
            foreach (DataGridViewRow row in dgFuncionalidades.Rows)
            {
                //Si la primer columna de los checks, está en true, guardo los privilegios
                if (Convert.ToInt16(row.Cells[0].Value) == 1)
                { tildoAlguno = true; break; }
            }
            if (!tildoAlguno)
                sbErrores.AppendLine("Debe seleccionar al menos un privilegio.");
        }
       
    }
}
