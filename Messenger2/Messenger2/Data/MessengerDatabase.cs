using Messenger2.Utility;
using System;
using System.Threading.Tasks;
using static Messenger2.Utility.Constants.Firebase.Tables;

namespace Messenger2.Data
{
    class MessengerDatabase
    {
        IDataStore db;

        /// <summary>
        /// 
        /// </summary>
        public MessengerDatabase() =>
            db = new FirebaseDatabase();

        /// <summary>
        /// Get a user from the current datastore.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IObservable<User> GetUser(string id) =>
            db.GetNodeAsync<User>($"{Constants.Firebase.TABLES[USERS]}/{id}");

        /// <summary>
        /// Update a user in the datastore
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateUserAsync(User user) =>
            await db.UpdateAsync(user, $"{Constants.Firebase.TABLES[USERS]}/{user.Id}");

        /// <summary>
        /// Get an obseravble message from the datastore.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IObservable<Message> GetMessageAsync(string id) =>
            db.GetNodeAsync<Message>($"{Constants.Firebase.TABLES[MESSAGES]}/{id}");

        /// <summary>
        /// Add a message to the given chat in the datastore.
        /// </summary>
        /// <param name="chat">The chat to update with the new message</param>
        /// <param name="message">The message to add</param>
        /// <returns></returns>
        public async Task PutMessageAsync(Channel chat, Message message)
        {
            chat.LastMessageId = message.Id;
            chat.MessageIds.Add(message.Id);

            await db.PutNodeAsync(message, $"{Constants.Firebase.TABLES[MESSAGES]}/{message.Id}");
            await db.UpdateAsync<Channel>(chat, $"{Constants.Firebase.TABLES[CHATS]}/{chat.Id}");
        }

        /// <summary>
        /// Get a chat from the datastore.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IObservable<Channel> GetChatAsync(string id) =>
             db.GetNodeAsync<Channel>($"{Constants.Firebase.TABLES[CHATS]}/{id}");
    }
}
