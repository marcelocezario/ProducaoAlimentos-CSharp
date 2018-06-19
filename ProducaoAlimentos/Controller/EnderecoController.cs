﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class EnderecoController
    {
        // Métodos para Criação, Edição e Exclusão de Marcas 
        public bool SalvarMarca(Endereco endereco)
        {
            ContextoSingleton.Instancia.Enderecos.Add(endereco);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarEnderedco(int idEndereco, Endereco enderecoEditado)
        {
            Endereco enderecoEditar = BuscarEnderecoPorId(idEndereco);

            if (enderecoEditar != null)
            {
                enderecoEditado.EnderecoID = enderecoEditar.EnderecoID;
                enderecoEditar = enderecoEditado;

                ContextoSingleton.Instancia.Entry(enderecoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirEndereco(Endereco endereco)
        {
            ContextoSingleton.Instancia.Entry(endereco).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Marca BuscarEnderecoPorId(int idEndereco)
        {
            return ContextoSingleton.Instancia.Enderecos.Find(idEndereco);
        }

        // Métodos para listagem de dados
        public List<Marca> ListarEnderecos() => ContextoSingleton.Instancia.Enderecos.ToList();
    }
}
