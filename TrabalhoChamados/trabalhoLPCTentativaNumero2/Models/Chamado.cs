using System;

namespace trabalhoLPCTentativaNumero2.Models
{
    public class Chamado
    {
        public Chamado() {}
        public Chamado(int id, string descricao, Situacao situacao, Cliente cliente, TimeSpan horaInicio, TimeSpan horaFim, DateTime data, TimeSpan tempoDuracao)
        {
            this.id = id;
            this.descricao = descricao;
            this.situacao = situacao;
            this.cliente = cliente;
            this.horaInicio = horaInicio;
            this.horaFim = horaFim;
            this.data = data;
            this.tempoDuracao = tempoDuracao;
        }
        public int id { get; set; }
        public string descricao { get; set; }
        public Situacao situacao { get; set; }
        public Cliente cliente { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan? horaFim { get; set; }  
        public TimeSpan? tempoDuracao { get; set; }    
        public DateTime data { get; set; } 
    }
}