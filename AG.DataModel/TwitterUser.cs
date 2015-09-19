using AG.TwitterFeed.DataModel.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace AG.TwitterFeed.DataModel
{
    public sealed class TwitterUser : IUser
    {
        #region Public Properties

        public List<string> Twitterers
        {
            get;
            set;
        }

        public List<IPost> TwitterPosts
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public TwitterUser()
        {

        }

        public TwitterUser(string userName)
        {
            this.UserName = userName.Trim();
            Twitterers = new List<string>();
            TwitterPosts = new List<IPost>();
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.UserName);

            foreach (TwitterPost post in this.TwitterPosts)
            {
                sb.AppendLine(post.ToString());
            }

            return sb.ToString();
        }

        #endregion
    }
}
