using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ServerUrl
    {
        public string Protocol { get; set; }

        public string Domain { get; set; }

        public string Port { get; set; }

        public string Subfix { get; set; }
    }
}
