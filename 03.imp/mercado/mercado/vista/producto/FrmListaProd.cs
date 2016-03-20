using mercado.model;
using mercado.model.vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mercado.vista.producto
{
    public partial class FrmListaProd : Form
    {
        public FrmListaProd()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ProductoTO> lista = Producto.buscar(txtBuscar.Text);
            BindingSource bs = new BindingSource();
            bs.DataSource = lista;
            gridProductos.DataSource = bs;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductoEd edit = new FrmProductoEd();
            edit.ShowDialog();
        }
    }
}
