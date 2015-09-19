using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AG.TwitterFeed.DataModel.UnitTest
{
    [TestClass]
    public class TwitterPostFixture
    {
        [TestMethod]
        public void Test_ValidToString()
        {
            string user = "test";
            string message = "This is a test message";
            TwitterPost post = new TwitterPost(user, message);

            Assert.IsNotNull(post, "Twitter Post is null");
            Assert.AreEqual<string>(string.Format("@{0}: {1}", user, message), post.ToString(), "Twitter Post ToString is invalid");
        }
    }
}
