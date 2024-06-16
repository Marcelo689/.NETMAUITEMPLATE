using Contacts.Models;

namespace Contacts.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void contactControl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactControl.Name,
            Adress = contactControl.Adress,
            Email = contactControl.Email,
            PhoneNumber = contactControl.PhoneNumber,
        });

        Shell.Current.GoToAsync("..");
    }
    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", "Field is required", "OK");
    }

    private void contactControl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}