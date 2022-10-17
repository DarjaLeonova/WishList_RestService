using System.Text.Json.Serialization;

namespace User_RestService.Models
{
    public class Users
    {
        [JsonPropertyName("users")]
        public List<User> UsersList { get; set; }
    }
}
