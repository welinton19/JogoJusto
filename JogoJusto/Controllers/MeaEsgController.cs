using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/meaesg")]
public class MeaEsgController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public MeaEsgController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarMeaEsg([FromBody] MetaEsgModel meta)
    {
        var metaesgExistente = _jogodbcontext.MetaEsg
            .FirstOrDefault(m => m.DescricaoMetaEsg == meta.DescricaoMetaEsg &&
                                 m.Empresa != null &&
                                 m.Empresa.EmpresaId == meta.Empresa.EmpresaId);

        if (meta == null)
            return BadRequest("Dados da Meta ESG não fornecidos.");


        return Ok("Endpoint para criar MeaEsg ainda não implementado.");
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetMeaEsg()
    {
        var metas = _jogodbcontext.MetaEsg.ToList();
        return Ok(metas);
    }

    [Authorize]
    [HttpPut("{id}")]
    [ValidateAntiForgeryToken]  
    public IActionResult AtualizarMeaEsg([FromBody] MetaEsgModel meta)
    {
        var metaExistente = _jogodbcontext.MetaEsg.Find(meta.IdMetaEsg);
        if (metaExistente == null)
        {
            return NotFound("Meta ESG não encontrada.");
        }
        metaExistente.DescricaoMetaEsg = meta.DescricaoMetaEsg;
        metaExistente.PrazoMetaEsg = meta.PrazoMetaEsg;
        metaExistente.TipoMetaEsg = meta.TipoMetaEsg;
        metaExistente.Empresa = meta.Empresa;
        _jogodbcontext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeleteMeaEsg(int id)
    {
        var metaExistente = _jogodbcontext.MetaEsg.Find(id);
        if (metaExistente == null)
        {
            return NotFound("Meta ESG não encontrada.");
        }
        _jogodbcontext.MetaEsg.Remove(metaExistente);
        _jogodbcontext.SaveChanges();
        return NoContent();
    }
}
