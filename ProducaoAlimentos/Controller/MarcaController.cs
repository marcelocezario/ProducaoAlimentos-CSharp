﻿using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class MarcaController
    {
        // Métodos para Criação, Edição e Exclusão de Marcas 
        public bool SalvarMarca(Marca marca)
        {
            ContextoSingleton.Instancia.Marcas.Add(marca);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarMarca(int idMarca, Marca marcaEditada)
        {
            Marca marcaEditar = BuscarMarcaPorId(idMarca);

            if (marcaEditar != null)
            {
                marcaEditada.MarcaID = marcaEditar.MarcaID;
                marcaEditar = marcaEditada;

                ContextoSingleton.Instancia.Entry(marcaEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirMarca(Marca marca)
        {
            ContextoSingleton.Instancia.Entry(marca).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Marca BuscarMarcaPorId(int idMarca)
        {
            return ContextoSingleton.Instancia.Marcas.Find(idMarca);
        }
        public Marca BuscarMarcaPorNome(string nomeMarca)
        {
            var i = from x in ContextoSingleton.Instancia.Marcas
                    where x.Nome.ToLower().Contains(nomeMarca.Trim().ToLower())
                    select x;

            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }

        // Métodos para listagem de dados
        public List<Marca> ListarMarcas() => ContextoSingleton.Instancia.Marcas.ToList();
    }
}
