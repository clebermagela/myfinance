namespace myfinance_web_dotnet.Domain
{
    public class PlanoConta
    {
        public int? Id { get; set; }
        public required string Nome { get; set; }
        public required string Tipo { get; set; }
    }
}