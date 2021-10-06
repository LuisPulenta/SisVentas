using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVistaArticulo_Ingreso : Form
    {
        public frmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        //Habilitar botones del formulario
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[5].Visible = false;
            dataListado.Columns[7].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NArticulo.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método Buscar
        private void BuscarNombre()
        {
            dataListado.DataSource = NArticulo.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            form.setArticulo(par1, par2);
            Hide();
        }

        private void frmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            Mostrar();
            PersonalizarGrilla();
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["codigo"].HeaderText = "Código";
            dataListado.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["nombre"].HeaderText = "Nombre";
            dataListado.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["descripcion"].HeaderText = "Descripción";
            dataListado.Columns["descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["imagen"].HeaderText = "Imagen";

            dataListado.Columns["categoria"].HeaderText = "Categoría";

            dataListado.Columns["presentacion"].HeaderText = "Presentación";



            dataListado.AutoResizeColumns();
        }
    }
}