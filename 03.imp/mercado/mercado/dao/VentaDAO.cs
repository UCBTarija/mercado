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
                    insert into venta (fecha, suma_items, descuento, importe, cliente_id) 
                    values (@fecha, @suma_items, @descuento, @importe, @cliente_id) 
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

                SqlTransaction transaccion = DAOFactory.getConnection().BeginTransaction();
                try {
                    //registra la venta
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@cliente_id", SqlDbType.Int).Value = venta.Cliente_id;
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
                            reader.Close();

                            //guarda detalle_transaccion 
                            SqlCommand cmdVenta = new SqlCommand(sql_prod, conn);
                            foreach (DetalleTransaccion item in venta.Productos)
                            {
                                cmdVenta.Parameters.Add("@venta_id", SqlDbType.Int).Value = venta_id;
                                cmdVenta.Parameters.Add("@producto_id", SqlDbType.Int).Value = item.Producto_id;
                                cmdVenta.Parameters.Add("@cantidad", SqlDbType.Real).Value = item.Cantidad;
                                cmdVenta.Parameters.Add("@precio_u", SqlDbType.Real).Value = item.Precio_u;
                                cmdVenta.Parameters.Add("@subtotal", SqlDbType.Real).Value = item.Subtotal;
                                cmdVenta.Parameters.Add("@saldo_cantidad", SqlDbType.Real).Value = item.Saldo_cantidad;
                                cmdVenta.ExecuteNonQuery();
                            }
                        }
                    }

                    transaccion.Commit();
                }catch(Exception ex)
                {
                    transaccion.Rollback();

                }
            }
        }
    }
}
