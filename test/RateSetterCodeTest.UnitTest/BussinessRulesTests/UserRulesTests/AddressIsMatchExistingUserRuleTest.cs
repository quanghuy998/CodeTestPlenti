using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class AddressIsMatchExistingUserRuleTest
    {
        [Fact]
        public void GivenNewUserAddressWithTheSameButHavingSpaceAtBeginning_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("   Level 3, 51 Pitt Street", "   Sydney", "  NSW", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserAddressWithTheSameButHavingSpaceAtEnd_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("Level 3, 51 Pitt Street  ", "Sydney  ", "NSW  ", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserAddressWithTheSameButHavingSpaceAtTwoHeads_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("  Level 3, 51 Pitt Street  ", "  Sydney  ", "  NSW  ", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserAddressWithTheSameButHavingSomeCharacters_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("Level 3,! 51_Pitt Street", "Sydney@", "NSW", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserAddressWithTheSameButInUpperCase_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("LEVEL 3, 51 PITT STREET", "SYDNEY", "NSW", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserAddressWithTheSameButInUpperCaseAndHavingSomeCharacters_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("LEVEL! 3, 51 PITT-STREET$", "SYDNEY!", "NSW", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserAddressWithTheDifference_WhenCheckingAddressIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var address2 = new Address("Level 3,! 53_Pitt Street", "Sydney", "NSW", 2000, 0, 0);

            var result = AddressIsMatchExistingUserRule.IsTrue(existingUserAddress, address2);

            Assert.False(result);
        }

        private Address GivenSampleExistingUserAddress()
        {
            return new Address("Level 3, 51 Pitt Street", "Sydney", "NSW", 2000, 0, 0);
        }
    }
}
