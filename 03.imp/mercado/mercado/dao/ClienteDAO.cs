using mercado.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class ClienteDAO
    {
        public Cliente getById(int id) 
        {
            Cliente o = null;
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                string sql = @"
                    SELECT id, num_doc, nombre
                    FROM cliente
                    WHERE id = @id
                ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        o = new Cliente();
                        o.Id = reader.GetInt32(0);
                        o.Num_doc = reader.GetInt64(1);
                        o.Nombre = reader.GetString(2);
                    }
                }
            }
            return o;
        }

        public Cliente getByNumDoc(long num_doc)
        {
            Cliente o = null;
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                string sql = @"
                    SELECT id, num_doc, nombre
                    FROM cliente
                    WHERE num_doc = @num_doc
                ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@num_doc", SqlDbType.BigInt).Value = num_doc;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        o = new Cliente();
                        o.Id = reader.GetInt32(0);
                        o.Num_doc = reader.GetInt64(1);
                        o.Nombre = reader.GetString(2);
                    }
                }
            }
            return o;
        }
    }
}
