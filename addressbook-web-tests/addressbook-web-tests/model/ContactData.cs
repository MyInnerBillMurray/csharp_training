using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string otherFields = "";

        public ContactData(string firstName, string lastName) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return lastName == other.LastName && firstName == other.firstName;
                 
        }

        public override int GetHashCode()
        {
            return lastName.GetHashCode() + firstName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + lastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (lastName == other.lastName)
            {
                return firstName.CompareTo(other.firstName);
            }
            return lastName.CompareTo(other.lastName);
        }

        public string FirstName { get { return firstName; } set { firstName = value; } }

        public string LastName { get { return lastName; } set { lastName = value; } }

        public string OtherFields { get { return otherFields; } set { otherFields = value; } }
    }
}
