using Kantor_Bea_lab2.Models;

namespace Kantor_Bea_lab2.Models.ViewModels

{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }  
        public IEnumerable<Book> Books { get; set; }
     }
}
