using Newtonsoft.Json;
using SoftwareConcessionaria.Dependencias.models;
using System;
using System.Collections;
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
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SoftwareConcessionaria
{
    public partial class ContatoCliente : Form
    {
        string url = "https://wild-lion-khakis.cyclic.app/cliente";        
        string urlEnd = "https://wild-lion-khakis.cyclic.app/endereco";
        //string urlTeste = "http://localhost:3000/cliente";
        //string urlEndTeste = "http://localhost:3000/endereco";
        string cpfcnpjCliente = null;
        int id_cliente = 0;
        int id_enderecoVenda = 0;
        ClienteModel clienteModel = new ClienteModel();
        CliEnderecoModel cliEnderecoModel = new CliEnderecoModel();
        EnderecoModel enderecoModel = new EnderecoModel();
        public ContatoCliente()
        {
            InitializeComponent();
        }

        private void ContatoCliente_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            btnLimpar.Enabled = false;
            btnCliCriar.Enabled = true;
            btnCliEditar.Enabled = false;
            btnCliAdicionarVenda.Enabled = false;
            btnCliCriarEndereco.Enabled = false;
            btnCliEditarEndereco.Enabled = false;
            btnCliAdicionarVenda.Enabled = false;
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

        private async void btnBuscar_Click(object sender, EventArgs e)
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
                    clienteModel = await buscarClientePorCpfCnpj(cpfcnpjCliente);

                    if (clienteModel != null)
                    {
                        imprimeCliente(clienteModel);
                        btnBuscar.Enabled = true;
                        btnLimpar.Enabled = true;
                        btnCliCriar.Enabled = false;
                        btnCliEditar.Enabled = true;
                        btnCliAdicionarVenda.Enabled = true;
                        cliEnderecoModel.id_cliente = clienteModel.id_cliente;
                        id_cliente = clienteModel.id_cliente;
                        cliEnderecoModel.enderecos = await buscarEnderecosCliente(id_cliente);
                        imprimirEndereco(cliEnderecoModel);
                        MessageBox.Show("Dados do cliente carregados com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }

        }

        public async Task<ClienteModel> buscarClientePorCpfCnpj(string cpfcnpjCliente)
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
                    var resposta = await cliente.PostAsync(urlBuscar, content);

                    if (resposta.IsSuccessStatusCode)
                    {
                        var respostaContent = await resposta.Content.ReadAsStringAsync();
                        clienteModel = JsonConvert.DeserializeObject<ClienteModel>(respostaContent);
                        return clienteModel;
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao buscar cliente por CPF/CNPJ. Código de status: {resposta.StatusCode}");
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


        public async Task<List<EnderecoModel>> buscarEnderecosCliente(int id_cliente)
        {
            int id = id_cliente;
            List<EnderecoModel> listEnderecoModel = new List<EnderecoModel>();

            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                    // Construir a URL com o id como parte da consulta
                    var urlBuscar = $"{urlEnd}/{id}";

                    // Fazer a requisição à API de forma assíncrona
                    var resposta = await cliente.GetAsync(urlBuscar);

                    // Verificar se a requisição foi bem-sucedida
                    if (resposta.IsSuccessStatusCode)
                    {
                        // Deserializar a resposta JSON para uma lista de objetos EnderecoModel
                        var respostaContent = await resposta.Content.ReadAsStringAsync();
                        var enderecoModels = JsonConvert.DeserializeObject<List<EnderecoModel>>(respostaContent);

                        // Adicionar os objetos à lista final
                        listEnderecoModel.AddRange(enderecoModels);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao buscar endereços. Código de status: {resposta.StatusCode}");
                        return null;
                    }
                }

                return listEnderecoModel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return null;
            }
        }

        public void imprimirEndereco(CliEnderecoModel cliEnderecoModel)
        {
            
            if(cbxCliTipoEndereco.SelectedIndex == -1 && cliEnderecoModel.enderecos.Count > 0)
            {
                cbxCliTipoEndereco.SelectedIndex = 0;
                btnCliAddEndVenda.Enabled = true;
                enderecoModel = cliEnderecoModel.enderecos[0];
                id_enderecoVenda = enderecoModel.id_endereco;
            }
            if (cliEnderecoModel.enderecos != null && cliEnderecoModel.enderecos.Count > 0)
            {
                int tipoEnderecoSelecionado = cbxCliTipoEndereco.SelectedIndex;

                if (tipoEnderecoSelecionado == 0)
                {
                    // Se estiver selecionado Residencial
                    enderecoModel = cliEnderecoModel.enderecos.Find(e => e.tipo_endereco == "Residencial");
                    btnCliAddEndVenda.Enabled = true;
                    id_enderecoVenda = enderecoModel.id_endereco;
                }
                else if (tipoEnderecoSelecionado == 1)
                {
                    // Se estiver selecionado Comercial
                    enderecoModel = cliEnderecoModel.enderecos.Find(e => e.tipo_endereco == "Comercial");
                    btnCliAddEndVenda.Enabled = true;
                    id_enderecoVenda = enderecoModel.id_endereco;
                }

                if (enderecoModel != null)
                {
                    id_enderecoVenda = enderecoModel.id_endereco;
                    // Preencher os campos do formulário com os dados do endereço
                    txtCliCep.Text = enderecoModel.cep;
                    txtCliRua.Text = enderecoModel.rua;
                    txtCliNumero.Text = enderecoModel.numero;
                    txtCliComplemento.Text = enderecoModel.complemento;
                    txtCliBairro.Text = enderecoModel.bairro;
                    txtCliCidade.Text = enderecoModel.cidade;
                    txtCliEstado.Text = enderecoModel.uf_estado;                    
                    
                    btnCliCriarEndereco.Enabled = false;
                    btnCliEditarEndereco.Enabled = true;
                    btnCliAdicionarVenda.Enabled = true;
                }
                else
                {
                   
                    btnCliCriarEndereco.Enabled = true;
                    btnCliEditarEndereco.Enabled = false;
                    btnCliAddEndVenda.Enabled = false;
                    txtCliCep.Text = string.Empty;
                    txtCliRua.Text = string.Empty;
                    txtCliNumero.Text = string.Empty;
                    txtCliComplemento.Text = string.Empty;
                    txtCliBairro.Text = string.Empty;
                    txtCliCidade.Text = string.Empty;
                    txtCliEstado.Text = string.Empty;
                    MessageBox.Show("Endereço não encontrado para o tipo selecionado.");
                }
            }
            else
            {
                btnCliCriarEndereco.Enabled = true;
                btnCliEditarEndereco.Enabled = false;
                btnCliAdicionarVenda.Enabled = false;
                limparEndereco();                
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
            btnBuscar.Enabled = true;
            btnLimpar.Enabled = false;
            btnCliCriar.Enabled = true;
            btnCliEditar.Enabled = false;
            btnCliAdicionarVenda.Enabled = false;
            btnCliCriarEndereco.Enabled = false;
            btnCliEditarEndereco.Enabled = false;
            btnCliAdicionarVenda.Enabled = false;
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

            id_enderecoVenda = 0;

            cbxCliTipoEndereco.SelectedIndex = -1;
            txtCliCep.Text = string.Empty;
            txtCliRua.Text = string.Empty;
            txtCliNumero.Text = string.Empty;
            txtCliComplemento.Text = string.Empty;
            txtCliBairro.Text = string.Empty;
            txtCliCidade.Text = string.Empty;
            txtCliEstado.Text = string.Empty;
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
                var urlEditar = $"{url}/{id_cliente}";

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
            clienteModel.id_cliente = id_cliente;
            ApplicationContext.Instance.clienteModel = clienteModel;
            MessageBox.Show("Cliente adicionado à área de vendas com sucesso.");
        }

        //btnCliEditarEndereco
        private async void button2_Click(object sender, EventArgs e)
        {//btnCliEditarEnderec
            if (cbxCliTipoEndereco.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtCliCep.Text) ||
                string.IsNullOrWhiteSpace(txtCliRua.Text) ||
                string.IsNullOrWhiteSpace(txtCliNumero.Text) ||
                string.IsNullOrWhiteSpace(txtCliComplemento.Text) ||
                string.IsNullOrWhiteSpace(txtCliBairro.Text) ||
                string.IsNullOrWhiteSpace(txtCliCidade.Text) ||
                string.IsNullOrWhiteSpace(txtCliEstado.Text))
            {
                MessageBox.Show("Preencha todos os campos para editar o endereco:\nTipo de endereço, CEP, rua, número, complemento, bairro, cidade, sigla UF do estado");
            }
            else
            {
                var id_endereco = enderecoModel.id_endereco;
                enderecoModel = montarEnderecoModel();
                enderecoModel.id_endereco = id_endereco;

                try
                {
                    using (var cliente = new HttpClient())
                    {
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                        // Construir a URL com o id_cliente e id_endereco como parte da consulta
                        var urlEditar = $"{urlEnd}/{id_endereco}";

                        var jsonEnderecoModel = JsonConvert.SerializeObject(enderecoModel);
                        var content = new StringContent(jsonEnderecoModel, Encoding.UTF8, "application/json");

                        // Enviar a solicitação PUT de forma assíncrona
                        var resposta = await cliente.PutAsync(urlEditar, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            var respostaContent = await resposta.Content.ReadAsStringAsync();
                            enderecoModel = JsonConvert.DeserializeObject<EnderecoModel>(respostaContent);
                            limparEndereco();
                            await buscarEnderecosCliente(id_cliente);
                            MessageBox.Show($"Endereço {enderecoModel.tipo_endereco} editado com sucesso.");
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao editar endereço. Código de status: {resposta.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        private void cbxCliTipoEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            imprimirEndereco(cliEnderecoModel);
        }

        private void btnCliAddEndVenda_Click(object sender, EventArgs e)
        {
            id_enderecoVenda = enderecoModel.id_endereco;
            EnderecoModel enderecoModelVenda = montarEnderecoModel();
            enderecoModelVenda.id_endereco = id_enderecoVenda;
            ApplicationContext.Instance.enderecoModel = enderecoModelVenda;
            MessageBox.Show("Endereco do cliente adicionado à área de vendas com sucesso.");
        }

        private async void btnCliCriarEndereco_Click(object sender, EventArgs e)
        {
            if (cbxCliTipoEndereco.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtCliCep.Text) ||
                string.IsNullOrWhiteSpace(txtCliRua.Text) ||
                string.IsNullOrWhiteSpace(txtCliNumero.Text) ||
                string.IsNullOrWhiteSpace(txtCliComplemento.Text) ||
                string.IsNullOrWhiteSpace(txtCliBairro.Text) ||
                string.IsNullOrWhiteSpace(txtCliCidade.Text) ||
                string.IsNullOrWhiteSpace(txtCliEstado.Text))
            {
                MessageBox.Show("Preencha todos os campos para criar o endereco:\nTipo de endereço, CEP, rua, número, complemento, bairro, cidade, sigla UF do estado");
            }
            else
            {
                EnderecoModel enderecoModel = montarEnderecoModel();
                var id_cliente = clienteModel.id_cliente;

                try
                {
                    using (var cliente = new HttpClient())
                    {
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                        // Construir a URL com o id como parte da consulta
                        var urlBuscar = $"{urlEnd}/{id_cliente}";

                        var jsonEnderecoModel = JsonConvert.SerializeObject(enderecoModel);
                        var content = new StringContent(jsonEnderecoModel, Encoding.UTF8, "application/json");

                        // Enviar a solicitação POST de forma assíncrona
                        var resposta = await cliente.PostAsync(urlBuscar, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            var respostaContent = await resposta.Content.ReadAsStringAsync();
                            enderecoModel = JsonConvert.DeserializeObject<EnderecoModel>(respostaContent);
                            limparEndereco();
                            await buscarEnderecosCliente(id_cliente);
                            MessageBox.Show($"Endereço {enderecoModel.tipo_endereco} criado com sucesso.");
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao criar endereço. Código de status: {resposta.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }


        public EnderecoModel montarEnderecoModel()
        {
            EnderecoModel model = new EnderecoModel();
            int tipoEnderecoSelecionado = cbxCliTipoEndereco.SelectedIndex;
            string tipo = (tipoEnderecoSelecionado == 0) ? "Residencial" : "Comercial";

            model.tipo_endereco = tipo;
            model.cep = txtCliCep.Text;
            model.rua = txtCliRua.Text;
            model.numero = txtCliNumero.Text;
            model.complemento = txtCliComplemento.Text;
            model.bairro = txtCliBairro.Text;
            model.cidade = txtCliCidade.Text;
            model.uf_estado = txtCliEstado.Text;
            
            return model;
        }

        public void limparEndereco()
        {
            id_enderecoVenda = 0;

            
            txtCliCep.Text = string.Empty;
            txtCliRua.Text = string.Empty;
            txtCliNumero.Text = string.Empty;
            txtCliComplemento.Text = string.Empty;
            txtCliBairro.Text = string.Empty;
            txtCliCidade.Text = string.Empty;
            txtCliEstado.Text = string.Empty;
        }

        private void txtCliEstado_TextChanged(object sender, EventArgs e)
        {
            txtCliEstado.CharacterCasing = CharacterCasing.Upper;

            
        }

        private void txtCliEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Se não for uma letra, impede a entrada no TextBox
                e.Handled = true;
            }
        }
    }
}
