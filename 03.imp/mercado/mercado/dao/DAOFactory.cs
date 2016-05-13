using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercado.dao
{
    class DAOFactory
    {
        public static SqlConnection getConnection()
        {
            StringBuilder dsn = new StringBuilder();

            dsn.Append("Server=").Append(Properties.Settings.Default.servidor).Append(";");
            dsn.Append("Database=").Append(Properties.Settings.Default.basedatos).Append(";");

            if (Properties.Settings.Default.integrada)
            {
                dsn.Append("Integrated Security=true");
            } else
            {
                dsn.Append("User Id=").Append(Properties.Settings.Default.usuario).Append(";");
                dsn.Append("Password=").Append(Properties.Settings.Default.clave).Append(";");
            }

            SqlConnection conn = new SqlConnection(dsn.ToString());

            //    @"Server=localhost\SQLExpress; Database=mercado; User Id=sa; Password=Tarija2016");
            conn.Open();
            return conn;
        }

        public static UnidadDAO getUnidadDAO()
        {
            return new UnidadDAO();
        }

        public static ProductoDAO getProductoDAO()
        {
            return new ProductoDAO();
        }

        public static CategoriaDAO getCategoriaDAO()
        {
            return new CategoriaDAO();
        }

        public static MarcaDAO getMarcaDAO()
        {
            return new MarcaDAO();
        }

        public static VentaDAO getVentaDAO()
        {
            return new VentaDAO();
        }

        public static CompraDAO getCompraDAO()
        {
            return new CompraDAO();
        }

        public static IngresoDAO getIngresoDAO()
        {
            return new IngresoDAO();
        }

        public static SalidaDAO getSalidaDAO()
        {
            return new SalidaDAO();
        }
    }
}
