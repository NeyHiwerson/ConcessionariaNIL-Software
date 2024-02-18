using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class VeiculoModel
    {
        public int id_veiculo { get; set; }
        public string codigo_renavam { get; set; }
        public string placa { get; set; }
        public string ano_fabricacao { get; set; }
        public string ano_modelo { get; set; }
        public string exercicio_atual { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string versao { get; set; }
        public string especie { get; set; }
        public string tipo { get; set; }
        public string chassi { get; set; }
        public string cor { get; set; }
        public string combustivel { get; set; }
        public string categoria { get; set; }
        public string potencia { get; set; }
        public string motor { get; set; }
        public string valvulas { get; set; }
        public string cambio { get; set; }
        public string peso { get; set; }
        public string eixos { get; set; }
        public string carroceria { get; set; }
        public string lotacao { get; set; }
        public string capacidade { get; set; }
        public string quilometragem { get; set; }
        public string portas { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string nome { get; set; }
        public string cpfcnpj { get; set; }
        public decimal valor { get; set; }
        public bool disponivel { get; set; }
        public string link_1 { get; set; }
        public string link_2 { get; set; }
        public string link_3 { get; set; }
        public string link_4 { get; set; }
        public string link_5 { get; set; }
        public string link_6 { get; set; }
        public string link_7 { get; set; }
        public string link_8 { get; set; }
        public string link_9 { get; set; }
        public string link_10 { get; set; }

        // Construtor padrão
        public void Veiculo()
        {
            // Inicialize propriedades padrão, se necessário
        }

    }
}
