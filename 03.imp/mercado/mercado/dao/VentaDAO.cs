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
    class VentaDAO
    {
        public void guardarVenta(Venta venta)
        {
            using (SqlConnection conn = DAOFactory.getConnection())
            {
                string sql = @"
                    insert into venta (fecha, suma_items, descuento, importe) 
                    values (@fecha, @suma_items, @descuento, @importe) 
                ";
                string sql_prod = @"
                    insert into detalle_transaccion (cantidad,precio_u,
                        subtotal,saldo_cantidad,producto_id,venta_id)
                    values (@cantidad,@precio_u,@subtotal,
                        @saldo_cantidad,@producto_id,@venta_id)
                ";
                String sql_id = @"
                    SELECT IDENT_CURRENT('venta');
                ";

                //registra la venta
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = venta.Fecha;
                cmd.Parameters.Add("@suma_items", SqlDbType.Int).Value = venta.Suma_items;
                cmd.Parameters.Add("@descuento", SqlDbType.Real).Value = venta.Descuento;
                cmd.Parameters.Add("@importe", SqlDbType.Real).Value = venta.Importe;
                cmd.ExecuteNonQuery();

                //obtiene el venta.id generado
                cmd = new SqlCommand(sql_id, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int venta_id = Convert.ToInt32(reader.GetValue(0));
                        
                        //guarda detalle_transaccion 
                        cmd = new SqlCommand(sql_prod, conn);
                        foreach (DetalleTransaccion item in venta.Productos)
                        {                                                        
                            cmd.Parameters.Add("@venta_id", SqlDbType.Int).Value = venta_id;
                            cmd.Parameters.Add("@producto_id", SqlDbType.Int).Value = item.Producto_id;
                            cmd.Parameters.Add("@cantidad", SqlDbType.Real).Value = item.Cantidad;
                            cmd.Parameters.Add("@precio_u", SqlDbType.Real).Value = item.Precio_u;
                            cmd.Parameters.Add("@subtotal", SqlDbType.Real).Value = item.Subtotal;
                            cmd.Parameters.Add("@saldo_cantidad", SqlDbType.Real).Value = item.Saldo_cantidad;                            
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
