using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Security.Policy;
using SoftwareConcessionaria.Dependencias.models;

namespace SoftwareConcessionaria
{
    public partial class Login : Form
    {
        //public Veiculo formVeiculo = new Veiculo();
        string urlBase = "https://wild-lion-khakis.cyclic.app";        
        string complemento = "https://wild-lion-khakis.cyclic.app/login";        
        public TokenManager tokenManager = new TokenManager();

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLoginEntrar;
            txtResposta.Text = "Offline";

            try
            {
                using (var cliente = new HttpClient())
                {

                    var resposta = cliente.GetStringAsync(urlBase);
                    resposta.Wait();

                    var responseObject = JsonConvert.DeserializeAnonymousType(resposta.Result, new { mensage = "" });

                    // Atualiza o campo de resposta com a mensagem da API
                    txtResposta.Text = responseObject.mensage;
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }
        
        private async void btnLoginEntrar_Click(object sender, EventArgs e)
        {
            string email = txtLoginUsuario.Text;
            string password = txtLoginSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            try
            {
                using (var cliente = new HttpClient())
                {
                    var data = new
                    {
                        email,
                        password
                    };

                    // Serializar o objeto para JSON
                    string jsonData = JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var resposta = cliente.PostAsync(complemento, content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        TokenManager tokenManager = JsonConvert.DeserializeObject<TokenManager>(retorno.Result);
                        txtLoginUsuario.Text = string.Empty;
                        txtLoginSenha.Text = string.Empty;
                        // Armazena o TokenManager na ApplicationContext
                        ApplicationContext.Instance.tokenManager = tokenManager;

                        // Instancia o formulário Veiculo e armazena na ApplicationContext
                        Veiculo veiculo = new Veiculo();
                        ApplicationContext.Instance.veiculo = veiculo;

                        veiculo.Show();

                    }
                    else
                    {
                        var erroResposta = resposta.Result.Content.ReadAsStringAsync().Result;
                        var erroObjeto = JsonConvert.DeserializeAnonymousType(erroResposta, new { message = "" });
                        MessageBox.Show("Erro: " + erroObjeto.message);
                    }

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }        

        private void lblLoginEsqueceuSuaSenha_Click(object sender, EventArgs e)
        {
            this.Hide();
            EsqueceuSenha esqueceuSenha = new EsqueceuSenha();
            esqueceuSenha.Show();
        }

        private void lblCadastro_Click(object sender, EventArgs e)
        {            
            this.Hide();
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
        }

        private void txtResposta_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLoginEntrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Impede o som do "ding" ao pressionar Enter
                e.Handled = true;

                // Chama o método associado ao clique do botão
                btnLoginEntrar.PerformClick();
            }
        }

        private void txtLoginSenha_TextChanged(object sender, EventArgs e)
        {
            txtLoginSenha.UseSystemPasswordChar = true;
        }
    }
}