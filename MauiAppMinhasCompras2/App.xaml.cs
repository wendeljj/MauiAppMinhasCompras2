﻿using MauiAppMinhasCompras2.Views;

namespace MauiAppMinhasCompras2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
