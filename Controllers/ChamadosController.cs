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
    public class ChamadosController : ControllerBase
    {
        private readonly ExemploContext _context;

        public ChamadosController(ExemploContext context)
        {
            _context = context;
        }
        
        // GET: api/Chamados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chamado>>> GetChamados()
        {
          if (_context.Chamados == null)
          {
              return NotFound();
          }
            return await _context.Chamados.ToListAsync();
        }
        

        /*// GET: api/Chamados/resumo
        [HttpGet("resumo")]
        public async Task<ActionResult<IEnumerable<ChamadoResumo>>> GetChamadosResumo()
        {
            if (_context.Chamados == null)
            {
                return NotFound();
            }
            List<Chamado> ChamadosCompletos = await _context.Chamados.ToListAsync();
            List<ChamadoResumo> resumos = new List<ChamadoResumo>();
            if (ChamadosCompletos != null)
            {
                foreach (Chamado? c in ChamadosCompletos)
                {
                    var classificacao = await _context.Classificacao.FindAsync(c.ClassificacaoId);
                    var solicitante = await _context.Funcionarios.FindAsync(c.SolicitanteId);
                    var executante = await _context.Funcionarios.FindAsync(c.ExecutanteId);

                    resumos.Add(new ChamadoResumo
                    {
                        IdChamado = c.IdChamado,
                        Titulo = c.Titulo,
                        Descricao = c.Descricao,
                        DataInicial = c.DataInicial,
                        DataFinal = c.DataFinal,
                        Status = c.Status,
                        Prioridade = c.Prioridade,
                        ClassificacaoNome = classificacao.NomeClassificacao, // Use o nome da classificação
                        SolicitanteNome = solicitante.NomeFuncionario, // Use o nome do solicitante
                        ExecutanteNome = executante.NomeFuncionario,// Use o nome do solicitante
                    });
                }
            }

            return resumos.ToList();
        }
*/


        // GET: api/Chamados/resumo
        [HttpGet("resumo")]
        public async Task<ActionResult<IEnumerable<ChamadoResumo>>> GetChamadosResumo()
        {
            if (_context.Chamados == null)
            {
                return NotFound();
            }

            List<Chamado> ChamadosCompletos = await _context.Chamados.ToListAsync();
            List<ChamadoResumo> resumos = new List<ChamadoResumo>();

            if (ChamadosCompletos != null)
            {
                foreach (Chamado? c in ChamadosCompletos)
                {
                    var classificacao = await _context.Classificacao.FindAsync(c.ClassificacaoId);
                    var solicitante = await _context.Funcionarios.FindAsync(c.SolicitanteId);
                    var executante = await _context.Funcionarios.FindAsync(c.ExecutanteId);

                    if (executante == null)
                    {
                        executante = new Funcionario();
                        executante.NomeFuncionario = "";
                    }
                    resumos.Add(new ChamadoResumo
                    {
                        IdChamado = c.IdChamado,
                        Titulo = c.Titulo,
                        Descricao = c.Descricao,
                        DataInicial = c.DataInicial,
                        DataFinal = c.DataFinal,
                        Status = c.Status,
                        Prioridade = c.Prioridade,
                        ClassificacaoNome = classificacao.NomeClassificacao,
                        SolicitanteNome = solicitante.NomeFuncionario,
                        ExecutanteNome = executante.NomeFuncionario,
                    });
                }
            }

            return resumos.ToList();
        }

        

        /*// GET: api/Chamados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chamado>> GetChamado(int id)
        {
          if (_context.Chamados == null)
          {
              return NotFound();
          }
            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
            {
                return NotFound();
            }

            return chamado;
        }*/

        // GET: api/Chamados/5
        [HttpGet("resumo/{id}")]
        public async Task<ActionResult<ChamadoResumo>> GetChamadoResumo(int id)
        {
            if (_context.Chamados == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados.FindAsync(id);

            if (chamado == null)
            {
                return NotFound();
            }
            var classificacao = await _context.Classificacao.FindAsync(chamado.ClassificacaoId);
            var solicitante = await _context.Funcionarios.FindAsync(chamado.SolicitanteId);
            var executante = await _context.Funcionarios.FindAsync(chamado.ExecutanteId);
            if (executante == null)
            {
                executante = new Funcionario();
                executante.NomeFuncionario = "";
            }
            var resumo = new ChamadoResumo
            {
                IdChamado = chamado.IdChamado,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                DataInicial = chamado.DataInicial,
                DataFinal = chamado.DataFinal,
                Status = chamado.Status,
                Prioridade = chamado.Prioridade,
                ClassificacaoNome = classificacao.NomeClassificacao, // Use o nome da classificação
                SolicitanteNome = solicitante.NomeFuncionario, // Use o nome do solicitante
                ExecutanteNome = executante.NomeFuncionario, // Use o nome do solicitante

                /*ClassificacaoNome = chamado.ClassificacaoId,*/
                /*SolicitanteNome = chamado.SolicitanteId,*/
                /*Solicitante = await _context.Funcionarios.FindAsync(Funcionario.NomeFuncionario),*/

            };

            return resumo;
        }

        

        // PUT: api/Chamados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutChamado(int id, Chamado chamado)
        {
            if (id != chamado.IdChamado)
            {
                return BadRequest();
            }

            _context.Entry(chamado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChamadoExists(id))
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

        [HttpPut("resumo/{id}")]
        public async Task<IActionResult> PutChamado(int id, ChamadoEditar chamadoEditar)
        {
            
            // Seu código para mapear os dados do chamadoDto para o objeto Chamado
            var chamado = _context.Chamados.Find(id);

            if (chamado == null)
            {
                return NotFound();
            }

            // Realize o mapeamento dos dados do DTO para o objeto Chamado
            chamado.Titulo = chamadoEditar.Titulo;
            chamado.Descricao = chamadoEditar.Descricao;
            chamado.Status = chamadoEditar.Status;
            chamado.Prioridade = chamadoEditar.Prioridade;
            chamado.ClassificacaoId = chamadoEditar.ClassificacaoId;
            chamado.SolicitanteId = chamadoEditar.SolicitanteId;
            chamado.ExecutanteId = chamadoEditar.ExecutanteId;
            // Mapeie outras propriedades conforme necessário


            _context.Entry(chamado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChamadoExists(id))
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




        // POST: api/Chamados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<Chamado>> PostChamado(Chamado chamado)
        {
          if (_context.Chamados == null)
          {
              return Problem("Entity set 'ExemploContext.Chamados'  is null.");
          }
            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChamado", new { id = chamado.IdChamado }, chamado);
        }*/


        /* public async Task<ActionResult<Produto>> PostProduto(ProdutoInputModel model)
         {
             var produto = new Produto
             {
                 Nome = model.Nome,
                 Quantidade = model.Quantidade,
                 Valor = model.Valor
             };

             _context.Produtos.Add(produto);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
         }*/

        
                [HttpPost("Resumo")]
                public async Task<ActionResult<ChamadoResumo>> PostChamado(ChamadoCreate model)

                {
                    if (_context.Chamados == null)
                    {
                        return Problem("Entity set 'ExemploContext.Funcionarios'  is null.");
                    }

                    if (model != null)
                    {
                        
                        var chamadoCreate = new Chamado
                        {
                            IdChamado = model.IdChamado,
                            Titulo = model.Titulo,
                            Descricao = model.Descricao,
                            DataInicial = model.DataInicial,
                            /*DataFinal = model.DataFinal,*/ //como ser nulo na hora de fazer o post 
                            Status = model.Status,
                            Prioridade = model.Prioridade,
                            ClassificacaoId = model.ClassificacaoId,
                            Classificacao = await _context.Classificacao.FindAsync(model.ClassificacaoId),
                            SolicitanteId = model.SolicitanteId,
                            Solicitante = await _context.Funcionarios.FindAsync(model.SolicitanteId),
                            /*ExecutanteId = model.ExecutanteId,*/
                            /*Executante = await _context.Funcionarios.FindAsync(model.ExecutanteId),*/
                            

                        };

                        _context.Chamados.Add(chamadoCreate);
                        await _context.SaveChangesAsync();

                        return CreatedAtAction("GetChamadoResumo", new { id = model.IdChamado }, model);
                    }
                    else 
                    {
                        return Problem("Erro = Chamado nao pode ser nulo");
                    }

                }

        /*[HttpPost("Resumo")]
        public async Task<ActionResult<Chamado>> PostChamado(ChamadoCreate model)
        {
            var chamadoCreate = new Chamado
            {
                IdChamado = model.IdChamado,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataInicial = model.DataInicial,
                DataFinal = model.DataFinal,
                Status = model.Status,
                Prioridade = model.Prioridade,
                ClassificacaoId = model.ClassificacaoId,
                SolicitanteId = model.SolicitanteId,
                *//* Solicitante = await _context.Funcionarios.FindAsync(model.Solicitante.NomeFuncionario),*//*
                ExecutanteId = model.ExecutanteId,
                *//* Executante = await _context.Funcionarios.FindAsync(model.Executante.NomeFuncionario),*//*

             };

            return CreatedAtAction("GetChamados", new { id = chamadoCreate.IdChamado }, chamadoCreate);
        }*/


        // DELETE: api/Chamados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChamado(int id)
        {
            if (_context.Chamados == null)
            {
                return NotFound();
            }
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChamadoExists(int id)
        {
            return (_context.Chamados?.Any(e => e.IdChamado == id)).GetValueOrDefault();
        }
    }
}
