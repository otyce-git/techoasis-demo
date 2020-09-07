
using System.Threading;
using MediatR;
using Resumes.Api.Models;
using System.Threading.Tasks;
using Resumes.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Resumes.Api.Helpers;

namespace Resumes.Api.Features.Profiles
{
    public class GetProfiles: IRequest<PagedList<Profile>>
    {
        public RequestParams Params { get; set; }

        public class GetProfilesHandler : IRequestHandler<GetProfiles, PagedList<Profile>>
        {

            private readonly ApplicationDbContext _context;

            public GetProfilesHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<PagedList<Profile>> Handle(GetProfiles request, CancellationToken cancellationToken)
            {
                var profiles = _context.Profiles;
                return await PagedList<Profile>.Create(profiles,
                    request.Params.PageNumber, request.Params.PageSize);
            }
        }
    }
}