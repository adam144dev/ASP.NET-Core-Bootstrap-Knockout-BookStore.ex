using Newtonsoft.Json;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.ViewModels
{
    public class CategoryViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
