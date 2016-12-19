using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    class ChuongTrinhDaoTao_DTO
    {
        [JsonProperty("MMH")]
        public string MaMonHoc { get; set; }

        [JsonProperty("TenMH")]
        public string TenMonHoc { get; set; }
        [JsonProperty("STC")]
        public string SoTinChi { get; set; }
        [JsonProperty("NDH")]
        public string NamHoc { get; set; }
        [JsonProperty("DDH")]
        public string DaHoc { get; set; }
    }
}
