using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Xml.Dom;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Regis
{
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();
            Test();
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
        async void Test()
        {
            var r = await DownloadPage("http://192.168.1.2:8080//thongbao.php");
            var t = JsonConvert.DeserializeObject<List<News_DTO>>(r);
            List<String> TD = new List<String>();
            List<String> ND = new List<String>();
            foreach (News_DTO n in t)
            {
                TD.Add(n.TieuDe);
                ND.Add(n.NoiDung);
                txtTieuDe.Text = TD[0].ToUpper();
                txtNoidung.Text = ND[0].ToString();
            }
        }
    }
}
