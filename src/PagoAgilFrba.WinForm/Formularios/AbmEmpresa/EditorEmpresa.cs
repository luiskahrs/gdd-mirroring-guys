using PagoAgilFrba.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class EditorEmpresa : EditorBase
    {
        private Empresa Empresa;
        
        public EditorEmpresa(Empresa Empresa) : base(Empresa)
        {
            this.Empresa = Empresa;
            InitializeComponent();
        }

        protected override void InicializarFormulario()
        {
            base.InicializarFormulario();

            comboBoxRubro.DisplayMember = "Text";
            comboBoxRubro.ValueMember = "Value";
            foreach (Tuple<int, string> o in Rubro.ListarDescripciones())
            {
                comboBoxRubro.Items.Add(new { Value = o.Item1, Text = o.Item2 });
            }
            textDireccion.Text = Empresa.Direccion;
            textDiaRedencion.Text = Empresa.DiaRedencion;
            tbCodigoPostal.Text = Empresa.CodigoPostal;
            txtNombre.Text = Empresa.Nombre;
            ckActiva.Checked = Empresa.IsActiva;
            textDiaRedencion.Text = Empresa.DiaRedencion;
            comboBoxRubro.SelectedText = Empresa.Rubro;
            comboBoxRubro.SelectedValue = Empresa.IdRubro;
            textCuit.Text = Empresa.Cuit;
            if (Empresa.Id != null)
                textCuit.Enabled = false;
        }

        protected override void Guardar()
        {
            Empresa.Nombre = txtNombre.Text;
            Empresa.Cuit = textCuit.Text;
            Empresa.Direccion = textDireccion.Text;
            Empresa.CodigoPostal = tbCodigoPostal.Text;
            Empresa.IsActiva = ckActiva.Checked;
            Empresa.DiaRedencion = textDiaRedencion.Text;

            if (comboBoxRubro.SelectedItem != null)
            {
                Empresa.Rubro = (comboBoxRubro.SelectedItem as dynamic).Text;
                string IdRub = (comboBoxRubro.SelectedItem as dynamic).Value.ToString();
                Empresa.IdRubro = int.Parse(IdRub);
            }

            Empresa.Guardar();
        }

        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
                sbErrores.AppendLine("Debe ingresar el nombre.");

            System.Text.RegularExpressions.Regex regexCodPost = new System.Text.RegularExpressions.Regex(@"[0-9]+");
            if (!regexCodPost.Match(tbCodigoPostal.Text).Success)
                sbErrores.AppendLine("Debe ingresar un Codigo postal valido.");

            if (!regexCodPost.Match(textDiaRedencion.Text).Success)
                sbErrores.AppendLine("Debe ingresar un dia de redencion numerico.");

            if (int.Parse(textDiaRedencion.Text) > 28)
                sbErrores.AppendLine("Debe ingresar un dia de redencion valido.");

            string Cuit = textCuit.Text;
            System.Text.RegularExpressions.Regex regexCuit = new System.Text.RegularExpressions.Regex(@"[0-9]-[0-9]{8}-[0-9]");
            if (!regexCuit.Match(Cuit).Success)
                sbErrores.AppendLine("Debe ingresar un cuit valido.");

            if (Empresa.Id != null && !ckActiva.Checked && Empresa.IsActiva && Factura.EmpresaTieneFacturasPagasNoRendidas(Empresa.Id.GetValueOrDefault(-1)))
                sbErrores.AppendLine("La empresa tiene facturas pagas sin rendir.");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRubro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
