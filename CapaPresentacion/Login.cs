using System;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brnIngresar_Click(object sender, EventArgs e)
        {
            Usuario oUsuario =new CN_Usuario().Listar().Where(x => x.Documento == txtDocumento.Text && x.Clave == txtContraseña.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                Inicio frmInicio = new Inicio();
                frmInicio.Show();
                this.Hide();

                frmInicio.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            


        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
