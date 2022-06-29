using RateSetterCodeTest.BussinesRules;
using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Interface;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.Services
{
    public class UserMatcher : IUserMatcher
    {
        public bool IsMatch(User newUser, User existingUser)
        {
            // Rule 1: New user does not live near the existing user.
            bool isMatchDistanceRule = DistanceBetweenTwoUsersIsLessThanRequiredRule.IsTrue(newUser.Address, existingUser.Address);
            if (isMatchDistanceRule) return true;

            // Rule 2: New user's name and address does not match an existing user.
            bool isMatchAddressRule = AddressIsMatchExistingUserRule.IsTrue(newUser.Address, existingUser.Address);
            if (newUser.Name.ToUpper() == existingUser.Name.ToUpper() && isMatchAddressRule) return true;

            // Rule 3: No other user has enterd the same code.
            if (newUser.ReferralCode != null)
            {
                return ReferralCodeIsMatchExistingUserRule.IsTrue(newUser.ReferralCode, existingUser.ReferralCode);
            }

            return false;
        }
    }

}
