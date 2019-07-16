using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApi.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApi.Domain.Authirs
{
    public class AuthorsController : JsonApiController<Author>
    {
        public AuthorsController(
            IJsonApiContext jsonApiContext,
            IResourceService<Author> resourceService,
            ILoggerFactory loggerFactory
        ) : base(jsonApiContext, resourceService, loggerFactory)
        {

        }
    }
}