namespace ProjectManagement.Shared.Models.Bases
{
    public class BaseResponse<T>
    {
        public bool Success => Error.Count == 0;

        public List<string> Error { get; set; } = new();

        public T Result { get; set; }

        public BaseResponse()
        {

        }

        public BaseResponse(T data)
        {
            Result = data;
        }
    }
}
