using Newtonsoft.Json;
using SoftwareConcessionaria.Dependencias.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareConcessionaria
{
    public partial class Veiculo : Form
    {
        string url = "https://wild-lion-khakis.cyclic.app/estoque/veiculo";
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
                var urlBase = $"{url}/{idDoVeiculo}";
                try
                {
                    using (var cliente = new HttpClient())
                    {
                        var resposta = cliente.GetStringAsync(urlBase);
                        resposta.Wait();

                        // Deserializa diretamente no objeto veiculoModel
                        veiculoModel = JsonConvert.DeserializeObject<VeiculoModel>(resposta.Result);

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

            MessageBox.Show("Campos limpos com sucesso!");

        }

        static string stringBoolean(bool value)
        {
            return value ? "Sim" : "Não";
        }

        private void btnVeiCriar_Click(object sender, EventArgs e)
        {

        }
    }
}
