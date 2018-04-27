using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{

    // Abre e fecha uma única conexão com o banco de dados
    public class ContextoSingleton
    {
        private static Contexto instancia;

        public static Contexto Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Contexto();
                }

                return instancia;
            }
        }
        private ContextoSingleton()
        {

        }
    }
}
