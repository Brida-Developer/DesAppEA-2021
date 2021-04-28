using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DCategoria
    {
        SqlParameter[] parameters = null;
        string comandText = string.Empty;
        public List<Categoria> Listar(Categoria categoria)
        {
     
            List<Categoria> categorias = null;

            try
            {
                comandText = "USP_GetCategoria";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                categorias = new List<Categoria>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            IdCategoria = reader["IdCategoria"] != null ? Convert.ToInt32(reader["idcategoria"]):0,
                            NombreCategoria = reader["NombreCategoria"] != null ? Convert.ToString(reader["nombrecategoria"]): string.Empty,
                            Descripcion = reader["Descripcion"] != null ? Convert.ToString(reader["descripcion"]): string.Empty

                        });
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return categorias;
        }
        public void Insertar(Categoria categoria)
        {
            
            try
            {
                comandText = "USP_InsCategoria";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[0].Value = categoria.NombreCategoria;
                parameters[1] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parameters[1].Value = categoria.Descripcion;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void Actualizar(Categoria categoria)
        {
            try
            {
                comandText = "USP_UpdCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                parameters[1] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[1].Value = categoria.NombreCategoria;
                parameters[2] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parameters[2].Value = categoria.Descripcion;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int Idcategoria)
        {
            try
            {
                comandText = "USP_DelCategoria";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = Idcategoria;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
