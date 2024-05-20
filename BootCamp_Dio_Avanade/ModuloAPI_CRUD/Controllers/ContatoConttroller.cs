using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Contexto;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoConttroller : ControllerBase
    {
        private readonly AgendaContexto _contexto;
        
        public ContatoConttroller(AgendaContexto contexto)
        {
            _contexto = contexto;
        }

        //Define qual comando CRUD vai ser executado

        //Adicionar
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _contexto.Add(contato);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.IdContato}, contato);
        }

        //Buscar
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _contexto.Contatos.Find(id);

                if(contato == null)
                    return NotFound();

            return Ok(contato);
        }
        
        /*  BuscarPorNome -> ao usar um metodo mais de uma vez, como é o exemplo do Get
         *  se faz necessario expecificar o "nome", como esta acontecendo em
         *  [HttpGet("ObterPorNome")]
         */ 
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _contexto.Contatos.Where(x => x.NomeContato.Contains(nome));
            return Ok(contatos);
        }

        //Atualizar o PATCH seria uma atualização parcial
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _contexto.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            contatoBanco.NomeContato = contato.NomeContato;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _contexto.Contatos.Update(contatoBanco);
            _contexto.SaveChanges();

            return Ok(contatoBanco);
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _contexto.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();
            
            _contexto.Contatos.Remove(contatoBanco);
            _contexto.SaveChanges();

            return NoContent();
        }
    }
}