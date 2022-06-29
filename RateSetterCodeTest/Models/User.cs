using System;

namespace RateSetterCodeTest.Models
{
    public class User
    {
        public Address Address { get; }
        public string Name { get; }
        public string ReferralCode { get; }

        public User(Address address, string name, string referralCode)
        {
            Address = address ?? throw new ArgumentNullException(nameof(Address));
            Name = name ?? throw new ArgumentNullException(nameof(Name));
            ReferralCode = referralCode;
        }
    }
}
