using System.Net;

namespace ProjectManagement.Server.Models.Bases.ActionResults
{
    public class BaseBadRequest : BaseActionResult
    {
        public BaseBadRequest() { }
        
        public BaseBadRequest(string err)
            : base(err) { }

        public BaseBadRequest(object value)
            : base(value) { }

        public BaseBadRequest(object value, string err)
            : base(value, err) { }

        protected override HttpStatusCode ReturnStatusCode => HttpStatusCode.BadRequest;
        
        protected override string ErrorMessage => "Bad request occured";
    }
}
