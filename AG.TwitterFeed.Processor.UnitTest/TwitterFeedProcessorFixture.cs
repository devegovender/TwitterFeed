using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.TwitterFeed.DataModel.Interfaces;
using System.Collections.Generic;
using AG.TwitterFeed.DataModel;

namespace AG.TwitterFeed.Processor.UnitTest
{
    [TestClass]
    public class TwitterFeedProcessorFixture
    {
        [TestMethod]
        public void Test_AddTwitterFeeds_Single()
        {
            string tweetFile = @"TestData\tweet_Test_AddTwitterFeeds_Single.txt";
            string twitterUser = "Alan";
            List<IUser> twitterUserList = GetTwitterUsers(twitterUser);

            TwitterFeedProcessor feedProcessor = new TwitterFeedProcessor(tweetFile);
            feedProcessor.AddTwitterFeeds(twitterUserList);

            Assert.AreEqual<int>(twitterUserList[0].TwitterPosts.Count, 1, "Twitter Posts not equal to 1.");
        }

        [TestMethod]
        public void Test_AddTwitterFeeds_Multiple()
        {
            string tweetFile = @"TestData\tweet_Test_AddTwitterFeeds_Multiple.txt";
            string twitterUser1 = "Alan";
            List<IUser> twitterUserList = GetTwitterUsers(twitterUser1);

            TwitterFeedProcessor feedProcessor = new TwitterFeedProcessor(tweetFile);
            feedProcessor.AddTwitterFeeds(twitterUserList);

            Assert.AreEqual<int>(twitterUserList[0].TwitterPosts.Count, 2, "Twitter Posts not equal to 2.");
        }

        [TestMethod]
        public void Test_AddTwitterFeeds_FollowsTweet()
        {
            string tweetFile = @"TestData\tweet_Test_AddTwitterFeeds_Multiple.txt";
            string twitterUser1 = "Alan";
            string twitterUser2 = "John";
            List<IUser> twitterUserList = GetTwitterUsers(twitterUser1, twitterUser2);

            //John follows Alan
            twitterUserList[1].Twitterers.Add(twitterUser1);

            TwitterFeedProcessor feedProcessor = new TwitterFeedProcessor(tweetFile);
            feedProcessor.AddTwitterFeeds(twitterUserList);

            Assert.AreEqual<int>(twitterUserList[0].TwitterPosts.Count, 2, "Twitter Posts not equal to 2.");
            Assert.AreEqual<int>(twitterUserList[1].TwitterPosts.Count, 2, "Twitter Posts not equal to 2.");
        }

        [TestMethod]
        public void Test_AddTwitterFeeds_GreateThan140Chars()
        {
            string tweetFile = @"TestData\tweet_Test_AddTwitterFeeds_140Characters.txt";
            string twitterUser1 = "Alan";
            List<IUser> twitterUserList = GetTwitterUsers(twitterUser1);

            TwitterFeedProcessor feedProcessor = new TwitterFeedProcessor(tweetFile);
            feedProcessor.AddTwitterFeeds(twitterUserList);

            Assert.AreEqual<int>(twitterUserList[0].TwitterPosts.Count, 1, "Twitter Posts not equal to 2.");
            Assert.IsTrue(twitterUserList[0].TwitterPosts[0].Message.Length == 140, "Twitter Posts greater than 140 characters.");
        }

        private List<IUser> GetTwitterUsers(params string[] names)
        {
            List<IUser> list = new List<IUser>();

            if (names != null && names.Length > 0)
            {
                foreach (var name in names)
                {
                    list.Add(new TwitterUser(name));
                }
            }

            return list;
        }
    }
}
