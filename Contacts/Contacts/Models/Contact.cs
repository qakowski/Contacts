using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Contacts.Models { 
    public class Contact
    {

        public static IList<Contact> Contacts;

        static Contact()
        {
            Contacts = new ObservableCollection<Contact>();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string name;
        private string phoneNumber;



        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
       
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNumber"));
            }
        }

        public static void SampleData()
        {
            Contacts.Clear();
            Contacts.Add(new Contact
            {
                Id = 1,
                Name = "Andrzej Nowak",
                PhoneNumber = "531960809"
            });
            Contacts.Add(new Contact
            {
                Id = 2,
                Name = "Marek Wójcik",
                PhoneNumber = "554332054"
            });
            Contacts.Add(new Contact
            {
                Id = 3,
                Name = "Krystian Nowak",
                PhoneNumber = "640340201"
            });
            Contacts.Add(new Contact
            {
                Id = 4,
                Name = "Krystian Wieczór",
                PhoneNumber = "530103954"
            });
            Contacts.Add(new Contact
            {
                Id = 5,
                Name = "Kamil Mąk",
                PhoneNumber = "543029313"
            });
            Contacts.Add(new Contact
            {
                Id = 6,
                Name = "Karolina Waciarz",
                PhoneNumber = "751982048"
            });
            Contacts.Add(new Contact
            {
                Id = 7,
                Name = "Grzegorz Czołg",
                PhoneNumber = "664235846"
            });
            Contacts.Add(new Contact
            {
                Id = 8,
                Name = "Łukasz Róża",
                PhoneNumber = "889624354"
            });
            Contacts.Add(new Contact
            {
                Id = 9,
                Name = "Marian Bodzisz",
                PhoneNumber = "849235415"
            });
            Contacts.Add(new Contact
            {
                Id = 10,
                Name = "Tomasz Mariuszewski",
                PhoneNumber = "557112345"
            });

        }

    }
}
