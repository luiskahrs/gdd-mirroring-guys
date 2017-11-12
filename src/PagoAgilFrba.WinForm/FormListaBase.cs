using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class FormListaBase : Form
    {
        protected DataGridViewButtonColumn Seleccionar;
        protected DataGridViewButtonColumn Eliminar;
        public FormListaBase()
        {
            InitializeComponent();
        }

        private void FormListaBase_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;

                Seleccionar = new DataGridViewButtonColumn()
                {
                    ReadOnly = false,
                    DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, NullValue = "Seleccionar", WrapMode = DataGridViewTriState.False }
                };
                Eliminar = new DataGridViewButtonColumn()
                {
                    ReadOnly = false,
                    DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter, NullValue = "Eliminar", WrapMode = DataGridViewTriState.False }
                };
                InicializarFormulario();
                CargarGrilla();
                //agrego las 2 columas para poder abrir y borrar elementos
                dgv.Columns.AddRange(Seleccionar,Eliminar);

                foreach (DataGridViewColumn col in dgv.Columns)
	            {
                    if (col.Name.ToUpper().EndsWith("ID"))
                        col.Visible = false;
	            } 
            }
            catch
            {
                Generico.MostrarError("Ocurrió un error al iniciar el formulario.");
            }
        }

        protected virtual void InicializarFormulario()
        {
            
        }

        protected virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrilla();
            }
            catch 
            {
                MessageBox.Show("Ocurrió un error al obtener los datos.");
            }
        }

        protected void CargarGrilla()
        {
            dgv.DataSource = RecuperarDatos();
        }

        protected virtual DataTable RecuperarDatos()
        {
            throw new NotImplementedException("Debe hacer override del método RecuperarDatos.");
        }

        public virtual void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex == Eliminar.Index)
                {
                    EliminarElemento(ObtenerDataRow(e.RowIndex));
                }
                else if (e.ColumnIndex == Seleccionar.Index)
                {
                    AbrirElemento(ObtenerDataRow(e.RowIndex));
                }
        }
        
        protected virtual void AbrirElemento(DataGridViewRow dr)
        {
            //throw new NotImplementedException();
        }

        protected virtual void EliminarElemento(DataGridViewRow dr)
        {
            //throw new NotImplementedException("No está implementada la función Eliminar");
        }
        public virtual DataGridViewRow ObtenerDataRow(int rowIndex) 
        {
            return dgv.Rows[rowIndex];
        }
        public virtual int GetID(int rowIndex)
        {
            DataGridViewRow fila = dgv.Rows[rowIndex];
            return Convert.ToInt32(fila.Cells["Id"].Value); 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in grpBusqueda.Controls)
            {
                if (c is TextBox)
                    (c as TextBox).Text = string.Empty;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (AgregarElemento())
                    CargarGrilla();
            }
            catch
            {
                Generico.MostrarError("Ocurrió un error al intentar agregar un nuevo elemento.");
            }
            
        }

        public virtual bool AgregarElemento()
        {
            return false;
        }
    }
}
