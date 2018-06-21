using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Cidade
    {
        public int CidadeID { get; set; }
        public string Nome { get; set; }

        [ForeignKey("_Estado")]
        public int EstadoID { get; set; }
        public virtual Estado _Estado { get; set; }
    }
}