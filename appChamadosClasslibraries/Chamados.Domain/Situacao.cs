namespace Chamados.Domain
{
    public class Situacao
    {
        public Situacao() {}
        public Situacao(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
        public int id { get; set; }
        public string nome { get; set; }
    }
}