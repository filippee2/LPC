using System;

namespace AvaliaçãoG1.Models
{
    public class Paciente
    {
        public Paciente()
        { }

        public Paciente(int id, string nome, string endereco, string email, int telefone, DateTime dataNascimento, bool isParticular, PlanoDeSaude planoSaude)
        {
            this.id = id;
            this.nome = nome;
            this.endereco = endereco;
            this.email = email;
            this.telefone = telefone;
            this.dataNascimento = dataNascimento;
            this.isParticular = isParticular;
            this.planoSaude = planoSaude;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public int telefone { get; set; }
        public DateTime dataNascimento { get; set; }
        public bool isParticular { get; set; }  
        public PlanoDeSaude planoSaude { get; set; }
    }
}