namespace SistemaRequisicao.Repositorios.Interfaces
{
    public interface IFeriadoService
    {
        Task<bool> VerificarFeriado(string data);
    }
}
