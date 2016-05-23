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

        public FrmVentaEd()
        {
            InitializeComponent();
            gridProductos.Columns["colDescripcion"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridProductos.Columns["colDisponible"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridProductos.Columns["colPrecioU"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridProductos.Columns["colTotal"].DefaultCellStyle.BackColor = SystemColors.ControlLight;
        }

        public void nuevaVenta()
        {
            this.Text = "Nueva Venta";
            this.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.Fecha = dtpFecha.Value;

            venta.Suma_items = Convert.ToDouble(txtSubtotal.Text);
            venta.Descuento = Convert.ToDouble(txtDescuento.Text);
            venta.Importe = Convert.ToDouble(txtImporte.Text);



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
        }

        private void gridProductos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void gridProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProductos.Columns[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void gridProductos_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
