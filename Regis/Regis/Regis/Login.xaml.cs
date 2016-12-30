using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Regis
{
    public partial class Login : ContentPage
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public Login()
        {
            InitializeComponent();
            dangnhap.Clicked += (sender, e) =>
            {
                (Application.Current as App).User = masinhvien.Text;
                (Application.Current as App).Pass = password.Text;
                Test();
            };
        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.2:8080/dangnhap.php");
            string s = r.Replace("\t", string.Empty);
            if (s != "")
            {
                await Navigation.PushAsync(new Home());
            }
            else
            {
                await DisplayAlert("Thông Báo", "MSSV hoặc Mật Khẩu Không Đúng", "OK");
            }
        }
        async Task<string> DownloadPage(string url)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("_user", masinhvien.Text),
                new KeyValuePair<string, string>("_pass", password.Text)
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
