namespace Conversor.Shared.Command
{
    public interface IComandoResultado
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object ResultadoObtido { get; set; }
    }
}
