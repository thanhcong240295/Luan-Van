﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Regis
{
    public class App : Application
    {
        public string Pass { get; internal set; }
        public string User { get; internal set; }

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
