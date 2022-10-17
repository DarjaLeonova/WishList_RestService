using User_RestService.Models;

namespace User_RestService.Services.Impl
{
    public class UserService : IUserService
    {
        public string CollectNames(Users users)
        {
            var names = new List<string>();

            foreach (var user in users.UsersList)
            {
                names.Add(user.Name);
            }
            return string.Join(", ", names);
        }
    }
}
