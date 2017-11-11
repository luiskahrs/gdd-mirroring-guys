using PagoAgilFrba.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Formularios.Login
{
    public partial class FormSelRol : Form
    {
        private Rol _rol;

        public Rol Rol
        {
            get
            {
                return _rol;
            }
        }

        public FormSelRol(List<Rol> roles)
        {
            InitializeComponent();

            _rol = new Rol();
            cbRoles.DisplayMember = "Text";
            cbRoles.ValueMember = "Value";

            foreach (Rol rol in roles)
            {
                cbRoles.Items.Add(new { Text = rol.Nombre, Value = rol.Id });
            }

            cbRoles.SelectedIndex = 0;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            _rol.Nombre = (cbRoles.SelectedItem as dynamic).Text;
            _rol.Id = (cbRoles.SelectedItem as dynamic).Value;

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
