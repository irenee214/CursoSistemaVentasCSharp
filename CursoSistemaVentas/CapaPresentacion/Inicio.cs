using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio(Usuario objUsuario = null)
        {
            if(objUsuario == null) 
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else 
                usuarioActual = objUsuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }

            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if(FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;
            
            contenedor.Controls.Add(formulario);
            formulario.Show();

        }

        private void menuusario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new frmCategoria());
        }

        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new frmProducto());
        }

        private void submenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmVentas());
        }

        private void submenuVerDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleVenta());
        }

        private void submenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmCompras(usuarioActual));
        }

        private void submenuVerDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleCompra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new frmNegocio());
        }
    }
}
