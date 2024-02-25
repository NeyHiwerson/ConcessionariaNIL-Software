using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class CliEnderecoModel
    {
        public int id_cliente { get; set; }
        public List<EnderecoModel> enderecos { get; set; }

        // Construtor para inicializar a lista de endereços
        public CliEnderecoModel()
        {
            enderecos = new List<EnderecoModel>();
        }
    }

}
