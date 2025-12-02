using JogoJusto.Atributtes;
using JogoJusto.Pagination;
using JogoJusto.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/esglog")]
public class EsgLogController : ControllerBase
{
    private readonly IEsgLogService _esglogservice;


    public EsgLogController(IEsgLogService esglogservice)
    {
        _esglogservice = esglogservice;
    }

    [HttpGet]
    [Authorize]
    [RoleAuthorize("Admin")]
    public async Task<IActionResult> GetEsgLogs([FromQuery] QueryParameters qp)
    {
        var result = await _esglogservice.GetEsgLogsAsync(qp.PageNumber, qp.PageSize);

        string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";

        result.NextPage =
            (qp.PageNumber * qp.PageSize < result.TotalCount)
                ? $"{baseUrl}?pageNumber={qp.PageNumber + 1}&pageSize={qp.PageSize}"
                : null;

        result.PreviousPage =
            qp.PageNumber > 1
                ? $"{baseUrl}?pageNumber={qp.PageNumber - 1}&pageSize={qp.PageSize}"
                : null;

        Response.Headers.Add("X-Total-Count", result.TotalCount.ToString());

        return Ok(result);
    }
}
