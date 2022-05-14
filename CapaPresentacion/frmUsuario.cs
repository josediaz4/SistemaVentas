using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombos() { Valor = 1.ToString(), Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombos() { Valor = 0.ToString(), Texto = "No Activo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;


            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cmbRol.Items.Add(new OpcionCombos() { Valor = item.IdRol.ToString(), Texto = item.Descripcion });
            }

            cmbRol.DisplayMember = "Texto";
            cmbRol.ValueMember = "Valor";
            cmbRol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvGrillaUsuario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionado")
                {
                    cmbBuscar.Items.Add(new OpcionCombos() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbBuscar.DisplayMember = "Texto";
            cmbBuscar.ValueMember = "Valor";
            cmbBuscar.SelectedIndex = 0;

            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvGrillaUsuario.Rows.Add(new object[]
                {
                    "", item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave, 
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado==true?"Activo" : "No Activo",
                    item.Telefono
                });
            }

        }

        private void brnGuardar_Click(object sender, EventArgs e)
        {
            dgvGrillaUsuario.Rows.Add(new object[]{
                "", txtId.Text, txtDocumento.Text, txtNombre.Text, txtCorreo.Text, txtTelefono.Text,
                ((OpcionCombos)cmbRol.SelectedItem).Valor.ToString(),
                ((OpcionCombos)cmbRol.SelectedItem).Texto.ToString(),
                ((OpcionCombos)cmbEstado.SelectedItem).Valor.ToString(),
                ((OpcionCombos)cmbEstado.SelectedItem).Texto.ToString()
            });
            LimpiarControles();
        }
        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtNombre.Clear();
            txtDocumento.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            txtTelefono.Clear();
            cmbRol.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private void dgvGrillaUsuario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvGrillaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrillaUsuario.Columns[e.ColumnIndex].Name == "btnSeleccionado")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtId.Text = dgvGrillaUsuario.Rows[indice].Cells["IdUsuario"].Value.ToString();
                    txtDocumento.Text = dgvGrillaUsuario.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Text = dgvGrillaUsuario.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvGrillaUsuario.Rows[indice].Cells["Correo"].Value.ToString();
                    txtContrasena.Text = dgvGrillaUsuario.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarContrasena.Text = dgvGrillaUsuario.Rows[indice].Cells["Clave"].Value.ToString();
                    txtTelefono.Text = dgvGrillaUsuario.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombos combo in cmbRol.Items)
                    {
                        if (Convert.ToInt32(combo.Valor) == Convert.ToInt32(dgvGrillaUsuario.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indiceCombo = cmbRol.Items.IndexOf(combo);
                            cmbRol.SelectedIndex = indiceCombo;
                            break;
                        }
                    }

                    foreach (OpcionCombos combo in cmbEstado.Items)
                    {
                        if (Convert.ToInt32(combo.Valor) == Convert.ToInt32(dgvGrillaUsuario.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = cmbEstado.Items.IndexOf(combo);
                            cmbEstado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }
    }
}
