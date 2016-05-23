using mercado.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.model
{
    class Cliente
    {
        private int id;
        private long num_doc;
        private string nombre;

        public static Cliente getById(int id)
        {
            return DAOFactory.getClienteDAO().getById(id);
        }

        public static Cliente getByNumDoc(long num_doc)
        {
            return DAOFactory.getClienteDAO().getByNumDoc(num_doc);
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

        public long Num_doc
        {
            get
            {
                return num_doc;
            }

            set
            {
                num_doc = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
    }
}
