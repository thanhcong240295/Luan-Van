using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    class TaiKhoan_DTO
    {
        [JsonProperty("TT")]
        public string ThongTin { get; set; }

        [JsonProperty("CN")]
        public string ChucNang { get; set; }

        public string TN { get; set; }
        public string NT { get; set; }

    }
}
