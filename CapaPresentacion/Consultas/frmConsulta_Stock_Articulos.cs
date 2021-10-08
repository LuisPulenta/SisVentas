using CapaNegocios;
using System;
using System.Windows.Forms;


namespace CapaPresentacion.Consultas
{
    public partial class frmConsulta_Stock_Articulos : Form
    {
        public frmConsulta_Stock_Articulos()
        {
            InitializeComponent();
        }

        private void frmConsulta_Stock_Articulos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        //Habilitar botones del formulario
        private void OcultarColumnas()
        {
            
        }

        //Método Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NArticulo.Stock_Articulos();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
    }
}