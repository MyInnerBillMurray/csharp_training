using NUnit.Framework;
using System;
using System.Collections.Generic;
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
                    return (CleanUpPhones(HomePhone1) + CleanUpPhones(MobilePhone)
                        + CleanUpPhones(WorkPhone) + CleanUpPhones(HomePhone2)).Trim();
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
                    return (CheckNames(CleanUpNames(FirstName) + CleanUpNames(Middlename) + CleanUpNames(LastName).Trim())
                        + CheckTab(CleanUp(Nickname) + CleanUp(Title) + CleanUp(Company) + CleanUpAddress(Address))
                        + CleanUp(CleanUpHomePhone1(HomePhone1) + CleanUpMobilePhone(MobilePhone)
                            + CleanUpWorkPhone(WorkPhone) + CleanUpFax(Fax))
                        + CleanUp(CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)
                        + CleanUpHomepage(Homepage))
                        + CleanUpAddress(Address2)
                        + CleanUpHomePhone2(HomePhone2)
                        + CleanUp(Notes)).Trim();
                }
            }
            set
            {
                allInfo = value;
            }
        }
        private string CleanUpPhones(string phone)
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
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        private string CleanUpNames(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }      
            return name + " ";
        }

        private string CheckNames(string names)
        {
            if (FirstName == null || FirstName == "" || Middlename == null || Middlename == "" || LastName == null || LastName == "")
            {
                return names + "\r\n";
            }
            return names;
        }

        private string CheckTab(string entry)
        {
            if (entry == null || entry == "")
            {
                return "\r\n" + entry;
            }
            return entry;
        }

        private string CleanUpHomePhone1(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "H: " + phone + "\r\n";
        }

        private string CleanUpMobilePhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "M: " + phone + "\r\n";
        }

        private string CleanUpWorkPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "W: " + phone + "\r\n";
        }

        private string CleanUpFax(string fax)
        {
            if (fax == null || fax == "")
            {
                return "";
            }
            return "F: " + fax + "\r\n";
        }

        private string CleanUpHomePhone2(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "P: " + phone + "\r\n" + "\r\n";
        }

        private string CleanUpAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address + "\r\n" + "\r\n";
        }

        private string CleanUpHomepage(string homepage)
        {
            if (homepage == null || homepage == "")
            {
                return "";
            }
            return "Homepage:" + "\r\n" + Homepage + "\r\n" + "\r\n";
        }

        public string OtherFields { get { return otherFields; } set { otherFields = value; } }
    }
}