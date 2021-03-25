using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Utils.HttpRequest
{
    public class ResponseBase<T>
    {
        public T Obj { get; internal set; }
        public int StatusCode { get; internal set; }
        public virtual bool IsSuccess { get; }
        public string Message { get; internal set; } = String.Empty;
    }
}
