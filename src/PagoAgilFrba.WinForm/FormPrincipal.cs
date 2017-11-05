using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Core;

namespace PagoAgilFrba
{
    public partial class FormPrincipal : Form
    {
        Usuario _usuario;
        public FormPrincipal(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPrivilegios = _usuario.ObtenerPrivilegios();

                // Hay que ver como controlar las solapas aca.
                if (dtPrivilegios == null || dtPrivilegios.Rows.Count == 0)
                    throw new PagoAgilException("No tiene ningun privilegio");
                foreach (DataRow dr in dtPrivilegios.Rows)
                {
                    TreeNode nodo = treeView1.Nodes.Add(dr["nombre"].ToString());
                    nodo.Tag = dr["formulario"];
                }

                this.Text = String.Format("Formulario principal - Usuario: {0}", _usuario.Username);
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

            ToolStripMenuItem newMenuTab = new ToolStripMenuItem();   //create menu to hold tab
            newMenuTab.Text = newChild.Text;                    //make sure the name and text are same to synchonize later
            newMenuTab.Name = newChild.Name;
            mnuTab.DropDownItems.Add(newMenuTab);    //add menu item
            newMenuTab.Click += new EventHandler(newMenuTab_Click); //add event handler
            tabControl1.SelectTab(childTab);     //this is to make sure that tab page is selected in the same time
            newChild.Show();                                 //as new form created so that corresponding tab and child form is active
        }

        void newMenuTab_Click(object sender, EventArgs e)
        {
            SeleccionarSolapa(sender.ToString());  //sender is the clicked menu 
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

        private void mnuClose_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;
            //if you want to close tab, you must close the corresponding form
            mnuTab.DropDownItems.RemoveByKey(tabControl1.SelectedTab.Name);   //this is why you must make sure menu's and tab page's name are same
            this.ActiveMdiChild.Close();                  //because of synchronize routine, you must close the form first before tab.
            tabControl1.SelectedTab.Dispose();    //if tab first, activated tab will change and so the child form, this will be the closed form.
            //the wrong form will close....
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
    }
}
