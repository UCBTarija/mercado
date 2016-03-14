using mercado.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class UnidadDAO
    {
        public List<Unidad> getAll()
        {
            List<Unidad> lista = new List<Unidad>();
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                SqlCommand cmd = new SqlCommand("select id,nombre from unidad", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Unidad u;
                    while (reader.Read())
                    {
                        u = new Unidad();
                        u.id = reader.GetString(0);
                        u.nombre = reader.GetString(1);
                        lista.Add(u);
                    }
                }
            }
            return lista;
        }
    }
}
