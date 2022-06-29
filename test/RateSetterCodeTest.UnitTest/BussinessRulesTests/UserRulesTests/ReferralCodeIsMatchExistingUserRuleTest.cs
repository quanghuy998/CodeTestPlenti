using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class ReferralCodeIsMatchExistingUserRuleTest
    {
        [Fact]
        public void GivenNewUserReferralCodeButExistingUserCodeIsNull_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            string existingUserReferralCode = null;
            string newUserReferralCode = "ABC213";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithTheSame_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            string existingUserReferralCode = "ABC123";
            string newUserReferralCode = existingUserReferralCode;

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReversalAtTheBeginning_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "CBA123";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReversalAtEnd_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "ABC321";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReversalAtBetween_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnTrue()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode1 = "A1CB23";
            var newUserReferralCode2 = "AB21C3";

            var result1 = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode1, existingUserReferralCode);
            var result2 = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode2, existingUserReferralCode);

            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithAllLowerCase_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "abc123";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithOneLowerCase_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "ABc123";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReveralOfTwoCharesAtBeginning_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "BAC123";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReveralOfTwoCharesAtEnd_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "ABC132";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReveralOfFourCharesAtBeginning_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "1BCA23";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReveralOfFourCharesAtEnd_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "AB312C";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithReveralOf4CharesAtBetween_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "A2C1B3";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithMultipleReversals_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "3A12CB";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithGreaterLength_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "ABVC1231124";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCodeWithDifferenceChares_WhenCheckingReferralCodeIsMatchExistingUserRule_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = "ABC123";
            var newUserReferralCode = "DEF456";

            var result = ReferralCodeIsMatchExistingUserRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }
    }
}
