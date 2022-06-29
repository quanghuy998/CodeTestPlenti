using System;
using System.IO;
using System.Linq;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class ReferralCodeIsMatchExistingUserRule
    {
        public static bool IsTrue(string newUserReferralCode, string existingUserReferralCode)
        {
            if(existingUserReferralCode == null || newUserReferralCode.Length != existingUserReferralCode.Length) return false;
            if (newUserReferralCode == existingUserReferralCode) return true;

            for (int i = 0; i < newUserReferralCode.Length - 2; i++)
            {
                string swappedRefferalCode = SwapIndex(newUserReferralCode, i, i + 2);
                if (swappedRefferalCode == existingUserReferralCode) return true;
            }

            return false;
        }

        private static string SwapIndex(string str, int index1, int index2)
        {
            if (str.Length <= index1 || str.Length <= index2) throw new InvalidDataException("Index of referral code is over the data length.");

            char[] strChar = str.ToCharArray();
            char temp = strChar[index1];
            strChar[index1] = strChar[index2];
            strChar[index2] = temp;

            return new String(strChar);
        }
    }
}
