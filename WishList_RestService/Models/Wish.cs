using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WishList_RestService.Models
{
    public class Wish
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int WishId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
