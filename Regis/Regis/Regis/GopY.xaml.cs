using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Regis
{
    public partial class GopY : ContentPage
    {
        string u = null;
        string p = null;
        public GopY()
        {
            InitializeComponent();
            u = (Application.Current as App).User;
            p = (Application.Current as App).Pass;
            btnLamMoi.Clicked += (sender, e) =>
            {
                txtChuDe.Text = null;
                txtNoiDung.Text = null;
            };
            btnGui.Clicked += (sender, e) =>
            {
                txtThongBao.Text = "Đang Gửi Thông Tin";
                txtChuDe.IsEnabled = false;
                txtNoiDung.IsEnabled = false;
                btnGui.IsEnabled = false;
                btnLamMoi.IsEnabled = false;
                Test();
                
            };
        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.2:8080//gopy.php");
            string s = r.Replace("\t", string.Empty);
            txtThongBao.Text = "Đã Gửi Xong";
            txtChuDe.IsEnabled = true;
            txtNoiDung.IsEnabled = true;
            txtChuDe.Text = null;
            txtNoiDung.Text = null;
            btnGui.IsEnabled = true;
            btnLamMoi.IsEnabled = true;
        }
        async Task<string> DownloadPage(string url)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("_user", u),
                new KeyValuePair<string, string>("_pass", p),
                new KeyValuePair<string, string>("_chude", txtChuDe.Text),
                new KeyValuePair<string, string>("_noidung", txtNoiDung.Text)
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
