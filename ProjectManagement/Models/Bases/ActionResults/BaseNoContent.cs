using System.Net;

namespace ProjectManagement.Server.Models.Bases.ActionResults
{
    public class BaseNoContent : BaseActionResult
    {
        public BaseNoContent() { }

        public BaseNoContent(string err)
            : base(err) { }

        public BaseNoContent(object value)
            : base(value) { }

        public BaseNoContent(object value, string err)
            : base(value, err) { }
        
        protected override HttpStatusCode ReturnStatusCode => HttpStatusCode.NoContent;

        protected override string ErrorMessage => null;
    }
}
