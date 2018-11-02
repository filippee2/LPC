using System;

namespace AvaliaçãoG1.Models
{
    public class Consulta
    {
        public Consulta()
        { }

        public Consulta(int id, Paciente paciente, DateTime data, string descricao, bool isPrimeira, double valor, TimeSpan hora)
        {
            this.id = id;
            this.paciente = paciente;
            this.data = data;
            this.hora = hora;
            this.descricao = descricao;
            this.isPrimeira = isPrimeira;
            this.valor = valor;
        }

        public int id { get; set; }     
        public Paciente paciente { get; set; }  
        public DateTime data { get; set; }  
        public string descricao { get; set; }
        public bool isPrimeira { get; set; }
        public double valor { get; set; }   
        public TimeSpan hora { get; set; }
    }
}