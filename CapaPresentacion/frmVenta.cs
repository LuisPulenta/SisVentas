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
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {

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
    }
}
