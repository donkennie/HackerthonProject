namespace HackerthonProject.Core
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null, bool isSuccessful = false)
        {
            StatusCode = statusCode;
            Message = message;
            IsSuccessful = isSuccessful;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }


    }
}
