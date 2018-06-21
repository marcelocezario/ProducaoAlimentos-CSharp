﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        [ForeignKey("_Cidade")]
        public int CidadeID { get; set; }
        public virtual Cidade _Cidade { get; set; }
    }
}
