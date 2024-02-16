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
        public Login()
        {
            InitializeComponent();
        }

        private const string url = "https://wild-lion-khakis.cyclic.app";
        private const string complemento = "/login";        

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtLoginUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLoginEntrar_Click(object sender, EventArgs e)
        {            
            string email = txtLoginUsuario.Text;
            string senha = txtLoginSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
                        
            var data = new
            {
                email,
                senha
            };

            // Serializar o objeto para JSON
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            // Criar cliente HTTP
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Configurar o cabeçalho da requisição
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Enviar a requisição POST
                    HttpResponseMessage response = await client.PostAsync(url + complemento, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Processar a resposta aqui (se necessário)
                        string conteudoResposta = await response.Content.ReadAsStringAsync();
                        // Faça algo com o conteúdo da resposta, se necessário
                        resposta.Text += conteudoResposta;
                    }
                    else
                    {
                        // Se a requisição não foi bem-sucedida, trate o erro aqui
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        private void lblLoginEsqueceuSuaSenha_Click(object sender, EventArgs e)
        {

        }
    }
}
