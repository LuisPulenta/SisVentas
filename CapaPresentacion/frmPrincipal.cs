using CapaPresentacion.Consultas;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";

        private int childFormNumber = 0;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frm = frmArticulo.GetInstancia(); ;
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void GestionUsuario()
        {
            //Controlar los Accesos
            if(Acceso == "Administrador")
            {
                MnuAlmacen.Enabled = true;
                MnuCompras.Enabled = true;
                MnuVentas.Enabled = true;
                MnuMantenimiento.Enabled = true;
                MnuConsultas.Enabled = true;
                MnuHerramientas.Enabled = true;
                tsCompras.Enabled = true;
                tsVentas.Enabled = true;
                tsClientes.Enabled = true;
                tsProveedores.Enabled = true;
            }
            else if (Acceso == "Vendedor")
            {
                MnuAlmacen.Enabled = false;
                MnuCompras.Enabled = false;
                MnuVentas.Enabled = true;
                MnuMantenimiento.Enabled = false;
                MnuConsultas.Enabled = true;
                MnuHerramientas.Enabled = true;
                tsCompras.Enabled = false;
                tsVentas.Enabled = true;
                tsClientes.Enabled = true;
                tsProveedores.Enabled = false;
            }
            else if (Acceso == "Almacenero")
            {
                MnuAlmacen.Enabled = true;
                MnuCompras.Enabled = true;
                MnuVentas.Enabled = false;
                MnuMantenimiento.Enabled = false;
                MnuConsultas.Enabled = true;
                MnuHerramientas.Enabled = true;
                tsCompras.Enabled = true;
                tsVentas.Enabled = false;
                tsClientes.Enabled = false;
                tsProveedores.Enabled = true;
            }
            else
            {
                MnuAlmacen.Enabled = false;
                MnuCompras.Enabled = false;
                MnuVentas.Enabled = false;
                MnuMantenimiento.Enabled = false;
                MnuConsultas.Enabled = false;
                MnuHerramientas.Enabled = false;
                tsCompras.Enabled = false;
                tsVentas.Enabled = false;
                tsClientes.Enabled = false;
                tsProveedores.Enabled = false;
            }
        }

        private void tsProveedores_Click(object sender, EventArgs e)
        {
            proveedoresToolStripMenuItem_Click(sender, e);
        }

        private void tsClientes_Click(object sender, EventArgs e)
        {
            clientesToolStripMenuItem_Click(sender, e);
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(Idtrabajador);
        }

        private void tsCompras_Click(object sender, EventArgs e)
        {
            ingresosToolStripMenuItem_Click(sender, e);
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            salirToolStripMenuItem_Click(sender, e);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(Idtrabajador);
        }

        private void tsVentas_Click(object sender, EventArgs e)
        {
            ventasToolStripMenuItem1_Click(sender, e);
        }

        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta_Stock_Articulos frm = new frmConsulta_Stock_Articulos();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}