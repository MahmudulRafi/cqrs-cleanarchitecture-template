using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs.Response
{
    public class ServiceResponse
    {
        public dynamic? Data { get; set; }
        public bool? IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public int? StatusCode { get; set; }

        public void SetSuccess()
        {
            IsSuccessful = true;
        }

        public void SetSuccess(dynamic data)
        {
            Data = data;
            IsSuccessful = true;
            StatusCode = 200;   
        }

        public void SetError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccessful = false;
            StatusCode = 500;
        }

        public void SetValidationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccessful = false;
            StatusCode = 400;
        }
    }
}
