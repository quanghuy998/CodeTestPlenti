using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class AddressIsMatchExistingUserRule
    {
        public static bool IsTrue(Address newUserAddress, Address existingUserAddress)
        {
            string address1 = RemoveCharacter(newUserAddress.GetAddress()).ToUpper();
            string address2 = RemoveCharacter(existingUserAddress.GetAddress()).ToUpper();
            
            if (address1 == address2) return true;
            
            return false;
        }

        private static string RemoveCharacter(string str)
        {
            string[] unsualCharacters = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "?", "~", "{", "}", "\\" };
            string[] spaceCharacters = new string[] { "_", "-" };

            foreach (var character in unsualCharacters)
            {
                str = str.Replace(character, string.Empty);
            }

            foreach (var character in spaceCharacters)
            {
                str = str.Replace(character, " ");
            }

            return str;
        }
    }
}
