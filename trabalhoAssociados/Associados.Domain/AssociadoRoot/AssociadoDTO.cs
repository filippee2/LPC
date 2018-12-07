namespace Associados.Domain.AssociadoRoot
{
    public class AssociadoDTO : Entity
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string email { get; set; }
    }
}