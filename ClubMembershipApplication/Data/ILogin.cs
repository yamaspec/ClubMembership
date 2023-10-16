using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    public interface ILogin
    {
        User Login(string emailAddres, string password);
    }
}
