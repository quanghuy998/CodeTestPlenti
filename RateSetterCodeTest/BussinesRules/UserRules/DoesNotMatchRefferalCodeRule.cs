using System.IO;
using System.Linq;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class DoesNotMatchRefferalCodeRule
    {
        public static bool IsTrue(string newUserReferralCode, string existingUserReferralCode)
        {
            if(existingUserReferralCode == null) return false;

            var array1 = newUserReferralCode.ToArray();
            var array2 = existingUserReferralCode.ToArray();

            for (int i = 0; i < array1.Length - 2; i++)
            {
                var swappedArray1 = SwapIndex(array1, i, i + 2);
                var result = CompareTwoArray(swappedArray1, array2);
                if (result) return false;
            }

            return true;
        }

        private static bool CompareTwoArray(char[] arr1, char[] arr2)
        {
            if (arr1 == null || arr2 == null || arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }

            return true;
        }

        private static char[] SwapIndex(char[] array, int index1, int index2)
        {
            if (array.Length <= index1 || array.Length <= index2) throw new InvalidDataException("Index of referral code is over the data length.");

            var newArray = new char[array.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            char temp = newArray[index1];
            newArray[index1] = newArray[index2];
            newArray[index2] = temp;

            return newArray;
        }
    }
}
