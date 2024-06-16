namespace Contacts.Views.Controls;

public partial class ContactControl : ContentView
{
	public event EventHandler<string> OnError;
	public event EventHandler<EventArgs> OnSave;
	public event EventHandler<EventArgs> OnCancel;
	public ContactControl()
	{
		InitializeComponent();
	}

	public string Name { 
		get { return entryName.Text; }
		set { entryName.Text = value; }
	}
	public string Email { 
		get { return entryEmail.Text; }
		set { entryEmail.Text = value; }
	}
	public string Adress { 
		get { return entryAdress.Text; }
		set { entryAdress.Text = value; }
	}
	public string PhoneNumber{ 
		get { return entryPhoneNumber.Text; }
		set { entryPhoneNumber.Text = value; }
	}


    private void Button_Clicked_Save(object sender, EventArgs e)
    {
        if (entryNameValidator.IsNotValid)
        {
			OnError?.Invoke(sender, "Name is Required!"); 
            return;
        }

        if (entryEmailValidator.IsNotValid)
        {

            foreach (var error in entryEmailValidator.Errors)
            {
				if(error is not null)
					OnError?.Invoke(sender, error.ToString());
            }

            return;
        }

		OnSave?.Invoke(sender, e);
    }

    private void Button_Clicked_Cancel(object sender, EventArgs e)
    {
		OnCancel?.Invoke(sender, e);
    }
}