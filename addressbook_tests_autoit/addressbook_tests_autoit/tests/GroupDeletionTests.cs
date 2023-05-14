using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void TestGroupDeletion()
        {
            app.Groups.ConfirmGroupExists();
            
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
