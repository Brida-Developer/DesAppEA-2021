using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_01
{
    public partial class Lab01_02 : Form
    {
        public Lab01_02()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)

        {
            string codigo = linkCodigo.Text;
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            
           
            dgvUsuarios.Rows.Add("", codigo, dni, nombre, apellido);


        }
    }
}
