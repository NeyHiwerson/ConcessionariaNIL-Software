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

namespace SoftwareConcessionaria
{
    public partial class Login : Form
    {
        string urlBase = "https://wild-lion-khakis.cyclic.app";
        //string url = "https://wild-lion-khakis.cyclic.app";
        string complemento = "https://wild-lion-khakis.cyclic.app/login";                   
        public Login()
        {
            InitializeComponent();            
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
                
        public class RespostaLogin
        {
            public string type { get; set; }
            public string token { get; set; }
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
                        var tokenCriado = JsonConvert.DeserializeObject<RespostaLogin>(retorno.Result);
                        this.Hide();
                        Veiculo veiculo = new Veiculo();
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
    }
}