using AG.TwitterFeed.DataModel;
using AG.TwitterFeed.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AG.TwitterFeed.Processor
{
    public class TwitterFeedProcessor
    {
        #region Private Properties
        
        private string TweetFileName
        {
            get;
            set;
        }

        private new string[] SplitStringConstant
        {
            get
            {
                return new string[] { ">" };
            }
        } 

        #endregion

        #region Constructors
        
        public TwitterFeedProcessor(string tweetFileName)
        {
            this.TweetFileName = tweetFileName;
        } 

        #endregion

        #region Public Methods
        
        public void AddTwitterFeeds(List<IUser> twitterUserList)
        {
            if (File.Exists(TweetFileName))
            {
                var fileLines = File.ReadAllLines(TweetFileName);

                foreach (var line in fileLines)
                {
                    try
                    {
                        var tweetData = line.Split(SplitStringConstant, StringSplitOptions.RemoveEmptyEntries);

                        var twitterUser = twitterUserList.FirstOrDefault(c => c.UserName.Equals(tweetData[0]));
                        if (twitterUser != null)
                        {
                            var twitterPost = new TwitterPost(tweetData[0], tweetData[1]);

                            //add post to the tweeter
                            twitterUser.TwitterPosts.Add(twitterPost);

                            //add post to the followers of the tweeter.
                            AddTweetToFollowers(twitterUserList, twitterPost);
                        }
                    }
                    catch
                    {
                        //if one line fails,ignore and continue reading the rest of the file.
                    }
                }
            }
        } 

        #endregion

        #region Private Methods
        
        private void AddTweetToFollowers(List<IUser> twitterUserList, IPost twitterPost)
        {
            foreach (IUser user in twitterUserList)
            {
                if (user.Twitterers.Contains(twitterPost.User))
                    user.TwitterPosts.Add(twitterPost);
            }
        } 

        #endregion
    }
}
