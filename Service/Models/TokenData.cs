using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models
{
    public class TokenData
    {
        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
