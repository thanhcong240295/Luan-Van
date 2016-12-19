using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regis
{
    class LichThi_DTO
    {
        [JsonProperty("MMH")]
        public string MaMonHoc { get; set; }

        [JsonProperty("TenMH")]
        public string TenMonHoc { get; set; }

        [JsonProperty("PhongThi")]
        public string PhongHoc { get; set; }

        [JsonProperty("NgayThi")]
        public string NgayThi { get; set; }

        [JsonProperty("TietBD")]
        public string TietBD { get; set; }

        [JsonProperty("SoTiet")]
        public string SoTiet { get; set; }

        public string MaTen { get; set; }
        public string Ngay { get; set; }
        public string ThoiGian { get; set; }
        public string PhongH { get; set; }
    }
}
