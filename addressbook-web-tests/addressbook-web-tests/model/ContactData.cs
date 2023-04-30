using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string otherFields = "";
        private string allPhones;
        private string allEmails;
        private string allInfo;

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
            return "lastname=" + LastName + "\nfirstname=" + FirstName + "\notherfields=" + OtherFields;
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
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone1 { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string HomePhone2 { get; set; }
        public string Notes { get; set; }

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
                    return CleanUp(HomePhone1) + CleanUp(MobilePhone) 
                        + CleanUp(WorkPhone) + CleanUp(HomePhone2).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return FirstName + " " + Middlename + " " + LastName + "\r\n"
                        + Nickname + "\r\n" + Title + "\r\n" + Company + "\r\n" + Address + "\r\n" + "\r\n"
                        + "H: " + HomePhone1 + "\r\n" + "M: " + MobilePhone + "\r\n" + "W: " + WorkPhone
                            + "\r\n" + "F: " + Fax + "\r\n" + "\r\n"
                        + Email1 + "\r\n" + Email2 + "\r\n" + Email3 + "\r\n"
                        + "Homepage:" + "\r\n" + Homepage + "\r\n" + "\r\n" + "\r\n"
                        + Address2 + "\r\n" + "\r\n"
                        + "P: " + HomePhone2 + "\r\n" + "\r\n"
                        + Notes;
                }
            }
            set
            {
                allInfo = value;
            }
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

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