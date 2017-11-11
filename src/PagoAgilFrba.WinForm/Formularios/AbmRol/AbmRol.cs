using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class AbmRol : FormListaBase
    {
        public AbmRol()
        {
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.DefaultCellStyle.NullValue = "Modificar";
            Eliminar.Visible = false; //Oculto la columna, porque los roles se deshabilitan desde el form de edicion.
            ckEstado.SetItemChecked(0, true);
            ckEstado.SetSelected(0, true);
        }
        
        protected override DataTable RecuperarDatos()
        {
            return Rol.Listar(txtNombreRol.Text, ckEstado.SelectedItem.ToString());
        }

        protected override void AbrirElemento(DataGridViewRow dr)
        {
            Rol rol = CrearRolDesdeDataRow(dr);
            EditorRol editor = new EditorRol(rol);
            if (editor.ShowDialog() == DialogResult.OK)
                CargarGrilla();
        }

        private void ckEstado_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < ckEstado.Items.Count; ++ix)
                    if (e.Index != ix) ckEstado.SetItemChecked(ix, false);
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
