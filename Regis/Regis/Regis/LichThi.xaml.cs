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
    public partial class LichThi : ContentPage
    {
        int Day = DateTime.Now.Day;
        int Month = DateTime.Now.Month;
        int Year = DateTime.Now.Year;
        public LichThi()
        {
            InitializeComponent();
            Test();
        }
        async void Test()
        {
            List<String> MMH = new List<String>();
            List<String> TMH = new List<String>();
            List<String> PHONG = new List<String>();
            List<String> NGAY = new List<String>();
            List<String> BD = new List<String>();
            List<String> KT = new List<String>();

            List<String> MT = new List<String>();
            List<String> N = new List<String>();
            List<String> TG = new List<String>();
            List<String> P = new List<String>();

            var r = await DownloadPage("http://192.168.1.5:8080//lichthi.php");
            var t = JsonConvert.DeserializeObject<List<LichThi_DTO>>(r);
            foreach (LichThi_DTO lt in t)
            {
                MMH.Add(lt.MaMonHoc);
                TMH.Add(lt.TenMonHoc);
                PHONG.Add(lt.PhongHoc);
                NGAY.Add(lt.NgayThi);

                string a = null;
                if (lt.TietBD == "1")
                {
                    a = "7:00";
                }

                if (lt.TietBD == "2")
                {
                    a = "7:50";
                }
                if (lt.TietBD == "3")
                {
                    a = "8:50";
                }
                if (lt.TietBD == "4")
                {
                    a = "9:40";
                }
                if (lt.TietBD == "5")
                {
                    a = "10:35";
                }
                if (lt.TietBD == "6")
                {
                    a = "13:00";
                }
                if (lt.TietBD == "7")
                {
                    a = "13:50";
                }
                if (lt.TietBD == "8")
                {
                    a = "14:50";
                }
                if (lt.TietBD == "9")
                {
                    a = "15:35";
                }
                if (lt.TietBD == "10")
                {
                    a = "14:35";
                }

               

                MT.Add(lt.MaMonHoc + " - " + lt.TenMonHoc);
                N.Add("Ngày: " + lt.NgayThi);
                TG.Add("Tiết: " + lt.TietBD + "; Số Tiết: " + lt.SoTiet + ";" + "Bắt Đầu Lúc: " + a);
                P.Add("Tại Phòng: " + lt.PhongHoc);
            }
            List<LichThi_DTO> s = new List<LichThi_DTO>();
            if (MMH.Count > 0)
            {
                Label[] lbMMH = new Label[MMH.Count];
                Label[] lbTMH = new Label[MMH.Count];
                Label[] lbPHONG = new Label[MMH.Count];
                Label[] lbNGAY = new Label[MMH.Count];
                Label[] txtMaTen = new Label[MMH.Count];
                Label[] txtThoiGian = new Label[MMH.Count];
                Label[] txtPhong = new Label[MMH.Count];
                Label[] txtNgay = new Label[MMH.Count];

                for (int i = 0; i < MMH.Count; i++)
                {

                    lbTMH[i] = new Label();
                    lbMMH[i] = new Label();
                    lbPHONG[i] = new Label();
                    lbNGAY[i] = new Label();
                    txtMaTen[i] = new Label();
                    txtThoiGian[i] = new Label();
                    txtPhong[i] = new Label();
                    txtNgay[i] = new Label();

                    lbMMH[i].Text = MMH[i].ToString();
                    lbTMH[i].Text = TMH[i].ToString();
                    lbPHONG[i].Text = PHONG[i].ToString();
                    lbNGAY[i].Text = NGAY[i].ToString();
                    txtMaTen[i].Text = MT[i].ToString();
                    txtThoiGian[i].Text = TG[i].ToString();
                    txtPhong[i].Text = P[i].ToString();
                    txtNgay[i].Text = N[i].ToString();

                    s.Add(new LichThi_DTO()
                    {
                        Ngay = N[i].ToString(),
                        MaTen = MT[i].ToString(),
                        ThoiGian = TG[i].ToString(),
                        PhongH = P[i].ToString()
                    });
                    lstTKB.ItemsSource = s;
                }
            }
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
