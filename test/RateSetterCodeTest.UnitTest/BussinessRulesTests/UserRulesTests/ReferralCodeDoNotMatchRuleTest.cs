using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class ReferralCodeDoNotMatchRuleTest
    {
        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingRuleWithNullExistingUserReferralCode_ThenItShouldReturnFalse()
        {
            string existingUserReferralCode = null;
            string newUserReferralCode = GivenSampleNewUserRefferralCodeNotMatch();

            var result = BussinesRules.UserRules.ReferralCodeDoNotMatchRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingRuleWithTheSameExistingUserReferralCode_ThenItShouldReturnFalse()
        {
            string existingUserReferralCode = GivenSampleExistingUserReferralCode();
            string newUserReferralCode = existingUserReferralCode;

            var result = BussinesRules.UserRules.ReferralCodeDoNotMatchRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingRuleIfExistingUserReferralCode_ThenItShouldReturnFalse()
        {
            bool result = false;
            var existingUserReferralCode = GivenSampleExistingUserReferralCode();
            var newUserReferralCodes = GivenSomeSampleNewUserRefferralCodesMatch();

            foreach(var code in newUserReferralCodes)
            {
                result = BussinesRules.UserRules.ReferralCodeDoNotMatchRule.IsTrue(code, existingUserReferralCode);
                if (result is false) break;
            }

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingRuleThatNotMatchExistingUserReferralCode_ThenItShouldReturnTrue()
        {
            var existingUserReferralCode = GivenSampleExistingUserReferralCode();
            var newUserReferralCode = GivenSampleNewUserRefferralCodeNotMatch();

            var result = BussinesRules.UserRules.ReferralCodeDoNotMatchRule.IsTrue(newUserReferralCode, existingUserReferralCode);

            Assert.True(result);
        }

        private string GivenSampleExistingUserReferralCode()
        {
            return "ABC123";
        }

        private string[] GivenSomeSampleNewUserRefferralCodesMatch()
        {
            return new string[] { "CBA123", "A1CB23", "AB21C3", "ABC321" };
        }

        private string GivenSampleNewUserRefferralCodeNotMatch()
        {
            return "ABC312";
        }
    }
}
