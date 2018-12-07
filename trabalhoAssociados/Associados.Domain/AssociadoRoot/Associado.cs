using System;
using System.Collections.Generic;
using Associados.Domain.DependenteRoot;

namespace Associados.Domain.AssociadoRoot
{
    public class Associado : Entity
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public List<Dependente> dependentes { get; set; }
        
    }
}