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
            textCuit.Text = Empresa.Cuit;
            ckActiva.Checked = Empresa.IsActiva;
            textDiaRedencion.Text = Empresa.DiaRedencion;
            comboBoxRubro.SelectedText = Empresa.Rubro;
            comboBoxRubro.SelectedValue = Empresa.IdRubro;
        }

        protected override void Guardar()
        {
            Empresa.Guardar();
        }

        protected override void RealizarValidaciones()
        {
            sbErrores.Clear();
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
                sbErrores.AppendLine("Debe ingresar el nombre.");

            System.Text.RegularExpressions.Regex regexCuit = new System.Text.RegularExpressions.Regex(@"[0-9]{2}-[0-9]{8}-[0-9]{2}");
            if (!regexCuit.Match(textCuit.Text).Success)
                sbErrores.AppendLine("Debe ingresar un cuit valido.");

            System.Text.RegularExpressions.Regex regexCodPost = new System.Text.RegularExpressions.Regex(@"[0-9]+");
            if (!regexCodPost.Match(tbCodigoPostal.Text).Success)
                sbErrores.AppendLine("Debe ingresar un Codigo postal valido.");

            if (!regexCodPost.Match(textDiaRedencion.Text).Success)
                sbErrores.AppendLine("Debe ingresar un dia de redencion numerico.");

            if (int.Parse(textDiaRedencion.Text) > 31)
                sbErrores.AppendLine("Debe ingresar un dia de redencion valido.");
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
