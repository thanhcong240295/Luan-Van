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
    public partial class XemDiem : ContentPage
    {
        string u = null;
        string p = null;
        public XemDiem()
        {
            InitializeComponent();
            u = (Application.Current as App).User;
            p = (Application.Current as App).Pass;
            Test();
        }
        async void Test()
        {
            List<String> MMH = new List<String>();
            List<String> TMH = new List<String>();
            List<String> STC = new List<String>();
            List<String> KT = new List<String>();
            List<String> THI1 = new List<String>();
            List<String> THI2 = new List<String>();
            List<String> TK10 = new List<String>();
            List<String> TK4 = new List<String>();

            List<String> MT = new List<String>();
            List<String> D = new List<String>();

            var r = await DownloadPage("http://192.168.1.2:8080/xemdiem.php");
            var t = JsonConvert.DeserializeObject<List<XemDiem_DTO>>(r);

            foreach(XemDiem_DTO d in t)
            {
                MMH.Add(d.MaMonHoc);
                TMH.Add(d.TenMonHoc);
                STC.Add(d.SoTinChi);
                KT.Add(d.DiemKiemTra);
                THI1.Add(d.ThiLan1);
                THI2.Add(d.ThiLan2);
                TK10.Add(d.HeSo10);
                TK4.Add(d.HeSo4);

                MT.Add(d.MaMonHoc + " - " + d.TenMonHoc);
                D.Add("Thi Lần 1: " + d.ThiLan1 + " - Thi Lần 2: " + d.ThiLan2 + " - Hệ 10: " + d.HeSo10 + " - Hệ 4: " + d.HeSo4);
            }
            List<XemDiem_DTO> xd = new List<XemDiem_DTO>();
            if (MMH.Count > 0)
            {
                Label[] lbMMH = new Label[MMH.Count];
                Label[] lbTMH = new Label[MMH.Count];
                Label[] lbSTC = new Label[MMH.Count];
                Label[] lbKT = new Label[MMH.Count];
                Label[] lbT1 = new Label[MMH.Count];
                Label[] lbT2 = new Label[MMH.Count];
                Label[] lbTK10 = new Label[MMH.Count];
                Label[] lbTK4 = new Label[MMH.Count];

                for (int i = 0; i < MMH.Count; i++)
                {
                    xd.Add(new XemDiem_DTO()
                    {
                        MaTen = MT[i].ToString(),
                        Diem = D[i].ToString()
                    });
                }
                lstTKB.ItemsSource = xd;
            }
            txtloading.Text = "";
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
    }
}
