using Newtonsoft.Json;
using SoftwareConcessionaria.Dependencias.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SoftwareConcessionaria
{
    public partial class ContatoCliente : Form
    {
        string url = "https://wild-lion-khakis.cyclic.app/cliente";        
        string urlTeste = "http://localhost:3000/cliente";
        string cpfcnpjCliente = null;
        int id_cliente = 0;
        ClienteModel clienteModel = new ClienteModel();        
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
            Veiculo veiculo = ApplicationContext.Instance.veiculo;

            // Se o formulário Venda ainda não foi instanciado, crie uma nova instância
            if (veiculo == null)
            {
                veiculo = new Veiculo();
                ApplicationContext.Instance.veiculo = veiculo;
                veiculo.FormClosed += (s, args) => Show(); // Exibe o formulário principal quando o formulário Venda for fechado
            }

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
            Venda venda = ApplicationContext.Instance.venda;

            // Se o formulário Venda ainda não foi instanciado, crie uma nova instância
            if (venda == null)
            {
                venda = new Venda();
                ApplicationContext.Instance.venda = venda;
                venda.FormClosed += (s, args) => Show(); // Exibe o formulário principal quando o formulário Venda for fechado
            }

            venda.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {  //buscarClientePorCpfCnpj
            if (txtCliCpfCnpj.Text == string.Empty)
            {
                MessageBox.Show("Informe o CPF/CNPJ do cliente.");
            }
            else
            {
                cpfcnpjCliente = txtCliCpfCnpj.Text;
                try
                {
                    clienteModel = buscarClientePorCpfCnpj(cpfcnpjCliente);

                    if (clienteModel != null)
                    {
                        imprimeCliente(clienteModel);

                        btnCliCriar.Enabled = false;
                        btnCliAdicionarVenda.Enabled = true;
                        btnCliEditar.Enabled = true;

                        MessageBox.Show("Dados do cliente carregados com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }

        }

        public ClienteModel buscarClientePorCpfCnpj(string cpfcnpjCliente)
        {
            ClienteModel clienteModel = new ClienteModel();
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                    // Construir a URL com o CPF/CNPJ como parte da consulta
                    var urlBuscar = $"{url}/busca";

                    // Construir o corpo da solicitação
                    var jsonCpfCnpj = JsonConvert.SerializeObject(new { cpfcnpj = cpfcnpjCliente });
                    var content = new StringContent(jsonCpfCnpj, Encoding.UTF8, "application/json");

                    // Enviar a solicitação POST
                    var resposta = cliente.PostAsync(urlBuscar, content);
                    resposta.Wait();

                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var respostaContent = resposta.Result.Content.ReadAsStringAsync();
                        clienteModel = JsonConvert.DeserializeObject<ClienteModel>(respostaContent.Result);
                        return clienteModel;
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao buscar cliente por CPF/CNPJ. Código de status: {resposta.Result.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return null;
            }
        }


        public void imprimeCliente(ClienteModel clienteModel)
        {
            txtCliCpfCnpj.Text = clienteModel.cpfcnpj;
            txtCliNome.Text = clienteModel.nome;
            txtCliEmail.Text = clienteModel.email;
            txtCliDtNasc.Text = clienteModel.dt_nascimento.ToString("dd/MM/yyyy");
            txtCliRenda.Text = clienteModel.renda.ToString("C");
            txtCliRg.Text = clienteModel.rg;
            txtCliTelefone.Text = clienteModel.telefone;
            txtCliCttTelefone.Text= clienteModel.ctt_telefone;

        }

        public ClienteModel montarClienteModel()
        {
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.cpfcnpj = txtCliCpfCnpj.Text;
            clienteModel.nome = txtCliNome.Text;
            // Validar e converter a data de nascimento
            if (DateTime.TryParseExact(txtCliDtNasc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtNascimento))
            {
                clienteModel.dt_nascimento = dtNascimento;
            }
            else
            {
                MessageBox.Show("Formato de data inválido.");
                return null; // Retornar null em caso de falha na validação/conversão
            }

            clienteModel.email = txtCliEmail.Text;
            clienteModel.renda = int.Parse(txtCliRenda.Text, NumberStyles.Currency);
            clienteModel.rg = txtCliRg.Text;
            clienteModel.telefone = txtCliTelefone.Text;
            clienteModel.ctt_telefone = txtCliCttTelefone.Text;

            return clienteModel;
        }


        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparFormularioCliente();
        }

        public void limparFormularioCliente()
        {
            cpfcnpjCliente = null;

            txtCliCpfCnpj.Text = string.Empty;
            txtCliNome.Text = string.Empty;
            txtCliEmail.Text = string.Empty;
            txtCliDtNasc.Text = string.Empty;
            txtCliRenda.Text = string.Empty;
            txtCliRg.Text = string.Empty;
            txtCliTelefone.Text = string.Empty;
            txtCliCttTelefone.Text = string.Empty;
        }

        private void btnCliCriar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliCpfCnpj.Text) ||
                string.IsNullOrWhiteSpace(txtCliNome.Text) ||
                string.IsNullOrWhiteSpace(txtCliEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCliDtNasc.Text) ||
                string.IsNullOrWhiteSpace(txtCliRenda.Text) ||
                string.IsNullOrWhiteSpace(txtCliRg.Text) ||
                string.IsNullOrWhiteSpace(txtCliTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtCliCttTelefone.Text))
            {
                MessageBox.Show("Preencha todos os campos para criar um novo cliente:\nCPF/CNPJ, Nome, Email, data de nascimento, renda, Rg, telefone e contato");
            }
            else
            {
                clienteModel = montarClienteModel();
                try
                {
                    using (var cliente = new HttpClient())
                    {
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                        var jsonClienteModel = JsonConvert.SerializeObject(clienteModel);
                        var content = new StringContent(jsonClienteModel, Encoding.UTF8, "application/json");

                        // Enviar a solicitação POST
                        var resposta = cliente.PostAsync(url, content);
                        resposta.Wait();

                        if (resposta.Result.IsSuccessStatusCode)
                        {
                            var respostaContent = resposta.Result.Content.ReadAsStringAsync();
                            clienteModel = JsonConvert.DeserializeObject<ClienteModel>(respostaContent.Result);
                            limparFormularioCliente();
                            imprimeCliente(clienteModel);
                            MessageBox.Show($"Cliente criado com sucesso no Id {clienteModel.id_cliente}");

                        }
                        else
                        {
                            MessageBox.Show($" Erro ao criar cliente.\n Código de status: {resposta.Result.StatusCode}");
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                   
                }
            }
        }

        private async void btnCliEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliCpfCnpj.Text) ||
                string.IsNullOrWhiteSpace(txtCliNome.Text) ||
                string.IsNullOrWhiteSpace(txtCliEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCliDtNasc.Text) ||
                string.IsNullOrWhiteSpace(txtCliRenda.Text) ||
                string.IsNullOrWhiteSpace(txtCliRg.Text) ||
                string.IsNullOrWhiteSpace(txtCliTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtCliCttTelefone.Text))
            {
                MessageBox.Show("Preencha todos os campos para editar o cliente:\nCPF/CNPJ, Nome, Email, data de nascimento, renda, Rg, telefone e contato");
            }
            else
            {
                id_cliente = clienteModel.id_cliente;
                clienteModel = montarClienteModel();
                clienteModel.id_cliente = id_cliente;
                var urlEditar = $"{urlTeste}/{id_cliente}";

                try
                {
                    using (var cliente = new HttpClient())
                    {
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                        var jsonClienteModel = JsonConvert.SerializeObject(clienteModel);
                        var content = new StringContent(jsonClienteModel, Encoding.UTF8, "application/json");

                        // Usar a requisição PUT para editar o recurso existente
                        var resposta = await cliente.PutAsync(urlEditar, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            var respostaContent = await resposta.Content.ReadAsStringAsync();
                            clienteModel = JsonConvert.DeserializeObject<ClienteModel>(respostaContent);
                            limparFormularioCliente();
                            imprimeCliente(clienteModel);
                            MessageBox.Show($"Cliente editado com sucesso no Id {clienteModel.id_cliente}");
                        }
                        else
                        {
                            MessageBox.Show($" Erro ao editar cliente.\n Código de status: {resposta.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        private void btnCliAdicionarVenda_Click(object sender, EventArgs e)
        {
            clienteModel = montarClienteModel();
            ApplicationContext.Instance.clienteModel = clienteModel;
            MessageBox.Show("Cliente adicionado à área de vendas com sucesso.");
        }
    }
}
