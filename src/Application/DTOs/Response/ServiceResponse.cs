using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class ServiceResponse
    {
        public dynamic? Data { get; set; }
        public bool? IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }

        public void SetSuccess()
        {
            IsSuccessful = true;
        }

        public void SetSuccess(dynamic data)
        {
            Data = data;
            IsSuccessful = true;
        }

        public void SetError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccessful = false;
        }
    }
}
