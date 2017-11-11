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
            txtNombre.Text = _cliente.EsNuevo()? "Nuevo Cliente" : _cliente.Nombre;
            ckHabilitado.Checked = _cliente.Habilitado;
        }
        protected override void Guardar()
        {
            //_rol.Nombre = txtNombre.Text;
            //_rol.Habilitado = ckHabilitado.Checked;
            //_rol.Funcionalidades = new List<int>();
            
            //List<DataGridViewRow> filasCheckeadas = new List<DataGridViewRow>();
            //foreach (DataGridViewRow row in dgFuncionalidades.Rows)
            //{
            //    //Si la primer columna de los checks, está en true, guardo los privilegios
            //    if (Convert.ToInt16(row.Cells[0].Value) == 1)
            //        _rol.Funcionalidades.Add(Convert.ToInt32(row.Cells[2].Value));
            //}
            //_rol.Guardar();
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
