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
            frmVenta.Dock = DockStyle.Fill;
            frmVenta.nuevaVenta();
        }
    }
}
