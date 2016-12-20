using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    class HocPhi_DTO
    {
        [JsonProperty("MMH")]
        public string MaMonHoc { get; set; }

        [JsonProperty("TenMH")]
        public string TenMonHoc { get; set; }

        [JsonProperty("STC")]
        public string SoTinChi { get; set; }

        [JsonProperty("SoTien")]
        public string SoTien { get; set; }
        public string MaTen { get; set; }
        public string Tien { get; set; }
    }
}
