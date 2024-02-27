using Newtonsoft.Json;
using SoftwareConcessionaria.Dependencias.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConcessionaria
{
    public partial class Venda : Form
    {
        ClienteModel clienteModel = ApplicationContext.Instance.clienteModel;
        EnderecoModel enderecoModel = ApplicationContext.Instance.enderecoModel;
        VeiculoModel veiculoModel = ApplicationContext.Instance.veiculoModel;
        ColaboradorModel colaboradorModel = new ColaboradorModel();
        VendaModel vendaModel = new VendaModel();       
        string urlUser = "https://wild-lion-khakis.cyclic.app/user/colaborador";
        string urlVenda = "https://wild-lion-khakis.cyclic.app/venda";
        //string urlUserTeste = "http://localhost:3000/user/colaborador";
        //string urlVendaTeste = "http://localhost:3000/venda";


        public Venda()
        {
            InitializeComponent();
        }

            private async void Venda_Load(object sender, EventArgs e)
        {
            imprimirCliente();
            imprimirEndereco();
            imprimirVeiculo();

            colaboradorModel = await BuscarColaboradorPorToken();

            imprimirColaborador();
        }

        private void btnVendaVeiculo_Click(object sender, EventArgs e)
        {
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

        private void btnVendaCliente_Click(object sender, EventArgs e)
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

        private void btnVendaVenda_Click(object sender, EventArgs e)
        {
            //colocar uma cor como clique e não faz nada
        }

        public async Task<ColaboradorModel> BuscarColaboradorPorToken()
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                    // Construir a URL para buscar o colaborador associado ao token
                    var urlBuscar = $"{urlUser}";

                    // Fazer a requisição à API de forma assíncrona
                    var resposta = await cliente.GetAsync(urlBuscar);

                    // Verificar se a requisição foi bem-sucedida
                    if (resposta.IsSuccessStatusCode)
                    {
                        // Deserializar a resposta JSON para um objeto ColaboradorModel
                        var respostaContent = await resposta.Content.ReadAsStringAsync();
                        var colaboradorModel = JsonConvert.DeserializeObject<ColaboradorModel>(respostaContent);

                        return colaboradorModel;
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao buscar colaborador. Código de status: {resposta.StatusCode}");
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

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public async void registrarVenda()
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApplicationContext.Instance.tokenManager.type, ApplicationContext.Instance.tokenManager.token);

                    vendaModel.id_cliente = clienteModel.id_cliente;
                    vendaModel.id_endereco = enderecoModel.id_endereco;
                    vendaModel.id_veiculo = ApplicationContext.Instance.id_veiculo;
                    vendaModel.valor = veiculoModel.valor;
                    vendaModel.dt_venda = DateTime.Now;

                    // Serializa o objeto para JSON
                    var jsonVenda = JsonConvert.SerializeObject(vendaModel);
                    var content = new StringContent(jsonVenda, Encoding.UTF8, "application/json");

                    // Faz a requisição POST
                    var resposta = await cliente.PostAsync(urlVenda, content);

                    if (resposta.IsSuccessStatusCode)
                    {
                        // Desserializa a resposta para a classe VendaModel
                        var respostaContent = await resposta.Content.ReadAsStringAsync();
                        VendaModel vendaRegistrada = JsonConvert.DeserializeObject<VendaModel>(respostaContent);

                        // Exibe os dados em um MessageBox
                        string mensagem = $"Venda registrada com sucesso!\n\nDetalhes da venda:\n\n" +
                                          $"ID Venda: {vendaRegistrada.id_venda}\n" +
                                          $"ID Cliente: {vendaRegistrada.id_cliente}\n" +
                                          $"ID Endereço: {vendaRegistrada.id_endereco}\n" +
                                          $"ID Veículo: {vendaRegistrada.id_veiculo}\n" +
                                          $"Valor: {vendaRegistrada.valor:C}\n" +
                                          $"Data da Venda: {vendaRegistrada.dt_venda:dd/MM/yyyy HH:mm:ss}\n" +
                                          $"ID Colaborador: {vendaRegistrada.id_colaborador}";
                  
                        MessageBox.Show(mensagem);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao registrar venda. Código de status: {resposta.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }


        public void imprimirCliente()
        {
            txtCpfCnpjVenda.Text = clienteModel.cpfcnpj;
            txtNomeVenda.Text = clienteModel.nome;
            txtTelefoneVenda.Text = clienteModel.telefone;
            txtContatoVenda.Text = clienteModel.ctt_telefone;
        }

        public void imprimirEndereco()
        {
            txtTipoEndVenda.Text = enderecoModel.tipo_endereco;
            txtCepVenda.Text = enderecoModel.cep;
            txtRuaVenda.Text = enderecoModel.rua;
            txtNumeroVenda.Text = enderecoModel.numero;
            txtComplementoVenda.Text = enderecoModel.complemento;
            txtBairroVenda.Text = enderecoModel.bairro;
            txtCidadeVenda.Text = enderecoModel.cidade;
            txtEstadoVenda.Text = enderecoModel.uf_estado;
        }

        public void imprimirVeiculo()
        {
            txtVenMarca.Text = veiculoModel.marca;
            txtVenAno.Text = (veiculoModel.ano_fabricacao + "/" + veiculoModel.ano_modelo);
            txtVenModelo.Text = veiculoModel.modelo;
            txtVenChassi.Text = veiculoModel.chassi;
            txtVenPeso.Text = veiculoModel.peso;
            txtVenRenavan.Text = veiculoModel.codigo_renavam;
            txtVenValor.Text = veiculoModel.valor.ToString("C");
        }

        public void imprimirColaborador()
        {
            txtIdVendedor.Text = colaboradorModel.id_colaborador.ToString();
            txtNomeVendaVendedor.Text = colaboradorModel.nome;
            txtCargoVendaVendedor.Text = colaboradorModel.cargo;
            txtTelefoneVendaVendedor.Text = colaboradorModel.telefone;
            txtVenNomeFilial.Text = colaboradorModel.filial_atual;
        }

        private void btnVenGerarVenda_Click(object sender, EventArgs e)
        {
            // Execute o método registrarVenda de forma assíncrona e lide com o resultado usando ContinueWith
            Task.Run(() => registrarVenda()).ContinueWith(task =>
            {
                // Verifique se houve exceção durante a execução do método registrarVenda
                if (task.Exception != null)
                {
                    MessageBox.Show($"Erro: {task.Exception.InnerException.Message}");
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
