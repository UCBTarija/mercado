using mercado.dao;
using mercado.model.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model
{
    class Producto
    {
        private int _id;
        private string _codigo;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public static List<ProductoTO> getAll(string texto)
        {
            return DAOFactory.getProductoDAO().getAll(texto);
        }
    }
}
