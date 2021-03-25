using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Utils.HttpRequest
{
    public class SuccessResponse<T> : ResponseBase<T>
    {
        public override bool IsSuccess => true;
        public SuccessResponse(int statusCode, T obj, string message)
        {
            StatusCode = statusCode;
            Obj = obj;
            Message = message;
        }

        public SuccessResponse(T obj, int statusCode = StatusCodes.Status200OK)
        {
            StatusCode = statusCode;
            Obj = obj;
        }
    }
}
