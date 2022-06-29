using RateSetterCodeTest.Models;
using RateSetterCodeTest.Services;

namespace RateSetterCodeTest.UnitTest.ServiceTests
{
    public class UserMatcherTest
    {
        private readonly UserMatcher _matcher = new();

        [Fact]
        public void GivenNewUserWithTheDistanceLessThanRequired_WhenCheckingIfMatchExistingUser_ThenItShouldReturnTrue()
        {
            var existingUser = GivenSampleExsitingUser();
            var newUseraddress = new Address("49 Pitt Street", "Sydney", "NSW", 2000, 0.001m, 0.201m);
            var newUser = new User(newUseraddress, "Marc Levy", "DEF536");

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserWithTheSameNameAndAddress_WhenCheckingIfMatchExistingUser_ThenItShouldReturnTrue()
        {
            var existingUser = GivenSampleExsitingUser();
            var newUseraddress = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW", 2000, 0, 0.2m);
            var newUser = new User(newUseraddress, "Guillaume Musso", "DEF536");

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserWithTheSameNameAndAddressButNameHasUpperCase_WhenCheckingIfMatchExistingUser_ThenItShouldReturnTrue()
        {
            var existingUser = GivenSampleExsitingUser();
            var newUseraddress = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW", 2000, 0, 0.2m);
            var newUser = new User(newUseraddress, "GUILLAUME MUSSO", "DEF536");

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserWithTheSameReferralCode_WhenCheckingIfMatchExistingUser_ThenItShouldReturnTrue()
        {
            var existingUser = GivenSampleExsitingUser();
            var newUseraddress = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW", 2000, 1, 1);
            var newUser = new User(newUseraddress, "Marc Levy", "ABC321");

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserThatNotMatchAnyRule_WhenCheckingIfMatchExistingUser_ThenItShouldReturnFalse()
        {
            var existingUser = GivenSampleExsitingUser();
            var newUseraddress = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW", 2000, 1, 1);
            var newUser = new User(newUseraddress, "Marc Levy", "ABC213");

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserWithNullRefferalCodeAndNotMatchAnyRule_WhenCheckingIfMatchExistingUser_ThenItShouldReturnFalse()
        {
            var existingUser = GivenSampleExsitingUser();
            var newUseraddress = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW", 2000, 1, 1);
            var newUser = new User(newUseraddress, "Marc Levy", null);

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }

        private User GivenSampleExsitingUser()
        {
            var existingAddress = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW", 2000, 0, 0.2m);
            return new User(existingAddress, "Guillaume Musso", "ABC123");
        }
    }
}
