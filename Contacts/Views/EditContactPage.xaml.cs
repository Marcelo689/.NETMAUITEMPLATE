using Contacts.Models;

namespace Contacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Models.Contact contact;

    public EditContactPage()
	{
		InitializeComponent();
	}

	public string ContactId { set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));
            contactControl.Name= contact.Name;	
			contactControl.Email = contact.Email;	
			contactControl.PhoneNumber = contact.PhoneNumber;
			contactControl.Adress = contact.Adress;
		} 
	}

    private void contactControl_OnSave(object sender, EventArgs e)
    {
        contact.Name = contactControl.Name;
        contact.Email = contactControl.Email;
        contact.PhoneNumber = contactControl.PhoneNumber;
        contact.Adress = contactControl.Adress;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }

    private void contactControl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}