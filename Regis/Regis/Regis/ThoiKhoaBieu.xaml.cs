using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Xamarin.Forms;
using LitJson;
using Java.Util;
using Android.OS;
using Android.Renderscripts;

namespace Regis
{
    public partial class ThoiKhoaBieu : ContentPage
    {
        DayOfWeek Thu = DateTime.Now.DayOfWeek;
        int Day = DateTime.Now.Day;
        int Month = DateTime.Now.Month;
        int Year = DateTime.Now.Year;
        string u = null;
        public ThoiKhoaBieu()
        {
            u = (Application.Current as App).User;
            string ngay, thang;
            InitializeComponent();
            txtThu.Text = Thu.ToString();
            if (Day < 10)
            {
                ngay = "0" + Day.ToString();
            }
            else
            {
                ngay = Day.ToString();
            }
            if (Month < 10)
            {
                thang = "0" + Month.ToString();
            }
            else
            {
                thang = Month.ToString();
            }
            txtNgay.Text = ngay + "-" + thang + "-" + Year.ToString();
            ThoiKhoaBieu_DTO tkb = new ThoiKhoaBieu_DTO();
            Test();

            btnTien.Clicked += (sender, e) =>
            {
                Thu += 1;
                if (Thu > DayOfWeek.Saturday)
                {
                    Thu = 0;
                }
                if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                {
                    if (Day < 31)
                    {
                        Day += 1;
                    }
                    else
                    {
                        Day = 1;
                        Month += 1;
                        if (Month > 12)
                        {
                            Month = 1;
                            Year += 1;
                        }
                    }
                }
                else if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                {
                    if (Day < 30)
                    {
                        Day += 1;
                    }
                    else
                    {
                        Day = 1;
                        Month += 1;
                        if (Month > 12)
                        {
                            Month = 1;
                            Year += 1;
                        }
                    }
                }
                else
                {
                    if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                    {
                        if (Day < 29)
                        {
                            Day += 1;
                        }
                        else
                        {
                            Day = 1;
                            Month += 1;
                            if (Month > 12)
                            {
                                Month = 1;
                                Year += 1;
                            }
                        }
                    }
                    else
                    {
                        if (Day < 28)
                        {
                            Day += 1;
                        }
                        else
                        {
                            Day = 1;
                            Month += 1;
                            if (Month > 12)
                            {
                                Month = 1;
                                Year += 1;
                            }
                        }
                    }
                }
                txtThu.Text = Thu.ToString();
                if (Day < 10)
                {
                    ngay = "0" + Day.ToString();
                }
                else
                {
                    ngay = Day.ToString();
                }
                if (Month < 10)
                {
                    thang = "0" + Month.ToString();
                }
                else
                {
                    thang = Month.ToString();
                }
                txtNgay.Text = ngay + "-" + thang + "-" + Year.ToString();
                Test();
            };

            btnLui.Clicked += (sender, e) =>
            {
                Thu -= 1;
                if (Thu < DayOfWeek.Sunday)
                {
                    Thu = DayOfWeek.Saturday;
                }
                if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                {
                    if (Day > 0)
                    {
                        Day -= 1;
                    }
                    else
                    {
                        Month -= 1;
                        if (Month == 0)
                        {
                            Month = 12;
                            Year -= 1;
                        }
                        if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                        {
                            Day = 30;
                        }
                        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                        {
                            Day = 31;
                        }
                        if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                        {
                            Day = 29;
                        }
                        else
                        {
                            Day = 28;
                        }

                    }
                }
                else if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                {
                    if (Day > 0)
                    {
                        Day -= 1;
                    }
                    else
                    {
                        Month -= 1;
                        if (Month == 0)
                        {
                            Month = 12;
                            Year -= 1;
                        }
                        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                        {
                            Day = 31;
                        }
                        if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                        {
                            Day = 30;
                        }
                        if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                        {
                            Day = 29;
                        }
                        else
                        {
                            Day = 28;
                        }
                    }
                }
                else
                {
                    if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                    {
                        if (Day > 0)
                        {
                            Day -= 1;
                        }
                        else
                        {
                            Month -= 1;
                            if (Month == 0)
                            {
                                Month = 12;
                                Year -= 1;
                            }
                            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                            {
                                Day = 31;
                            }
                            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                            {
                                Day = 30;
                            }
                            if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                            {
                                Day = 29;
                            }
                            else
                            {
                                Day = 28;
                            }
                        }
                    }
                    else
                    {
                        if (Day > 0)
                        {
                            Day -= 1;
                        }
                        else
                        {
                            Month -= 1;
                            if (Month == 0)
                            {
                                Month = 12;
                                Year -= 1;
                            }
                            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                            {
                                Day = 31;
                            }
                            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                            {
                                Day = 30;
                            }
                            if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                            {
                                Day = 29;
                            }
                            else
                            {
                                Day = 28;
                            }
                        }
                    }
                }
                txtThu.Text = Thu.ToString();
                if (Day < 10)
                {
                    ngay = "0" + Day.ToString();
                }
                else
                {
                    ngay = Day.ToString();
                }
                if (Month < 10)
                {
                    thang = "0" + Month.ToString();
                }
                else
                {
                    thang = Month.ToString();
                }
                txtNgay.Text = ngay + "-" + thang + "-" + Year.ToString();
                Test();
            };

        }
        async void Test()
        {
            txtload.Text = "Loading ...";
            List<String> MMH = new List<String>();
            List<String> TMH = new List<String>();
            List<String> PHONG = new List<String>();
            List<String> BD = new List<String>();
            List<String> KT = new List<String>();
            List<String> MT = new List<String>();
            List<String> TG = new List<String>();
            List<String> P = new List<String>();

            var r = await DownloadPage("http://192.168.1.2:8080/action.php");
            var t = JsonConvert.DeserializeObject<List<ThoiKhoaBieu_DTO>>(r);
            foreach (ThoiKhoaBieu_DTO tkb in t)
            {
                foreach (var n in tkb.NgayHoc)
                {
                    if (n == txtNgay.Text)
                    {
                        MMH.Add(tkb.MaMonHoc);
                        TMH.Add(tkb.TenMonHoc);
                        PHONG.Add(tkb.PhongHoc);
                        BD.Add(tkb.BatDau);
                        KT.Add(tkb.KetThuc);

                        string a = null;
                        if (tkb.BatDau == "7:00")
                        {
                            a = "1";
                        }

                        if (tkb.BatDau == "7:50")
                        {
                            a = "2";
                        }
                        if (tkb.BatDau == "8:50")
                        {
                            a = "3";
                        }
                        if (tkb.BatDau == "9:40")
                        {
                            a = "4";
                        }
                        if (tkb.BatDau == "10:35")
                        {
                            a = "5";
                        }
                        if (tkb.BatDau == "13:00")
                        {
                            a = "6";
                        }
                        if (tkb.BatDau == "13:50")
                        {
                            a = "7";
                        }
                        if (tkb.BatDau == "14:50")
                        {
                            a = "8";
                        }
                        if (tkb.BatDau == "15:35")
                        {
                            a = "9";
                        }
                        if (tkb.BatDau == "16:35")
                        {
                            a = "10";
                        }

                        string b = null;
                        if (tkb.KetThuc == "7:50")
                        {
                            b = "1";
                        }

                        if (tkb.KetThuc == "8:50")
                        {
                            b = "2";
                        }
                        if (tkb.KetThuc == "9:40")
                        {
                            b = "3";
                        }
                        if (tkb.KetThuc == "10:35")
                        {
                            b = "4";
                        }
                        if (tkb.KetThuc == "11:30")
                        {
                            b = "5";
                        }
                        if (tkb.KetThuc == "13:50")
                        {
                            b = "6";
                        }
                        if (tkb.KetThuc == "14:50")
                        {
                            b = "7";
                        }
                        if (tkb.KetThuc == "15:35")
                        {
                            b = "8";
                        }
                        if (tkb.KetThuc == "16:35")
                        {
                            b = "9";
                        }
                        if (tkb.KetThuc == "17:30")
                        {
                            b = "10";
                        }


                        MT.Add(tkb.MaMonHoc + " - " + tkb.TenMonHoc);
                        TG.Add("Tiết: " + a + " - " + b + ";" + "Thời Gian: " + tkb.BatDau + " - " + tkb.KetThuc);
                        P.Add("Tại Phòng: " + tkb.PhongHoc);
                    }
                }
                List<ThoiKhoaBieu_DTO> s = new List<ThoiKhoaBieu_DTO>();
                if (MMH.Count > 0)
                {
                    Label[] lbMMH = new Label[MMH.Count];
                    Label[] lbTMH = new Label[MMH.Count];
                    Label[] lbPHONG = new Label[MMH.Count];
                    Label[] lbBD = new Label[MMH.Count];
                    Label[] lbKT = new Label[MMH.Count];
                    Label[] txtMaTen = new Label[MMH.Count];
                    Label[] txtThoiGian = new Label[MMH.Count];
                    Label[] txtPhong = new Label[MMH.Count];

                    for (int i = 0; i < MMH.Count; i++)
                    {
                        lbTMH[i] = new Label();
                        lbMMH[i] = new Label();
                        lbPHONG[i] = new Label();
                        lbBD[i] = new Label();
                        lbKT[i] = new Label();
                        txtMaTen[i] = new Label();
                        txtThoiGian[i] = new Label();
                        txtPhong[i] = new Label();

                        lbMMH[i].Text = MMH[i].ToString();
                        lbTMH[i].Text = TMH[i].ToString();
                        lbPHONG[i].Text = PHONG[i].ToString();
                        lbBD[i].Text = BD[i].ToString();
                        lbKT[i].Text = KT[i].ToString();
                        txtMaTen[i].Text = MT[i].ToString();
                        txtThoiGian[i].Text = TG[i].ToString();
                        txtPhong[i].Text = P[i].ToString();




                        s.Add(new ThoiKhoaBieu_DTO()
                        {
                            ThoiGian = txtThoiGian[i].Text,
                            MaTen = txtMaTen[i].Text,
                            PhongH = txtPhong[i].Text
                        });
                    }
                    lstTKB.ItemsSource = s;
                }
                else if (MMH.Count == 0)
                {
                    List<ThoiKhoaBieu_DTO> h = new List<ThoiKhoaBieu_DTO>();
                    h.Add(new ThoiKhoaBieu_DTO()
                    {
                        MaTen = "Không Có Lịch Học"
                    });
                    lstTKB.ItemsSource = h;
                }
            }
            txtload.Text = null;
        }

        async Task<string> DownloadPage(string url)
        {
            var comment = u;
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("_user", comment)
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
