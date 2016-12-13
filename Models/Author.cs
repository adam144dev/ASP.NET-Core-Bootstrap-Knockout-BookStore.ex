using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }

        [NotMapped]
        public string FullName => FirstName + ' ' + LastName;

        public virtual ICollection<Book> Books { get; set; }

    }
}
