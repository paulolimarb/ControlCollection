using ControlCollection.Domain.Validation;

namespace ControlCollection.Domain
{
    public class Contact
    {
        //public Contact(string name, string email, string phone)
        //{
        //    //if()

        //    this.Name = name;
        //    this.Email = email;
        //    this.Phone = phone;
        //}



        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        

    }
}
