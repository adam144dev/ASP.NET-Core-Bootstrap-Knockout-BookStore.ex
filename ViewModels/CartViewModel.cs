using System.Collections.Generic;
using Newtonsoft.Json;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels
{
    public class CartViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cartItems")]
        public virtual ICollection<CartItemViewModel> CartItems { get; set; }
    }
}
