
namespace SnippetRepository.Web.Services
{
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the SnippetRepositoryModelContainer context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess]
    public class SnippetRepositoryDomainService : LinqToEntitiesDomainService<SnippetRepositoryModelContainer>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Snippets' query.
        [Query(IsDefault = true)]
        public IQueryable<Snippet> GetSnippets()
        {
            return ObjectContext.Snippets.OrderByDescending(s=>s.DateAdded);
        }

        public IQueryable<Snippet> GetSnippetsByTag(string tag)
        {
            return ObjectContext.Snippets.Where(s=>s.Tags.Contains(tag)).OrderByDescending(s => s.DateAdded);
        }


        public void InsertSnippet(Snippet snippet)
        {
            if ((snippet.EntityState != EntityState.Detached))
            {
                ObjectContext.ObjectStateManager.ChangeObjectState(snippet, EntityState.Added);
            }
            else
            {
                ObjectContext.Snippets.AddObject(snippet);
            }
        }

        public void UpdateSnippet(Snippet currentSnippet)
        {
            ObjectContext.Snippets.AttachAsModified(currentSnippet, ChangeSet.GetOriginal(currentSnippet));
        }

        public void DeleteSnippet(Snippet snippet)
        {
            if ((snippet.EntityState == EntityState.Detached))
            {
                ObjectContext.Snippets.Attach(snippet);
            }
            ObjectContext.Snippets.DeleteObject(snippet);
        }
    }
}


