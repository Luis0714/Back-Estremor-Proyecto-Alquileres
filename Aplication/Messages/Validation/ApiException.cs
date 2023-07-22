using System.Globalization;

namespace Application.Execteptions.Validation
{
    public class ApiException : Exception
    {
      
        public ApiException(): base() 
        {
        }
        public ApiException(string message) : base(message)
        {

        }

        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture,message,args))
        {
            
        }
    }
}
