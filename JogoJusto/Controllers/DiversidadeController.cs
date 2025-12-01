using JogoJusto.DTO;
using JogoJusto.Pagination;
using JogoJusto.Service;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers
{
    [ApiController]
    [Route("api/diversidade")]
    public class DiversidadeController : ControllerBase
    {
        private readonly IDiversidadeService _service;

        public DiversidadeController(IDiversidadeService service)
        {
            _service = service;
        }

        [HttpGet("indicadores")]
        public async Task<ActionResult<DiversidadeDTO>> GetIndicadores([FromQuery] QueryParameters qp)
        {
            try
            {
                var result = await _service.GerarIndicadoresAsync(qp.PageNumber, qp.PageSize);

                string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";

                var deptos = result.Departamentos;

                deptos.NextPage =
                    (qp.PageNumber * qp.PageSize < deptos.TotalCount)
                    ? $"{baseUrl}?pageNumber={qp.PageNumber + 1}&pageSize={qp.PageSize}"
                    : null;

                deptos.PreviousPage =
                    qp.PageNumber > 1
                    ? $"{baseUrl}?pageNumber={qp.PageNumber - 1}&pageSize={qp.PageSize}"
                    : null;

                Response.Headers.Add("X-Total-Count", deptos.TotalCount.ToString());

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
