 Assumptions made:
    1. File paths are configurable via the config file.
    2. If an error occurs during processing a single user, the program continues to process other users. This can be changed if deemed necessary to stop the process.
    3. If an error occurs during processing a single tweeet, the program continues to process other tweets. This can be changed if deemed necessary to stop the process.
    4. The program does fail if the user file does not exist, as this was deemed important to the twitter application.
    5. The program will continue without a tweet file, as the application can still display users that have been captured.
    6. If a user that is being followed does not exist, the user is automatically created.
    7. Tweets are only added to valid users.
    8. For a robust and long term solution, a Database would be used to store users and tweets.
    9. It was decided to trim the tweet to 140 characters instead of throwing an error or ignoring the tweet.