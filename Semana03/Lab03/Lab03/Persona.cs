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

namespace Lab03
{
    public partial class Persona : Form
    {
        //SqlConecction nos permite manejar un acceso al servidor
        SqlConnection conn;

        public Persona(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Persona_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sql = "SELECT * FROM People";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();

            }
            else {
                MessageBox.Show("La conexion esta cerrada");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                String FirstName = txtNombre.Text;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "BuscarPersonaNombre";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@FirstName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Value = FirstName;

                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }
            else 
            {
                MessageBox.Show("La conexion esta cerrada");
            }
            /*{
                try
                {
                    //Abrimos la conexión
                    conn.Open();

                    //Creamos nuestra consulta
                    SqlCommand command =
                        new SqlCommand("USP_BuscarPersonaNombre", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@FirstName";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Value = txtNombre.Text.Trim();


                    //Asignamos parametros a nuestro comando

                    command.Parameters.Add(parameter2);

                    //Trabjamos con el data reader
                    SqlDataReader reader = command.ExecuteReader();

                    List<Person> people = new List<Person>();
                    while (reader.Read())
                    {
                        people.Add(
                        new Person
                        {
                            PersonID = (int)reader["PeopleID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            HireDate = reader["HireDate"].ToString(),
                            EnrollmentDate = (DateTime)reader["EnrollmentDate"]

                        });
                    }
                    conn.Close();
                    dgvListado.DataSource = people;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message.ToString());
                }*/

        }





    }
    }