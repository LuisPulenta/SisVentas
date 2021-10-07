using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVenta : Form
    {
        private static frmVenta _Instancia;

        public static frmVenta GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmVenta();
            }
            return _Instancia;
        }

        public int Idtrabajador;

        private bool IsNuevo = false;
        private bool IsEditar = false;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        public void setCliente(string idcliente, string nombre)
        {
            txtIdCliente.Text = idcliente;
            txtCliente.Text = nombre;
        }

        public void setArticulo(string iddetalle_ingreso, string nombre, decimal precio_compra, decimal precio_venta, int stock, DateTime fecha_vencimiento)
        {
            txtIdArticulo.Text = iddetalle_ingreso;
            txtArticulo.Text = nombre;
            txtPrecioCompra.Text = precio_compra.ToString();
            txtPrecioVenta.Text = precio_venta.ToString();
            txtStockActual.Text = stock.ToString();
            dtFechaVencimiento.Value = fecha_vencimiento;
        }

        public frmVenta()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCliente, "Seleccione el Cliente");
            ttMensaje.SetToolTip(txtSerie, "Ingrese la Serie del Comprobante");
            ttMensaje.SetToolTip(txtCorrelativo, "Ingrese el N° del Comprobante");
            ttMensaje.SetToolTip(txtCantidad, "Ingrese la Cantidad vendida");
            ttMensaje.SetToolTip(txtArticulo, "Seleccione el Artículo");
            txtIdCliente.Visible = false;
            txtIdArticulo.Visible = false;
            txtCliente.ReadOnly = true;
            txtArticulo.ReadOnly = true;
            dtFechaVencimiento.Enabled = false;
            txtPrecioVenta.ReadOnly = true;
            txtPrecioCompra.ReadOnly = true;
            txtStockActual.ReadOnly = true;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            _Instancia = this;
            Mostrar();
            Habilitar(false);
            Botones();
            crearTabla();
            PersonalizarGrilla();
            PersonalizarGrillaDetalle();
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente_Venta form = new frmVistaCliente_Venta();
            form.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Venta form = new frmVistaArticulo_Venta();
            form.ShowDialog();
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
            txtIdVenta.Text = string.Empty;
            txtIdCliente.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtSerie.Text = string.Empty;
            txtCorrelativo.Text = string.Empty;
            txtIgv.Text = string.Empty;
            lblTotal.Text = "0,0";
            txtIgv.Text = "21";
            crearTabla();

        }

        private void LimpiarDetalle()
        {
            txtIdArticulo.Text = string.Empty;
            txtArticulo.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtStockActual.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            txtSerie.ReadOnly = !valor;
            txtCorrelativo.ReadOnly = !valor;
            txtIgv.ReadOnly = !valor;
            dtFecha.Enabled = valor;
            cbTipo_Comprobante.Enabled = valor;
            txtCantidad.ReadOnly = !valor;
            txtStockActual.ReadOnly = !valor;
            txtPrecioCompra.ReadOnly = !valor;
            txtPrecioVenta.ReadOnly = !valor;
            txtDescuento.ReadOnly = !valor;
            dtFechaVencimiento.Enabled = valor;
            btnBuscarArticulo.Enabled = valor;
            btnBuscarCliente.Enabled = valor;
            btnAgregar.Enabled = valor;
            btnQuitar.Enabled = valor;
        }

        //Habilitar botones del formulario
        private void Botones()
        {
            if (IsNuevo || IsEditar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
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
            dataListado.DataSource = NVenta.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFecha
        private void BuscarFecha()
        {
            dataListado.DataSource = NVenta.BuscarFecha(dtFecha1.Value.ToString("dd/MM/yyyy"), dtFecha2.Value.ToString("dd/MM/yyyy"));
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método MostrarDetalle
        private void MostrarDetalle()
        {
            dataListadoDetalle.DataSource = NVenta.MostrarDetalle(txtIdVenta.Text);
        }

        private void crearTabla()
        {
            dtDetalle = new DataTable("Detalle");
            dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar nuestri DataGridView con nuesto DataTable
            dataListadoDetalle.DataSource = dtDetalle;
            PersonalizarGrillaDetalle();
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["idventa"].HeaderText = "Id";
            dataListado.Columns["idventa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["fecha"].HeaderText = "Fecha";
            dataListado.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["tipo_comprobante"].HeaderText = "Tipo Comprobante";
            dataListado.Columns["tipo_comprobante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["serie"].HeaderText = "Serie";
            dataListado.Columns["serie"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["correlativo"].HeaderText = "Correlativo";
            dataListado.Columns["correlativo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["igv"].HeaderText = "Igv";
            dataListado.Columns["igv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.AutoResizeColumns();
        }

        private void PersonalizarGrillaDetalle()
        {

            dataListadoDetalle.Columns["iddetalle_ingreso"].HeaderText = "Id Artículo";
            dataListadoDetalle.Columns["iddetalle_ingreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListadoDetalle.Columns["articulo"].HeaderText = "Artículo";
            dataListadoDetalle.Columns["articulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListadoDetalle.Columns["cantidad"].HeaderText = "Cantidad";
            dataListadoDetalle.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListadoDetalle.Columns["precio_venta"].HeaderText = "Precio Venta";
            dataListadoDetalle.Columns["precio_venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListadoDetalle.Columns["descuento"].HeaderText = "Descuento";
            dataListadoDetalle.Columns["descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListadoDetalle.Columns["subtotal"].HeaderText = "Subtotal";
            dataListadoDetalle.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListadoDetalle.AutoResizeColumns();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFecha();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea aliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdVenta.Text = dataListado.CurrentRow.Cells["idventa"].Value.ToString();
            txtCliente.Text = dataListado.CurrentRow.Cells["cliente"].Value.ToString();
            dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            cbTipo_Comprobante.Text = dataListado.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            txtSerie.Text = dataListado.CurrentRow.Cells["serie"].Value.ToString();
            txtCorrelativo.Text = dataListado.CurrentRow.Cells["correlativo"].Value.ToString();
            lblTotalPagado.Text = dataListado.CurrentRow.Cells["total"].Value.ToString();
            MostrarDetalle();
            tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            LimpiarDetalle();
            Habilitar(true);
            PersonalizarGrillaDetalle();
            txtSerie.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();
                string rpta = "";
                if (txtCliente.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Cliente");
                    errorIcono.SetError(txtCliente, "Debe ingresar un Cliente");
                    return;
                }

                if (txtSerie.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un N° de Serie");
                    errorIcono.SetError(txtSerie, "Debe ingresar un N° de Serie");
                    return;
                }

                if (txtCorrelativo.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un N° de Comprobante");
                    errorIcono.SetError(txtCorrelativo, "Debe ingresar un N° de Comprobante");
                    return;
                }

                if (IsNuevo)
                {
                    rpta = NVenta.Insertar(
                        Idtrabajador,
                        Convert.ToInt32(txtIdCliente.Text),
                        dtFecha.Value,
                        cbTipo_Comprobante.Text,
                        txtSerie.Text,
                        txtCorrelativo.Text,
                        Convert.ToDecimal(txtIgv.Text),
                        dtDetalle);
                }

                if (rpta.Equals("OK"))
                {
                    if (IsNuevo)
                    {
                        MensajeOk("El Registro se guardó con éxito!");
                    }
                }
                else
                {
                    MensajeError(rpta);
                }

                IsNuevo = false;
                Botones();
                Limpiar();
                LimpiarDetalle();
                Mostrar();
                PersonalizarGrilla();
                PersonalizarGrillaDetalle();
                Habilitar(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            Limpiar();
            LimpiarDetalle();
            Mostrar();
            PersonalizarGrillaDetalle();
            Habilitar(false);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();
                if (txtIdArticulo.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Artículo");
                    errorIcono.SetError(txtIdArticulo, "Debe ingresar un Artículo");
                    return;
                }

                if (txtCantidad.Text == string.Empty)
                {
                    MensajeError("Debe ingresar una Cantidad");
                    errorIcono.SetError(txtCantidad, "Debe ingresar una Cantidad");
                    return;
                }

                if (txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Precio de Venta");
                    errorIcono.SetError(txtPrecioVenta, "Debe ingresar un Precio de Venta");
                    return;
                }

                if (txtDescuento.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Descuento");
                    errorIcono.SetError(txtDescuento, "Debe ingresar Descuento");
                    return;
                }



                bool registrar = true;
                foreach (DataRow row in dtDetalle.Rows)
                {
                    if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(txtIdArticulo.Text))
                    {
                        registrar = false;
                        MensajeError("Ya se encuentra el artículo en el detalle");
                    }
                }
                if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                {
                    decimal subTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecioCompra.Text)-Convert.ToDecimal(txtDescuento.Text);
                    totalPagado = totalPagado + subTotal;
                    lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                    //Agregar ese detalle al datalistadoDetalle
                    DataRow row = dtDetalle.NewRow();
                    row["iddetalle_ingreso"] = Convert.ToInt32(txtIdArticulo.Text);
                    row["articulo"] = txtArticulo.Text;
                    row["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                    row["precio_venta"] = Convert.ToDecimal(txtPrecioVenta.Text);
                    row["descuento"] = Convert.ToDecimal(txtDescuento.Text);
                    row["subtotal"] = subTotal;
                    dtDetalle.Rows.Add(row);
                    PersonalizarGrillaDetalle();
                    LimpiarDetalle();
                }
                else
                {
                    MensajeError("No hay stock suficiente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoDetalle.Rows.Count == 0)
                {
                    return;
                }

                int indiceFila = dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = dtDetalle.Rows[indiceFila];
                //Disminuir el total pagado
                totalPagado = totalPagado - Convert.ToDecimal(row["subtotal".ToString()]);
                lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //Borramos la fila
                dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para borrar");
                throw;
            }
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
    }
}