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
        private int cliente_id;

        private List<DetalleTransaccion> productos;

        public void guardar()
        {
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

        public int Cliente_id
        {
            get
            {
                return cliente_id;
            }

            set
            {
                cliente_id = value;
            }
        }
    }
}
