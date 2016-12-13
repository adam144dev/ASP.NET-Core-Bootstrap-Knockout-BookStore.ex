using System.Collections.Generic;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
