using mercado.dao;
using mercado.model.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model
{
    public class Producto
    {
        private int _id;
        private string _codigo;
        private string _descripcion;
        private double _cantidad_minima;
        private double _precio;
        private int _categoria_id;
        private int _marca_id;

        public void guardar()
        {
            DAOFactory.getProductoDAO().agregar(this);
        }

        public static List<ProductoTO> buscar(string texto)
        {
            return DAOFactory.getProductoDAO().buscar(texto);
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        public double Cantidad_minima
        {
            get
            {
                return _cantidad_minima;
            }

            set
            {
                _cantidad_minima = value;
            }
        }

        public double Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
            }
        }

        public int Categoria_id
        {
            get
            {
                return _categoria_id;
            }

            set
            {
                _categoria_id = value;
            }
        }

        public int Marca_id
        {
            get
            {
                return _marca_id;
            }

            set
            {
                _marca_id = value;
            }
        }
    }
}
