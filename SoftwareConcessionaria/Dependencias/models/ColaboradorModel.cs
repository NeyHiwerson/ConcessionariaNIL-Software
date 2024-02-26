using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class ColaboradorModel
    {
        public int id_colaborador { get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
        public string telefone { get; set; }
        public string filial_atual { get; set; }

        public ColaboradorModel() { }
    }
}
