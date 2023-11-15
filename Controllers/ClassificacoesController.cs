using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleDeChamado.Data;
using ControleDeChamado.Models;

namespace ControleDeChamado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificacoesController : ControllerBase
    {
        private readonly ExemploContext _context;

        public ClassificacoesController(ExemploContext context)
        {
            _context = context;
        }

        /*// GET: api/Classificacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classificacao>>> GetClassificacao()
        {
          if (_context.Classificacao == null)
          {
              return NotFound();
          }
            return await _context.Classificacao.ToListAsync();
        }*/


        // GET: api/Chamados/resumo
        [HttpGet("resumo")]
        public async Task<ActionResult<IEnumerable<ClassificacaoResumo>>> GetClassificacaoResumo()
        {
            if (_context.Classificacao == null)
            {
                return NotFound();
            }
            List<Classificacao> ClassificacaoCompletos = await _context.Classificacao.ToListAsync();
            List<ClassificacaoResumo> resumos = new List<ClassificacaoResumo>();
            if (ClassificacaoCompletos != null)
            {
                foreach (Classificacao? c in ClassificacaoCompletos)
                {
                    
                    resumos.Add(new ClassificacaoResumo
                    {
                        IdClassificacao = c.IdClassificacao,
                        NomeClassificacao = c.NomeClassificacao,
                       
                    });
                }
            }

            return resumos.ToList();
        }

        /*// GET: api/Classificacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classificacao>> GetClassificacao(int id)
        {
          if (_context.Classificacao == null)
          {
              return NotFound();
          }
            var classificacao = await _context.Classificacao.FindAsync(id);

            if (classificacao == null)
            {
                return NotFound();
            }

            return classificacao;
        }*/

        // GET: api/Chamados/5
        [HttpGet("resumo/{id}")]
        public async Task<ActionResult<ClassificacaoResumo>> GetClassificacaoResumo(int id)
        {
            if (_context.Classificacao == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacao.FindAsync(id);

            if (classificacao == null)
            {
                return NotFound();
            }
           
            var resumo = new ClassificacaoResumo
            {
                IdClassificacao = classificacao.IdClassificacao,
                NomeClassificacao = classificacao.NomeClassificacao,

            };

            return resumo;
        }

        /*// PUT: api/Classificacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassificacao(int id, Classificacao classificacao)
        {
            if (id != classificacao.IdClassificacao)
            {
                return BadRequest();
            }

            _context.Entry(classificacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // PUT: api/Classificacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("resumo/{id}")]
        public async Task<IActionResult> PutClassificacao(int id, ClassificacaoEditar classificacaoEditar)
        {

            var classificacao = _context.Classificacao.Find(id);


            if (classificacao == null)
            {
                return NotFound();
            }

            classificacao.NomeClassificacao = classificacaoEditar.NomeClassificacao;

            _context.Entry(classificacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /* // POST: api/Classificacoes
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<Classificacao>> PostClassificacao(Classificacao classificacao)
         {
           if (_context.Classificacao == null)
           {
               return Problem("Entity set 'ExemploContext.Classificacao'  is null.");
           }
             _context.Classificacao.Add(classificacao);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetClassificacao", new { id = classificacao.IdClassificacao }, classificacao);
         }*/

        // POST: api/Classificacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Resumo")]
        public async Task<ActionResult<ClassificacaoResumo>> PostClassificacao(ClassificacaoCreate classificacao)
        {
            if (_context.Classificacao == null)
            {
                return Problem("Entity set 'ExemploContext.Funcionarios'  is null.");
            }

            if (classificacao != null)
            {

                var classificacaoCreate = new Classificacao
                {
                  NomeClassificacao = classificacao.NomeClassificacao,
                };

                _context.Classificacao.Add(classificacaoCreate);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction("GetClassificacaoResumo", new { id = classificacao.IdClassificacao}, classificacao);
            }
            else
            {
                return Problem("Erro = Chamado nao pode ser nulo");
            }

        }

        // DELETE: api/Classificacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassificacao(int id)
        {
            if (_context.Classificacao == null)
            {
                return NotFound();
            }
            var classificacao = await _context.Classificacao.FindAsync(id);
            if (classificacao == null)
            {
                return NotFound();
            }

            _context.Classificacao.Remove(classificacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassificacaoExists(int id)
        {
            return (_context.Classificacao?.Any(e => e.IdClassificacao == id)).GetValueOrDefault();
        }
    }
}
