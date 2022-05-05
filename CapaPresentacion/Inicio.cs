using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        /// Variable privadas
        private static Usuario _usuarioActual;
        private static IconMenuItem _menuActivo = null;
        private static Form _formularioActivo;

        public Inicio(Usuario usuarioActual)
        {
            _usuarioActual = usuarioActual;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermiso = new CN_Permiso().Listar(_usuarioActual.IdUsuario);

            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = listaPermiso.Any(x => x.NombreMenu == iconMenu.Name);

                if (!encontrado)
                {
                    iconMenu.Visible = false;
                }
            }

            lblUsuario.Text = _usuarioActual.NombreCompleto;
        }
        private void AbrirFormulario(IconMenuItem menuActivo, Form formularioActivo)
        {
            if (_menuActivo != null)
            {
                _menuActivo.BackColor = Color.White;
            }
            menuActivo.BackColor = Color.Silver;
            _menuActivo = menuActivo;

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
            }
            _formularioActivo = formularioActivo;
            formularioActivo.TopLevel = false;
            formularioActivo.FormBorderStyle = FormBorderStyle.None;
            formularioActivo.Dock = DockStyle.Fill;
            formularioActivo.BackColor = Color.SteelBlue;

            ContenedorPrincipal.Controls.Add(formularioActivo);
            formularioActivo.Show();
        }

        private void menuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario());
        }

        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmCategoria());
        }

        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmProductos());
        }

        private void submenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompras());
        }

        private void submenuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());
        }

        private void submenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmVentas());
        }

        private void submenuDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleVenta());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuclientes, new frmClientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuproveedores, new frmProveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new frmReportes());
        }
    }
}
