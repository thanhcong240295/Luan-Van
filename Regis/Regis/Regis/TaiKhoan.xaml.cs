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
    public partial class TaiKhoan : ContentPage
    {
        string u = null;
        string p = null;
        public TaiKhoan()
        {
            u = (Application.Current as App).User;
            p = (Application.Current as App).Pass;
            InitializeComponent();
            Test();
        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.2:8080//taikhoan.php");
            var t = JsonConvert.DeserializeObject<List<TaiKhoan_DTO>>(r);
            List<String> TC = new List<String>();
            List<String> CT = new List<String>();
            foreach (TaiKhoan_DTO tk in t)
            {
                TC.Add(tk.ThongTin + ":");
                CT.Add(tk.ChucNang);
            }

            List<TaiKhoan_DTO> s = new List<TaiKhoan_DTO>();
            if (TC.Count > 0)
            {
                for(int i = 0; i < TC.Count; i++)
                {
                    s.Add(new TaiKhoan_DTO()
                    {
                        TN = TC[i].ToUpper(),
                        NT = CT[i].ToString()
                    });
                    lstTKB.ItemsSource = s;
                }
            }
            txtLoading.Text = "";
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
