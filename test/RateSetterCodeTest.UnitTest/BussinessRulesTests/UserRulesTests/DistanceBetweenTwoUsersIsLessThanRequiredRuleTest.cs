using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class DistanceBetweenTwoUsersIsLessThanRequiredRuleTest
    {
        [Fact]
        public void GivenNewUserLocationWithDistanceIsFarThanRequired_WhenCheckingDistanceBetweenTwoUsersIsLessThanRequiredRule_ThenItShouldReturnFalse()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("350 Pitt Street", "Sydney", "NSW", 2000, 1, 1);

            var result = DistanceBetweenTwoUsersIsLessThanRequiredRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserLocationWithDistanceIsLessThanRequired_WhenCheckingDistanceBetweenTwoUsersIsLessThanRequiredRule_ThenItShouldReturnTrue()
        {
            var existingUserAddress = GivenSampleExistingUserAddress();
            var newUserAddress = new Address("20 Pitt Street", "Sydney", "NSW", 2000, 0.001m, 0.201m);

            var result = DistanceBetweenTwoUsersIsLessThanRequiredRule.IsTrue(existingUserAddress, newUserAddress);

            Assert.True(result);
        }

        private Address GivenSampleExistingUserAddress()
        {
            return new Address("Level 3, 51 Pitt Street", "Sydney", "NSW", 2000, 0, 0.2m);
        }
    }
}
