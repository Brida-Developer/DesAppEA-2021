using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;
        
        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }catch(Exception ex)
            {
                throw ex;
            }
            return categorias;
        }
        public bool Actualizar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Insertar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Insertar(categoria);
            }catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Eliminar(int idCategoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(idCategoria);
            }catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        
    }
}
