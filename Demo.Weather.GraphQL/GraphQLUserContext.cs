using System.Security.Claims;

namespace Demo.Weather.GraphQL
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
