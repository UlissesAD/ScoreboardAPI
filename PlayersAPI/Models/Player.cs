namespace PlayersAPI.Models
{
    //Modelo da Tabela para o Banco de Dados
    public class Player
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Cash { get; set; }
    }
}
