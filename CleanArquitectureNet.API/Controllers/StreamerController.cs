﻿using CleanArquitectureNet.Application.Features.Directors.Queries.GetDirectorsList;
using CleanArquitectureNet.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArquitectureNet.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArquitectureNet.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArquitectureNet.Application.Features.Streamers.Queries.GetStreamersList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArquitectureNet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController : ControllerBase
    {
        private IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetStreamers")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<StreamersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StreamersVm>>> GetStreamers()
        {
            var query = new GetStreamersListQuery();

            var streamers = await _mediator.Send(query);

            return Ok(streamers);
        }

        [HttpPost(Name = "CreateStreamer")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteStreamer(int id)
        {
            var command = new DeleteStreamerCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }


    }
}
