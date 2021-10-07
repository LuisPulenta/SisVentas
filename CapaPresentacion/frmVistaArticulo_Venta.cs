using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVistaArticulo_Venta : Form
    {
        public frmVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        private void frmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            BuscarNombre();
            PersonalizarGrilla();
        }

        //Habilitar botones del formulario
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            dataListado.DataSource = NVenta.MostrarArticulo_Venta_Nombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarCodigo
        private void BuscarCodigo()
        {
            dataListado.DataSource = NVenta.MostrarArticulo_Venta_Codigo(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["codigo"].HeaderText = "Código";
            dataListado.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["nombre"].HeaderText = "Nombre";
            dataListado.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["stock_actual"].HeaderText = "Stock Actual";
            dataListado.Columns["stock_actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["precio_compra"].HeaderText = "Precio Compra";
            dataListado.Columns["precio_compra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["precio_venta"].HeaderText = "Precio Venta";
            dataListado.Columns["precio_venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["fecha_vencimiento"].HeaderText = "Fecha Vencimiento";
            dataListado.Columns["fecha_vencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.AutoResizeColumns();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Nombre"))
            {
                BuscarNombre();
            }
            else if (cbBuscar.Text.Equals("Código"))
            {
                BuscarCodigo();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            decimal par3, par4;
            int par5;
            DateTime par6;
            
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(dataListado.CurrentRow.Cells["stock_actual"].Value);
            par6 = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);
            form.setArticulo(par1, par2, par3, par4, par5, par6);
            Hide();
        }
    }
}