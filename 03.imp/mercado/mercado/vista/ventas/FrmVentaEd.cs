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
        private bool _isNew;

        public FrmVentaEd()
        {
            InitializeComponent();
        }

        public void nuevaVenta()
        {
            this._isNew = true;
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
    }
}
