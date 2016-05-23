using mercado.dao;
using mercado.model;
using mercado.model.vo;
using mercado.vista.producto;
using mercado.vista.ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mercado
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListaProd lista = new FrmListaProd();
            lista.MdiParent = this;
            lista.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentaEd frmVenta = new FrmVentaEd(); 
            frmVenta.MdiParent = this;

            Rectangle bounds = this.ClientRectangle;
            bounds.Width -= SystemInformation.Border3DSize.Width * 2;
            bounds.Height -= SystemInformation.Border3DSize.Height * 2 + menuStrip1.Height;
            frmVenta.Bounds = bounds;

            frmVenta.Location = new Point(0, 0);
            frmVenta.nuevaVenta();
        }
    }
}
