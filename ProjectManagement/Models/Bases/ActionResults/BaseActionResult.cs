using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Shared.Models.Bases;
using System.Net;

namespace ProjectManagement.Server.Models.Bases.ActionResults
{
    public abstract class BaseActionResult : ActionResult
    {
        private readonly string _err;

        private readonly object _value;

        protected BaseActionResult()
        {

        }

        protected BaseActionResult(string err)
        {
            _err = err;
        }

        protected BaseActionResult(object value)
        {
            _value = value;
        }

        protected BaseActionResult(object value, string err)
        {
            _value = value;
            _err = err;
        }

        protected abstract HttpStatusCode ReturnStatusCode { get; }

        protected abstract string ErrorMessage { get; }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)ReturnStatusCode;
            await Write(context);

        }

        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)ReturnStatusCode;
            Task.Run(async () => await Write(context)).Wait();
        }

        private async Task Write(ActionContext context)
        {
            var ret = new BaseResponse<object>(_value);
            if ((_err) != null)
                ret.Error.Add($"{_err}");

            if (ReturnStatusCode !=
                HttpStatusCode.NoContent) //it is not allowed to write in body with HttpStatusCode=NoContent
                await context.HttpContext.Response.WriteAsJsonAsync(ret);
        }
    }
}
