using Demo.Shared.Database;
using Demo.Shared.Entities;

namespace Demo.Weather.HotChocolate.GraphQL.GraphQL
{
    /***************************************************************************************
     * The query type in GraphQL represents a read-only view of all of our entities 
     * and ways to retrieve them. A query type is required for every GraphQL server.
     * 
     * A query type can be defined in three ways:
     * - Annotation-based or Pure Code-First (following example):
     *   In this approach, we don't bother about GraphQL schema types, we will just 
     *   write clean C# code that automatically translates to GraphQL types.
     * - Code-first
     *   In this approach, we use Schema types, Schema types allow us to keep the GraphQL 
     *   type configuration separate from our .NET types. This can be the right approach 
     *   when we do not want any Hot Chocolate attributes on our business objects.
     * - Schema-first
     ***************************************************************************************/
    public class Query
    {
        /* To lean more about DbContext injection:         * 
         * https://chillicream.com/docs/hotchocolate/v13/integrations/entity-framework
         */

        //public async Task<List<Product>> GetProductsAsync([Service(ServiceKind.Synchronized)] ProductDbContext context)
        //    => await context.Products.ToListAsync();

        //public async Task<Product?> GetProductByNameAsync([Service(ServiceKind.Synchronized)] ProductDbContext context, string name)
        //    => await context.Products.FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        //[UseDbContext(typeof(BlogDbContext))]
        public IQueryable<Author> GetAuthors(BlogDbContext context)
        {
            return context.Authors;
        }

        // [UsePaging]
        // [UseSorting]
        public IQueryable<Post> GetPosts(BlogDbContext context)
        {
            return context.Posts;
        }

        //[UseDbContext(typeof(BlogDbContext))]
        public IQueryable<Comment> GetComments(BlogDbContext context)
        {
            return context.Comments;
        }
    }
}
