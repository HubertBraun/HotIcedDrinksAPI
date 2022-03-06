using System;

namespace Company.API.HotIcedDrinksAPI.Models.BusinessModels
{
    public class StatusCodesContainer<T> where T : Enum
    {
        public T StatusCode { get; set; }
        public string Message { get; set; }
    }
}
