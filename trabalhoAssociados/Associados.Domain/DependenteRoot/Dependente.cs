using System;

namespace Associados.Domain.DependenteRoot
{
    public class Dependente : Entity
    {
        public string nome { get; set; }
        public string grauParentesco { get; set; }
        public DateTime dataNascimento { get; set; }    
    }
}