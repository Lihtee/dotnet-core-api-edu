namespace LibraryApi.Domain.Authors
{
    using System.Linq;
    using JsonApiDotNetCore.Data;
    using JsonApiDotNetCore.Internal.Query;
    using JsonApiDotNetCore.Models;
    using JsonApiDotNetCore.Services;
    using LibraryApi.Models;
    using Microsoft.Extensions.Logging;

    public class AuthorsRepository : DefaultEntityRepository<Author>
    {
        public AuthorsRepository(
            ILoggerFactory loggerFactory, 
            IJsonApiContext jsonApiContext, 
            IDbContextResolver contextResolver, 
            ResourceDefinition<Author> resourceDefinition = null
            ) : base(loggerFactory, jsonApiContext, contextResolver, resourceDefinition)
        {

        }

        public override IQueryable<Author> Filter(IQueryable<Author> authors, FilterQuery filterQuery)
        {
            if (filterQuery.Attribute.Equals("query")){
                return authors.Where(a => 
                a.First.Contains(filterQuery.Value, System.StringComparison.OrdinalIgnoreCase)
                || a.Last.Contains(filterQuery.Value, System.StringComparison.OrdinalIgnoreCase));
            }

            return base.Filter(authors, filterQuery);
        }
    }
}