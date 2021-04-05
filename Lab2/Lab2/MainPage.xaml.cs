using Lab2.Entities;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab2
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Organization> OrgsList { get; set; }
        public Organization SelectedItem { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand DescriptionCommand { get; set; }

        public MainPage()
        {
            InitializeComponent();

            OrgsList = new ObservableCollection<Organization>()
            {
                new Organization()
                {
                    ManagerName = "Alex",
                    OrgName = "MyOrganization",
                    OrgNumber = 1234567,
                    PhoneNumber = "+380506314441",
                    Product = "Apple"
                },
                new Organization()
                {
                    ManagerName = "Maks",
                    OrgName = "SecondOrganization",
                    OrgNumber = 1234568,
                    PhoneNumber = "+380506314441",
                    Product = "Ice-Cream"
                }
            };

            this.BindingContext = this;
        }

        public void AddOrganization(Organization org)
        {
            if (org != null)
            {
                OrgsList.Add(org);
            }
        }

        public void UpdateOrganization(Organization org)
        {
            if (this.SelectedItem != null)
            {
                var oldOrganization = OrgsList.Where(x => x.OrgNumber == this.SelectedItem.OrgNumber).FirstOrDefault();
                OrgsList.Remove(oldOrganization);
            }

            OrgsList.Add(this.SelectedItem);
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new AddPage());
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            var smsManager = CrossMessaging.Current.SmsMessenger;
            if (smsManager.CanSendSms)
            {
                smsManager.SendSms(this.SelectedItem.PhoneNumber, "Your organization was deleted!");
            }
            OrgsList.Remove(this.SelectedItem);
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            var updatePage = new UpdatePage();
            updatePage.BindingContext = this.SelectedItem;
            await this.Navigation.PushAsync(updatePage);
        }

        private async void Show_Description(object sender, EventArgs e)
        {
            var description = new Description();
            description.BindingContext = this.SelectedItem;
            await this.Navigation.PushAsync(description);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                this.SelectedItem = e.SelectedItem as Organization;
            }
        }
    }
}
