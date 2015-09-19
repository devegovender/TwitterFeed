using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.TwitterFeed.DataModel.Interfaces;
using System.Text;

namespace AG.TwitterFeed.DataModel.UnitTest
{
    [TestClass]
    public class TwitterUserFixture
    {
        [TestMethod]
        public void Test_ValidTwitterer()
        {
            var user = "test";
            var twitterer = "Tom";
            var twitterUser = new TwitterUser(user);
            twitterUser.Twitterers.Add(twitterer);

            Assert.IsNotNull(twitterUser, "Twitter Post is null");
            Assert.AreEqual<string>(twitterer, twitterUser.Twitterers[0], "Twitterer is invalid");
        }

        [TestMethod]
        public void Test_ValidTweet()
        {
            var user = "test";
            var tweet = new TwitterPost(user, "Some random message");
            var twitterUser = new TwitterUser(user);
            twitterUser.TwitterPosts.Add(tweet);

            Assert.IsNotNull(twitterUser, "Twitter User is null");
            Assert.IsTrue(twitterUser.TwitterPosts.Count == 1, "Tweet count is invalid");
            Assert.AreEqual<IPost>(tweet, twitterUser.TwitterPosts[0], "Tweet is invalid");
        }

        [TestMethod]
        public void Test_ValidToString()
        {
            var user = "test";
            var message = "Some random message";
            var tweet = new TwitterPost(user, message);
            var twitterUser = new TwitterUser(user);
            twitterUser.TwitterPosts.Add(tweet);

            Assert.IsNotNull(twitterUser, "Twitter User is null");
            Assert.IsTrue(twitterUser.TwitterPosts.Count == 1, "Tweet count is invalid");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@{0}: {1}", user, message);

            Assert.AreEqual<string>(sb.ToString(), twitterUser.TwitterPosts[0].ToString(), "Twitter Post ToString is invalid");
        }
    }
}
