﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == lblUsuario.Text && u.Clave == txtclave.Text).FirstOrDefault();

            if(oUsuario != null)
            {
                Inicio form = new Inicio(oUsuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;

            } 
            else
            {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            

        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            lblUsuario.Text = "";
            txtclave.Text = "";
            this.Show();
        }
    }
}
