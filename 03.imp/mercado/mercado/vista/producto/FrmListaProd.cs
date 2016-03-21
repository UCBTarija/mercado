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
            //carga la lista de productos
            List<ProductoTO> lista = Producto.buscar(txtBuscar.Text);
            //inicializa el objeto que proporcionará los datos de la lista al grid
            BindingSource bs = new BindingSource();
            bs.DataSource = lista;
            gridProductos.DataSource = bs;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductoEd edit = new FrmProductoEd();
            edit.nuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (gridProductos.SelectedRows.Count > 0)
            {
                //obtiene el productoTO seleccionado
                ProductoTO selected = (gridProductos.SelectedRows[0].DataBoundItem as ProductoTO);
                //carga el producto en base a productoTO.id seleccionado
                Producto producto = Producto.getById(selected.Id);

                //inicializa la ventana de edición y le pasa el producto a modificar
                FrmProductoEd productoEd = new FrmProductoEd();
                productoEd.modificar(producto);
            }
        }

        private void gridProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.PerformClick();
        }
    }
}
