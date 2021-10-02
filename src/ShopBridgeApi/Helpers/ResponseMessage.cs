using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Helpers
{
    public class ResponseMessage
    {
        public const string Success = "Success";
        public const string Error = "Error";
        public const string Exist = "Already Exist";
        public const string SuccessOtp = "Otp Sent Successfully";
        public const string EmailNotFound = "Email Id Not Found";
    }
}
