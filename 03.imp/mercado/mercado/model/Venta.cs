using mercado.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mercado.model
{
    class Venta
    {
        private int id;
        private DateTime fecha;
        private double suma_items;
        private double descuento;
        private double importe;

        private List<DetalleTransaccion> productos;

        public void guardar()
        {
            //calcula el nuevo saldo de cada producto
            foreach(DetalleTransaccion item in this.productos)
            {
                item.Saldo_cantidad = Producto.getSaldo(item.Producto_id);
            }

            DAOFactory.getVentaDAO().guardarVenta(this);
        }

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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public double Suma_items
        {
            get
            {
                return suma_items;
            }

            set
            {
                suma_items = value;
            }
        }

        public double Descuento
        {
            get
            {
                return descuento;
            }

            set
            {
                descuento = value;
            }
        }

        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }

        public List<DetalleTransaccion> Productos
        {
            get
            {
                return productos;
            }

            set
            {
                productos = value;
            }
        }
    }
}
