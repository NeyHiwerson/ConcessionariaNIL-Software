using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class VendaModel
    {
        public int id_venda { get; set; }
        public int id_cliente { get; set; }
        public int id_endereco { get; set; }
        public int id_veiculo { get; set; }
        public decimal valor { get; set; }
        public DateTime dt_venda { get; set; }
        public int id_colaborador { get; set; }

        public VendaModel() { }
    }
}
