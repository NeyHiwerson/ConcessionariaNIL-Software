using Newtonsoft.Json;
using SoftwareConcessionaria.Dependencias.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareConcessionaria
{
    public partial class Veiculo : Form
    {
        string url = "https://wild-lion-khakis.cyclic.app/estoque/veiculo";
        string urlVeiCriar = "https://wild-lion-khakis.cyclic.app/veiculo";
        //string urlVeiCriarTeste = "http://localhost:3000/veiculo";
        string idDoVeiculo = null;
        VeiculoModel veiculoModel = new VeiculoModel();
        public TokenManager tokenManager { get; set; }
        public Veiculo()
        {
            InitializeComponent();
        }

        private void Veiculo_Load(object sender, EventArgs e)
        {

        }

        private void btnVeiculoVeiculo_Click(object sender, EventArgs e)
        {
            //colocar uma cor como clique e não faz nada pois estou nesse form
        }

        private void btnVeiculoCliente_Click(object sender, EventArgs e)
        {

            ContatoCliente contatoCliente = ApplicationContext.Instance.contatoCliente;

            // Se o formulário ContatoCliente ainda não foi instanciado, crie uma nova instância
            if (contatoCliente == null)
            {
                contatoCliente = new ContatoCliente();
                ApplicationContext.Instance.contatoCliente = contatoCliente;
                contatoCliente.FormClosed += (s, args) => Show(); // Exibe o formulário principal quando o formulário ContatoCliente for fechado
            }           

            contatoCliente.Show();
        }

        private void btnVeiculoVenda_Click(object sender, EventArgs e)
        {
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVeiCombustivel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVeiBuscarPorId_Click(object sender, EventArgs e)
        {
            if(txtVeiIdVeiculo.Text == string.Empty)
            {
                MessageBox.Show("Informe o ID do veículo.");
            }
            else
            {
                idDoVeiculo = txtVeiIdVeiculo.Text;                
                try
                {
                    VeiculoModel veiculoModel = buscarVeiculoPorId(idDoVeiculo);

                    if (veiculoModel != null)
                    {
                        imprimeVeiculo(veiculoModel);                        

                        btnVeiCriar.Enabled = false;
                        btnVeiAdicionarVenda.Enabled = true;
                        btnVeiEditar.Enabled = true;

                        MessageBox.Show("Dados do veículo carregados com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        private void btnVeiLimpar_Click(object sender, EventArgs e)
        {
            veiculoModel = new VeiculoModel();

            limparFormulario();

            MessageBox.Show("Campos limpos com sucesso!");

        }

        static string stringBoolean(bool value)
        {
            return value ? "Sim" : "Não";
        }

        static bool ConvertToBoolean(string userInput)
        {
            return userInput.Equals("Sim", StringComparison.OrdinalIgnoreCase);
        }

        private async void btnVeiCriar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtVeiIdVeiculo.Text))
            {                
                MessageBox.Show("O ID do veículo é gerado automaticamente pelo sistema. Por favor, não preencha o campo de ID ao criar um veículo.");
            }
            else if (string.IsNullOrWhiteSpace(txtVeiMarca.Text) || 
                string.IsNullOrWhiteSpace(txtVeiModelo.Text) ||
                string.IsNullOrWhiteSpace(txtVeiTipo.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCor.Text) ||
                string.IsNullOrWhiteSpace(txtVeiMotor.Text ) ||
                string.IsNullOrWhiteSpace(txtVeiValvulas.Text ) ||
                string.IsNullOrWhiteSpace(txtVeiCombustivel.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCambio.Text) ||
                string.IsNullOrWhiteSpace(txtVeiValor.Text) ||
                string.IsNullOrWhiteSpace(txtVeiAnoFabricacao.Text) ||
                string.IsNullOrWhiteSpace(txtVeiAnoModelo.Text) ||
                string.IsNullOrWhiteSpace(txtVeiQuilometragem.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCidade.Text) ||
                string.IsNullOrWhiteSpace(txtVeiEstado.Text))
            {
                //falta implementar a imagem1
                MessageBox.Show("Preencha os dados minimos para criação do veículo:\nMarca, Modelo, Tipo, Cor, Motor, Valvulas, Combustível, Cambio, Valor, Ano de Fabricação, Ano Modelo, Quilometragem, Cidade, Estado e Imagem1.");
            }
            else
            {
                try
                {
                    // Código para criar veículo
                    VeiculoModel veiculoModel = montarVeiculo();

                    using (var cliente = new HttpClient())
                    {
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);
                        var jsonVeiculo = JsonConvert.SerializeObject(veiculoModel);
                        var content = new StringContent(jsonVeiculo, Encoding.UTF8, "application/json");

                        var resposta = await cliente.PostAsync(urlVeiCriar, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Veículo criado com sucesso.");

                            // Aqui você precisa verificar a estrutura da resposta e ajustar conforme necessário
                            // Supondo que a resposta contenha o VeiculoModel serializado diretamente
                            var respostaContent = await resposta.Content.ReadAsStringAsync();
                            veiculoModel = JsonConvert.DeserializeObject<VeiculoModel>(respostaContent);

                            // Refatorar e jogar as lógicas em funções e chamar do botão
                            limparFormulario();
                            imprimeVeiculo(veiculoModel);

                            // btnVeiBuscarPorId_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao criar veículo. Código de status: {resposta.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }


        }

        private async void btnVeiEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVeiIdVeiculo.Text))
            {
                MessageBox.Show("O ID do veículo é obrigatório. Por favor, não preencha o campo de ID e busque o veículo para editar.");
            }
            else if (string.IsNullOrWhiteSpace(txtVeiMarca.Text) ||
                string.IsNullOrWhiteSpace(txtVeiModelo.Text) ||
                string.IsNullOrWhiteSpace(txtVeiTipo.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCor.Text) ||
                string.IsNullOrWhiteSpace(txtVeiMotor.Text) ||
                string.IsNullOrWhiteSpace(txtVeiValvulas.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCombustivel.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCambio.Text) ||
                string.IsNullOrWhiteSpace(txtVeiValor.Text) ||
                string.IsNullOrWhiteSpace(txtVeiAnoFabricacao.Text) ||
                string.IsNullOrWhiteSpace(txtVeiAnoModelo.Text) ||
                string.IsNullOrWhiteSpace(txtVeiQuilometragem.Text) ||
                string.IsNullOrWhiteSpace(txtVeiCidade.Text) ||
                string.IsNullOrWhiteSpace(txtVeiEstado.Text))
            {
                //falta implementar a imagem1
                MessageBox.Show("Preencha os dados minimos para criação do veículo:\nMarca, Modelo, Tipo, Cor, Motor, Valvulas, Combustível, Cambio, Valor, Ano de Fabricação, Ano Modelo, Quilometragem, Cidade, Estado e Imagem1.");
            }
            else
            {
                try
                {
                    // Código para criar veículo
                    VeiculoModel veiculoModel = montarVeiculo();
                    var idDoVeiculo = txtVeiIdVeiculo.Text;
                    var urlBase = $"{urlVeiCriar}/{idDoVeiculo}";
                    using (var cliente = new HttpClient())
                    {
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);
                        var jsonVeiculo = JsonConvert.SerializeObject(veiculoModel);
                        var content = new StringContent(jsonVeiculo, Encoding.UTF8, "application/json");

                        var resposta = await cliente.PostAsync(urlBase, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Veículo Editado com sucesso.");

                            // Aqui você precisa verificar a estrutura da resposta e ajustar conforme necessário
                            // Supondo que a resposta contenha o VeiculoModel serializado diretamente
                            var respostaContent = await resposta.Content.ReadAsStringAsync();
                            veiculoModel = JsonConvert.DeserializeObject<VeiculoModel>(respostaContent);

                            // Refatorar e jogar as lógicas em funções e chamar do botão
                            limparFormulario();
                            imprimeVeiculo(veiculoModel);
                            btnVeiCriar.Enabled = false;
                            btnVeiEditar.Enabled = true;
                            btnVeiAdicionarVenda.Enabled = true;
                            
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao criar veículo. Código de status: {resposta.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }


        }

        private void btnVeiAdicionarVenda_Click(object sender, EventArgs e)
        {
            veiculoModel = montarVeiculo();
            ApplicationContext.Instance.veiculoModel = veiculoModel;
            MessageBox.Show("Veículo adicionado à área de vendas com sucesso.");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        public void limparFormulario()
        {
            txtVeiIdVeiculo.Text = "";
            txtVeiCodRenavan.Text = "";
            txtVeiPlaca.Text = "";
            txtVeiAnoFabricacao.Text = "";
            txtVeiAnoModelo.Text = "";
            txtVeiAnoExercicioAtual.Text = "";
            txtVeiMarca.Text = "";
            txtVeiModelo.Text = "";
            txtVeiVersao.Text = "";
            txtVeiEspecie.Text = "";
            txtVeiTipo.Text = "";
            txtVeiChassi.Text = "";
            txtVeiCor.Text = "";
            txtVeiCombustivel.Text = "";
            txtVeiCategoria.Text = "";
            txtVeiPotencia.Text = "";
            txtVeiMotor.Text = "";
            txtVeiValvulas.Text = "";
            txtVeiCambio.Text = "";
            txtVeiPeso.Text = "";
            txtVeiEixos.Text = "";
            txtVeiCarroceria.Text = "";
            txtVeiLotacao.Text = "";
            txtVeiCapacidade.Text = "";
            txtVeiQuilometragem.Text = "";
            txtVeiPortas.Text = "";
            txtVeiCidade.Text = "";
            txtVeiEstado.Text = "";
            txtVeiNome.Text = "";
            txtVeiCpfCnpj.Text = "";
            txtVeiValor.Text = "";
            txtVeiDisponivel.Text = "";
            txtVeiLink1.Text = "";

            btnVeiCriar.Enabled = true;
            btnVeiEditar.Enabled = false;
            btnVeiAdicionarVenda.Enabled = false;
        }

        public void imprimeVeiculo(VeiculoModel veiculoModel)
        {
            txtVeiIdVeiculo.Text = veiculoModel.id_veiculo.ToString();
            txtVeiCodRenavan.Text = veiculoModel.codigo_renavam;
            txtVeiPlaca.Text = veiculoModel.placa;
            txtVeiAnoFabricacao.Text = veiculoModel.ano_fabricacao;
            txtVeiAnoModelo.Text = veiculoModel.ano_modelo;
            txtVeiAnoExercicioAtual.Text = veiculoModel.exercicio_atual;
            txtVeiMarca.Text = veiculoModel.marca;
            txtVeiModelo.Text = veiculoModel.modelo;
            txtVeiVersao.Text = veiculoModel.versao;
            txtVeiEspecie.Text = veiculoModel.especie;
            txtVeiTipo.Text = veiculoModel.tipo;
            txtVeiChassi.Text = veiculoModel.chassi;
            txtVeiCor.Text = veiculoModel.cor;
            txtVeiCombustivel.Text = veiculoModel.combustivel;
            txtVeiCategoria.Text = veiculoModel.categoria;
            txtVeiPotencia.Text = veiculoModel.potencia;
            txtVeiMotor.Text = veiculoModel.motor;
            txtVeiValvulas.Text = veiculoModel.valvulas;
            txtVeiCambio.Text = veiculoModel.cambio;
            txtVeiPeso.Text = veiculoModel.peso;
            txtVeiEixos.Text = veiculoModel.eixos;
            txtVeiCarroceria.Text = veiculoModel.carroceria;
            txtVeiLotacao.Text = veiculoModel.lotacao;
            txtVeiCapacidade.Text = veiculoModel.capacidade;
            txtVeiQuilometragem.Text = veiculoModel.quilometragem;
            txtVeiPortas.Text = veiculoModel.portas;
            txtVeiCidade.Text = veiculoModel.cidade;
            txtVeiEstado.Text = veiculoModel.estado;
            txtVeiNome.Text = veiculoModel.nome;
            txtVeiCpfCnpj.Text = veiculoModel.cpfcnpj;
            txtVeiValor.Text = veiculoModel.valor.ToString("C");
            txtVeiDisponivel.Text = stringBoolean(veiculoModel.disponivel);
            txtVeiLink1.Text = veiculoModel.link_1;

        }

        public VeiculoModel buscarVeiculoPorId(string id)
        {
            VeiculoModel veiculoModel = new VeiculoModel();
            var urlBase = $"{url}/{idDoVeiculo}";
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resposta = cliente.GetStringAsync(urlBase);
                    resposta.Wait();

                    // Deserializa diretamente no objeto veiculoModel
                    veiculoModel = JsonConvert.DeserializeObject<VeiculoModel>(resposta.Result);


                    return veiculoModel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: Não achou o ID {ex.Message}");
                return null;
            }
        }

        public VeiculoModel montarVeiculo()
        {
            VeiculoModel veiculoModel = new VeiculoModel();

            veiculoModel.codigo_renavam = txtVeiCodRenavan.Text;
            veiculoModel.placa = txtVeiPlaca.Text;
            veiculoModel.ano_fabricacao = txtVeiAnoFabricacao.Text;
            veiculoModel.ano_modelo = txtVeiAnoModelo.Text;
            veiculoModel.exercicio_atual = txtVeiAnoExercicioAtual.Text;
            veiculoModel.marca = txtVeiMarca.Text;
            veiculoModel.modelo = txtVeiModelo.Text;
            veiculoModel.versao = txtVeiVersao.Text;
            veiculoModel.especie = txtVeiEspecie.Text;
            veiculoModel.tipo = txtVeiTipo.Text;
            veiculoModel.chassi = txtVeiChassi.Text;
            veiculoModel.cor = txtVeiCor.Text;
            veiculoModel.combustivel = txtVeiCombustivel.Text;
            veiculoModel.categoria = txtVeiCategoria.Text;
            veiculoModel.potencia = txtVeiPotencia.Text;
            veiculoModel.motor = txtVeiMotor.Text;
            veiculoModel.valvulas = txtVeiValvulas.Text;
            veiculoModel.cambio = txtVeiCambio.Text;
            veiculoModel.peso = txtVeiPeso.Text;
            veiculoModel.eixos = txtVeiEixos.Text;
            veiculoModel.carroceria = txtVeiCarroceria.Text;
            veiculoModel.lotacao = txtVeiLotacao.Text;
            veiculoModel.capacidade = txtVeiCapacidade.Text;
            veiculoModel.quilometragem = txtVeiQuilometragem.Text;
            veiculoModel.portas = txtVeiPortas.Text;
            veiculoModel.cidade = txtVeiCidade.Text;
            veiculoModel.estado = txtVeiEstado.Text;
            veiculoModel.nome = txtVeiNome.Text;
            veiculoModel.cpfcnpj = txtVeiCpfCnpj.Text;
            veiculoModel.disponivel = ConvertToBoolean(txtVeiDisponivel.Text);
            string valorFormatado = txtVeiValor.Text;
            decimal valorNumerico;
            decimal.TryParse(valorFormatado, NumberStyles.Currency, CultureInfo.CurrentCulture, out valorNumerico);
            veiculoModel.valor = valorNumerico;
            //Implementar as imagens e os links
            veiculoModel.link_1 = txtVeiLink1.Text;

            return veiculoModel;
        }

    }
}
