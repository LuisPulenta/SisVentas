using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtRazonSocial, "Ingrese la Razón Social del Proveedor");
            ttMensaje.SetToolTip(cbSectorComercial, "Seleccione el Sector Comercial del Proveedor");
            ttMensaje.SetToolTip(cbTipoDocumento, "Seleccione el Tipo de DOcumento");
            ttMensaje.SetToolTip(txtNumDocumento, "Ingrese el N° de Documento");
            ttMensaje.SetToolTip(txtDireccion, "Ingrese la Dirección");
            ttMensaje.SetToolTip(txtTelefono, "Ingrese el Teléfono");
            ttMensaje.SetToolTip(txtEmail, "Ingrese el Email");
            ttMensaje.SetToolTip(txtUrl, "Ingrese la URL");
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
            txtIdProveedor.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            cbSectorComercial.SelectedIndex = -1;
            cbTipoDocumento.SelectedIndex = -1;
            txtNumDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUrl.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            txtRazonSocial.ReadOnly = !valor;
            cbSectorComercial.Enabled = valor;
            cbTipoDocumento.Enabled = valor;
            txtNumDocumento.ReadOnly = !valor;
            txtDireccion.ReadOnly = !valor;
            txtTelefono.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            txtUrl.ReadOnly = !valor;
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

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            Mostrar();
            PersonalizarGrilla();
            Habilitar(false);
            Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cbBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                BuscarNum_Documento();
            }
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
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

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
            txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();
                string rpta = "";
                if (txtRazonSocial.Text == string.Empty)
                {
                    MensajeError("Debe ingresar una Razón Social");
                    errorIcono.SetError(txtRazonSocial, "Debe ingresar una Razón Social");
                    return;
                }

                if (cbSectorComercial.SelectedIndex==-1)
                {
                    MensajeError("Seleccione un Sector Comercial");
                    errorIcono.SetError(cbSectorComercial, "Seleccione un Sector Comercial");
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
                    rpta = NProveedor.Insertar(
                        txtRazonSocial.Text.Trim().ToUpper(),
                        cbSectorComercial.Text,
                        cbTipoDocumento.Text,
                        txtNumDocumento.Text,
                        txtDireccion.Text,
                        txtTelefono.Text,
                        txtEmail.Text,
                        txtUrl.Text);
                }
                else
                {
                    rpta = NProveedor.Editar(
                        Convert.ToInt32(txtIdProveedor.Text),
                        txtRazonSocial.Text.Trim().ToUpper(),
                        cbSectorComercial.Text,
                        cbTipoDocumento.Text,
                        txtNumDocumento.Text,
                        txtDireccion.Text,
                        txtTelefono.Text,
                        txtEmail.Text,
                        txtUrl.Text);
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

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            txtRazonSocial.Text = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
            cbSectorComercial.Text = Convert.ToString(dataListado.CurrentRow.Cells["sector_comercial"].Value);
            cbTipoDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_documento"].Value);
            txtNumDocumento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
            txtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);
            txtUrl.Text = Convert.ToString(dataListado.CurrentRow.Cells["url"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();
            if (txtRazonSocial.Text == string.Empty)
            {
                MensajeError("Debe seleccionar el Registro a Modificar");
                errorIcono.SetError(txtRazonSocial, "Debe seleccionar el Registro a Modificar");
                return;
            }

            if (cbSectorComercial.SelectedIndex == -1)
            {
                MensajeError("Seleccione un Sector Comercial");
                errorIcono.SetError(cbSectorComercial, "Seleccione un Sector Comercial");
                return;
            }

            if (cbTipoDocumento.SelectedIndex == -1)
            {
                MensajeError("Seleccione un Tipo de Documentol");
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
            txtRazonSocial.Focus();
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