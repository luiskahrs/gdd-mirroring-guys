namespace PagoAgilFrba
{
    using PagoAgilFrba.Core;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FormPrincipal : Form
    {
        Usuario _usuario;
        Sucursal _sucursal;

        public FormPrincipal(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            var dtPrivilegios = new DataTable();

            try
            {
                // Tengo que mostrar si tiene mas de un rol el pop up
                var dtRoles = _usuario.ObtenerRoles();

                if (dtRoles.Rows.Count > 1)
                {
                    var roles = new List<Rol>();

                    foreach (DataRow dr in dtRoles.Rows)
                    {
                        roles.Add(new Rol
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["nombre"].ToString()
                        });
                    }

                    var formRoles = new FormSelRol(roles);

                    if (formRoles.ShowDialog() == DialogResult.OK)
                    {
                        dtPrivilegios = _usuario.ObtenerPrivilegios(formRoles.Rol.Id.Value);
                    }
                }
                else
                {
                    dtPrivilegios = _usuario.ObtenerPrivilegios();
                }

                if (dtPrivilegios == null || dtPrivilegios.Rows.Count == 0)
                {
                    throw new PagoAgilException("No tiene ningun privilegio");
                }

                foreach (DataRow dr in dtPrivilegios.Rows)
                {
                    TreeNode nodo = treeView1.Nodes.Add(dr["nombre"].ToString());
                    nodo.Tag = dr["formulario"];
                }

                // Hacemos lo mismo que rol, pero para sucursal
                var dtSucursales = _usuario.ObtenerSucursales();

                if (dtSucursales.Rows.Count > 1)
                {
                    var sucursales = new List<Sucursal>();

                    foreach (DataRow dr in dtSucursales.Rows)
                    {
                        sucursales.Add(new Sucursal
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["nombre"].ToString()
                        });
                    }

                    var formSucursales = new FormSelSuc(sucursales);

                    if (formSucursales.ShowDialog() == DialogResult.OK)
                    {
                        _sucursal = formSucursales.Sucursal;
                    }
                }
                else
                {
                    if (dtSucursales == null || dtSucursales.Rows.Count == 0)
                    {
                        throw new PagoAgilException("No tiene ninguna sucursal asociada.");
                    }

                    var sucursal = new Sucursal()
                    {
                        Id = (int)dtSucursales.Rows[0]["Id"],
                        Nombre = dtSucursales.Rows[0]["nombre"].ToString()
                    };

                    _sucursal = sucursal;
                }

                this.Text = String.Format("Pago Agil Frba (Main) - Usuario Logueado: {0} Sucursal: {1}", _usuario.Username, _sucursal.Nombre);
            }
            catch (Exception ex)
            {
                Generico.MostrarError(ex);
                this.Close();
            }
 
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string formulario = e.Node.Tag as String;
            AbrirFormulario(formulario);
        }

        private void AbrirFormulario(string formulario)
        {
            var type = Type.GetType(formulario);
            if (type == null) return;
            Form newChild = Activator.CreateInstance(type) as Form;
            if (newChild == null) return;
            if (tabControl1.TabPages.ContainsKey(newChild.Name))
            {
                SeleccionarSolapa(newChild.Text);
                return;
            }
            TabPage childTab = new TabPage();         //create new tab page
            newChild.MdiParent = this;                       //set as child of this form
            newChild.Dock = DockStyle.Fill;
            newChild.TopLevel = false;
            newChild.ControlBox = false;
            childTab.Name = newChild.Name;           //make sure name and text are same
            childTab.Text = newChild.Text;                  //this is for syncrhonize later
            tabControl1.TabPages.Add(childTab);     //add new tab
            if (newChild is FormListaBase)
                (newChild as FormListaBase).panel1.Parent = childTab;     //attach to tab
            else
            {
                if(newChild.HasChildren)
                {
                    Control control = newChild.Controls.Find("panel1", false).FirstOrDefault();
                    if (control != null)
                        control.Parent = childTab;
                }
            }

            tabControl1.SelectTab(childTab);     //this is to make sure that tab page is selected in the same time
            newChild.Show();                                 //as new form created so that corresponding tab and child form is active
        }

        private void SeleccionarSolapa(string nombreSolapa)
        {
            foreach (TabPage theTab in tabControl1.TabPages)
            {
                if (theTab.Text == nombreSolapa)       
                {   //when nemu is clicked, activate the corresponding form and tab page
                    tabControl1.SelectTab(theTab);    // when menu is clicked, select tab and activate mdi child
                    foreach (Form WantToSelect in this.MdiChildren)
                    {
                        if (WantToSelect.Name == theTab.Name)    //this is why you must make sure child form's and tab page's name are same
                        {                                                                           //for easier control
                            WantToSelect.Select();                                //activate mdi child
                        }
                    }
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            foreach (Form WantToSelect in this.MdiChildren)
            {
                if (tabControl1.SelectedTab != null)     //if no child has created, an error will occur
                {
                    if (WantToSelect.Name == tabControl1.SelectedTab.Name)    //again, this is why you must make sure child form's and tab page's name are same
                    {                                                                           //for easier control
                        WantToSelect.Select();                                //activate mdi child
                    }
                }
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                TreeView tv = sender as TreeView;
                if (tv.SelectedNode == null) return;
                AbrirFormulario(tv.SelectedNode.Tag as string);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
