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

namespace mercado.vista.ventas
{
    public partial class FrmVentaEd : Form
    {
        private Cliente cliente = null;
        BindingSource bsClientes = new BindingSource();
        BindingSource bsProductos = new BindingSource();
        
        public FrmVentaEd()
        {
            InitializeComponent();

            gridProductos.Columns["colDescripcion"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridProductos.Columns["colDisponible"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridProductos.Columns["colPrecioU"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridProductos.Columns["colTotal"].DefaultCellStyle.BackColor = SystemColors.ControlLight;

            txtDescuento.Text = "0";

            


        }

        public void nuevaVenta()
        {
            this.Text = "Nueva Venta";
            this.Show();
        }

        private void validar()
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validar();

            Venta venta = new Venta();
            venta.Fecha = dtpFecha.Value;
            venta.Cliente_id = this.cliente.Id;
            venta.Suma_items = Convert.ToDouble(txtSubtotal.Text);
            venta.Descuento = Convert.ToDouble(txtDescuento.Text);
            venta.Importe = Convert.ToDouble(txtImporte.Text);

            venta.Productos = new List<DetalleTransaccion>();            

            for(int i=0; i<gridProductos.Rows.Count - 1; i++)
            {
                string codigo = gridProductos.Rows[i].Cells["colCodigo"].Value.ToString();
                string strCantidad = gridProductos.Rows[i].Cells["colCantidad"].Value.ToString();
                int cantidad = Convert.ToInt32(strCantidad);

                Producto p = Producto.getByCodigo(codigo);

                DetalleTransaccion dt = new DetalleTransaccion();
                dt.Producto_id = p.Id;
                dt.Cantidad = cantidad;
                dt.Precio_u = p.Precio;
                dt.Saldo_cantidad = p.getSaldo() - cantidad;
                dt.Subtotal = p.Precio * cantidad;

                venta.Productos.Add(dt);
            }

            venta.guardar();

            Close();
        }

        private void txtNit_Validating(object sender, CancelEventArgs e)
        {
            long numDoc = 0;

            txtNombre.Text = "";
            txtNombre.ReadOnly = false;
            txtNombre.BackColor = SystemColors.Window;
            this.cliente = null;

            if ((txtNit.Text.Length > 0) && Int64.TryParse(txtNit.Text, out numDoc))
            {
                this.cliente = Cliente.getByNumDoc(numDoc);
                if (this.cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtNombre.ReadOnly = true;
                    txtNombre.BackColor = SystemColors.ControlLight;
                }

            } 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if(gridProductos.Columns[e.ColumnIndex].Name == "colCodigo" && (gridProductos.CurrentCell.Value!= null))
            {
                string codigo = gridProductos.CurrentCell.Value.ToString();
                if (codigo.Length > 0)
                {
                    Producto producto = Producto.getByCodigo(codigo);
                    if (producto != null)
                    {
                        gridProductos.Rows[e.RowIndex].Cells["colDescripcion"].Value = producto.Descripcion;
                        gridProductos.Rows[e.RowIndex].Cells["colDisponible"].Value = producto.getSaldo().ToString();
                        gridProductos.Rows[e.RowIndex].Cells["colCantidad"].Value = 1;
                        gridProductos.Rows[e.RowIndex].Cells["colPrecioU"].Value = producto.Precio;
                        gridProductos.Rows[e.RowIndex].Cells["colTotal"].Value = producto.Precio * 1;
                    }
                }
            } else if (gridProductos.Columns[e.ColumnIndex].Name == "colCantidad")
            {
                string strCantidad = gridProductos.CurrentCell.Value.ToString();
                int cantidad;

                if(strCantidad.Length>0 && Int32.TryParse(strCantidad, out cantidad))
                {
                    double precio = Convert.ToDouble(gridProductos.Rows[e.RowIndex].Cells["colPrecioU"].Value);
                    gridProductos.Rows[e.RowIndex].Cells["colTotal"].Value = precio * cantidad;
                } else
                {
                    gridProductos.Rows[e.RowIndex].Cells["colTotal"].Value = 0;
                }
            }

            calcularTotal();
        }

        private void calcularTotal()
        {
            double suma_items = 0;

            for (int i =0; i<gridProductos.Rows.Count - 1; i++)
            {
                suma_items += Convert.ToDouble(gridProductos.Rows[i].Cells["colTotal"].Value);
            }

            txtSubtotal.Text = suma_items.ToString();
            double descuento = Convert.ToDouble(txtDescuento.Text);
            double total = suma_items - descuento;
            txtImporte.Text = total.ToString();
        }

        
        private void gridProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProductos.Columns[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtDescuento_Validating(object sender, CancelEventArgs e)
        {
            if (txtDescuento.Text.Length > 0)
            {
                double descuento;
                if(!Double.TryParse(txtDescuento.Text, out descuento)){
                    txtDescuento.Text = "0";
                    MessageBox.Show("Valor introducido inválido");
                } else
                {
                    calcularTotal();
                }
            }
        }

        Producto p = new Producto();
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                
                bsProductos.DataSource = Producto.getByCodigo(txtCodigo.Text);
                if (bsProductos.DataSource != null)
                {
                    txtProducto.DataBindings.Add("TEXT", bsProductos.DataSource, "Descripcion");
                    p = (Producto)bsProductos.DataSource;
                    txtProducto.Focus();
                }
                else
                    MessageBox.Show("PRODUCTO NO ENCONTRADO");
                
            }
           
        }

        
        private void txtNit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                
                bsClientes.DataSource = Cliente.getByNumDoc(Convert.ToInt64(txtNit.Text));
                if (bsClientes.DataSource != null)
                {
                    txtNombre.DataBindings.Add("TEXT", bsClientes.DataSource, "Nombre");
                    txtCodigo.Focus();
                    
                }
                else
                    MessageBox.Show("CLIENTE NO ENCONTRADO");
                bsClientes.DataSource = null;
            }
            
            
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                gridProductos.Rows.Add(p.Codigo, p.Descripcion, "SI", p.Precio, 1, p.Precio);


            }
            
        }
    }
}
