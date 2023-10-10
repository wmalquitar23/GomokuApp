namespace GomokuApp.Common.Exceptions
{
    public class ApiException : Exception
    { 
        public int Status { get; set; }
        public ApiException(int status, string message) : base(message)
        {
            Status = status;
        }
    }
}
