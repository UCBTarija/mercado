using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model
{
    class DetalleTransaccion
    {
        private int id;
        private double cantidad;
        private double precio_u;
        private double subtotal;
        private double saldo_cantidad;

        private int venta_id;
        private int producto_id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public double Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public double Precio_u
        {
            get
            {
                return precio_u;
            }

            set
            {
                precio_u = value;
            }
        }

        public double Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public double Saldo_cantidad
        {
            get
            {
                return saldo_cantidad;
            }

            set
            {
                saldo_cantidad = value;
            }
        }

        public int Venta_id
        {
            get
            {
                return venta_id;
            }

            set
            {
                venta_id = value;
            }
        }

        public int Producto_id
        {
            get
            {
                return producto_id;
            }

            set
            {
                producto_id = value;
            }
        }
    }
}
