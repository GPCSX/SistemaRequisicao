using SistemaRequisicao.Models;

namespace SistemaRequisicao.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<TarefaModel> BuscarId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefa);
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
