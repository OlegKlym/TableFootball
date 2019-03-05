using System;
namespace TableFootball.Models.Responces
{
    public class BaseResponce
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public BaseResponce(string error = null)
        {
            Success = error == null;
            Error = error;
        }
    }
}
