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
    public class TipoFuncionariosController : ControllerBase
    {
        private readonly ExemploContext _context;

        public TipoFuncionariosController(ExemploContext context)
        {
            _context = context;
        }

        /*// GET: api/TipoFuncionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFuncionario>>> GetTipoFuncionarios()
        {
          if (_context.TipoFuncionarios == null)
          {
              return NotFound();
          }
            return await _context.TipoFuncionarios.ToListAsync();
        }*/

        // GET: api/TipoFuncionarios
        [HttpGet("resumo")]
        public async Task<ActionResult<IEnumerable<TipoFuncionarioResumo>>> GetTipoFuncionariosResumo()
        {
            if (_context.TipoFuncionarios == null)
            {
                return NotFound();
            }
            List<TipoFuncionario> TipoFuncionarioCompletos = await _context.TipoFuncionarios.ToListAsync();
            List<TipoFuncionarioResumo> resumos = new List<TipoFuncionarioResumo>();
            if (TipoFuncionarioCompletos != null)
            {
                foreach (TipoFuncionario? t in TipoFuncionarioCompletos)
                {
                    resumos.Add(new TipoFuncionarioResumo
                    {
                       IdTipo = t.IdTipo,
                       NomeTipo = t.NomeTipo,
                    }) ;
                }
            }

            return resumos.ToList();
        }

        /*// GET: api/TipoFuncionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFuncionario>> GetTipoFuncionario(int id)
        {
          if (_context.TipoFuncionarios == null)
          {
              return NotFound();
          }
            var tipoFuncionario = await _context.TipoFuncionarios.FindAsync(id);

            if (tipoFuncionario == null)
            {
                return NotFound();
            }

            return tipoFuncionario;
        }*/

        // GET: api/TipoFuncionarios/5
        [HttpGet("resumo/{id}")]
        public async Task<ActionResult<TipoFuncionarioResumo>> GetTipoFuncionarioResumo(int id)
        {
            if (_context.TipoFuncionarios == null)
            {
                return NotFound();
            }

            var t = await _context.TipoFuncionarios.FindAsync(id);

            if (t == null)
            {
                return NotFound();
            }

            var resumo = new TipoFuncionarioResumo
            {
                IdTipo = t.IdTipo,
                NomeTipo = t.NomeTipo,
               
            };

            return resumo;
        }


        /* // PUT: api/Tipo_Funcionarios/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutTipoFuncionario(int id, TipoFuncionario tipoFuncionario)
         {
             if (id != tipoFuncionario.IdTipo)
             {
                 return BadRequest();
             }

             _context.Entry(tipoFuncionario).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!TipoFuncionarioExists(id))
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

        // PUT: api/Tipo_Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("resumo/{id}")]
        public async Task<IActionResult> PutTipoFuncionario(int id, TipoFuncionarioEditar tipoFuncionarioEditar)
        {
            // Seu código para mapear os dados do chamadoDto para o objeto Chamado
            var tipoFuncionario = _context.TipoFuncionarios.Find(id);

            if (tipoFuncionario == null)
            {
                return NotFound();
            }

            // Realize o mapeamento dos dados do DTO para o objeto Chamado
            tipoFuncionario.NomeTipo = tipoFuncionarioEditar.NomeTipo;
           
            // Mapeie outras propriedades conforme necessário
            _context.Entry(tipoFuncionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoFuncionarioExists(id))
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

        /* // POST: api/TipoFuncionarios
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<TipoFuncionario>> PostTipoFuncionario(TipoFuncionario tipoFuncionario)
         {
           if (_context.TipoFuncionarios == null)
           {
               return Problem("Entity set 'ExemploContext.TipoFuncionarios'  is null.");
           }
             _context.TipoFuncionarios.Add(tipoFuncionario);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetTipoFuncionario", new { id = tipoFuncionario.IdTipo }, tipoFuncionario);
         }*/

        // POST: api/TipoFuncionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("resumo")]
        public async Task<ActionResult<TipoFuncionario>> PostTipoFuncionario(TipoFuncionarioCreate tipoFuncionario)
        {
            if (_context.TipoFuncionarios == null)
            {
                return Problem("Entity set 'ExemploContext.Funcionarios'  is null.");
            }

            if (tipoFuncionario != null)
            {

                var TipoFuncionariosCreate = new TipoFuncionario
                {
                    /*IdChamado = model.IdChamado,*/
                    NomeTipo = tipoFuncionario.NomeTipo,
                    

                };

                _context.TipoFuncionarios.Add(TipoFuncionariosCreate);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTipoFuncionariosResumo", new { id = TipoFuncionariosCreate.IdTipo }, TipoFuncionariosCreate);
            }
            else
            {
                return Problem("Erro = Chamado nao pode ser nulo");
            }

        }

        // DELETE: api/TipoFuncionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoFuncionario(int id)
        {
            if (_context.TipoFuncionarios == null)
            {
                return NotFound();
            }
            var tipoFuncionario = await _context.TipoFuncionarios.FindAsync(id);
            if (tipoFuncionario == null)
            {
                return NotFound();
            }

            _context.TipoFuncionarios.Remove(tipoFuncionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoFuncionarioExists(int id)
        {
            return (_context.TipoFuncionarios?.Any(e => e.IdTipo == id)).GetValueOrDefault();
        }
    }
}
