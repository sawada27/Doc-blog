  public class AjaxResponse<T> : AjaxResponseBase
    {
        public AjaxResponse(T data){
            Data = data;
            Success = true;
        }

        public AjaxResponse(bool success)
        {
            Success = success;
        }

        public AjaxResponse(ErrorInfo errorInfo)
        {
            Success = false;
            ErrorInfo = errorInfo;
        }

        public AjaxResponse(bool success,int code)
        {
            Success = success;
            StatusCode = code;
        }

        public T Data { get; set; }

        public ErrorInfo ErrorInfo { get; set; }
    }


    public abstract class AjaxResponseBase
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
    }

    [Serializable]
    public class ErrorInfo
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ErrorInfo(string message)
        {
            Message = message;
        }
        public ErrorInfo(int code)
        {
            Code = code;
        }
        public ErrorInfo(int code, string message)
            : this(message)
        {
            Code = code;
            Message = message;
        }
    }
