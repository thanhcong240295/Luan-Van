using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    class News_DTO
    {
        [JsonProperty("TIEUDE")]
        public string TieuDe { get; set; }

        [JsonProperty("NOIDUNG")]
        public string NoiDung { get; set; }
    }
}
