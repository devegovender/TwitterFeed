using AG.TwitterFeed.Common;
using AG.TwitterFeed.DataModel.Interfaces;
using System;
namespace AG.TwitterFeed.DataModel
{
    public class TwitterPost : IPost
    {
        #region Public Properties

        public string Message
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public TwitterPost()
        {

        }

        public TwitterPost(string user, string message)
        {
            this.User = user.Trim();
            this.Message = message.Trim();

            if (this.Message.Length > ConfigSettings.Instance.TweetLength)
                this.Message = Message.Substring(0, ConfigSettings.Instance.TweetLength);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("@{0}: {1}", User, Message);
        }

        #endregion
    }
}
