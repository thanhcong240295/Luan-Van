using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    public class XemDiem_DTO
    {
        [JsonProperty("MMH")]
        public string MaMonHoc { get; set; }
        [JsonProperty("TenMH")]
        public string TenMonHoc { get; set; }
        [JsonProperty("STC")]
        public string SoTinChi { get; set; }
        [JsonProperty("DKT")]
        public string DiemKiemTra { get; set; }
        [JsonProperty("THI1")]
        public string ThiLan1 { get; set; }
        [JsonProperty("THI2")]
        public string ThiLan2 { get; set; }
        [JsonProperty("TK10")]
        public string HeSo10 { get; set; }
        [JsonProperty("TKCH")]
        public string HeSo4 { get; set; }

        public string MaTen { get; set; }
        public string Diem { get; set; }
    }
}
