using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.ViewModels
{
    public class ResponseVM
    {
        public bool flag { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }

        public dynamic response { get; set; }

        public ResponseVM(dynamic Data, string Message, bool Flag, int StatusCode)
        {
            flag = Flag;
            status_code = StatusCode;
            message = Message;
            response = Data;
        }
    }
}
