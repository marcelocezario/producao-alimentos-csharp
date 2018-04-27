﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public string UnidadeDeMedida { get; set; }

        public virtual List<ItemComposicaoProduto> ItemComposicaoProduto { get; set; }
    }
}
