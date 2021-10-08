using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteArticulos : Form
    {
        public frmReporteArticulos()
        {
            InitializeComponent();
        }

        private void frmReporteArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                this.sparticulo_mostrarTableAdapter.Fill(this.dsPrincipal.sparticulo_mostrar);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
