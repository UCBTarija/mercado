using mercado.model;
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
    public partial class FrmProductoEd : Form
    {
        private Producto _producto;
        private Boolean isNew = false;

        public FrmProductoEd()
        {
            InitializeComponent();

            /*En el momento de cargar la ventana, antes de mostrarla,
                        Inicializamos un objeto BindingSource para poder utilizar
                        la lista de objetos Categoría en el ComboBox*/

            BindingSource bsCat = new BindingSource();
            bsCat.DataSource = Categoria.getAll();
            cboCategoria.DataSource = bsCat;
            /*se indica explícitamente cual miembro del objeto
            se mostrará en la lista*/
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "id";

            BindingSource bsMarca = new BindingSource();
            bsMarca.DataSource = Marca.getAll();
            cboMarca.DataSource = bsMarca;
            cboMarca.DisplayMember = "Nombre";
            cboMarca.ValueMember = "id";
        }

        public void modificar(Producto producto)
        {
            this.isNew = false;
            this._producto = producto;
            txtCodigo.Text = producto.Codigo;
            txtCantidadMinima.Text = producto.Cantidad_minima.ToString();
            txtDescripcion.Text = producto.Descripcion;
            txtPrecioUnitario.Text = producto.Precio.ToString();

            cboCategoria.SelectedValue = producto.Categoria_id;
            cboMarca.SelectedValue = producto.Marca_id;

            this.ShowDialog();
        }

        public void nuevo()
        {
            this.isNew = true;
            this._producto = new Producto();
            this.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*carga los datos en el objeto instancia this._producto */
            _producto.Codigo = txtCodigo.Text;
            _producto.Categoria_id = Convert.ToInt32(cboCategoria.SelectedValue);
            _producto.Marca_id = Convert.ToInt32(cboMarca.SelectedValue);
            _producto.Descripcion = txtDescripcion.Text;
            _producto.Cantidad_minima = Convert.ToDouble(txtCantidadMinima.Text);
            _producto.Precio = Convert.ToDouble(txtPrecioUnitario.Text);

            //guarda el objeto en la bd
            if (this.isNew)
            {
                _producto.guardar();
            } else
            {
                _producto.modificar();
            }
            

            //cierra la ventana
            this.Close();
        }
    }
}
