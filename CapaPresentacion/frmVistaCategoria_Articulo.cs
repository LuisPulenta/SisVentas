using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVistaCategoria_Articulo : Form
    {
        public frmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        private void frmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        //Método OcultarColumnas
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NCategoria.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método Buscar
        private void BuscarNombre()
        {
            dataListado.DataSource = NCategoria.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["nombre"].HeaderText = "Nombre";
            dataListado.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["descripcion"].HeaderText = "Descripción";
            dataListado.Columns["descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.AutoResizeColumns();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmArticulo form = frmArticulo.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCategoria(par1, par2);
            Hide();
        }
    }
}
