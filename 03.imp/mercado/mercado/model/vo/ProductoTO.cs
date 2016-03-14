using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model.vo
{
    class ProductoTO
    {
        private int _id;
        private string _codigo;
        private string _descripcion;
        private string _marca;

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
    }
}
