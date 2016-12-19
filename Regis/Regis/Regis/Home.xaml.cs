using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Regis
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            btnnews.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new News());
            };

            btnTKB.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ThoiKhoaBieu());
            };

            btnCTDT.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ChuongTrinhDaoTao());
            };
        }
    }
}
