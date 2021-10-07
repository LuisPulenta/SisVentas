using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVistaCliente_Venta : Form
    {
        public frmVistaCliente_Venta()
        {
            InitializeComponent();
        }

        private void frmVistaCliente_Venta_Load(object sender, EventArgs e)
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
            dataListado.DataSource = NCliente.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellido
        private void BuscarApellidos()
        {
            dataListado.DataSource = NCliente.Buscar_Apellido(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNumDocumento
        private void BuscarNum_Documento()
        {
            dataListado.DataSource = NCliente.BuscarNum_Documento(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["nombre"].HeaderText = "Nombre";
            dataListado.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["apellidos"].HeaderText = "Apellidos";
            dataListado.Columns["apellidos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["sexo"].HeaderText = "Sexo";
            dataListado.Columns["sexo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["fecha_nacimiento"].HeaderText = "Fec. Nac.";
            dataListado.Columns["fecha_nacimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

            dataListado.AutoResizeColumns();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNum_Documento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dataListado.CurrentRow.Cells["idcliente"].Value);
            par2 = Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value)+' '+ Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCliente(par1, par2);
            Hide();
        }
    }
}
