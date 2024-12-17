using Dominio.Entidad.Herramientas.Abstraccion;
using Dominio.Entidad.Herramientas.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;


namespace Infraestructura.Data.Herramienta
{
    public class HerramientaDAL : IHerramienta
    {
        public string Add(Herramientas registro)
        {
            string mensaje = "";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conex"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_Merge_Herramienta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", registro.idher);
                    cmd.Parameters.AddWithValue("@desc", registro.desher);
                    cmd.Parameters.AddWithValue("@med", registro.medher);
                    cmd.Parameters.AddWithValue("@idcategoria", registro.idcategoria);
                    cmd.Parameters.AddWithValue("@preUni", registro.preuni);
                    cmd.Parameters.AddWithValue("@stock", registro.stock);
                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {c} herramienta";
                }
                catch (SqlException ex)
                {
                    mensaje += ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            return mensaje;

        }

        public string Delete(string id)
        {
            string mensaje = "";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conex"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_eliminar_herramienta @idher", conn);
                cmd.Parameters.AddWithValue("@idher", id);
                int c = cmd.ExecuteNonQuery();
                mensaje = $"Se ha eliminado {c} herramienta correctamente";
            }

            return mensaje;
        }

        public Herramientas find(string id)
        {
            Herramientas reg = new Herramientas();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conex"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_buscar_herramienta @idher", conn);
                cmd.Parameters.AddWithValue("@idher", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    reg = new Herramientas()
                    {
                        idher = id,
                        desher = dr.GetString(1),
                        medher = dr.GetString(2),
                        idcategoria = dr.GetInt32(3),
                        preuni = dr.GetDecimal(4),
                        stock = dr.GetInt32(5)
                    };
                }
                conn.Close();
                dr.Close();
            };
            return reg;

        }

        public IEnumerable<Herramientas> GetAll()
        {
            List<Herramientas> temp = new List<Herramientas>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conex"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_herramientas", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(new Herramientas(){
                        idher = dr.GetString(0),
                        desher = dr.GetString(1),
                        medher = dr.GetString(2),
                        idcategoria = dr.GetInt32(3),
                        preuni = dr.GetDecimal(4),
                        stock = dr.GetInt32(5)
                    });
                }
                conn.Close();
                dr.Close();
            }
            return temp;

        }

        public IEnumerable<Herramientas> GetByName(string nombre)
        {
            throw new NotImplementedException();
        }

        public string Update(Herramientas registro)
        {
            string mensaje = "";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conex"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_Merge_Herramienta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", registro.idher);
                    cmd.Parameters.AddWithValue("@desc", registro.desher);
                    cmd.Parameters.AddWithValue("@med", registro.medher);
                    cmd.Parameters.AddWithValue("@idcategoria", registro.idcategoria);
                    cmd.Parameters.AddWithValue("@preUni", registro.preuni);
                    cmd.Parameters.AddWithValue("@stock", registro.stock);
                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {c} herramienta";
                }
                catch (SqlException ex)
                {
                    mensaje += ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            return mensaje;
        }

    }
}

