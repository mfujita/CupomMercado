﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupomMercado
{
    class AtacadaoStaTerezinhaVar
    {
        public string indice { get; set; }
        public string codProduto { get; set; }
        public string descricao { get; set; }
        public string preco { get; set; }

        public AtacadaoStaTerezinhaVar(string i, string c, string d, string p)
        {
            indice = i;
            codProduto = c;
            descricao = d;
            preco = p;
        }
    }
}
