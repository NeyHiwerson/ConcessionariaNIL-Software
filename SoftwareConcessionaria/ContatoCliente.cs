using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConcessionaria
{
    public partial class ContatoCliente : Form
    {
        public ContatoCliente()
        {
            InitializeComponent();
        }

        private void ContatoCliente_Load(object sender, EventArgs e)
        {

        }

        //btnClienteVeiculo
        private void btnVendaVeiculo_Click(object sender, EventArgs e)
        {//btnClienteVeiculo
            this.Hide();
            Veiculo veiculo = new Veiculo();
            veiculo.Show();
        }

        //btnClienteCliente
        private void btnVendaCliente_Click(object sender, EventArgs e)
        {//btnClienteCliente
            //colocar uma cor como clique e não faz nada
        }

        //btnClienteVenda
        private void btnVendaVenda_Click(object sender, EventArgs e)
        {//btnClienteVenda
            this.Hide();
            Venda venda = new Venda();
            venda.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
