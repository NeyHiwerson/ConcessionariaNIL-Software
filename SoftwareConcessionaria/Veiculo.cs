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
    public partial class Veiculo : Form
    {
        public Veiculo()
        {
            InitializeComponent();
        }

        private void Veiculo_Load(object sender, EventArgs e)
        {

        }

        private void btnVeiculoVeiculo_Click(object sender, EventArgs e)
        {
            //colocar uma cor como clique e não faz nada
        }

        private void btnVeiculoCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContatoCliente contatoCliente = new ContatoCliente();
            contatoCliente.Show();
        }

        private void btnVeiculoVenda_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venda venda = new Venda();
            venda.Show();
        }
    }
}
