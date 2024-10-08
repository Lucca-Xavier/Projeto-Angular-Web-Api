using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly Contexto _contexto;
        private readonly ILogger<PessoasController> _logger; // Adicione esta linha


        public PessoasController(Contexto contexto, ILogger<PessoasController> logger)
        {
            _contexto = contexto;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pessoa>>> PegarTodosAsync()
        {
            return await _contexto.Pessoas.ToListAsync();
        }

        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> PegarPessoaPeloIdAsync(int pessoaId)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);
            if (pessoa == null)
                return NotFound();

            return pessoa;
        }


        [HttpPost]
        public async Task<ActionResult<Pessoa>> SalvarPessoaAsync(Pessoa pessoa)
        {
            await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPessoaAsync(Pessoa pessoa) //Boa pratica passar o id da pessoa tambem, ao inves de passar somente o objeto novo
        { 
            _contexto.Pessoas.Update(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{pessoaId}")]

        public async Task<ActionResult> ExcluirPessoaAsync(int pessoaId)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);

            if (pessoa == null)
            {
                return NotFound();
            }

            _contexto.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
    }
}