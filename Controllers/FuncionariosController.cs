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
    public class FuncionariosController : ControllerBase
    {
        private readonly ExemploContext _context;

        public FuncionariosController(ExemploContext context)
        {
            _context = context;
        }

        /*// GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
          if (_context.Funcionarios == null)
          {
              return NotFound();
          }
            return await _context.Funcionarios.ToListAsync();
        }*/

        // GET: api/Funcionarios/resumo
        [HttpGet("resumo")]
        public async Task<ActionResult<IEnumerable<FuncionarioResumo>>> GetFuncionarioResumo()
        {
            if (_context.Funcionarios == null)
            {
                return NotFound();
            }
            List<Funcionario> FuncionarioCompletos = await _context.Funcionarios.ToListAsync();
            List<FuncionarioResumo> resumos = new List<FuncionarioResumo>();
            if (FuncionarioCompletos != null)
            {
                foreach (Funcionario? f in FuncionarioCompletos)
                {
                    var setor= await _context.Setores.FindAsync(f.SetorId);
                    
                    resumos.Add(new FuncionarioResumo
                    {
                        IdFuncionario = f.IdFuncionario,
                        NomeFuncionario = f.NomeFuncionario,
                        Usuario = f.Usuario,
                        TipoFuncionarioId = f.TipoFuncionarioId,
                        Status = f.Status,
                        SetorId = f.SetorId,
                        SetorNome = setor.Nome, // Use o nome da classificação
                       
                    });
                }
            }

            return resumos.ToList();
        }


        /*// GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
          if (_context.Funcionarios == null)
          {
              return NotFound();
          }
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }*/

        // GET: api/Funcionarios/5
        [HttpGet("rerumo/{id}")]
        public async Task<ActionResult<FuncionarioResumo>> GetFuncionario(int id)
        {
          if (_context.Funcionarios == null)
          {
              return NotFound();
          }
            var f = await _context.Funcionarios.FindAsync(id);

            if (f == null)
            {
                return NotFound();
            }

            var setor = await _context.Setores.FindAsync(f.SetorId);

            var resumos = new FuncionarioResumo
            {
                IdFuncionario = f.IdFuncionario,
                NomeFuncionario = f.NomeFuncionario,
                Usuario = f.Usuario,
                TipoFuncionarioId = f.TipoFuncionarioId,
                Status = f.Status,
                SetorId = f.SetorId,
                SetorNome = setor.Nome, // Use o nome da classificação

            };

            return resumos;
        }


        /*
                // PUT: api/Funcionarios/5
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutFuncionario(int id, Funcionario funcionario)
                {
                    if (id != funcionario.IdFuncionario)
                    {
                        return BadRequest();
                    }

                    _context.Entry(funcionario).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FuncionarioExists(id))
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



        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("resumo/admin/{id}")]
        public async Task<IActionResult> PutFuncionario(int id, FuncionarioEditarAdmin funcionarioEditar)
        {
            // Seu código para mapear os dados do chamadoDto para o objeto Chamado
            var funcionario = _context.Funcionarios.Find(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            // Realize o mapeamento dos dados do DTO para o objeto Chamado
            funcionario.NomeFuncionario = funcionarioEditar.NomeFuncionario;
            funcionario.Usuario = funcionarioEditar.Usuario;
            funcionario.Status = funcionarioEditar.Status;
            funcionario.Senha = funcionarioEditar.Senha;
            funcionario.Status = funcionarioEditar.Status;
            funcionario.TipoFuncionarioId = funcionarioEditar.TipoFuncionarioId;
            funcionario.SetorId = funcionarioEditar.SetorId;
            // Mapeie outras propriedades conforme necessário


            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("resumo/{id}")]
        public async Task<IActionResult> PutFuncionario(int id, FuncionarioEditar funcionarioEditar)
        {
            // Seu código para mapear os dados do chamadoDto para o objeto Chamado
            var funcionario = _context.Funcionarios.Find(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            // Realize o mapeamento dos dados do DTO para o objeto Chamado
           
            funcionario.Senha = funcionarioEditar.Senha;
          
            // Mapeie outras propriedades conforme necessário

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        /*// POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
          if (_context.Funcionarios == null)
          {
              return Problem("Entity set 'ExemploContext.Funcionarios'  is null.");
          }
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.IdFuncionario }, funcionario);
        }*/

        [HttpPost("resumo")]
        public async Task<ActionResult<Funcionario>> PostFuncionarioF(FuncionarioCreate model)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'ExemploContext.Funcionarios'  is null.");
            }
            var funcionario = new Funcionario
            {
                NomeFuncionario = model.NomeFuncionario,
                Usuario = model.Usuario,
                Senha = model.Senha,
                TipoFuncionarioId = model.TipoFuncionarioId,
                FuncionarioTipo = await _context.TipoFuncionarios.FindAsync(model.TipoFuncionarioId),
                SetorId = model.SetorId,
                Setor = await _context.Setores.FindAsync(model.SetorId)
            };
                
                

            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.IdFuncionario }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            if (_context.Funcionarios == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(int id)
        {
            return (_context.Funcionarios?.Any(e => e.IdFuncionario == id)).GetValueOrDefault();
        }
    }
}
