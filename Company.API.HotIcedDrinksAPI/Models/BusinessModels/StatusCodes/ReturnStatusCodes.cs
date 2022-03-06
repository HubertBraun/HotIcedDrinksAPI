namespace Company.API.HotIcedDrinksAPI.Models.BusinessModels
{
    public class ReturnStatusCodes
    {
        public enum DeleteStatusCode
        {
            OK,
            NotFound,
            Error,
        }
        public enum UpdateStatusCode
        {
            OK,
            NotFound,
            Error,
        }
        public enum InsertStatusCode
        {
            OK,
            Conflict,
            Error,
        }
    }
}
