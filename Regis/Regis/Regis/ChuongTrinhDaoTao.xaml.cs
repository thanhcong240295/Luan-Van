using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Regis
{
    public partial class ChuongTrinhDaoTao : ContentPage
    {
        string u = null;
        string p = null;
        public ChuongTrinhDaoTao()
        {
            InitializeComponent();
            u = (Application.Current as App).User;
            p = (Application.Current as App).Pass;
            Test();
        }
        async Task<string> DownloadPage(string url)
        {
            var comment = u;
            var questionId = p;

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("_user", comment),
                new KeyValuePair<string, string>("_pass", questionId)
            });
            using (var client = new HttpClient())
            {
                using (var r = await client.PostAsync(new Uri(url), formContent))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.2:8080//chuongtrinhdaotao.php");
            var t = JsonConvert.DeserializeObject<List<ChuongTrinhDaoTao_DTO>>(r);
            List<String> MMH = new List<String>();
            List<String> TMH = new List<String>();
            List<String> STC = new List<String>();
            List<String> NDH = new List<String>();
            List<String> DDH = new List<String>();
            foreach (ChuongTrinhDaoTao_DTO dt in t)
            {
                MMH.Add(dt.MaMonHoc);
                TMH.Add(dt.TenMonHoc);
                STC.Add(dt.SoTinChi);
                NDH.Add(dt.NamHoc);
                DDH.Add(dt.DaHoc);

                for(int i = 0; i < MMH.Count; i++)
                {
                    List<ChuongTrinhDaoTao_DTO> ctdt = new List<ChuongTrinhDaoTao_DTO>();
                    ctdt.Add(new ChuongTrinhDaoTao_DTO() { MaMonHoc = MMH[i].Replace("\r\n ", ""), TenMonHoc = TMH[i].Replace("\r\n " , ""), SoTinChi = STC[i].Replace("\r\n ", ""), NamHoc = NDH[i].Replace("\r\n ", ""), DaHoc = DDH[i].Replace("\r\n ", "") });
                    lstCTDT.ItemsSource = ctdt;
                }
            }
        }
    }
}
