using RateSetterCodeTest.Models;
using RateSetterCodeTest.Services;

namespace RateSetterCodeTest.UnitTest.ServiceTests
{
    public class UserMatcherTest
    {
        private readonly UserMatcher _matcher = new();

        [Fact]
        public void GivenNewUserAddress_WhenCheckingIfExistingUserAddressAndUserName_ThenItShouldReturnTrue()
        {
            var newUser = GivenSampleNewUserHaveSameAddressAndName();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserLocation_WhenCheckingIfExistingUserWhoLiveNearby_ThenItShouldReturnTrue()
        {
            var newUser = GivenSampleNewUserHaveLocationNearby();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingIfExistingUserReferralCodeThatMatch_ThenItShouldReturnTrue()
        {
            var newUser = GivenSampleNewUserHaveReferralCodeMatch();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingWithSameExistingUserReferralCode_ThenItShouldReturnTrue()
        {
            var newUser = GivenSampleNewUserHaveTheSameReferralCode();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserHaveNotExistingReferralCode_WhenCheckingWithExistingUser_ThenItShouldReturnFalse()
        {
            var newUser = GivenSampleNewUser();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserDoNotHaveRefferalCode_WhenCheckingWithExistingUser_ThenItShouldReturnFalse()
        {
            var newUser = GivenSampleNewUserDoNotHaveReferralCode();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }


        private User GivenSampleExistingUser()
        {
            var address = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW 2000", 0, 0.2m);
            return new User(address, "Gullaume Musso", "ABC123");
        }

        private User GivenSampleNewUserHaveSameAddressAndName()
        {
            var address = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW 2000", 0, 0.2m);
            return new User(address, "Gullaume Musso", "ABC321");
        }

        private User GivenSampleNewUserHaveLocationNearby()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 0.001m, 0.201m);
            return new User(address, "Marc Levy", "ABC321");
        }

        private User GivenSampleNewUserHaveReferralCodeMatch()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 1, 1);
            return new User(address, "Marc Levy", "ABC321");
        }

        private User GivenSampleNewUserHaveTheSameReferralCode()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 1, 1);
            return new User(address, "Marc Levy", "ABC123");
        }

        private User GivenSampleNewUserDoNotHaveReferralCode()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 1, 1);
            return new User(address, "Marc Levy", null);
        }

        private User GivenSampleNewUser()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 1, 1);
            return new User(address, "Marc Levy", "ABC213");
        }
    }
}
