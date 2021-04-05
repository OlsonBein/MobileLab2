using System.ComponentModel;

namespace Lab2.Entities
{
    public class Organization : INotifyPropertyChanged
    {
        private string orgName;
        private int orgNumber;
        private string managerName;
        private string phoneNumber;
        private string product;


        public string OrgName {
            get { return orgName; }
            set
            {
                if (orgName != value)
                {
                    orgName = value;
                    OnPropertyChanged("OrgName");
                }
            }
        }

        public int OrgNumber {
            get { return orgNumber; }
            set
            {
                if (orgNumber != value)
                {
                    orgNumber = value;
                    OnPropertyChanged("OrgNumber");
                }
            }
        }

        public string ManagerName {
            get { return managerName; }
            set
            {
                if (managerName != value)
                {
                    managerName = value;
                    OnPropertyChanged("ManagerName");
                }
            }
        }

        public string PhoneNumber {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public string Product {
            get { return product; }
            set
            {
                if (product != value)
                {
                    product = value;
                    OnPropertyChanged("Product");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}