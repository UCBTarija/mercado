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
        public FrmProductoEd()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*crea la instancia vacía de producto y carga los datos 
            del nuevo producto */
            Producto p = new Producto();
            p.Codigo = txtCodigo.Text;
            /*
            cboCategoria.SelectedItem tiene el objeto seleccionado, pero es
            de la clase genérica Object y como sabemos que es una 
            instancia de la clase Categoría, indicamos eso de forma 
            explícita haciendo un casting para poder acceder a su
            atributo Id
            */
            p.Categoria_id = (cboCategoria.SelectedItem as Categoria).Id;
            p.Marca_id = (cboMarca.SelectedItem as Marca).Id;
            p.Descripcion = txtDescripcion.Text;
            p.Cantidad_minima = Convert.ToDouble(txtCantidadMinima.Text);
            p.Precio = Convert.ToDouble(txtPrecioUnitario.Text);

            //guarda el objeto en la bd
            p.guardar();

            //cierra la ventana
            this.Close();
        }

        private void FrmProductoEd_Load(object sender, EventArgs e)
        {
            /*En el momento de cargar la ventana, antes de mostrarla,
            Inicializamos un objeto BindingSource para poder utilizar
            la lista de objetos Categoría en el ComboBox*/

            BindingSource bsCat = new BindingSource();
            bsCat.DataSource = Categoria.getAll();
            cboCategoria.DataSource = bsCat;
            /*se indica explícitamente cual miembro del objeto
            se mostrará en la lista*/
            cboCategoria.DisplayMember = "Nombre";

            BindingSource bsMarca = new BindingSource();
            bsMarca.DataSource = Marca.getAll();
            cboMarca.DataSource = bsMarca;
            cboMarca.DisplayMember = "Nombre";
        }
    }
}
