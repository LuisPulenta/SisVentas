using CapaNegocios;
using System;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        
        public frmCategoria()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre de la Categoría");
            ttMensaje.SetToolTip(txtDescripcion, "Ingrese una Descripción de la Categoría");
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeErrork(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar controles del formulario
        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtDescripcion.ReadOnly = !valor;
            txtIdCategoria.ReadOnly = !valor;
        }

        //Habilitar botones del formulario
        private void Botones()
        {
            if(IsNuevo || IsEditar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }

        //Habilitar botones del formulario
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

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            Mostrar();
            PersonalizarGrilla();
            Habilitar(false);
            Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar();
        }
    }
}
