using System.Collections.Generic;
using Model;
using System.Data.Entity;
using Model.DAL;

namespace Controller
{
    class InicializarDadosDB : DropCreateDatabaseIfModelChanges<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            List<UnidadeDeMedida> unidadesDeMedida = new List<UnidadeDeMedida>()
            {
                new UnidadeDeMedida(){ Nome = "Centimetro", Sigla = "cm", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Litro", Sigla = "l", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Quilo", Sigla = "kg", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Unidade", Sigla = "un", Fracionavel = false}
            };

            foreach (UnidadeDeMedida unidadeDeMedida in unidadesDeMedida)
            {
                ContextoSingleton.Instancia.UnidadesDeMedida.Add(unidadeDeMedida);
                ContextoSingleton.Instancia.SaveChanges();
            }
        }
    }
}
