﻿using RateSetterCodeTest.BussinesRules;
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
            bool distanceRule = DoesNotLessThanDistanceRule.IsTrue(newUser.Address, existingUser.Address);
            if (distanceRule is false) return true;

            // Rule 2: New user's name and address does not match an existing user.
            bool addressRule = DoestNotMatchAddressRule.IsTrue(newUser.Address, existingUser.Address);
            if (newUser.Name == existingUser.Name && addressRule is false) return true;

            // Rule 3: No other user has enterd the same code.
            if (newUser.ReferralCode != null)
            {
                if (newUser.ReferralCode == existingUser.ReferralCode) return true;
                bool referralCodeRule = DoesNotMatchRefferalCodeRule.IsTrue(newUser.ReferralCode, existingUser.ReferralCode);
                if (referralCodeRule is false) return true;
                else return false;
            }
            else return true;
        }
    }

}