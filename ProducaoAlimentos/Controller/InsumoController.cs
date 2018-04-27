﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class InsumoController
    {
        public bool SalvarInsumo (Insumo insumo)
        {
            ContextoSingleton.Instancia.Insumos.Add(insumo);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Insumo PesquisarInsumoPorID (int insumoID)
        {
            return ContextoSingleton.Instancia.Insumos.Find(insumoID);
        }

        public bool ExcluirInsumo (Insumo insumo)
        {
            ContextoSingleton.Instancia.Entry(insumo).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Insumo PesquisarInsumoPorNome (string nomeInsumo)
        {
            var i = from x in ContextoSingleton.Instancia.Insumos
                    where x.Nome.ToLower().Contains(nomeInsumo.Trim().ToLower())
                    select x;

            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }

        
    }
}
