

namespace mercado.model.vo
{
    public class ProductoTO
    {
        private int _id;
        private string _codigo;
        private string _descripcion;
        private string _marca;
        private string _categoria;
        private double _cantidad_minima;
        private double _precio;

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

        public string Marca
        {
            get
            {
                return _marca;
            }

            set
            {
                _marca = value;
            }
        }

        public string Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
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
    }
}
