namespace Kantor_Bea_lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
