using PagoAgilFrba.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba
{

    using System.Collections.Generic;

    public partial class AbmRendicion : FormListaBase
    {
        decimal Total = 0;
        List<int> ids = new List<int>();

        public AbmRendicion()
        {
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();
            Seleccionar.Visible = false; 
            Eliminar.Visible = false; 
        }
        
        protected override DataTable RecuperarDatos()
        {
            DataTable DataTable = Rendicion.Listar();

            foreach (DataRow dr in DataTable.Rows)
            {
                Total += dr.Field<decimal>("Total");
                ids.Add(dr.Field<int>("id"));
            }
            txtTotal.Text = Total.ToString();
            txtCantidad.Text = DataTable.Rows.Count.ToString();

            if (Total == 0) buttonRendir.Enabled = false;
            return DataTable;
        }

        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ckEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected override void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Text.RegularExpressions.Regex regexCodPost = new System.Text.RegularExpressions.Regex(@"[0-9]+");
                if (!regexCodPost.Match(((TextBox)sender).Text).Success)
                {
                    Generico.MostrarAdvertencia("El porcentaje debe ser numerico");
                    return;
                }

                int Porcentaje = int.Parse(((TextBox)sender).Text);
                if (Porcentaje > 100)
                {
                    Generico.MostrarAdvertencia("El porcentaje debe estar entres 0 y 100");
                    return;
                }
                
                
                decimal ARendir = (this.Total * Porcentaje / 100);
                txtARendir.Text = ARendir.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void buttonRendir_Click(object sender, EventArgs e)
        {
            buttonRendir.Enabled = false;
            Rendicion.Rendir(ids, int.Parse(txtPorcentaje.Text));
        }
    }
}
