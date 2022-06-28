namespace RateSetterCodeTest.Models
{
    public class User
    {
        public Address Address { get; }
        public string Name { get; }
        public string ReferralCode { get; }

        public User(Address address, string name, string referralCode)
        {
            Address = address;
            Name = name;
            ReferralCode = referralCode;
        }
    }
}
