using mercado.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model
{
    class Marca
    {
        private int _id;
        private string _nombre;

        public static List<Marca> getAll()
        {
            return DAOFactory.getMarcaDAO().getAll();
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

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
    }
}
