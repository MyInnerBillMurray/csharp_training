using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string otherFields = "";
        private string allPhones;
        private string allEmails;

        public ContactData(string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return LastName == other.LastName && FirstName == other.FirstName;
                 
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName == other.LastName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone1 { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string HomePhone2 { get; set; }

        public string AllPhones 
        { 
            get
            {
                if (allPhones != null) 
                {
                    return allPhones;
                }
                else 
                {
                    return CleanUp(HomePhone1) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(HomePhone2).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ","").Replace("-","").Replace("(","").Replace(")", "") + "\r\n";
        }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails 
        { 
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUpEmails(Email1) + CleanUpEmails(Email2) + CleanUpEmails(Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmails(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        public string OtherFields { get { return otherFields; } set { otherFields = value; } }
    }
}
