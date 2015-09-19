using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AG.TwitterFeed.Processor.UnitTest
{
    [TestClass]
    public class TwitterUserProcessorFixture
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "File not found exception not thrown")]
        public void Test_NoUserFileException()
        {
            string fileName = "Test.txt";
            TwitterUserProcessor processor = new TwitterUserProcessor(fileName);
            processor.CreateTwitterUsers();
        }

        [TestMethod]
        public void Test_InvalidFileLayout()
        {
            string fileName = @"TestData\user_Test_InvalidFileLayout.txt";
            TwitterUserProcessor processor = new TwitterUserProcessor(fileName);

            Assert.IsNotNull(processor, "TwitterUserProcessor is null");

            var list = processor.CreateTwitterUsers();

            Assert.IsNotNull(list, "User list is null");
            Assert.IsTrue(list.Count == 0, "User list contains more than one record");
        }

        [TestMethod]
        public void Test_TwoRecords()
        {
            string fileName = @"TestData\user_Test_TwoRecord.txt";
            TwitterUserProcessor processor = new TwitterUserProcessor(fileName);

            Assert.IsNotNull(processor, "TwitterUserProcessor is null");

            var list = processor.CreateTwitterUsers();

            Assert.IsNotNull(list, "User list is null");
            Assert.IsTrue(list.Count == 2, "User list contains more than two record");
        }

        [TestMethod]
        public void Test_ThreeRecord()
        {
            string fileName = @"TestData\user_Test_ThreeRecord.txt";
            TwitterUserProcessor processor = new TwitterUserProcessor(fileName);

            Assert.IsNotNull(processor, "TwitterUserProcessor is null");

            var list = processor.CreateTwitterUsers();

            Assert.IsNotNull(list, "User list is null");
            Assert.IsTrue(list.Count == 3, "User list does not contain record");
        }

        [TestMethod]
        public void Test_OneFollowingRecord()
        {
            string fileName = @"TestData\user_Test_OneFollowingRecord.txt";
            TwitterUserProcessor processor = new TwitterUserProcessor(fileName);

            Assert.IsNotNull(processor, "TwitterUserProcessor is null");

            var list = processor.CreateTwitterUsers();

            Assert.IsNotNull(list, "User list is null");
            Assert.IsTrue(list.Count > 1, "User list contains less than one record");
            Assert.IsTrue(list[0].Twitterers.Count == 1, "User is not following anyone");
            Assert.IsTrue(list[1].Twitterers.Count == 0, "Follower is following someone");
        }

        [TestMethod]
        public void Test_MultipleFollowingRecord()
        {
            string fileName = @"TestData\user_Test_MultipleFollowingRecord.txt";
            TwitterUserProcessor processor = new TwitterUserProcessor(fileName);

            Assert.IsNotNull(processor, "TwitterUserProcessor is null");

            var list = processor.CreateTwitterUsers();

            Assert.IsNotNull(list, "User list is null");
            Assert.IsTrue(list.Count > 1, "User list contains less than one record");
            Assert.IsTrue(list[0].Twitterers.Count > 1, "User is not following anyone");
            Assert.IsTrue(list[1].Twitterers.Count == 0, "Follower is following someone");
        }
    }
}
