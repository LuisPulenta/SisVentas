using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmIngreso : Form
    {
        private static frmIngreso _Instancia;

        public static frmIngreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmIngreso();
            }
            return _Instancia;
        }

        public int Idtrabajador;

        private bool IsNuevo = false;
        private bool IsEditar = false;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;


        public frmIngreso()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtProveedor, "Seleccione el Proveedor");
            ttMensaje.SetToolTip(txtSerie, "Ingrese la Serie del Comprobante");
            ttMensaje.SetToolTip(txtCorrelativo, "Ingrese el N° del Comprobante");
            ttMensaje.SetToolTip(txtStock, "Ingrese la Cantidad comprada");
            ttMensaje.SetToolTip(txtArticulo, "Seleccione el Artículo");
            txtIdProveedor.Visible = false;
            txtIdArticulo.Visible = false;
            txtProveedor.ReadOnly = true;
            txtArticulo.ReadOnly = true;
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
            txtIdIngreso.Text = string.Empty;
            txtIdProveedor.Text = string.Empty;
            txtProveedor.Text = string.Empty;
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
            txtStock.Text = string.Empty;
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
            txtStock.ReadOnly = !valor;
            txtPrecioCompra.ReadOnly = !valor;
            txtPrecioVenta.ReadOnly = !valor;
            dtFechaProduccion.Enabled = valor;
            dtFechaVencimiento.Enabled = valor;
            
            btnBuscarArticulo.Enabled = valor;
            btnBuscarProveedor.Enabled = valor;
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
            dataListado.DataSource = NIngreso.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFecha
        private void BuscarFecha()
        {
            dataListado.DataSource = NIngreso.BuscarFecha(dtFecha1.Value.ToString("dd/MM/yyyy"), dtFecha2.Value.ToString("dd/MM/yyyy"));
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método MostrarDetalle
        private void MostrarDetalle()
        {
            dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(txtIdIngreso.Text);
        }

        private void crearTabla()
        {
            dtDetalle = new DataTable("Detalle");
            dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("stock_actual", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Realacionar nuestri DataGRidView con nuesto DataTable
            dataListadoDetalle.DataSource = dtDetalle;
            PersonalizarGrillaDetalle();
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["idingreso"].HeaderText = "Id";
            dataListado.Columns["idingreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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

            dataListado.Columns["estado"].HeaderText = "Estado";
            dataListado.Columns["estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.AutoResizeColumns();
        }

        private void PersonalizarGrillaDetalle()
        {
           
                dataListadoDetalle.Columns["idarticulo"].HeaderText = "Id Artículo";
                dataListadoDetalle.Columns["idarticulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["articulo"].HeaderText = "Artículo";
                dataListadoDetalle.Columns["articulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["precio_compra"].HeaderText = "Precio Compra";
                dataListadoDetalle.Columns["precio_compra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["precio_venta"].HeaderText = "Precio Venta";
                dataListadoDetalle.Columns["precio_venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["stock_inicial"].HeaderText = "Stock inicial";
                dataListadoDetalle.Columns["stock_inicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["fecha_produccion"].HeaderText = "Fecha Producción";
                dataListadoDetalle.Columns["fecha_produccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["fecha_vencimiento"].HeaderText = "Fecha Vencimiento";
                dataListadoDetalle.Columns["fecha_vencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.Columns["subtotal"].HeaderText = "Subtotal";
                dataListadoDetalle.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataListadoDetalle.AutoResizeColumns();
            
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            _Instancia = this;
            Mostrar();
            Habilitar(false);
            Botones();
            crearTabla();
            PersonalizarGrilla();
            PersonalizarGrillaDetalle();
        }

        public void setProveedor(string idproveedor, string nombre)
        {
            txtIdProveedor.Text = idproveedor;
            txtProveedor.Text = nombre;
        }

        public void setArticulo(string idarticulo, string nombre)
        {
            txtIdArticulo.Text = idarticulo;
            txtArticulo.Text = nombre;
        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Ingreso form = new frmVistaArticulo_Ingreso();
            form.ShowDialog();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso form = new frmVistaProveedor_Ingreso();
            form.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFecha();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea anular los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                MensajeOk("Se anuló el Registro con éxito!");
                            }
                            else
                            {
                                MensajeError(Rpta);
                            }
                        }
                    }
                    chkAnular.Checked = false;
                    Mostrar();
                    PersonalizarGrilla();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked)
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
            if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcono.Clear();
                string rpta = "";
                if (txtProveedor.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Proveedor");
                    errorIcono.SetError(txtProveedor, "Debe ingresar un Proveedor");
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
                    rpta = NIngreso.Insertar(
                        Idtrabajador,
                        Convert.ToInt32(txtIdProveedor.Text),
                        dtFecha.Value,
                        cbTipo_Comprobante.Text,
                        txtSerie.Text,
                        txtCorrelativo.Text,
                        Convert.ToDecimal(txtIgv.Text),
                        "EMITIDO",
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

                if (txtPrecioCompra.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Precio de Compra");
                    errorIcono.SetError(txtPrecioCompra, "Debe ingresar un Precio de Compra");
                    return;
                }

                if (txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Precio de Venta");
                    errorIcono.SetError(txtPrecioVenta, "Debe ingresar un Precio de Venta");
                    return;
                }

                if (txtStock.Text == string.Empty)
                {
                    MensajeError("Debe ingresar una Cantidad a comprar");
                    errorIcono.SetError(txtStock, "Debe ingresar Cantidad a comprar");
                    return;
                }

                bool registrar = true;
                foreach(DataRow row in dtDetalle.Rows)
                {
                    if(Convert.ToInt32(row["idarticulo"])==Convert.ToInt32(txtIdArticulo.Text))
                    {
                        registrar = false;
                        MensajeError("Ya se encuentra el artículo en el detalle");
                    }
                }
                if(registrar)
                {
                    decimal subTotal = Convert.ToDecimal(txtStock.Text) * Convert.ToDecimal(txtPrecioCompra.Text);
                    totalPagado = totalPagado + subTotal;
                    lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                    //Agregar ese detalle al datalistadoDetalle
                    DataRow row = dtDetalle.NewRow();
                    row["idarticulo"] = Convert.ToInt32(txtIdArticulo.Text);
                    row["articulo"] = txtArticulo.Text;
                    row["precio_compra"] = Convert.ToDecimal(txtPrecioCompra.Text);
                    row["precio_venta"] = Convert.ToDecimal(txtPrecioVenta.Text);
                    row["stock_inicial"] = Convert.ToInt32(txtStock.Text);
                    row["stock_actual"] = Convert.ToInt32(txtStock.Text);
                    row["fecha_produccion"] = dtFechaProduccion.Value;
                    row["fecha_vencimiento"] = dtFechaVencimiento.Value;
                    row["subtotal"] = subTotal;
                    dtDetalle.Rows.Add(row);
                    PersonalizarGrillaDetalle();
                    LimpiarDetalle();
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
                if(dataListadoDetalle.Rows.Count==0)
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdIngreso.Text = dataListado.CurrentRow.Cells["idingreso"].Value.ToString();
            txtProveedor.Text = dataListado.CurrentRow.Cells["proveedor"].Value.ToString();
            dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            cbTipo_Comprobante.Text = dataListado.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            txtSerie.Text = dataListado.CurrentRow.Cells["serie"].Value.ToString();
            txtCorrelativo.Text = dataListado.CurrentRow.Cells["correlativo"].Value.ToString();
            lblTotalPagado.Text = dataListado.CurrentRow.Cells["total"].Value.ToString();
            MostrarDetalle();
            tabControl1.SelectedIndex = 1;
        }
    }
}