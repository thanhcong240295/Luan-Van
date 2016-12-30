using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Regis
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            List<About_DTO> a = new List<About_DTO>();
            a.Add(new About_DTO()
            {
                ThongTin = "Kiểm Tra Phiên Bản Mới"
            });
            lstTKB.ItemsSource = a;
            a.Add(new About_DTO()
            {
                ThongTin = "Bình Chọn Cho Ứng Dụng"
            });
            lstTKB.ItemsSource = a;
            a.Add(new About_DTO()
            {
                ThongTin = "Website: http://www.agu.edu.vn/"
            });
            lstTKB.ItemsSource = a;
            a.Add(new About_DTO()
            {
                ThongTin = "Email: thanhcong240295@gmail.com"
            });
            lstTKB.ItemsSource = a;
            a.Add(new About_DTO()
            {
                ThongTin = "SĐT: 01636.858.950"
            });
            lstTKB.ItemsSource = a;

        }
    }
}
