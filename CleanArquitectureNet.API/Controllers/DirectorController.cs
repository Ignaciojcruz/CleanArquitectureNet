using CleanArquitectureNet.Application.Features.Directors.Commands.CreateDirector;
using CleanArquitectureNet.Application.Features.Directors.Commands.DeleteDirector;
using CleanArquitectureNet.Application.Features.Directors.Commands.UpdateDirector;
using CleanArquitectureNet.Application.Features.Directors.Queries.GetDirectorsList;
using CleanArquitectureNet.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArquitectureNet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DirectorController : ControllerBase
    {
        private IMediator _mediator;

        public DirectorController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet(Name = "GetDirectors")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<DirectorsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DirectorsVm>>> GetDirectors()
        {
            var query = new GetDirectorsListQuery();

            var directors = await _mediator.Send(query);

            return Ok(directors);
        }

        [HttpGet("{name}", Name = "GetDirectorsByName")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<DirectorsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DirectorsVm>>> GetDirectorsByName(string name)
        {
            var query = new GetDirectorsListQuery();

            var directors = await _mediator.Send(query);

            var directorsByname = directors.Where(d => d.Nombre!.ToUpper().Contains(name.ToUpper()));

            return Ok(directorsByname);
        }

        [HttpPost(Name ="CreateDirector")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateDirector([FromBody] CreateDirectorCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateDirector")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateDirector([FromBody] UpdateDirectorCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteDirector")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrator")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            var command = new DeleteDirectorCommand { Id = id};

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
