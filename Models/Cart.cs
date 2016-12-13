using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models
{
    public class Cart
    {
        public int Id { get; set; }

        //[Index(IsUnique = true)]
        [StringLength(255)]
        public string SessionId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
