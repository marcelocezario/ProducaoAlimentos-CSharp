namespace Model
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        
        public int EstadoID { get; set; }
        public virtual Estado _Estado { get; set; }

    }
}
