using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVistaProveedor_Ingreso : Form
    {
        public frmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }

        private void frmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            Mostrar();
            PersonalizarGrilla();
        }

        //Habilitar botones del formulario
        private void OcultarColumnas()
        {
            dataListado.Columns[0].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NProveedor.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarRazonSocial
        private void BuscarRazon_Social()
        {
            dataListado.DataSource = NProveedor.Buscar_Razon_Social(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNumDocumento
        private void BuscarNum_Documento()
        {
            dataListado.DataSource = NProveedor.BuscarNum_Documento(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNum_Documento();
            }
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["razon_social"].HeaderText = "Razón Social";
            dataListado.Columns["razon_social"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["sector_comercial"].HeaderText = "Sector Comercial";
            dataListado.Columns["sector_comercial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["tipo_documento"].HeaderText = "Tipo Documento";
            dataListado.Columns["tipo_documento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["num_documento"].HeaderText = "N° de Documento";
            dataListado.Columns["num_documento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["direccion"].HeaderText = "Dirección";
            dataListado.Columns["direccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["telefono"].HeaderText = "Teléfono";
            dataListado.Columns["telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["email"].HeaderText = "Email";
            dataListado.Columns["email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["url"].HeaderText = "URL";
            dataListado.Columns["url"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.AutoResizeColumns();
        }

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
            form.setProveedor(par1, par2);
            Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNum_Documento();
            }
        }
    }
}