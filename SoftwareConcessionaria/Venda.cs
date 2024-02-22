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
    public partial class Venda : Form
    {
        public Venda()
        {
            InitializeComponent();
        }

        private void Venda_Load(object sender, EventArgs e)
        {

        }

        private void btnVendaVeiculo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Veiculo veiculo = new Veiculo();
            veiculo.Show();
        }

        private void btnVendaCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContatoCliente contatoCliente = new ContatoCliente();
            contatoCliente.Show();
        }

        private void btnVendaVenda_Click(object sender, EventArgs e)
        {
            //colocar uma cor como clique e não faz nada
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefoneVendaVendedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
