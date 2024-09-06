using eshop.Domain;

namespace eshop.API.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new()
        {
            new(){ Id=1, UserName="admin", Password="1234", Email="test@test.com", Role="Admin"},
            new(){ Id=2, UserName="editor", Password="1234", Email="test@test.com", Role="Editor"},
             new(){ Id=3, UserName="client", Password="1234", Email="test@test.com", Role="Client"}
        };
        public User? ValidateUser(string username, string password)
        {
            return users.SingleOrDefault(u => u.UserName == username
                                            &&
                                            u.Password == password);

        }
    }
}
