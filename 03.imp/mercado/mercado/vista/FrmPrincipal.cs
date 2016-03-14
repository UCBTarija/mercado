using mercado.dao;
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

namespace mercado
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ProductoTO> lista = Producto.getAll("xxx");
            BindingSource bs = new BindingSource();
            bs.DataSource = lista;
            dataGridView1.DataSource = bs;

        }
    }
}
