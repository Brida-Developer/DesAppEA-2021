using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : Form
    {
        //Iniciando con la autenticacion de Windons
        private SqlConnection conn = new SqlConnection("Server=DESKTOP-E712RJ8; Database=db_lab03; Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            int result = LoginValidacion(txtUsuario.Text, txtPassword.Text);
            if (result == 1) {
                MDIParent1 mnu = new MDIParent1();
                this.Hide();
                mnu.ShowDialog();
            } else if(result == 0) {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }

        private int LoginValidacion(string usuario, string password)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario_nombre", usuario);
                cmd.Parameters.AddWithValue("@usuario_password", password);

                SqlDataReader redr = cmd.ExecuteReader();
                if (redr.Read())
                {
                    return redr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return -1;

        }
    }
}
