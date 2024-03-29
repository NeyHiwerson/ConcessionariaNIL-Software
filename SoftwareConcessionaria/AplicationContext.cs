﻿using SoftwareConcessionaria.Dependencias.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConcessionaria
{
    public class ApplicationContext
    {
        public TokenManager tokenManager { get; set; }

        public Veiculo veiculo { get; set; }
        public ContatoCliente contatoCliente { get; set; }
        public Venda venda { get; set; }
        public VeiculoModel veiculoModel { get; set; }
        public ClienteModel clienteModel { get; set; }
        public EnderecoModel enderecoModel {  get; set; } 
        public int id_veiculo { get; set; }
        public int id_enderecoVenda { get; set; }
        public ColaboradorModel colaboradorModel { get; set; }


        private static ApplicationContext instance;

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }
    }
}

