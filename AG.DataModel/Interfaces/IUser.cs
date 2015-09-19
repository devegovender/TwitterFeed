using System.Collections.Generic;

namespace AG.TwitterFeed.DataModel.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Twitter accounts that this user follows
        /// </summary>
        List<string> Twitterers
        {
            get;
            set;
        }

        /// <summary>
        /// Twitter Posts that this user follows
        /// </summary>
        List<IPost> TwitterPosts
        {
            get;
            set;
        }

        string UserName
        {
            get;
            set;
        }
    }
}
