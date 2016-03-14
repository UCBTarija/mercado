using mercado.model.vo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class ProductoDAO
    {
        public List<ProductoTO> getAll(string texto)
        {
            List<ProductoTO> lista = new List<ProductoTO>();
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                SqlCommand cmd = new SqlCommand("select id,codigo from producto", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ProductoTO o;
                    while (reader.Read())
                    {
                        o = new ProductoTO();
                        o.id = reader.GetInt32(0);
                        o.codigo = reader.GetString(1);
                        lista.Add(o);
                    }
                }
            }
            return lista;

        }
    }
}
