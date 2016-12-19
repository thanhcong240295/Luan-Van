using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    public class ThoiKhoaBieu_DTO
    {
        [JsonProperty("MMH")]
        public string MaMonHoc { get; set; }

        [JsonProperty("TenMH")]
        public string TenMonHoc { get; set; }

        [JsonProperty("NMH")]
        public string NhomMonHoc { get; set; }

        [JsonProperty("STC")]
        public string SoTinChi { get; set; }

        [JsonProperty("NTH")]
        public string NhomThucHanh { get; set; }

        [JsonProperty("Phong")]
        public string PhongHoc { get; set; }

        [JsonProperty("batDau")]
        public string BatDau { get; set; }

        [JsonProperty("ketThuc")]
        public string KetThuc { get; set; }

        [JsonProperty("dates")]
        public List<string> NgayHoc { get; set; }

        public string MaTen { get; set; }
        public string ThoiGian { get; set; }
        public string PhongH { get; set; }
    }
}
