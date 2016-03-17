using mercado.model.vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class ProductoDAO
    {
        public List<ProductoTO> buscar(string texto)
        {
            List<ProductoTO> lista = new List<ProductoTO>();
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                string sql = @"
                    SELECT producto.id, 
	                    producto.codigo,
	                    marca.nombre AS marca, 
	                    categoria.nombre as categoria,
	                    producto.descripcion,
	                    producto.cantidad_minima,
	                    producto.precio
                    FROM producto
	                    JOIN marca ON marca.id = producto.marca_id
	                    JOIN categoria ON categoria.id = producto.categoria_id
                    WHERE codigo like @TEXTO
                    OR descripcion like @TEXTO
                    OR categoria.nombre like @TEXTO
                    OR marca.nombre like @TEXTO                    
                ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar).Value = "%" + texto + "%";
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ProductoTO o;
                    while (reader.Read())
                    {
                        o = new ProductoTO();
                        o.Id = reader.GetInt32(0);
                        o.Codigo = reader.GetString(1);
                        o.Marca = reader.GetString(2);
                        o.Categoria = reader.GetString(3);
                        o.Descripcion = reader.GetString(4);
                        o.Cantidad_minima = reader.GetDouble(5);
                        o.Precio = reader.GetDouble(6);
                        lista.Add(o);
                    }
                }
            }
            return lista;

        }
    }
}
