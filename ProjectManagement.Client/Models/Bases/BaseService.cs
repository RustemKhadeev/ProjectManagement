using ProjectManagement.Shared.Models.Bases;

namespace ProjectManagement.Client.Models.Bases
{
    public abstract class BaseService : BaseHttpService
    {
        protected BaseService(IHttpClientFactory clientFactory)
            : base(clientFactory.CreateClient("ProjectManagementServerAPI"))
        {
        }
    }
}
