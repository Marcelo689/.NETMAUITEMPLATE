using CommunityToolkit.Maui.Core.Extensions;
using Contacts.Models;
using System.Collections.ObjectModel;
namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={( (Models.Contact) listContacts.SelectedItem).ContactId}");
		}
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;

        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts =  App.Repository.GetAllContacts().ToObservableCollection();
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = App.Repository.FilterContacts(((SearchBar)sender).Text).ToObservableCollection();
        listContacts.ItemsSource = contacts;
    }

}