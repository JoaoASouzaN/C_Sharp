using Microsoft.AspNetCore.Mvc;
using Proj4.Context;
using Proj4.Entities;

namespace Proj4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        // Buscar por Id no banco utilizando o EF
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            // Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound,
            // caso contrário retornar OK com a tarefa encontrada
            if(tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        //Buscar todas as tarefas no banco utilizando o EF
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var todasTarefas = _context.Tarefas.ToList();

            return Ok(todasTarefas);
        }

        // Buscar as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var obterPorTitulo = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            if(obterPorTitulo == null)
                return NotFound();

            return Ok(obterPorTitulo);
        }

        // Buscar as tarefas por data
        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date).ToList();

            return Ok(tarefa);
        }

        // Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status).ToList();
            
            return Ok(tarefa);
        }

        // Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        // Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
        // Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;
            _context.SaveChanges();
            return Ok(tarefaBanco);
        }

        // Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
