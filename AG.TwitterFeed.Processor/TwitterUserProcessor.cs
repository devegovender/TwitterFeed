using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AG.TwitterFeed.DataModel;
using AG.TwitterFeed.DataModel.Interfaces;

namespace AG.TwitterFeed.Processor
{
    public class TwitterUserProcessor
    {
        #region Private Properties
       
        private string UserFileName
        {
            get;
            set;
        }

        private string[] SplitFollowsConstant
        {
            get
            {
                return new string[] { Constants.FollowsConstant };
            }
        }

        private string[] SplitUsersConstant
        {
            get
            {
                return new string[] { "," };
            }
        } 

        #endregion

        #region Constructors
        
        public TwitterUserProcessor(string userFileName)
        {
            this.UserFileName = userFileName;
        } 

        #endregion

        #region Public Methods

        public List<IUser> CreateTwitterUsers()
        {
            string[] fileLines = File.ReadAllLines(UserFileName);
            List<IUser> twitterUserList = new List<IUser>();

            foreach (string line in fileLines)
            {
                try
                {
                    if (line.Contains(Constants.FollowsConstant))
                    {
                        string[] userData = line.Split(SplitFollowsConstant, StringSplitOptions.RemoveEmptyEntries);

                        if (userData.Length > 1)
                        {
                            var twitterUser = AddTwitterUserToList(twitterUserList, userData[0]);

                            AddTwitterFollowers(twitterUserList, userData[1], twitterUser);
                        }
                    }

                }
                catch
                {
                    //Ignore error user and continue processing other users.
                }
            }

            return twitterUserList;
        } 
        #endregion

        #region Private Methods
        
        private void AddTwitterFollowers(List<IUser> twitterUserList, string userFollowData, IUser twitterUser)
        {
            string[] userFollows = userFollowData.Split(SplitUsersConstant, StringSplitOptions.RemoveEmptyEntries);

            foreach (string follow in userFollows)
            {
                var trimedFollow = follow.Trim();
                //add followers to master list
                AddTwitterUserToList(twitterUserList, trimedFollow);

                //add followers to twitter user
                if (!twitterUser.Twitterers.Contains(trimedFollow))
                    twitterUser.Twitterers.Add(trimedFollow);
            }
        }

        private IUser AddTwitterUserToList(List<IUser> twitterUserList, string userName)
        {
            userName = userName.Trim();

            var twitterUser = twitterUserList.FirstOrDefault(c => c.UserName.Equals(userName));
            if (twitterUser == null)
            {
                twitterUser = new TwitterUser(userName);
                twitterUserList.Add(twitterUser);
            }

            return twitterUser;
        } 

        #endregion
    }
}
