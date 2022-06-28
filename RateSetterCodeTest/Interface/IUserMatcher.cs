using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.Interface
{
    public interface IUserMatcher
    {
        bool IsMatch(User newUser, User existingUser);
    }
}
