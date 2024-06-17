using SQLite;

namespace Contacts.Models
{
    public class SQLiteRepository
    {
        public SQLiteConnection Connection;
        string _dbPath;
        public SQLiteRepository(string dbPath)
        {
            _dbPath = dbPath;
            InitializeConnection();
            CreateTable();
        }
        public void InitializeConnection()
        {
            Connection = new SQLiteConnection(_dbPath);
        }
        public void CreateTable()
        {
            Connection.CreateTable<Contact>();
        }

        public void AddContact(Contact contact)
        {
            Connection.Insert(contact);
        }

        public void UpdateContact(Contact contact)
        {
            Connection.Update(contact);
        }
        public List<Contact> GetAllContacts() {
            return Connection.Table<Contact>().ToList();
        }

        public List<Contact> FilterContacts(string name)
        {
            return GetAllContacts().Where(contact => contact.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        internal Contact GetContactById(int id)
        {
            return GetAllContacts().FirstOrDefault(e => e.ContactId == id);
        }
    }
}
