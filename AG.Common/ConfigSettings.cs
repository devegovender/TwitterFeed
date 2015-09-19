using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG.TwitterFeed.Common
{
   public sealed class ConfigSettings
   {
      /// <summary>
      /// Implement Singleton --.NET static initialization is guaranteed to be thread-safe
      /// </summary>
      #region [Fields]

      private static readonly ConfigSettings configSettings = new ConfigSettings();

      #endregion

      #region Constructors + Destructors

      // Prevent C# compiler from marking type as beforefieldinit - see http://www.yoda.arachsys.com/csharp/beforefieldinit.html
      static ConfigSettings()
      {
      }

      private ConfigSettings()
      {
      }

      public static ConfigSettings Instance
      {
         get
         {
            return configSettings;
         }
      }

      #endregion

      #region [Public Properties]

      public string UserFileName
      {
         get
         {
             return ConfigurationManager.AppSettings[Constants.UserFileName];
         }
      }

      public string TweetFileName
      {
          get
          {
              return ConfigurationManager.AppSettings[Constants.TweetFileName];
          }
      }

      public int TweetLength
      {
          get
          {
              int tweetLength = 0;
              Int32.TryParse(ConfigurationManager.AppSettings[Constants.TweetLength],out tweetLength);
              
              return tweetLength;
          }
      }

      #endregion
   }
}