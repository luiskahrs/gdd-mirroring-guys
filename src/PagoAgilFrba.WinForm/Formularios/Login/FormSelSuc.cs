namespace PagoAgilFrba
{
    using PagoAgilFrba.Core;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class FormSelSuc : Form
    {
        private Sucursal _sucursal;

        public Sucursal Sucursal
        {
            get
            {
                return _sucursal;
            }
        }

        public FormSelSuc(List<Sucursal> sucursales)
        {
            InitializeComponent();

            _sucursal = new Sucursal();
            cbSucursales.DisplayMember = "Text";
            cbSucursales.ValueMember = "Value";

            foreach (Sucursal suc in sucursales)
            {
                cbSucursales.Items.Add(new { Text = suc.Nombre, Value = suc.Id });
            }

            cbSucursales.SelectedIndex = 0;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            _sucursal.Nombre = (cbSucursales.SelectedItem as dynamic).Text;
            _sucursal.Id = (cbSucursales.SelectedItem as dynamic).Value;

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
