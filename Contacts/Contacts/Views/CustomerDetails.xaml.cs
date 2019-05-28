using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetails : ContentPage
    {
        private bool newContact = false;
        
        public CustomerDetails()
        {
            InitializeComponent();
            BindingContext = new Contact();
            newContact = true;
            CallButton.IsVisible = false;
            Title = "Dodaj kontakt";
        }
        public CustomerDetails(Contact contact)
        {
            InitializeComponent();
            BindingContext = contact;
            InsertButton.IsVisible = false;
            CallButton.IsVisible = true;
        }

        async void InsertButton_Clicked(object sender, EventArgs e)
        {
            if (newContact)
            {
                Contact.Contacts.Add((Contact)BindingContext);
            }
            await Navigation.PopAsync(animated: true);
        }
        async void CallButton_Clicked(object sender, EventArgs e)
        {
            if (!newContact)
            {
                
                Contact c = BindingContext as Contact;
                if (await this.DisplayAlert("Wybór Numeru: ", "Czy chcesz zadzwonić do " + c.PhoneNumber + "?", "Tak", "Nie"))
                {
                    var dialer = DependencyService.Get<IDialer>();
                    if (dialer != null)
                    {
                        dialer.Dial(c.PhoneNumber);
                    }
                }
            }
        }
    }
}