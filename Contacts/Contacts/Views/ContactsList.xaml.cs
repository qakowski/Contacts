using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsList : ContentPage
    {

        public ContactsList()
        {
            InitializeComponent();
            //JAK NIE BEDZIE DZIALAC TO WYRZUCI
            Contact.SampleData();
            
            BindingContext = Contact.Contacts;
            
        }

        //JAK NIE BEDZIE DZIALAC TO WYRZUCIC
        //public async Task<List<Contact>> getContacts(Context db)
        //{
        //    return await db.getList();
        //}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        async void Contact_Tapped(object sender, ItemTappedEventArgs e)
        {
            Contact c = e.Item as Contact;
            if (c == null)
            {
                return;
            }
            await Navigation.PushAsync(new CustomerDetails(c));
        }
        async void Contacts_Refreshing(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            listView.IsRefreshing = true;
            await Task.Delay(1500);
            listView.IsRefreshing = false;
        }

        void Contact_Deleted(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Contact c = menuItem.BindingContext as Contact;
            Contact.Contacts.Remove(c);
        }

        async void Contact_Phoned(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Contact c = menuItem.BindingContext as Contact;
            if (await this.DisplayAlert("Wybór Numeru: ", "Czy chcesz zadzwonić do " + c.PhoneNumber + "?", "Tak", "Nie"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(c.PhoneNumber);
                }
            }
        }
        async void Add_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerDetails());
        }


        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }
    }
}