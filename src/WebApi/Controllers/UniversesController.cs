using System.Threading.Tasks;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UniversesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UniversesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("time")]
        public async Task<IActionResult> GetCurrentTime()
        {
            var query = new GetCurrentTime.Query();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}