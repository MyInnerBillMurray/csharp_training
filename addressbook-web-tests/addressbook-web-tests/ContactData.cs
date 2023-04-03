﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string lastName;
        private string otherFields = "";

        public ContactData(string firstName, string lastName) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName { get { return firstName; } set { firstName = value; } }

        public string LastName { get { return lastName; } set { lastName = value; } }

        public string OtherFields { get { return otherFields; } set { otherFields = value; } }
    }
}
