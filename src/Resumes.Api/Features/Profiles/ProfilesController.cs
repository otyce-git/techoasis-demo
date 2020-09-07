using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resumes.Api.Helpers;
using Resumes.Api.Models;

namespace Resumes.Api.Features.Profiles
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] RequestParams requestParams)
        {
            var profiles = await  _mediator.Send(new GetProfiles { Params = requestParams });
            Response.AddPagination(profiles.CurrentPage, profiles.PageSize,
                profiles.TotalCount, profiles.TotalPages);

            return Ok(profiles);
        }

    }
}