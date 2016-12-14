namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int CartId { get; set; }
        public int BookId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Book Book { get; set; }
    }
}
