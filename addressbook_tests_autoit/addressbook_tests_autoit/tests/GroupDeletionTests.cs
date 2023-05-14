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

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Remove(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }
    }
}
