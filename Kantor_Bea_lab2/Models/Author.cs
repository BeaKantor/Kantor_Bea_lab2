using System.ComponentModel.DataAnnotations;

namespace Kantor_Bea_lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }
        
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
