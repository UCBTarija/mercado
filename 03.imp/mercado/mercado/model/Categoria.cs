using mercado.dao;
using System.Collections.Generic;

namespace mercado.model
{
    public class Categoria
    {
        private int _id;
        private string _nombre;

        public static List<Categoria> getAll()
        {
            return DAOFactory.getCategoriaDAO().getAll();
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