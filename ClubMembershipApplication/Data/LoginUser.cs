using ClubMembershipApplication.Models;
using System.Linq;

namespace ClubMembershipApplication.Data
{
    public class LoginUser : ILogin
    {
        public User Login(string emailAddres, string password)
        {
            User user = null;
            using (var dbContext = new ClubMembershipDbContext())
            {
                user = dbContext.Users.FirstOrDefault(
                    u => u.EmailAddress.ToLower().Trim().Equals(emailAddres.ToLower().Trim()) && u.Password.Equals(password)
                );
            }
            return user;
        }
    }
}
