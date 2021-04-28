using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Login1 : Form
    {
        //SqlConecction nos permite manejar un acceso al servidor
        SqlConnection conn;

        public Login1(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
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
            finally {
                conn.Close();
            }
            
            return -1;

            

        }

        private void Login1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            int result = LoginValidacion(txtUsuario.Text, txtPassword.Text);
            
            if (result ==1) {
                MDIParent1 mnu = new MDIParent1();
                this.Hide();
                mnu.ShowDialog();
            }
            else {
                MessageBox.Show("Usuario o contraseña incorreta");
            }
            
        }
    }
}
