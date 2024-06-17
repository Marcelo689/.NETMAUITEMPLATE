using SQLite;

namespace Contacts.Models
{
    [Table("user")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ContactId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(250)]
        public string Adress { get; set; }
    }
}
