using GomokuApp.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GomokuApp.Common.Response
{
    public class JsonOutput
    {
        private ApiException? ex = null;

        [JsonIgnore]
        public ApiException? Exception 
        { 
            get { return ex; } 
            set { 
                ex = value; 
                if (value != null)
                    message = ex.Message; 
                success = ex == null; 
            } 
        }

        public bool success { get; set; } = true;
        public string message { get; set; } = "";
        public virtual object? result { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class JsonActionResult<T> : IActionResult where T : JsonOutput
    {
        private readonly T _result;

        public JsonActionResult(T result)
        {
            _result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result)
            {
                StatusCode = _result.Exception != null
                    ? _result.Exception.Status
                    : StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
