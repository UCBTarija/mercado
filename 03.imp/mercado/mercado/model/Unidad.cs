using mercado.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model
{
    class Unidad
    {
        private string _id;
        public string id {
            get { return _id; }
            set { this._id = value; }
        }

        private string _nombre;
        public string nombre {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public static List<Unidad> getAll()
        {
            return  DAOFactory.getUnidadDAO().getAll();
        }
    }
}
