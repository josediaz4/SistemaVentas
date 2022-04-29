using System;
using System.Windows.Forms;

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
            Inicio frmInicio = new Inicio();
            frmInicio.Show();
            this.Hide();

            frmInicio.FormClosing += frm_closing;


        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
