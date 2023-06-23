using System.Net;

namespace ProjectManagement.Server.Models.Bases.ActionResults
{
    public class BaseNotFound : BaseActionResult
    {
        public BaseNotFound() { }
       
        public BaseNotFound(string err)
            : base(err) { }

        public BaseNotFound(object value)
            : base(value) { }

        public BaseNotFound(object value, string err)
            : base(value, err) { }

        protected override HttpStatusCode ReturnStatusCode => HttpStatusCode.NotFound;
        
        protected override string ErrorMessage => "Объект или вызываемый метод не найден.";
    }
}
