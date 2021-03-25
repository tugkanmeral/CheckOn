using Microsoft.AspNetCore.Http;
using Phoenix.Aspects.Logging;
using Phoenix.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Utils.HttpRequest
{
    public class ErrorResponse<T> : ResponseBase<T>
    {
        public override bool IsSuccess => false;

        public ErrorResponse(int statusCode, T obj, string message)
        {
            StatusCode = statusCode;
            Obj = obj;
            Message = message;
        }

        public ErrorResponse(string message, int statusCode = StatusCodes.Status400BadRequest)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
