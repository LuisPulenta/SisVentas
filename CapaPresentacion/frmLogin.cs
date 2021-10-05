using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();
            if(txtUsuario.Text==string.Empty)
            {
                errorIcono.SetError(txtUsuario, "Ingrese el Usuario");
                return;
            }

            if (txtPassword.Text == string.Empty)
            {
                errorIcono.SetError(txtPassword, "Ingrese el Password");
                return;
            }

            DataTable Datos = CapaNegocios.NTrabajador.Login(txtUsuario.Text, txtPassword.Text);
            
            //Evaluar si existe el Usuario
            if(Datos.Rows.Count==0)
            {
                MessageBox.Show("Usuario o password incorrectos", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmPrincipal frm = new frmPrincipal();
                frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();
                frm.Show();
                Hide();
            }
        }
    }
}