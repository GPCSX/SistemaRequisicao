using Microsoft.EntityFrameworkCore;
using SistemaRequisicao.Data;
using SistemaRequisicao.Models;
using SistemaRequisicao.Repositorios.Interfaces;

namespace SistemaRequisicao.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaRequisicaoDBContext _dbContext;
        public TarefaRepositorio(SistemaRequisicaoDBContext sistemaRequisicaoDBContext)
        {
            _dbContext = sistemaRequisicaoDBContext;
        }
        public async Task<TarefaModel> BuscarId(int id)
        {
            return await _dbContext.Tarefa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            
            return tarefa;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaID = await BuscarId(id);

            if(tarefaID == null)
            {
                throw new Exception($"A Tarefa para o {id}, não foi encontrada no Banco de Dados");
            }

            _dbContext.Tarefa.Remove(tarefaID);
            await _dbContext.SaveChangesAsync();    
            return true;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaID = await BuscarId(id);

            if(tarefaID == null)
            {
                throw new Exception($"A Tarefa para o {id}, não foi encontrada no Banco de Dados");
            }
            tarefaID.Nome = tarefa.Nome;
            tarefaID.Descricao = tarefa.Descricao;

            _dbContext.Tarefa.Update(tarefaID);
            await _dbContext.SaveChangesAsync();

            return tarefaID;    
        }
    }
}
