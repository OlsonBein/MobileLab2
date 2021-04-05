using Lab2.Entities;
using System;

using Xamarin.Forms;

namespace Lab2
{
    public partial class Description : ContentPage
    {
        public Organization Organization { get; set; }

        public Description()
        {
            InitializeComponent();
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}