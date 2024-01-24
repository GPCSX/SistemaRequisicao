using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaRequisicao.Models;
using SistemaRequisicao.Repositorios.Interfaces;
using System; 
using System.Threading.Tasks;

namespace SistemaRequisicao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        /*[HttpGet]
        public ActionResult<List<TarefaModel>> BuscarTodasTarefas() {
            return Ok();
        }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id; 
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool tarefa = await _tarefaRepositorio.Apagar(id);
            return Ok(tarefa);
        }

        [Route("api/[controller]")]
        [ApiController]
        public class TarefaControllerF : ControllerBase
        {
            private readonly ITarefaRepositorio _tarefaRepositorio;
            private readonly IFeriadoService _feriadoService;

            public TarefaControllerF(ITarefaRepositorio tarefaRepositorio, IFeriadoService feriadoService)
            {
                _tarefaRepositorio = tarefaRepositorio;
                _feriadoService = feriadoService;
            }

            // ... outros métodos

            [HttpGet("VerificarFeriado")]
            public async Task<ActionResult<bool>> VerificarFeriado([FromQuery] string data)
            {
                try
                {
                    bool ehFeriado = await _feriadoService.VerificarFeriado(data);
                    return Ok(ehFeriado);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro ao verificar feriado: {ex.Message}");
                }
            }
        }

    }
}
