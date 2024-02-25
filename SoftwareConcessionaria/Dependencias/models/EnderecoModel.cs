using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class EnderecoModel
    {
        public int id_endereco { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string tipo_endereco { get; set; }
        public string cidade { get; set; }
        public string uf_estado { get; set; }

        public EnderecoModel() { }
    }

}
