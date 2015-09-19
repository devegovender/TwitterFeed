using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using AG.TwitterFeed.DataModel;
using AG.TwitterFeed.DataModel.Interfaces;

namespace AG.TwitterFeed.Processor
{
    public class TwitterProcessor
    {
        #region Constructors

        public TwitterProcessor()
        {

        }

        #endregion

        #region Constructors

        public string GetTwitterFeeds(string userFile, string tweetFile)
        {
            try
            {
                //load users
                TwitterUserProcessor userProcessor = new TwitterUserProcessor(userFile);
                List<IUser> twitterUserList = userProcessor.CreateTwitterUsers();

                //load twitterfeeds
                TwitterFeedProcessor feedProcessor = new TwitterFeedProcessor(tweetFile);
                feedProcessor.AddTwitterFeeds(twitterUserList);

                //format string
                return GenerateDisplayString(twitterUserList);
            }
            catch (Exception ex)
            {
                return string.Format("Error occured during processing twitter feeds. Message: {0}", ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private string GenerateDisplayString(List<IUser> twitterUserList)
        {
            StringBuilder sb = new StringBuilder();

            twitterUserList = twitterUserList.OrderBy(o => o.UserName).ToList();

            foreach (TwitterUser user in twitterUserList)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString();
        }

        #endregion
    }
}
