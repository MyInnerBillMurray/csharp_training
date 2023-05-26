﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using static System.Net.WebRequestMethods;

namespace mantis_tests
{
    public class TestBase
    {

        public static bool PERFORM_LONG_UI_GROUPS_CHECKS = false;
        public static bool PERFORM_LONG_UI_CONTACTS_CHECKS = false;
        
        protected ApplicationManager app;
        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++) 
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
