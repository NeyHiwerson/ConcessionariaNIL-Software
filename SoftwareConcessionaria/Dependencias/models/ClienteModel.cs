using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class ClienteModel
    {
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public DateTime dt_nascimento { get; set; }
        public string email { get; set; }
        public string cpfcnpj { get; set; }
        public string telefone { get; set; }
        public string ctt_telefone { get; set; }
        public DateTime dt_cadastro { get; set; }
        public string rg { get; set; }
        public int renda { get; set; }

        public ClienteModel()
        {
            
        }

    }
}
