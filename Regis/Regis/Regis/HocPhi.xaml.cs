using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Regis
{
    public partial class HocPhi : ContentPage
    {
        string u = null;
        string p = null;
        public HocPhi()
        {
            InitializeComponent();
            u = (Application.Current as App).User;
            p = (Application.Current as App).Pass;
            Test();
        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.2:8080//hocphi.php");
            var t = JsonConvert.DeserializeObject<List<HocPhi_DTO>>(r);

            List<String> MMH = new List<String>();
            List<String> TMH = new List<String>();
            List<String> SOTINCHI = new List<String>();
            List<String> SOTIEN = new List<String>();

            List<String> MT = new List<String>();
            List<String> ST = new List<String>();

            foreach (HocPhi_DTO hp in t)
            {
                SOTINCHI.Add(hp.SoTinChi);
                SOTIEN.Add(hp.SoTien);

                MT.Add(hp.MaMonHoc + " - " + hp.TenMonHoc);
                ST.Add("Số Tín Chỉ: " + hp.SoTinChi + " - $ " + hp.SoTien + " vnđ");
            }
            
            int c = 0;
            double vl = 0;
            List<HocPhi_DTO> s = new List<HocPhi_DTO>();
            if (MT.Count > 0)
            {
                Label[] lbMMH = new Label[MT.Count];
                Label[] lbTMH = new Label[MT.Count];
                Label[] lbSTC = new Label[MT.Count];
                Label[] lbST = new Label[MT.Count];

                Label[] txtMT = new Label[MT.Count];
                Label[] txtST = new Label[MT.Count];
                string k = "";
                for (int i = 0; i < MT.Count; i++)
                {
                    string e = "";
                    lbTMH[i] = new Label();
                    lbMMH[i] = new Label();
                    lbSTC[i] = new Label();
                    lbST[i] = new Label();
                    txtMT[i] = new Label();
                    txtST[i] = new Label();

                    lbSTC[i].Text = SOTINCHI[i].ToString();
                    lbST[i].Text = SOTIEN[i].ToString();
                    txtMT[i].Text = MT[i].ToString();
                    txtST[i].Text = ST[i].ToString();
                    /*
                    string f = "Cái gì thế này";
                    string[] slipt = f.Split(new char[] {' '});
                    for(int q = 0; q < slipt.Length-1; q++)
                    {
                        e = slipt[i].ToString();
                    }
                    k += e;
                    int g = Int32.Parse(SOTINCHI[i].ToString());
                    //double v = double.Parse(e.ToString());
                    c = c + g;
                    //vl = vl + v;
                    */
                    s.Add(new HocPhi_DTO()
                    {
                        MaTen = MT[i].ToString(),
                        Tien = ST[i].ToString(),
                    });
                    lstTKB.ItemsSource = s;
                }
                //txtTongChi.Text = "Tổng Số Tín Chỉ: " + c.ToString();
                //txtTongTien.Text = "Tổng Số Tiền HP: " + k;
            }
            else
            {
                s.Add(new HocPhi_DTO()
                {
                    MaTen = "Chưa Có Lịch Học Phí",
                });
                lstTKB.ItemsSource = s;
            }
            txtLoang.Text = "";
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
