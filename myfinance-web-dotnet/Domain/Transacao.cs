using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Historico { get; set; }
        public string Tipo { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }


        //Exame especial
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}