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
            txtIdProveedor.ReadOnly = true;
            txtIdArticulo.ReadOnly = true;
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
            txtProveedor.ReadOnly = !valor;
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
            dataListadoDetalle.DataSource = NIngreso.BuscarDetalle(txtIdIngreso.Text);
        }

        private void crearTabla()
        {
            dtDetalle = new DataTable("Detalle");
            dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Realacionar nuestri DataGRidView con nuesto DataTable
            dataListado.DataSource = dtDetalle;
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["nombre"].HeaderText = "Nombre";
            dataListado.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["descripcion"].HeaderText = "Descripción";
            dataListado.Columns["descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.AutoResizeColumns();
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            _Instancia = this;
            Mostrar();
            Habilitar(false);
            Botones();
            crearTabla();
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

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
            Habilitar(true);
            txtSerie.Focus();
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
                        cbTipo_Comprobante.SelectedValue.ToString(),
                        txtSerie.Text,
                        txtCorrelativo.Text,
                        Convert.ToDecimal(txtIgv.Text),
                        "ACTIVO",
                        dtDetalles)
                        ;
                }
                else
                {
                    rpta = NIngreso.Editar(Convert.ToInt32(txtIdCategoria.Text), txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text);
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
    }
}