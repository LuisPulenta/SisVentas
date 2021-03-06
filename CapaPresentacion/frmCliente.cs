using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmCliente()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese Nombre del Cliente");
            ttMensaje.SetToolTip(txtApellidos, "Ingrese Apellidos del Cliente");
            ttMensaje.SetToolTip(cbSexo, "Seleccione el Sexo del Cliente");
            ttMensaje.SetToolTip(dtFechaNac, "Seleccione la Fecha de Nacimiento del Cliente");
            ttMensaje.SetToolTip(cbTipoDocumento, "Seleccione el Tipo de Documento");
            ttMensaje.SetToolTip(txtNumDocumento, "Ingrese el N° de Documento");
            ttMensaje.SetToolTip(txtDireccion, "Ingrese la Dirección");
            ttMensaje.SetToolTip(txtTelefono, "Ingrese el Teléfono");
            ttMensaje.SetToolTip(txtEmail, "Ingrese el Email");
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar controles del formulario
        private void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            cbSexo.SelectedIndex = -1;
            dtFechaNac.Value = DateTime.Today;
            cbTipoDocumento.SelectedIndex = -1;
            txtNumDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            txtNombre.ReadOnly = !valor;
            txtApellidos.ReadOnly = !valor;
            cbSexo.Enabled = valor;
            dtFechaNac.Enabled = valor;
            cbTipoDocumento.Enabled = valor;
            txtNumDocumento.ReadOnly = !valor;
            txtDireccion.ReadOnly = !valor;
            txtTelefono.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
        }

        //Habilitar botones del formulario
        private void Botones()
        {
            if (IsNuevo || IsEditar)
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

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
            PersonalizarGrilla();
            Habilitar(false);
            Botones();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                MensajeOk("Se eliminó el Registro con éxito!");
                            }
                            else
                            {
                                MensajeError(Rpta);
                            }
                        }
                    }
                    chkEliminar.Checked = false;
                    Mostrar();
                    PersonalizarGrilla();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();
                string rpta = "";
                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Nombre de Cliente");
                    errorIcono.SetError(txtNombre, "Debe ingresar un Nombre de Cliente");
                    return;
                }

                if (txtApellidos.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Apellido de Cliente");
                    errorIcono.SetError(txtApellidos, "Debe ingresar un Apellido de Cliente");
                    return;
                }

                if (cbSexo.SelectedIndex == -1)
                {
                    MensajeError("Seleccione un Sexo");
                    errorIcono.SetError(cbSexo, "Seleccione un Sexo");
                    return;
                }

                if (cbTipoDocumento.SelectedIndex == -1)
                {
                    MensajeError("Seleccione un Tipo de Documento");
                    errorIcono.SetError(cbTipoDocumento, "Seleccione un Tipo de Documento");
                    return;
                }

                if (txtNumDocumento.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un N° de Documento");
                    errorIcono.SetError(txtNumDocumento, "Debe ingresar un N° de Documento");
                    return;
                }

                if (IsNuevo)
                {
                    rpta = NCliente.Insertar(
                        txtNombre.Text.Trim().ToUpper(),
                        txtApellidos.Text.Trim().ToUpper(),
                        cbSexo.Text,
                        dtFechaNac.Value,
                        cbTipoDocumento.Text,
                        txtNumDocumento.Text,
                        txtDireccion.Text,
                        txtTelefono.Text,
                        txtEmail.Text);
                }
                else
                {
                    rpta = NCliente.Editar(
                        Convert.ToInt32(txtIdCliente.Text),
                        txtNombre.Text.Trim().ToUpper(),
                        txtApellidos.Text.Trim().ToUpper(),
                        cbSexo.Text,
                        dtFechaNac.Value,
                        cbTipoDocumento.Text,
                        txtNumDocumento.Text,
                        txtDireccion.Text,
                        txtTelefono.Text,
                        txtEmail.Text);
                }
                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        MensajeOk("El Registro se guardó con éxito!");
                    }
                    else
                    {
                        MensajeOk("El Registro se actualizó con éxito!");
                    }
                }
                else
                {
                    MensajeError(rpta);
                }

                IsNuevo = false;
                IsEditar = false;
                Botones();
                Limpiar();
                Mostrar();
                PersonalizarGrilla();
                Habilitar(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCliente.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcliente"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtApellidos.Text = Convert.ToString(dataListado.CurrentRow.Cells["apellidos"].Value);
            cbSexo.Text = Convert.ToString(dataListado.CurrentRow.Cells["sexo"].Value);
            dtFechaNac.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            cbTipoDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_documento"].Value);
            txtNumDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
            txtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();
            if (txtNombre.Text == string.Empty)
            {
                MensajeError("Debe seleccionar el Registro a Modificar");
                errorIcono.SetError(txtNombre, "Debe seleccionar el Registro a Modificar");
                return;
            }

            if (txtApellidos.Text == string.Empty)
            {
                MensajeError("Debe ingresar un Apellido de Cliente");
                errorIcono.SetError(txtNombre, "Debe ingresar un Apellido de Cliente");
                return;
            }

            if (cbSexo.SelectedIndex == -1)
            {
                MensajeError("Seleccione un Sexo");
                errorIcono.SetError(cbSexo, "Seleccione un Sexo");
                return;
            }

            if (cbTipoDocumento.SelectedIndex == -1)
            {
                MensajeError("Seleccione un Tipo de Documento");
                errorIcono.SetError(cbTipoDocumento, "Seleccione un Tipo de Documento");
                return;
            }

            if (txtNumDocumento.Text == string.Empty)
            {
                MensajeError("Debe ingresar un N° de Documento");
                errorIcono.SetError(txtNumDocumento, "Debe ingresar un N° de Documento");
                return;
            }

            IsEditar = true;
            Botones();
            Habilitar(true);
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            Limpiar();
            Mostrar();
            PersonalizarGrilla();
            Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
    }
}