using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static frmArticulo _Instancia;

        public static frmArticulo GetInstancia()
        {
            if(_Instancia==null)
            {
                _Instancia = new frmArticulo();
            }
            return _Instancia;
        }
        
        public void setCategoria(string idcategoria, string nombre)
        {
            txtIdCategoria.Text = idcategoria;
            txtCategoria.Text = nombre;
        }


        public frmArticulo()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese el Código del Artículo");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre del Artículo");
            ttMensaje.SetToolTip(txtDescripcion, "Ingrese una Descripción del Artículo");
            ttMensaje.SetToolTip(txtIdCategoria, "Ingrese una Categoría");
            ttMensaje.SetToolTip(txtCategoria, "Ingrese una Categoría");
            ttMensaje.SetToolTip(pxImagen, "Seleccione la imagen del Artículo");
            ttMensaje.SetToolTip(cbIdPresentacion, "Seleccione una Presentación");
            txtIdCategoria.Visible = false;
            txtCategoria.ReadOnly = true;
            LlenarComboPresentacion();
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
            txtIdArticulo.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtIdCategoria.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            cbIdPresentacion.SelectedIndex = -1;
            pxImagen.Image = global::CapaPresentacion.Properties.Resources.noimage;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            txtCodigo.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            txtDescripcion.ReadOnly = !valor;
            btnBuscarCategoria.Enabled = valor;
            cbIdPresentacion.Enabled= valor;
            btnCargar.Enabled = valor;
            btnLimpiar.Enabled = valor;
            txtIdArticulo.ReadOnly = !valor;
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
            dataListado.Columns[6].Visible = false;
            dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            dataListado.DataSource = NArticulo.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método Buscar
        private void BuscarNombre()
        {
            dataListado.DataSource = NArticulo.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para llenar el ComboBox de Presentacion
        private void LlenarComboPresentacion()
        {
            cbIdPresentacion.DataSource = NPresentacion.Mostrar();
            cbIdPresentacion.ValueMember = "idpresentacion";
            cbIdPresentacion.DisplayMember = "nombre";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pxImagen.SizeMode = PictureBoxSizeMode.Zoom;
                pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pxImagen.Image = global::CapaPresentacion.Properties.Resources.noimage;
        }

        private void PersonalizarGrilla()
        {
            dataListado.Columns["codigo"].HeaderText = "Código";
            dataListado.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["nombre"].HeaderText = "Nombre";
            dataListado.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["descripcion"].HeaderText = "Descripción";
            dataListado.Columns["descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataListado.Columns["imagen"].HeaderText = "Imagen";

            dataListado.Columns["categoria"].HeaderText = "Categoría";

            dataListado.Columns["presentacion"].HeaderText = "Presentación";



            dataListado.AutoResizeColumns();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            _Instancia = this;
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
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

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
                if (txtCodigo.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Código");
                    errorIcono.SetError(txtNombre, "Debe ingresar un Código");
                    return;
                }

                if (txtCodigo.Text.Length > 50)
                {
                    MensajeError("El Código no puede tener más de 50 caracteres");
                    errorIcono.SetError(txtCodigo, "El Código no puede tener más de 50 caracteres");
                    return;
                }

                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Debe ingresar un Nombre");
                    errorIcono.SetError(txtNombre, "Debe ingresar un Nombre");
                    return;
                }

                if (txtNombre.Text.Length > 50)
                {
                    MensajeError("El Nombre no puede tener más de 50 caracteres");
                    errorIcono.SetError(txtNombre, "El Nombre no puede tener más de 50 caracteres");
                    return;
                }

                if (txtIdCategoria.Text == string.Empty)
                {
                    MensajeError("Debe ingresar una Categoría");
                    errorIcono.SetError(txtCategoria, "Debe ingresar una Categoría");
                    return;
                }

                if (cbIdPresentacion.SelectedIndex==-1)
                {
                    MensajeError("Debe seleccionar una Presentación");
                    errorIcono.SetError(txtCategoria, "Debe seleccionar una Presentación");
                    return;
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imagen = ms.GetBuffer();

                if (IsNuevo)
                {
                    rpta = NArticulo.Insertar(
                        txtCodigo.Text,
                        txtNombre.Text.Trim().ToUpper(),
                        txtDescripcion.Text,
                        imagen,
                        Convert.ToInt32(txtIdCategoria.Text),
                        (int) cbIdPresentacion.SelectedValue);
                }
                else
                {
                    rpta = NArticulo.Editar(
                        Convert.ToInt32(txtIdArticulo.Text),
                        txtCodigo.Text,
                        txtNombre.Text.Trim().ToUpper(),
                        txtDescripcion.Text,
                        imagen,
                        Convert.ToInt32(txtIdCategoria.Text),
                        (int)cbIdPresentacion.SelectedValue);
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
            txtIdArticulo.Text = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            txtCodigo.Text = Convert.ToString(dataListado.CurrentRow.Cells["codigo"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);

            byte[] imagenBuffer = (byte[]) dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            pxImagen.Image = Image.FromStream(ms);
            pxImagen.SizeMode = PictureBoxSizeMode.Zoom;

            txtIdCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["categoria"].Value);
            cbIdPresentacion.SelectedValue= Convert.ToString(dataListado.CurrentRow.Cells["idpresentacion"].Value);

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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
