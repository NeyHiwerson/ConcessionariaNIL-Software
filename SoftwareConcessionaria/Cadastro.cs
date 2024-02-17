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
    public partial class Cadastro : Form
    {
        private const string url = "https://wild-lion-khakis.cyclic.app";
        private const string complemento = "/registration";
        
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void txtCadNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCadEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCadSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCadConfirmaSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadEntrar_Click(object sender, EventArgs e)
        {

        }

        private void lblCadLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
