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
        public Login()
        {
            InitializeComponent();
            Login_DTO lg = new Login_DTO();
            Test();
        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.5:8080//dangnhap.php");
            string s = r.Replace("\t", string.Empty);
            dangnhap.Clicked += (sender, e) =>
            {
                if (s != "")
                {
                    Navigation.PushAsync(new Home());
                }
                else
                {
                    DisplayAlert("Thông Báo", "MSSV hoặc Mật Khẩu Không Đúng", "OK");
                }
            };
        }
        static async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}
