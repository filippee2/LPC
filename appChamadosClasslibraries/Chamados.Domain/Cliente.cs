namespace Chamados.Domain
{
    public class Cliente
    {
        public Cliente() {}
        public Cliente(int id, string nome, string email, int telefone, Chamado chamado)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;    
            this.telefone = telefone;    
        }

        public int id { get; set; } 
        public string nome { get; set; }
        public string email { get; set; }
        public int telefone { get; set; }
    }
}