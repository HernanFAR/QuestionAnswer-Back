using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class SendGridConfiguration
    {
        public string ApiKey { get; set; }

        public string From { get; set; }
    }
}
