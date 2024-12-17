using Dominio.Entidad.Herramientas.Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dominio.Entidad.Herramientas.Entidad;

namespace Infraestructura.Data.Herramienta
{
    public class CategoriaDAL : ICategorias
    {
        public IEnumerable<Categorias> GetAll()
        {
            List<Categorias> temp = new List<Categorias>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conex"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_categoria", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(new Categorias()
                    {
                        idcategoria = dr.GetInt32(0),
                        nombre = dr.GetString(1)
                    });
                }
                dr.Close();
                conn.Close();
            }
            return temp;
        }

        public IEnumerable<Categorias> GetByName(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
