using mercado.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class CategoriaDAO
    {
        public List<Categoria> getAll()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                string sql = @"
                    SELECT id, nombre
                    FROM categoria
                ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Categoria o;
                    while (reader.Read())
                    {
                        o = new Categoria();
                        o.Id = reader.GetInt32(0);
                        o.Nombre = reader.GetString(1);
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }
    }
}
