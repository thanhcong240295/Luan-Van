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
            //Test();
            dangnhap.Clicked += (sender, e) =>
            {
                    Navigation.PushAsync(new Home());
            };

        }
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.5:8080//dangnhap.php");
            dangnhap.Clicked += (sender, e) =>
            {
                if (r != null)
                {
                    Navigation.PushAsync(new Home());
                }
                else
                {
                    txtErro.Text = "Đăng Nhập Thất Bại";
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
