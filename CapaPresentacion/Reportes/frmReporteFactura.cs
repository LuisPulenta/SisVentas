using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteFactura : Form
    {
        private int _IdVenta;
        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }

        public frmReporteFactura()
        {
            InitializeComponent();
        }

        

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_factura' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spreporte_facturaTableAdapter.Fill(this.dsPrincipal.spreporte_factura, IdVenta);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}