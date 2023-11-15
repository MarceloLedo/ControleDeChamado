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
    public class SetoresController : ControllerBase
    {
        private readonly ExemploContext _context;

        public SetoresController(ExemploContext context)
        {
            _context = context;
        }

        /* // GET: api/Setores
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Setor>>> GetSetores()
         {
           if (_context.Setores == null)
           {
               return NotFound();
           }
             return await _context.Setores.ToListAsync();
         }*/

        // GET: api/Setores
        [HttpGet("resumo")]
        public async Task<ActionResult<IEnumerable<SetorResumo>>> GetSetoresResumo()
        {
            if (_context.Setores == null)
            {
                return NotFound();
            }
            List<Setor> SetorCompletos = await _context.Setores.ToListAsync();
            List<SetorResumo> resumos = new List<SetorResumo>();
            if (SetorCompletos != null)
            {
                foreach (Setor? s in SetorCompletos)
                {
                    resumos.Add(new SetorResumo
                    {
                        IdSetor = s.IdSetor,
                        Nome = s.Nome,
                        Funcao = s.Funcao,
                        Ramal = s.Ramal,
                        Status = s.Status,
                    });
                }
            }

            return resumos.ToList();
        }

        /* // GET: api/Setores/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Setor>> GetSetor(int id)
         {
           if (_context.Setores == null)
           {
               return NotFound();
           }
             var setor = await _context.Setores.FindAsync(id);

             if (setor == null)
             {
                 return NotFound();
             }

             return setor;
         }*/

        // GET: api/Setores/5
        [HttpGet("resumo/{id}")]
        public async Task<ActionResult<SetorResumo>> GetSetorResumo(int id)
        {
            if (_context.Setores == null)
            {
                return NotFound();
            }

            var s = await _context.Setores.FindAsync(id);

            if (s == null)
            {
                return NotFound();
            }
          
            var resumo = new SetorResumo
            {
                IdSetor = s.IdSetor,
                Nome = s.Nome,
                Funcao = s.Funcao,
                Ramal = s.Ramal,
                Status = s.Status,
            };

            return resumo;
        }


        /*// PUT: api/Setores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetor(int id, Setor setor)
        {
            if (id != setor.IdSetor)
            {
                return BadRequest();
            }

            _context.Entry(setor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetorExists(id))
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



        // PUT: api/Setores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("resumo/{id}")]
        public async Task<IActionResult> PutSetor(int id, SetorEditar setorEditar)
        {
            // Seu código para mapear os dados do chamadoDto para o objeto Chamado
            var setor = _context.Setores.Find(id);

            if (setor == null)
            {
                return NotFound();
            }

            // Realize o mapeamento dos dados do DTO para o objeto Chamado
            setor.Nome = setorEditar.Nome;
            setor.Funcao = setorEditar.Funcao;
            setor.Ramal = setorEditar.Ramal;
            setor.Status = setorEditar.Status;

            // Mapeie outras propriedades conforme necessário


            _context.Entry(setor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetorExists(id))
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

        /*// POST: api/Setores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Setor>> PostSetor(Setor setor)
        {
          if (_context.Setores == null)
          {
              return Problem("Entity set 'ExemploContext.Setores'  is null.");
          }
            _context.Setores.Add(setor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSetor", new { id = setor.IdSetor }, setor);
        }*/

        // POST: api/Setores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SetorResumo>> PostSetor(SetorCreate setor)
        {
            if (_context.Setores == null)
            {
                return Problem("Entity set 'ExemploContext.Funcionarios'  is null.");
            }

            if (setor != null)
            {

                var setorCreate = new Setor
                {
                    Nome = setor.Nome,
                    Funcao = setor.Funcao,
                    Ramal = setor.Ramal,
                    Status = setor.Status,


                };

                _context.Setores.Add(setorCreate);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSetoresResumo", new { id = setorCreate.IdSetor }, setor);
            }
            else
            {
                return Problem("Erro = Chamado nao pode ser nulo");
            }

        }

        // DELETE: api/Setores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetor(int id)
        {
            if (_context.Setores == null)
            {
                return NotFound();
            }
            var setor = await _context.Setores.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SetorExists(int id)
        {
            return (_context.Setores?.Any(e => e.IdSetor == id)).GetValueOrDefault();
        }
    }
}
