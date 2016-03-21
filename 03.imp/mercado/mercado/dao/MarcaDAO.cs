using mercado.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class MarcaDAO
    {
        public List<Marca> getAll()
        {
            List<Marca> lista = new List<Marca>();
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                string sql = @"
                    SELECT id, nombre
                    FROM marca
                ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Marca o;
                    while (reader.Read())
                    {
                        o = new Marca();
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
